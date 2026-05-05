using System.Text.Json.Serialization;

namespace Siscomex.Automacao.Core.Models.Duimp;

/// <summary>
/// Representa um item de uma DUIMP retornado pelo endpoint de consulta de itens.
/// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}/itens
/// </summary>
public class DuimpItemResponse
{
    /// <summary>Situação do item: ATIVO ou INATIVO.</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("identificacao")]
    public ItemIdentificacao? Identificacao { get; set; }

    [JsonPropertyName("produto")]
    public ItemProduto? Produto { get; set; }

    [JsonPropertyName("caracterizacaoImportacao")]
    public ItemCaracterizacaoImportacao? CaracterizacaoImportacao { get; set; }

    [JsonPropertyName("indicadorExportadorFabricante")]
    public ItemCodigoStr? IndicadorExportadorFabricante { get; set; }

    [JsonPropertyName("fabricante")]
    public ItemOperador? Fabricante { get; set; }

    [JsonPropertyName("exportador")]
    public ItemOperador? Exportador { get; set; }

    [JsonPropertyName("indicadorCompradorVendedor")]
    public ItemCodigoStr? IndicadorCompradorVendedor { get; set; }

    [JsonPropertyName("mercadoria")]
    public ItemMercadoria? Mercadoria { get; set; }

    [JsonPropertyName("condicaoVenda")]
    public ItemCondicaoVenda? CondicaoVenda { get; set; }

    [JsonPropertyName("lpcos")]
    public List<ItemLpco> Lpcos { get; set; } = [];

    [JsonPropertyName("certificadoMercosul")]
    public List<ItemCertificadoMercosul> CertificadoMercosul { get; set; } = [];

    [JsonPropertyName("declaracoesVinculadas")]
    public List<DeclaracaoVinculada> DeclaracoesVinculadas { get; set; } = [];

    [JsonPropertyName("dadosCambiais")]
    public ItemDadosCambiais? DadosCambiais { get; set; }

    [JsonPropertyName("atributosDuimp")]
    public List<ItemAtributo> AtributosDuimp { get; set; } = [];

    [JsonPropertyName("atributosFundamentoLegalDuimp")]
    public List<ItemAtributo> AtributosFundamentoLegalDuimp { get; set; } = [];

    [JsonPropertyName("tributos")]
    public ItemTributos? Tributos { get; set; }

    [JsonPropertyName("dadosInsumoDrawbackIsencao")]
    public ItemDrawback? DadosInsumoDrawbackIsencao { get; set; }
}

// -------------------------------------------------------
// Identificação
// -------------------------------------------------------

/// <summary>Identificação do item dentro da DUIMP.</summary>
public class ItemIdentificacao
{
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;

    /// <summary>
    /// Versão da DUIMP. Mínimo: 0, Máximo: 9999.
    /// Documentação define como string mas API retorna int — mapeado como int.
    /// </summary>
    [JsonPropertyName("versao")]
    public int Versao { get; set; }

    [JsonPropertyName("numeroItem")]
    public int NumeroItem { get; set; }
}

// -------------------------------------------------------
// Produto
// -------------------------------------------------------

/// <summary>Dados do produto cadastrado no Catálogo de Produtos.</summary>
public class ItemProduto
{
    /// <summary>
    /// Código do produto. Até 10 dígitos.
    /// Documentação define como int mas API retorna string — mapeado como string.
    /// </summary>
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    /// <summary>Versão do produto. Tamanho: 1-7.</summary>
    [JsonPropertyName("versao")]
    public string Versao { get; set; } = string.Empty;

    /// <summary>NI do responsável — CNPJ raiz (8 dígitos) ou CPF (11 dígitos).</summary>
    [JsonPropertyName("niResponsavel")]
    public string NiResponsavel { get; set; } = string.Empty;

