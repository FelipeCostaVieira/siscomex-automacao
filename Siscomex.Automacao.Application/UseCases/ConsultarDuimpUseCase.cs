using Siscomex.Automacao.Core.Interfaces;
using Siscomex.Automacao.Core.Models.Duimp;

namespace Siscomex.Automacao.Application.UseCases;

/// <summary>
/// Orquestra a consulta completa de uma DUIMP no Portal Único.
/// Fluxo:
///   0 - Consulta versão vigente (se não informada)
///   1 - Consulta capa da DUIMP
///   2 - Consulta itens da DUIMP
///   3 - Consulta valores calculados de cada item (em paralelo)
/// </summary>
public class ConsultarDuimpUseCase
{
    private readonly IDuimpService _duimpService;

    public ConsultarDuimpUseCase(IDuimpService duimpService)
    {
        _duimpService = duimpService;
    }

    /// <summary>
    /// Resultado consolidado da consulta completa de uma DUIMP registrada.
    /// Nota: valores-calculados por item não está incluído pois esse endpoint
    /// é restrito a DUIMPs em elaboração. Os tributos calculados já vêm
    /// nos próprios itens via ConsultarItensAsync.
    /// </summary>
    public record ResultadoConsultaDuimp(
        DuimpConsultaResponse Capa,
        List<DuimpItemResponse> Itens);

    /// <summary>
    /// Executa a consulta completa: capa + itens.
    /// Se versao = 0, consulta a versão vigente automaticamente.
    /// </summary>
    public async Task<ResultadoConsultaDuimp> ExecutarAsync(
        string numeroDuimp,
        int versao = 0,
        CancellationToken ct = default)
    {
        numeroDuimp = numeroDuimp.Trim().ToUpperInvariant();

        if (string.IsNullOrWhiteSpace(numeroDuimp) || numeroDuimp.Length < 10)
            throw new ArgumentException($"Número da DUIMP inválido: '{numeroDuimp}'.");

        // Passo 0 — versão vigente se não informada
        if (versao == 0)
        {
            var vigente = await _duimpService.ConsultarVersaoVigenteAsync(numeroDuimp, ct);
            versao = vigente.Versao;
        }

        // Passo 1 e 2 — capa e itens em paralelo
        var capaTask = _duimpService.ConsultarAsync(numeroDuimp, versao, ct);
        var itensTask = _duimpService.ConsultarItensAsync(numeroDuimp, versao, ct: ct);

        await Task.WhenAll(capaTask, itensTask);

        return new ResultadoConsultaDuimp(await capaTask, await itensTask);
    }
}