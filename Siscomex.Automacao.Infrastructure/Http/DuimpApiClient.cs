using Siscomex.Automacao.Core.Interfaces;
using Siscomex.Automacao.Core.Models.Duimp;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Siscomex.Automacao.Infrastructure.Http;


//A implementação que usa o IAuthTokenProvider para se autenticar e chama a API do Portal Único.
//Note que após cada resposta ele atualiza o CSRF token automaticamente, conforme exigido pelo Portal.
public class DuimpApiClient : IDuimpService
{
    private readonly IAuthTokenProvider _auth;
    private readonly HttpClient _httpClient;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public DuimpApiClient(IAuthTokenProvider auth, string urlBase)
    {
        _auth = auth;

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(urlBase)
        };
    }

    public async Task<DuimpConsultaResponse> ConsultarAsync(
        string numeroDuimp,
        int versao = 1,
        CancellationToken ct = default)
    {
        var tokens = await _auth.ObterTokensAsync(ct);

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"/duimp-api/api/ext/duimp/{numeroDuimp}/{versao}");

        // Adiciona os dois tokens obrigatórios
        //request.Headers.Authorization =
        //    new AuthenticationHeaderValue("Bearer", tokens.JwtToken);
        request.Headers.Add("Authorization", tokens.JwtToken);
        request.Headers.Add("X-CSRF-Token", tokens.CsrfToken);

        var response = await _httpClient.SendAsync(request, ct);

        // Atualiza o CSRF token com o que veio na resposta (obrigatório pelo Portal Único)
        AtualizarCsrfSePresente(response);

        if (!response.IsSuccessStatusCode)
        {
            var erro = await response.Content.ReadAsStringAsync(ct);
            throw new InvalidOperationException(
                $"Erro ao consultar DUIMP {numeroDuimp}: " +
                $"HTTP {(int)response.StatusCode} - {erro}");
        }

        var json = await response.Content.ReadAsStringAsync(ct);

        return JsonSerializer.Deserialize<DuimpConsultaResponse>(json, JsonOptions)
            ?? throw new InvalidOperationException(
                $"Resposta vazia ou inválida para DUIMP {numeroDuimp}.");
    }

    // -------------------------------------------------------

    private void AtualizarCsrfSePresente(HttpResponseMessage response)
    {
        if (response.Headers.TryGetValues("X-CSRF-Token", out var csrf) &&
            response.Headers.TryGetValues("X-CSRF-Expiration", out var exp))
        {
            _auth.AtualizarCsrfToken(csrf.First(), exp.First());
        }
    }
}