    /// <summary>NCM associada ao produto. Tamanho: 8. Formato: NNNNNNNN.</summary>
    [JsonPropertyName("ncm")]
    public string Ncm { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Caracterização da importação
// -------------------------------------------------------

/// <summary>Caracterização do tipo de importação e NI do adquirente/encomendante.</summary>
public class ItemCaracterizacaoImportacao
{
    /// <summary>IMPORTACAO_DIRETA, IMPORTACAO_POR_CONTA_E_ORDEM ou IMPORTACAO_POR_ENCOMENDA.</summary>
    [JsonPropertyName("indicador")]
    public string Indicador { get; set; } = string.Empty;

    /// <summary>CNPJ do adquirente/encomendante. Preenchido apenas em importação indireta.</summary>
    [JsonPropertyName("ni")]
    public string? Ni { get; set; }
}

// -------------------------------------------------------
// Fabricante / Exportador
// -------------------------------------------------------

/// <summary>Dados de operador (fabricante ou exportador) do Catálogo de Produtos.</summary>
public class ItemOperador
{
    /// <summary>Código do operador. Tamanho: 1-35.</summary>
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    /// <summary>Versão do operador. Tamanho: 0-6.</summary>
    [JsonPropertyName("versao")]
    public string Versao { get; set; } = string.Empty;

    /// <summary>NI do operador — CNPJ raiz (8) ou CPF (11).</summary>
    [JsonPropertyName("niOperador")]
    public string NiOperador { get; set; } = string.Empty;

    [JsonPropertyName("pais")]
    public ItemCodigoStr? Pais { get; set; }
}

// -------------------------------------------------------
// Mercadoria
// -------------------------------------------------------

/// <summary>Dados da mercadoria: descrição, quantidades, peso e valor unitário.</summary>
public class ItemMercadoria
{
    [JsonPropertyName("tipoAplicacao")]
    public ItemCodigoStr? TipoAplicacao { get; set; }

    [JsonPropertyName("condicao")]
    public string Condicao { get; set; } = string.Empty;

    [JsonPropertyName("unidadeComercial")]
    public string UnidadeComercial { get; set; } = string.Empty;

    /// <summary>
    /// Quantidade na unidade comercial. Tamanho: 9,5.
    /// Documentação define como number mas API retorna string — mapeado como string.
    /// </summary>
    [JsonPropertyName("quantidadeComercial")]
    public string QuantidadeComercial { get; set; } = string.Empty;

    /// <summary>Quantidade na unidade estatística da NCM. Tamanho: 9,5.</summary>
    [JsonPropertyName("quantidadeMedidaEstatistica")]
    public string QuantidadeMedidaEstatistica { get; set; } = string.Empty;

    /// <summary>Peso líquido em kg. Tamanho: 9,5.</summary>
    [JsonPropertyName("pesoLiquido")]
    public string PesoLiquido { get; set; } = string.Empty;

    [JsonPropertyName("moedaNegociada")]
    public ItemCodigoStr? MoedaNegociada { get; set; }

    /// <summary>Valor unitário na condição de venda. Tamanho: 13,7.</summary>
    [JsonPropertyName("valorUnitarioMoedaNegociada")]
    public string ValorUnitarioMoedaNegociada { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Condição de venda
// -------------------------------------------------------

/// <summary>Condição de venda: método de valoração, incoterm, valores e acréscimos/deduções.</summary>
public class ItemCondicaoVenda
{
    [JsonPropertyName("metodoValoracao")]
    public ItemCodigoStr? MetodoValoracao { get; set; }

    [JsonPropertyName("incoterm")]
    public ItemIncoterm? Incoterm { get; set; }

    /// <summary>Valor na moeda negociada convertido em R$. Tamanho: 13,2.</summary>
    [JsonPropertyName("valorBRL")]
    public string ValorBRL { get; set; } = string.Empty;

    /// <summary>Valor na moeda negociada. Tamanho: 13,2.</summary>
    [JsonPropertyName("valorMoedaNegociada")]
    public string ValorMoedaNegociada { get; set; } = string.Empty;

    [JsonPropertyName("frete")]
    public ItemValorBRLStr? Frete { get; set; }

    [JsonPropertyName("seguro")]
    public ItemValorBRLStr? Seguro { get; set; }

    [JsonPropertyName("acrescimosDeducoes")]
    public List<ItemAcrescimoDeducao> AcrescimosDeducoes { get; set; } = [];
}

public class ItemIncoterm
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("complemento")]
    public string? Complemento { get; set; }
}

/// <summary>
/// Wrapper para valorBRL retornado como string pelo Portal Único.
/// Substitui ItemValorBRL (decimal) para itens da DUIMP.
/// </summary>
public class ItemValorBRLStr
{
    [JsonPropertyName("valorBRL")]
    public string ValorBRL { get; set; } = string.Empty;
}

public class ItemAcrescimoDeducao
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("moeda")]
    public ItemMoedaValorStr? Moeda { get; set; }

