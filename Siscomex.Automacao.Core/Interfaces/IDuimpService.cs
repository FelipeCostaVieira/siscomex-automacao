using Siscomex.Automacao.Core.Models.Duimp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscomex.Automacao.Core.Interfaces;

//contrato da consulta.
//Por ora só tem a consulta de dados gerais, mas já deixo espaço comentado para as próximas operações a serem adicionadas.
public interface IDuimpService
{
    /// <summary>
    /// Consulta os dados gerais de uma DUIMP já registrada.
    /// </summary>
    /// <param name="numeroDuimp">Ex: 24BR00001001899</param>
    /// <param name="versao">Versão da DUIMP. Use 1 se não souber.</param>
    Task<DuimpConsultaResponse> ConsultarAsync(
        string numeroDuimp,
        int versao = 1,
        CancellationToken ct = default);

    // Futuras operações:
    // Task<DuimpItemResponse> ConsultarItemAsync(string numeroDuimp, int versao, int item, ...);
    // Task<int> ConsultarVersaoVigenteAsync(string numeroDuimp, ...);
}
