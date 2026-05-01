using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Siscomex.Automacao.Core.Interfaces;
using Siscomex.Automacao.Core.Models;

namespace Siscomex.Automacao.Infrastructure.Http;

public class PortalUnicoAuthService : IAuthTokenProvider
{
    private readonly string _urlBase;
    private readonly string _cpfCnpj;
    private readonly string _arquivoTokens;
    private AuthTokens? _tokens;
    private readonly SemaphoreSlim _lock = new(1, 1);

    // Portal bloqueia reautenticação em menos de 60 segundos
    private static readonly TimeSpan IntervaloMinimoAuth = TimeSpan.FromSeconds(65);

    public PortalUnicoAuthService(string urlBase, string cpfCnpj)
    {
        _urlBase = urlBase;
        _cpfCnpj = cpfCnpj
            .Replace(".", "")
            .Replace("-", "")
            .Replace("/", "")
            .Trim();

        // Salva tokens na pasta do usuário — não fica solto no projeto
        _arquivoTokens = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Siscomex.Automacao",
            "tokens.dat");

        Directory.CreateDirectory(Path.GetDirectoryName(_arquivoTokens)!);
    }

    public async Task<AuthTokens> ObterTokensAsync(CancellationToken ct = default)
    {
        // 1. Tenta memória primeiro
        if (_tokens is not null && !_tokens.CsrfExpirado)
            return _tokens;

        await _lock.WaitAsync(ct);
        try
        {
            if (_tokens is not null && !_tokens.CsrfExpirado)
                return _tokens;

            // 2. Tenta carregar do arquivo (entre reinicializações do app)
            var tokensSalvos = CarregarTokensDoArquivo();
            if (tokensSalvos is not null && !tokensSalvos.CsrfExpirado)
            {
                _tokens = tokensSalvos;
                return _tokens;
            }

            // 3. Verifica se pode autenticar (respeita janela de 60s do Portal)
            if (tokensSalvos is not null)
            {
                var tempoDesdeUltimaAuth = DateTimeOffset.UtcNow - tokensSalvos.UltimaAutenticacao;
                if (tempoDesdeUltimaAuth < IntervaloMinimoAuth)
                {
                    var aguardar = IntervaloMinimoAuth - tempoDesdeUltimaAuth;
                    throw new InvalidOperationException(
                        $"Portal Único bloqueia reautenticação por 60 segundos. " +
                        $"Aguarde {aguardar.Seconds} segundo(s) e tente novamente.");
                }
            }

            // 4. Autentica no Portal
            _tokens = await AutenticarAsync(ct);
            SalvarTokensNoArquivo(_tokens);
            return _tokens;
        }
        finally
        {
            _lock.Release();
        }
    }

    public void AtualizarCsrfToken(string csrfToken, string csrfExpiration)
    {
        if (_tokens is null) return;

        var expiration = long.TryParse(csrfExpiration, out var ms)
            ? DateTimeOffset.FromUnixTimeMilliseconds(ms)
            : DateTimeOffset.UtcNow.AddMinutes(60);

        _tokens = new AuthTokens
        {
            JwtToken = _tokens.JwtToken,
            CsrfToken = csrfToken,
            CsrfExpiration = expiration,
            UltimaAutenticacao = _tokens.UltimaAutenticacao
        };

        SalvarTokensNoArquivo(_tokens);
    }

    public void Invalidar()
    {
        _tokens = null;
        if (File.Exists(_arquivoTokens))
            File.Delete(_arquivoTokens);
    }

    // -------------------------------------------------------

    private async Task<AuthTokens> AutenticarAsync(CancellationToken ct)
    {
        var cert = ObterCertificadoDoWindows();

        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(cert);

        using var client = new HttpClient(handler);
        client.BaseAddress = new Uri(_urlBase);

        var request = new HttpRequestMessage(HttpMethod.Post, "/portal/api/autenticar");
        request.Headers.Add("Role-Type", "IMPEXP");
        request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/xml");

        var response = await client.SendAsync(request, ct);

        if (!response.IsSuccessStatusCode)
        {
            var corpo = await response.Content.ReadAsStringAsync(ct);
            throw new InvalidOperationException(
                $"Falha na autenticação: HTTP {(int)response.StatusCode}\n{corpo}");
        }

        var jwtToken = ObterHeader(response, "set-token")
            ?? throw new InvalidOperationException("set-token não retornado pelo Portal Único.");

        var csrfToken = ObterHeader(response, "x-csrf-token")
            ?? throw new InvalidOperationException("x-csrf-token não retornado pelo Portal Único.");

        var csrfExpiration = ObterHeader(response, "x-csrf-expiration") ?? "0";

        var expiration = long.TryParse(csrfExpiration, out var ms)
            ? DateTimeOffset.FromUnixTimeMilliseconds(ms)
            : DateTimeOffset.UtcNow.AddMinutes(60);

        return new AuthTokens
        {
            JwtToken = jwtToken,
            CsrfToken = csrfToken,
            CsrfExpiration = expiration,
            UltimaAutenticacao = DateTimeOffset.UtcNow
        };
    }

    private X509Certificate2 ObterCertificadoDoWindows()
    {
        using var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);

        var encontrados = store.Certificates
            .Cast<X509Certificate2>()
            .Where(c =>
                c.Subject.Contains(_cpfCnpj, StringComparison.OrdinalIgnoreCase) &&
                c.NotAfter > DateTime.Now)
            .OrderByDescending(c => c.NotAfter)
            .ToList();

        if (encontrados.Count == 0)
            throw new InvalidOperationException(
                $"Nenhum certificado válido encontrado para o CPF/CNPJ '{_cpfCnpj}'.");

        return encontrados.First();
    }

    private static string? ObterHeader(HttpResponseMessage response, string nome)
    {
        return response.Headers.TryGetValues(nome, out var valores)
            ? valores.First()
            : null;
    }

    // -------------------------------------------------------
    // Persistência local com criptografia (DPAPI do Windows)
    // -------------------------------------------------------

    private void SalvarTokensNoArquivo(AuthTokens tokens)
    {
        try
        {
            var json = JsonSerializer.Serialize(tokens);
            var bytes = Encoding.UTF8.GetBytes(json);

            // ProtectedData usa a conta do usuário Windows como chave
            // — só o mesmo usuário consegue descriptografar
            var criptografado = ProtectedData.Protect(
                bytes,
                null,
                DataProtectionScope.CurrentUser);

            File.WriteAllBytes(_arquivoTokens, criptografado);
        }
        catch
        {
            // Falha ao salvar não deve interromper o fluxo
        }
    }

    private AuthTokens? CarregarTokensDoArquivo()
    {
        try
        {
            if (!File.Exists(_arquivoTokens))
                return null;

            var criptografado = File.ReadAllBytes(_arquivoTokens);
            var bytes = ProtectedData.Unprotect(
                criptografado,
                null,
                DataProtectionScope.CurrentUser);

            var json = Encoding.UTF8.GetString(bytes);
            return JsonSerializer.Deserialize<AuthTokens>(json);
        }
        catch
        {
            return null;
        }
    }
}