using System.Text.Json.Serialization;

namespace Siscomex.Automacao.Core.Models.Duimp;

public class DuimpConsultaResponse
{
    [JsonPropertyName("identificacao")]
    public Identificacao? Identificacao { get; set; }

    [JsonPropertyName("situacao")]
    public Situacao? Situacao { get; set; }

    [JsonPropertyName("carga")]
    public Carga? Carga { get; set; }

    [JsonPropertyName("tributos")]
    public Tributos? Tributos { get; set; }

    [JsonPropertyName("adicoes")]
    public List<Adicao> Adicoes { get; set; } = [];

    [JsonPropertyName("quantidadeItens")]
    public int QuantidadeItens { get; set; }

    [JsonPropertyName("itens")]
    public List<ItemLink> Itens { get; set; } = [];

    [JsonPropertyName("pagamentos")]
    public List<Pagamento> Pagamentos { get; set; } = [];

    [JsonPropertyName("documentos")]
    public Documentos? Documentos { get; set; }
}

// -------------------------------------------------------
// Identificação
// -------------------------------------------------------

public class Identificacao
{
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;

    [JsonPropertyName("versao")]
    public int Versao { get; set; }

    [JsonPropertyName("importador")]
    public ImportadorIdentificacao? Importador { get; set; }

    [JsonPropertyName("dataRegistro")]
    public string DataRegistro { get; set; } = string.Empty;

    [JsonPropertyName("responsavelRegistroNumero")]
    public string ResponsavelRegistroNumero { get; set; } = string.Empty;

    [JsonPropertyName("informacaoComplementar")]
    public string InformacaoComplementar { get; set; } = string.Empty;

    [JsonPropertyName("chaveAcesso")]
    public string ChaveAcesso { get; set; } = string.Empty;
}

public class ImportadorIdentificacao
{
    [JsonPropertyName("tipoImportador")]
    public string TipoImportador { get; set; } = string.Empty;

    [JsonPropertyName("ni")]
    public string Ni { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Situação
// -------------------------------------------------------

public class Situacao
{
    [JsonPropertyName("situacaoDuimp")]
    public string SituacaoDuimp { get; set; } = string.Empty;

    [JsonPropertyName("situacaoAnaliseRetificacao")]
    public string SituacaoAnaliseRetificacao { get; set; } = string.Empty;

    [JsonPropertyName("situacaoLicenciamento")]
    public string SituacaoLicenciamento { get; set; } = string.Empty;

    [JsonPropertyName("controleCarga")]
    public string ControleCarga { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Carga
// -------------------------------------------------------

public class Carga
{
    [JsonPropertyName("tipoIdentificacaoCarga")]
    public string TipoIdentificacaoCarga { get; set; } = string.Empty;

    [JsonPropertyName("identificacao")]
    public string Identificacao { get; set; } = string.Empty;

    [JsonPropertyName("paisProcedencia")]
    public CodigoPais? PaisProcedencia { get; set; }

    [JsonPropertyName("frete")]
    public ValorMoeda? Frete { get; set; }

    [JsonPropertyName("seguro")]
    public ValorMoeda? Seguro { get; set; }
}

public class CodigoPais
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;
}

public class ValorMoeda
{
    [JsonPropertyName("codigoMoedaNegociada")]
    public string CodigoMoeda { get; set; } = string.Empty;

    [JsonPropertyName("valorMoedaNegociada")]
    public decimal Valor { get; set; }
}

// -------------------------------------------------------
// Tributos
// -------------------------------------------------------

public class Tributos
{
    [JsonPropertyName("mercadoria")]
    public MercadoriaTributo? Mercadoria { get; set; }

    [JsonPropertyName("tributosCalculados")]
    public List<TributoCalculado> TributosCalculados { get; set; } = [];
}

public class MercadoriaTributo
{
    [JsonPropertyName("valorTotalLocalEmbarqueBRL")]
    public decimal ValorTotalBRL { get; set; }

    [JsonPropertyName("valorTotalLocalEmbarqueUSD")]
    public decimal ValorTotalUSD { get; set; }
}

public class TributoCalculado
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("valoresBRL")]
    public ValoresTributo? ValoresBRL { get; set; }
}

public class ValoresTributo
{
    [JsonPropertyName("calculado")]
    public decimal? Calculado { get; set; }

    [JsonPropertyName("devido")]
    public decimal? Devido { get; set; }

    [JsonPropertyName("aRecolher")]
    public decimal? ARecolher { get; set; }

    [JsonPropertyName("recolhido")]
    public decimal? Recolhido { get; set; }
}

// -------------------------------------------------------
// Adições e Itens
// -------------------------------------------------------

public class Adicao
{
    [JsonPropertyName("numero")]
    public int Numero { get; set; }

    [JsonPropertyName("itens")]
    public List<int> Itens { get; set; } = [];
}

public class ItemLink
{
    [JsonPropertyName("indice")]
    public int Indice { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Pagamentos
// -------------------------------------------------------

public class Pagamento
{
    [JsonPropertyName("versaoOrigem")]
    public int VersaoOrigem { get; set; }

    [JsonPropertyName("principal")]
    public PagamentoPrincipal? Principal { get; set; }
}

public class PagamentoPrincipal
{
    [JsonPropertyName("dataPagamento")]
    public string DataPagamento { get; set; } = string.Empty;

    [JsonPropertyName("codigoReceita")]
    public string CodigoReceita { get; set; } = string.Empty;

    [JsonPropertyName("tributo")]
    public TributoTipo? Tributo { get; set; }

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

public class TributoTipo
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Documentos
// -------------------------------------------------------

public class Documentos
{
    [JsonPropertyName("documentosInstrucao")]
    public List<DocumentoInstrucao> DocumentosInstrucao { get; set; } = [];
}

public class DocumentoInstrucao
{
    [JsonPropertyName("tipo")]
    public CodigoTipo? Tipo { get; set; }

    [JsonPropertyName("palavrasChave")]
    public List<PalavraChave> PalavrasChave { get; set; } = [];
}

public class CodigoTipo
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;
}

public class PalavraChave
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public string Valor { get; set; } = string.Empty;
}