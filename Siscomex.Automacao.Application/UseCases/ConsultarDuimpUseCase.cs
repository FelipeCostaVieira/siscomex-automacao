using Siscomex.Automacao.Core.Interfaces;
using Siscomex.Automacao.Core.Models.Duimp;

namespace Siscomex.Automacao.Application.UseCases;


//Orquestra o fluxo completo: recebe o número da DUIMP do formulário, chama o serviço e devolve o resultado tratado.
//A Application nunca conhece detalhes de HTTP ou banco — ela só conversa com interfaces.
public class ConsultarDuimpUseCase
{
    private readonly IDuimpService _duimpService;

    public ConsultarDuimpUseCase(IDuimpService duimpService)
    {
        _duimpService = duimpService;
    }

    public async Task<DuimpConsultaResponse> ExecutarAsync(
        string numeroDuimp,
        int versao = 1,
        CancellationToken ct = default)
    {
        numeroDuimp = numeroDuimp.Trim().ToUpperInvariant();

        if (string.IsNullOrWhiteSpace(numeroDuimp))
            throw new ArgumentException("Número da DUIMP não pode ser vazio.");

        // Validação básica de formato: ex. 24BR00001001899
        if (numeroDuimp.Length < 15)
            throw new ArgumentException($"Número da DUIMP inválido: '{numeroDuimp}'.");

        return await _duimpService.ConsultarAsync(numeroDuimp, versao, ct);
    }
}