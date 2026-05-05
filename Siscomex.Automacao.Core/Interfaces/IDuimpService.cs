using Siscomex.Automacao.Core.Models.Duimp;

namespace Siscomex.Automacao.Core.Interfaces;

/// <summary>
/// Contrato de acesso às APIs da DUIMP no Portal Único.
/// Implementado por DuimpApiClient na camada Infrastructure.
/// </summary>
public interface IDuimpService
{
    /// <summary>
    /// Consulta os dados gerais (capa) de uma DUIMP já registrada.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}
    /// </summary>
    Task<DuimpConsultaResponse> ConsultarAsync(
        string numeroDuimp,
        int versao,
        CancellationToken ct = default);

    /// <summary>
    /// Consulta a versão vigente de uma DUIMP registrada.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/versoes
    /// </summary>
    Task<DuimpVersaoVigenteResponse> ConsultarVersaoVigenteAsync(
        string numeroDuimp,
        CancellationToken ct = default);

    /// <summary>
    /// Consulta uma faixa de itens de uma DUIMP já registrada.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}/itens
    /// Suporta paginação via parâmetros inicial e tamanho (máx. 100 por chamada).
    /// </summary>
    Task<List<DuimpItemResponse>> ConsultarItensAsync(
        string numeroDuimp,
        int versao,
        int inicial = 1,
        int tamanho = 100,
        CancellationToken ct = default);

    /// <summary>
    /// Consulta os valores calculados de um item específico de uma DUIMP.
    /// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}/itens/{numeroItem}/valores-calculados
    /// Retorna valores de tributos, condição de venda e mercadoria para pagamento.
    /// </summary>
    Task<DuimpItemValoresCalculadosResponse> ConsultarValoresCalculadosItemAsync(
        string numeroDuimp,
        int versao,
        int numeroItem,
        CancellationToken ct = default);
}