using Siscomex.Automacao.Core.Interfaces;
using Siscomex.Automacao.Core.Models.Duimp;
using System.Text.Json;

namespace Siscomex.Automacao.Infrastructure.Http;

/// <summary>
/// Cliente HTTP para as APIs da DUIMP no Portal Único.
/// Depende de IAuthTokenProvider para obter e renovar os tokens de autenticação.
/// O Portal Único exige:
///   - Header "Authorization" com o JWT diretamente (sem prefixo Bearer)
///   - Header "X-CSRF-Token" renovado a cada requisição
///   - Header "Role-Type" com o perfil de acesso
/// </summary>
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

    /// <summary>
    /// Consulta os dados gerais de uma DUIMP já registrada.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}
    /// </summary>
    public async Task<DuimpConsultaResponse> ConsultarAsync(
        string numeroDuimp,
        int versao,
        CancellationToken ct = default)
    {
        var response = await EnviarGetAsync(
            $"/duimp-api/api/ext/duimp/{numeroDuimp}/{versao}", ct);

        var json = await response.Content.ReadAsStringAsync(ct);

        return JsonSerializer.Deserialize<DuimpConsultaResponse>(json, JsonOptions)
            ?? throw new InvalidOperationException(
                $"Resposta vazia ou inválida para DUIMP {numeroDuimp}.");
    }

    /// <summary>
    /// Consulta a versão vigente de uma DUIMP registrada.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/versoes
    /// </summary>
    public async Task<DuimpVersaoVigenteResponse> ConsultarVersaoVigenteAsync(
        string numeroDuimp,
        CancellationToken ct = default)
    {
        var response = await EnviarGetAsync(
            $"/duimp-api/api/ext/duimp/{numeroDuimp}/versoes", ct);

        var json = await response.Content.ReadAsStringAsync(ct);

        return JsonSerializer.Deserialize<DuimpVersaoVigenteResponse>(json, JsonOptions)
            ?? throw new InvalidOperationException(
                $"Resposta de versão vigente vazia para DUIMP {numeroDuimp}.");
    }

    // -------------------------------------------------------
    // Métodos privados compartilhados
    // -------------------------------------------------------

    /// <summary>
    /// Monta e envia uma requisição GET autenticada ao Portal Único.
    /// Centraliza o padrão de headers exigidos em todas as chamadas.
    /// Atualiza o CSRF token automaticamente após cada resposta.
    /// Nota: o header Role-Type é exigido apenas na autenticação, não nas demais APIs.
    /// </summary>
    private async Task<HttpResponseMessage> EnviarGetAsync(string endpoint, CancellationToken ct)
    {
        var tokens = await _auth.ObterTokensAsync(ct);

        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

        // Portal Único exige o JWT diretamente no header Authorization, sem prefixo "Bearer"
        request.Headers.Add("Authorization", tokens.JwtToken);
        request.Headers.Add("X-CSRF-Token", tokens.CsrfToken);

        var response = await _httpClient.SendAsync(request, ct);

        // Renova o CSRF com o token retornado — obrigatório pelo Portal Único
        AtualizarCsrfSePresente(response);

        if (!response.IsSuccessStatusCode)
        {
            var erro = await response.Content.ReadAsStringAsync(ct);
            throw new InvalidOperationException(
                $"Erro na requisição {endpoint}: HTTP {(int)response.StatusCode} - {erro}");
        }

        return response;
    }

    /// <summary>
    /// Atualiza o CSRF token em memória com o valor renovado retornado pelo Portal.
    /// O Portal Único renova o CSRF a cada requisição — sempre use o mais recente.
    /// </summary>
    private void AtualizarCsrfSePresente(HttpResponseMessage response)
    {
        if (response.Headers.TryGetValues("X-CSRF-Token", out var csrf) &&
            response.Headers.TryGetValues("X-CSRF-Expiration", out var exp))
        {
            _auth.AtualizarCsrfToken(csrf.First(), exp.First());
        }
    }

    /// <summary>
    /// Consulta os itens de uma DUIMP registrada.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}/itens?inicial={i}&tamanho={t}
    /// Retorna um array JSON de itens — desserializado diretamente como List.
    /// </summary>
    public async Task<List<DuimpItemResponse>> ConsultarItensAsync(
        string numeroDuimp,
        int versao,
        int inicial = 1,
        int tamanho = 100,
        CancellationToken ct = default)
    {
        var endpoint =
            $"/duimp-api/api/ext/duimp/{numeroDuimp}/{versao}/itens?inicial={inicial}&tamanho={tamanho}";

        var response = await EnviarGetAsync(endpoint, ct);
        var json = await response.Content.ReadAsStringAsync(ct);

        return JsonSerializer.Deserialize<List<DuimpItemResponse>>(json, JsonOptions)
            ?? [];
    }

    /// <summary>
    /// Consulta os valores calculados de um item específico de uma DUIMP.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}/itens/{numeroItem}/valores-calculados
    /// </summary>
    public async Task<DuimpItemValoresCalculadosResponse> ConsultarValoresCalculadosItemAsync(
        string numeroDuimp,
        int versao,
        int numeroItem,
        CancellationToken ct = default)
    {
        var response = await EnviarGetAsync(
            $"/duimp-api/api/ext/duimp/{numeroDuimp}/{versao}/itens/{numeroItem}/valores-calculados",
            ct);

        var json = await response.Content.ReadAsStringAsync(ct);

        return JsonSerializer.Deserialize<DuimpItemValoresCalculadosResponse>(json, JsonOptions)
            ?? throw new InvalidOperationException(
                $"Resposta vazia de valores calculados para item {numeroItem} da DUIMP {numeroDuimp}.");
    }
}