    [JsonPropertyName("valorBRL")]
    public string ValorBRL { get; set; } = string.Empty;

    [JsonPropertyName("denominacao")]
    public ItemCodigoStr? Denominacao { get; set; }
}

/// <summary>Moeda com código e valor em string — padrão real do Portal Único.</summary>
public class ItemMoedaValorStr
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public string Valor { get; set; } = string.Empty;
}

/// <summary>Moeda com código e valor — usada em acréscimos/deduções.</summary>
public class ItemMoedaValor
{
    /// <summary>Código ISO-4217. Tamanho: 3.</summary>
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    /// <summary>Valor na moeda negociada. Tamanho: 13,2.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

// -------------------------------------------------------
// LPCOs e Certificados
// -------------------------------------------------------

public class ItemLpco
{
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;
}

/// <summary>Certificado Mercosul — apenas para mercadorias de países do Mercosul.</summary>
public class ItemCertificadoMercosul
{
    /// <summary>CCPTC ou CCROM.</summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    /// <summary>Número do certificado. Tamanho: 1-20.</summary>
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;

    /// <summary>Quantidade na unidade estatística. Tamanho: 11,5.</summary>
    [JsonPropertyName("quantidade")]
    public string Quantidade { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Declarações vinculadas
// -------------------------------------------------------

/// <summary>Declaração aduaneira vinculada ao item.</summary>
public class DeclaracaoVinculada
{
    /// <summary>DUIMP, DUE, DI ou DE.</summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("numeroDeclaracaoVinculada")]
    public string? NumeroDeclaracaoVinculada { get; set; }

    [JsonPropertyName("versaoDeclaracaoVinculada")]
    public string? VersaoDeclaracaoVinculada { get; set; }

    [JsonPropertyName("dataRegistro")]
    public string? DataRegistro { get; set; }

    [JsonPropertyName("numeroDeclaracaoOriginal")]
    public string? NumeroDeclaracaoOriginal { get; set; }

    [JsonPropertyName("versaoDeclaracaoOriginal")]
    public string? VersaoDeclaracaoOriginal { get; set; }

    [JsonPropertyName("numeroItemDeclaracaoOriginal")]
    public int? NumeroItemDeclaracaoOriginal { get; set; }

    [JsonPropertyName("item")]
    public DeclaracaoVinculadaItem? Item { get; set; }
}

/// <summary>Dados do item da declaração vinculada.</summary>
public class DeclaracaoVinculadaItem
{
    [JsonPropertyName("numeroItemDeclaracaoVinculada")]
    public int NumeroItemDeclaracaoVinculada { get; set; }

    [JsonPropertyName("frete")]
    public ItemValorBRL? Frete { get; set; }

    [JsonPropertyName("seguro")]
    public ItemValorBRL? Seguro { get; set; }

    [JsonPropertyName("qtdUnidadeEstatistica")]
    public decimal? QtdUnidadeEstatistica { get; set; }

    [JsonPropertyName("ncm")]
    public string? Ncm { get; set; }
}

// -------------------------------------------------------
// Dados cambiais
// -------------------------------------------------------

/// <summary>Dados cambiais: cobertura, ROF, instituição financiadora e valor.</summary>
public class ItemDadosCambiais
{
    /// <summary>ATE_180_DIAS, DE_180_ATE_360, ACIMA_360 ou SEM_COBERTURA.</summary>
    [JsonPropertyName("coberturaCambial")]
    public ItemCodigoStr? CoberturaCambial { get; set; }

    /// <summary>Número do ROF no BACEN. Tamanho: 1-8.</summary>
    [JsonPropertyName("numeroROF")]
    public string? NumeroROF { get; set; }

    [JsonPropertyName("instituicaoFinanciadora")]
    public ItemCodigoInt? InstituicaoFinanciadora { get; set; }

    /// <summary>Valor da cobertura cambial. Tamanho: 13,2.</summary>
    [JsonPropertyName("valorCoberturaCambial")]
    public string? ValorCoberturaCambial { get; set; }

    [JsonPropertyName("motivoSemCobertura")]
    public ItemCodigoInt? MotivoSemCobertura { get; set; }
}

// -------------------------------------------------------
// Atributos
// -------------------------------------------------------

/// <summary>Atributo por NCM (Duimp) ou por Fundamento Legal.</summary>
public class ItemAtributo
{
    /// <summary>Código do atributo. Tamanho: 1-14.</summary>
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    /// <summary>Valor do atributo. Tamanho: 0-10000.</summary>
    [JsonPropertyName("valor")]
    public string Valor { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Tributos do item
// -------------------------------------------------------

/// <summary>Tributos do item: mercadoria, tributos aplicados e tributos calculados.</summary>
public class ItemTributos
{
    [JsonPropertyName("mercadoria")]
    public ItemMercadoriaTributo? Mercadoria { get; set; }

    [JsonPropertyName("tributosAplicados")]
    public List<ItemTributoAplicado> TributosAplicados { get; set; } = [];

    [JsonPropertyName("tributosCalculados")]
    public List<ItemTributoCalculado> TributosCalculados { get; set; } = [];
}

/// <summary>Valores aduaneiros da mercadoria do item. Tamanho: 16,7.</summary>
public class ItemMercadoriaTributo
{
    [JsonPropertyName("valorLocalEmbarqueBRL")]
    public decimal? ValorLocalEmbarqueBRL { get; set; }

    [JsonPropertyName("valorAduaneiroBRL")]
    public decimal? ValorAduaneiroBRL { get; set; }
}

/// <summary>Tributo aplicado ao item com regime e fundamento legal.</summary>
public class ItemTributoAplicado
{
    [JsonPropertyName("tributo")]
    public ItemCodigoStr? Tributo { get; set; }

    [JsonPropertyName("regime")]
    public ItemCodigoInt? Regime { get; set; }

    [JsonPropertyName("fundamento")]
    public ItemCodigoInt? Fundamento { get; set; }

    [JsonPropertyName("atributos")]
    public List<ItemAtributo> Atributos { get; set; } = [];
}

/// <summary>Tributo calculado do item com valores em R$ e memória de cálculo.</summary>
public class ItemTributoCalculado
{
    /// <summary>Tipo: II, IPI, PIS, COFINS, CIDE, ANTIDUMPING, TAXA_UTILIZACAO etc.</summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("valoresBRL")]
    public ItemValoresTributo? ValoresBRL { get; set; }

    [JsonPropertyName("memoriaCalculo")]
    public ItemMemoriaCalculo? MemoriaCalculo { get; set; }
}

/// <summary>Valores calculados do tributo em R$. Tamanho: 16,7.</summary>
public class ItemValoresTributo
{
    [JsonPropertyName("calculado")]
    public decimal? Calculado { get; set; }

    [JsonPropertyName("aReduzir")]
    public decimal? AReduzir { get; set; }

    [JsonPropertyName("devido")]
    public decimal? Devido { get; set; }

    [JsonPropertyName("suspenso")]
    public decimal? Suspenso { get; set; }

    [JsonPropertyName("aRecolher")]
    public decimal? ARecolher { get; set; }

    [JsonPropertyName("originalDevido")]
    public decimal? OriginalDevido { get; set; }

    [JsonPropertyName("calculadoPagProporcional")]
    public decimal? CalculadoPagProporcional { get; set; }
}

/// <summary>Memória de cálculo do tributo — alíquotas, bases e percentuais.</summary>
public class ItemMemoriaCalculo
{
    [JsonPropertyName("codigoFundamentoLegalNormal")]
    public int? CodigoFundamentoLegalNormal { get; set; }

    /// <summary>Base de cálculo em R$. Tamanho: 16,7.</summary>
    [JsonPropertyName("baseCalculoBRL")]
    public decimal? BaseCalculoBRL { get; set; }

    [JsonPropertyName("baseCalculoEspecificaBRL")]
    public decimal? BaseCalculoEspecificaBRL { get; set; }

    [JsonPropertyName("baseCalculoReduzidaBRL")]
    public decimal? BaseCalculoReduzidaBRL { get; set; }

    /// <summary>Percentual de redução da base de cálculo. Tamanho: 16,5.</summary>
    [JsonPropertyName("percentualReducaoBaseCalculo")]
    public decimal? PercentualReducaoBaseCalculo { get; set; }

    /// <summary>AD_VALOREM ou ESPECIFICA.</summary>
    [JsonPropertyName("tipoAliquota")]
    public string? TipoAliquota { get; set; }

    [JsonPropertyName("percentualReducaoAliquotaReduzida")]
    public decimal? PercentualReducaoAliquotaReduzida { get; set; }

    /// <summary>Valor da alíquota em %. Tamanho: 16,7.</summary>
    [JsonPropertyName("valorAliquota")]
    public decimal? ValorAliquota { get; set; }

    [JsonPropertyName("valorAliquotaEspecifica")]
    public decimal? ValorAliquotaEspecifica { get; set; }

    [JsonPropertyName("valorAliquotaReduzida")]
    public decimal? ValorAliquotaReduzida { get; set; }

    [JsonPropertyName("normal")]
    public decimal? Normal { get; set; }

    [JsonPropertyName("tributado")]
    public bool? Tributado { get; set; }

    /// <summary>Percentual de pagamento — apenas para ATUE. Tamanho: 16,7.</summary>
    [JsonPropertyName("percentualPagamento")]
    public decimal? PercentualPagamento { get; set; }
}

// -------------------------------------------------------
// Drawback
// -------------------------------------------------------

/// <summary>Dados do Ato Concessório do Drawback Isenção.</summary>
public class ItemDrawback
{
    /// <summary>Número do Ato vinculado à DUIMP de insumo. Tamanho: 9.</summary>
    [JsonPropertyName("numeroAtoDuimpInsumo")]
    public string? NumeroAtoDuimpInsumo { get; set; }

    /// <summary>Número do item do Ato. Até 6 dígitos.</summary>
    [JsonPropertyName("itemAtoDuimpInsumo")]
    public int? ItemAtoDuimpInsumo { get; set; }
}

// -------------------------------------------------------
// Wrappers reutilizáveis
// -------------------------------------------------------

/// <summary>Wrapper para objetos com campo "codigo" do tipo string.</summary>
public class ItemCodigoStr
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;
}

/// <summary>Wrapper para objetos com campo "codigo" do tipo inteiro.</summary>
public class ItemCodigoInt
{
    [JsonPropertyName("codigo")]
    public int Codigo { get; set; }
}

/// <summary>Wrapper para objetos com campo "valorBRL".</summary>
public class ItemValorBRL
{
    [JsonPropertyName("valorBRL")]
    public decimal ValorBRL { get; set; }
}