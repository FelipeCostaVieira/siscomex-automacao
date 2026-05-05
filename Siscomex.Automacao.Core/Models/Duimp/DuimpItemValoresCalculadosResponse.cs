using System.Text.Json.Serialization;

namespace Siscomex.Automacao.Core.Models.Duimp;

/// <summary>
/// Representa os valores calculados de um item específico de uma DUIMP.
/// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}/itens/{numeroItem}/valores-calculados
/// Usado para recuperar valores para pagamento de tributos do item.
/// </summary>
public class DuimpItemValoresCalculadosResponse
{
    [JsonPropertyName("identificacao")]
    public ItemIdentificacao? Identificacao { get; set; }

    [JsonPropertyName("condicaoVenda")]
    public ValoresCalculadosCondicaoVenda? CondicaoVenda { get; set; }

    [JsonPropertyName("mercadoria")]
    public ValoresCalculadosMercadoria? Mercadoria { get; set; }

    /// <summary>
    /// Usa ItemTributoCalculado — que inclui memoriaCalculo e todos os campos
    /// de valores (aReduzir, suspenso, originalDevido, calculadoPagProporcional)
    /// presentes neste endpoint mas ausentes no TributoCalculado da capa.
    /// </summary>
    [JsonPropertyName("tributosCalculados")]
    public List<ItemTributoCalculado> TributosCalculados { get; set; } = [];
}

/// <summary>
/// Valores da condição de venda calculados para o item.
/// valorBRL: Tamanho 13,7 — até 7 casas decimais.
/// </summary>
public class ValoresCalculadosCondicaoVenda
{
    /// <summary>Valor unitário da mercadoria na condição de venda em R$. Tamanho: 13,7.</summary>
    [JsonPropertyName("valorBRL")]
    public decimal ValorBRL { get; set; }

    [JsonPropertyName("frete")]
    public FreteValoresCalculados? Frete { get; set; }

    [JsonPropertyName("seguro")]
    public SeguroValoresCalculados? Seguro { get; set; }

    [JsonPropertyName("acrescimosDeducoes")]
    public List<AcrescimoDeducaoCalculado> AcrescimosDeducoes { get; set; } = [];
}

/// <summary>
/// Valor do frete do item em R$.
/// Tamanho: 16,7 — até 7 casas decimais.
/// </summary>
public class FreteValoresCalculados
{
    [JsonPropertyName("valorBRL")]
    public decimal ValorBRL { get; set; }
}

/// <summary>
/// Valor do seguro do item em R$.
/// Tamanho: 16,7 — até 7 casas decimais.
/// </summary>
public class SeguroValoresCalculados
{
    [JsonPropertyName("valorBRL")]
    public decimal ValorBRL { get; set; }
}

/// <summary>
/// Acréscimo ou dedução da condição de venda calculada.
/// Nota: diferente de ItemAcrescimoDeducao, este endpoint não retorna o campo "moeda".
/// </summary>
public class AcrescimoDeducaoCalculado
{
    /// <summary>ACRESCIMO ou DEDUCAO.</summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("denominacao")]
    public AcrescimoDeducaoDenominacao? Denominacao { get; set; }

    /// <summary>Valor do acréscimo/dedução em R$. Tamanho: 16,7.</summary>
    [JsonPropertyName("valorBRL")]
    public decimal ValorBRL { get; set; }
}

/// <summary>
/// Denominação do acréscimo ou dedução.
/// Código: 1-99. Domínio: Tabela de Acréscimos/Deduções do Siscomex.
/// </summary>
public class AcrescimoDeducaoDenominacao
{
    [JsonPropertyName("codigo")]
    public int Codigo { get; set; }
}

/// <summary>
/// Valores da mercadoria calculados para o item.
/// Nulos para DUIMP com situação especial de despacho com cobrança de tributo suspenso.
/// Tamanho: 16,7 — até 7 casas decimais.
/// </summary>
public class ValoresCalculadosMercadoria
{
    [JsonPropertyName("valorLocalEmbarqueBRL")]
    public decimal? ValorLocalEmbarqueBRL { get; set; }

    [JsonPropertyName("valorAduaneiroBRL")]
    public decimal? ValorAduaneiroBRL { get; set; }
}