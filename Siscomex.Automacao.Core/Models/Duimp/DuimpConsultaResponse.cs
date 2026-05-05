using System.Text.Json.Serialization;

namespace Siscomex.Automacao.Core.Models.Duimp;

/// <summary>
/// Representa a resposta completa da consulta de uma DUIMP registrada.
/// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/{versao}
/// </summary>
public class DuimpConsultaResponse
{
    [JsonPropertyName("identificacao")]
    public Identificacao? Identificacao { get; set; }

    [JsonPropertyName("situacao")]
    public Situacao? Situacao { get; set; }

    [JsonPropertyName("equipesTrabalho")]
    public List<EquipeTrabalho> EquipesTrabalho { get; set; } = [];

    [JsonPropertyName("resultadoAnaliseRisco")]
    public ResultadoAnaliseRisco? ResultadoAnaliseRisco { get; set; }

    [JsonPropertyName("carga")]
    public Carga? Carga { get; set; }

    [JsonPropertyName("documentos")]
    public Documentos? Documentos { get; set; }

    [JsonPropertyName("adicoes")]
    public List<Adicao> Adicoes { get; set; } = [];

    [JsonPropertyName("tributos")]
    public Tributos? Tributos { get; set; }

    [JsonPropertyName("pagamentos")]
    public List<Pagamento> Pagamentos { get; set; } = [];

    [JsonPropertyName("tratamentoAdministrativo")]
    public TratamentoAdministrativo? TratamentoAdministrativo { get; set; }

    [JsonPropertyName("quantidadeItens")]
    public int QuantidadeItens { get; set; }

    [JsonPropertyName("itens")]
    public List<ItemLink> Itens { get; set; } = [];
}

// -------------------------------------------------------
// Identificação
// -------------------------------------------------------

/// <summary>Dados de identificação da DUIMP.</summary>
public class Identificacao
{
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;

    /// <summary>
    /// Versão da DUIMP. Mínimo: 0, Máximo: 9999.
    /// Documentação define como string mas API retorna int — mapeado como int.
    /// </summary>
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

/// <summary>Identificação do importador: CNPJ (14 dígitos) ou CPF (11 dígitos).</summary>
public class ImportadorIdentificacao
{
    /// <summary>CNPJ ou CPF.</summary>
    [JsonPropertyName("tipoImportador")]
    public string TipoImportador { get; set; } = string.Empty;

    [JsonPropertyName("ni")]
    public string Ni { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Situação
// -------------------------------------------------------

/// <summary>Tipos de situações e controles da DUIMP.</summary>
public class Situacao
{
    /// <summary>
    /// Situação vigente da DUIMP.
    /// Ex: REGISTRADA_AGUARDANDO_CANAL, DESEMBARACADA_CARGA_ENTREGUE, CANCELADA_PELA_ADUANA.
    /// </summary>
    [JsonPropertyName("situacaoDuimp")]
    public string SituacaoDuimp { get; set; } = string.Empty;

    /// <summary>
    /// Situação da análise de retificação.
    /// Ex: NA, PENDENTE_AGUARDANDO_ANALISE, DEFERIDA, DEFERIDA_AUTOMATICAMENTE.
    /// </summary>
    [JsonPropertyName("situacaoAnaliseRetificacao")]
    public string SituacaoAnaliseRetificacao { get; set; } = string.Empty;

    /// <summary>DISPENSADO, DEFERIDO, PENDENTE ou IMPEDIDO.</summary>
    [JsonPropertyName("situacaoLicenciamento")]
    public string SituacaoLicenciamento { get; set; } = string.Empty;

    /// <summary>DESVINCULADA, ENTREGUE, ATRACADA ou VINCULADA.</summary>
    [JsonPropertyName("controleCarga")]
    public string ControleCarga { get; set; } = string.Empty;

    [JsonPropertyName("situacaoConferenciaAduaneira")]
    public List<SituacaoConferenciaAduaneira> SituacaoConferenciaAduaneira { get; set; } = [];

    [JsonPropertyName("situacaoConferenciaAnuente")]
    public List<SituacaoConferenciaAnuente> SituacaoConferenciaAnuente { get; set; } = [];
}

/// <summary>Conferência aduaneira por órgão.</summary>
public class SituacaoConferenciaAduaneira
{
    /// <summary>Sigla do órgão. Tamanho: 1-30.</summary>
    [JsonPropertyName("siglaOrgao")]
    public string SiglaOrgao { get; set; } = string.Empty;

    /// <summary>
    /// Situação da conferência.
    /// Ex: AGUARDANDO_ANALISE_RISCO, CONCLUIDA, DESEMBARACO_AUTORIZADO_CONDICIONADO_CONCLUSAO_CONFERENCIA_ANUENTE.
    /// </summary>
    [JsonPropertyName("situacao")]
    public string Situacao { get; set; } = string.Empty;

    /// <summary>SIM, NAO ou NA.</summary>
    [JsonPropertyName("indicadorAutorizacaoEntrega")]
    public string IndicadorAutorizacaoEntrega { get; set; } = string.Empty;

    /// <summary>SIM, NAO ou NA.</summary>
    [JsonPropertyName("indicadorDesembaracoDecisaoJudicial")]
    public string IndicadorDesembaracoDecisaoJudicial { get; set; } = string.Empty;
}

/// <summary>Conferência do anuente por órgão.</summary>
public class SituacaoConferenciaAnuente
{
    /// <summary>Sigla do órgão. Tamanho: 1-30.</summary>
    [JsonPropertyName("siglaOrgao")]
    public string SiglaOrgao { get; set; } = string.Empty;

    /// <summary>
    /// Situação da conferência do anuente.
    /// Ex: AGUARDANDO_ANALISE_RISCO, CONCLUIDA, EM_CONFERENCIA, EM_EXIGENCIA.
    /// </summary>
    [JsonPropertyName("situacao")]
    public string Situacao { get; set; } = string.Empty;

    /// <summary>SIM, NAO ou NA.</summary>
    [JsonPropertyName("indicadorAutorizacaoProsseguimentoConferenciaAnuente")]
    public string IndicadorAutorizacaoProsseguimento { get; set; } = string.Empty;

    /// <summary>SIM, NAO ou NA.</summary>
    [JsonPropertyName("indicadorConclusaoDecisaoJudicial")]
    public string IndicadorConclusaoDecisaoJudicial { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Equipes de trabalho
// -------------------------------------------------------

/// <summary>Equipe de trabalho associada a um órgão.</summary>
public class EquipeTrabalho
{
    /// <summary>Sigla do órgão. Tamanho: 1-30.</summary>
    [JsonPropertyName("siglaOrgao")]
    public string SiglaOrgao { get; set; } = string.Empty;

    /// <summary>Código da equipe. Tamanho: 10.</summary>
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    /// <summary>Descrição da equipe. Tamanho: 60.</summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Resultado análise de risco
// -------------------------------------------------------

/// <summary>Resultado da análise de risco da DUIMP.</summary>
public class ResultadoAnaliseRisco
{
    /// <summary>Canal consolidado: VERDE, AMARELO, VERMELHO ou CINZA.</summary>
    [JsonPropertyName("canalConsolidado")]
    public string? CanalConsolidado { get; set; }

    [JsonPropertyName("resultadoRFB")]
    public List<ResultadoAnaliseRiscoRfb> ResultadoRFB { get; set; } = [];

    [JsonPropertyName("resultadoAnuente")]
    public List<ResultadoAnaliseRiscoAnuente> ResultadoAnuente { get; set; } = [];
}

/// <summary>Resultado da análise de risco da RFB.</summary>
public class ResultadoAnaliseRiscoRfb
{
    /// <summary>Sigla do órgão. Tamanho: 1-30.</summary>
    [JsonPropertyName("orgao")]
    public string Orgao { get; set; } = string.Empty;

    /// <summary>
    /// Ex: DESEMBARACO_AUTORIZADO, EXAME_DOCUMENTAL,
    /// EXAME_DOCUMENTAL_VERIFICACAO_FISICA_APURACAO_INDICIOS_FRAUDE.
    /// </summary>
    [JsonPropertyName("resultado")]
    public string Resultado { get; set; } = string.Empty;
}

/// <summary>Resultado da análise de risco do anuente.</summary>
public class ResultadoAnaliseRiscoAnuente
{
    /// <summary>Sigla do órgão. Tamanho: 1-30.</summary>
    [JsonPropertyName("orgao")]
    public string Orgao { get; set; } = string.Empty;

    /// <summary>DISPENSADO, EXAME_DOCUMENTAL, EXAME_DOCUMENTAL_INSPECAO_FISICA ou PROCEDIMENTO_AUDITORIA_INVESTIGACAO.</summary>
    [JsonPropertyName("resultado")]
    public string Resultado { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Carga
// -------------------------------------------------------

/// <summary>Dados da carga vinculada à DUIMP.</summary>
public class Carga
{
    [JsonPropertyName("unidadeDeclarada")]
    public CargaUnidadeDeclarada? UnidadeDeclarada { get; set; }

    /// <summary>CE ou RUC.</summary>
    [JsonPropertyName("tipoIdentificacaoCarga")]
    public string TipoIdentificacaoCarga { get; set; } = string.Empty;

    /// <summary>
    /// Número de identificação da carga.
    /// CE: 15 dígitos. RUC: 1-32 caracteres.
    /// Nulo para DUIMP com situação especial de despacho.
    /// </summary>
    [JsonPropertyName("identificacao")]
    public string? Identificacao { get; set; }

    [JsonPropertyName("seguro")]
    public ValorMoeda? Seguro { get; set; }

    [JsonPropertyName("frete")]
    public ValorMoeda? Frete { get; set; }

    [JsonPropertyName("paisProcedencia")]
    public CodigoPais? PaisProcedencia { get; set; }

    [JsonPropertyName("motivoSituacaoEspecial")]
    public CargaMotivoSituacaoEspecial? MotivoSituacaoEspecial { get; set; }
}

/// <summary>Unidade de despacho da RFB. Código: 7 dígitos (NNNNNNN).</summary>
public class CargaUnidadeDeclarada
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;
}

/// <summary>
/// Motivo da situação especial de despacho.
/// Nulo para DUIMP sem situação especial.
/// </summary>
public class CargaMotivoSituacaoEspecial
{
    /// <summary>Código do motivo. Tamanho: 5. Formato: NNNNN.</summary>
    [JsonPropertyName("codigo")]
    public string? Codigo { get; set; }
}

public class CodigoPais
{
    /// <summary>Código ISO 3166-1 alfa-2. Tamanho: 2.</summary>
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;
}

/// <summary>Valor em moeda negociada — usado para frete e seguro da carga.</summary>
public class ValorMoeda
{
    /// <summary>Código ISO-4217. Tamanho: 3. Ex: USD.</summary>
    [JsonPropertyName("codigoMoedaNegociada")]
    public string CodigoMoeda { get; set; } = string.Empty;

    /// <summary>Valor na moeda negociada. Tamanho: 13,2.</summary>
    [JsonPropertyName("valorMoedaNegociada")]
    public decimal Valor { get; set; }
}

// -------------------------------------------------------
// Documentos
// -------------------------------------------------------

/// <summary>Documentos instrutivos, processos, declarações estrangeiras e dossiês.</summary>
public class Documentos
{
    [JsonPropertyName("documentosInstrucao")]
    public List<DocumentoInstrucao> DocumentosInstrucao { get; set; } = [];

    [JsonPropertyName("processos")]
    public List<ProcessoDocumento> Processos { get; set; } = [];

    [JsonPropertyName("declaracoesExportacaoEstrangeira")]
    public List<DeclaracaoExportacaoEstrangeira> DeclaracoesExportacaoEstrangeira { get; set; } = [];

    [JsonPropertyName("dossies")]
    public List<Dossie> Dossies { get; set; } = [];
}

/// <summary>Documento instrutivo para despacho (E-Docex).</summary>
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

/// <summary>Processo administrativo vinculado à DUIMP.</summary>
public class ProcessoDocumento
{
    [JsonPropertyName("identificacao")]
    public string Identificacao { get; set; } = string.Empty;

    /// <summary>ADMINISTRATIVO.</summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;
}

/// <summary>Declaração estrangeira — apenas para cargas do Mercosul.</summary>
public class DeclaracaoExportacaoEstrangeira
{
    /// <summary>Número da declaração. Tamanho: 1-70.</summary>
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;

    /// <summary>Item inicial da faixa. Tamanho: 1-7.</summary>
    [JsonPropertyName("faixaInicio")]
    public string FaixaInicio { get; set; } = string.Empty;

    /// <summary>Item final da faixa. Tamanho: 1-7.</summary>
    [JsonPropertyName("faixaFim")]
    public string FaixaFim { get; set; } = string.Empty;
}

/// <summary>Dossiê vinculado à DUIMP. Número com tamanho 20.</summary>
public class Dossie
{
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Adições e Itens
// -------------------------------------------------------

/// <summary>
/// Adição da DUIMP.
/// Nota: documentação define numero e itens como number($double).
/// </summary>
public class Adicao
{
    [JsonPropertyName("numero")]
    public decimal Numero { get; set; }

    [JsonPropertyName("itens")]
    public List<decimal> Itens { get; set; } = [];
}

public class ItemLink
{
    [JsonPropertyName("indice")]
    public int Indice { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;
}

// -------------------------------------------------------
// Tributos da capa
// -------------------------------------------------------

/// <summary>Tributos totais da DUIMP — valores consolidados de todos os itens.</summary>
public class Tributos
{
    [JsonPropertyName("mercadoria")]
    public MercadoriaTributo? Mercadoria { get; set; }

    [JsonPropertyName("tributosCalculados")]
    public List<TributoCalculado> TributosCalculados { get; set; } = [];
}

/// <summary>Valores totais da mercadoria em R$ e USD. Tamanho: 16,7.</summary>
public class MercadoriaTributo
{
    [JsonPropertyName("valorTotalLocalEmbarqueBRL")]
    public decimal? ValorTotalBRL { get; set; }

    [JsonPropertyName("valorTotalLocalEmbarqueUSD")]
    public decimal? ValorTotalUSD { get; set; }
}

/// <summary>Tributo calculado consolidado da DUIMP (nível capa).</summary>
public class TributoCalculado
{
    /// <summary>II, IPI, PIS, COFINS, CIDE, ANTIDUMPING, TAXA_UTILIZACAO etc.</summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("valoresBRL")]
    public ValoresTributo? ValoresBRL { get; set; }
}

/// <summary>Valores do tributo calculado em R$. Tamanho: 16,7.</summary>
public class ValoresTributo
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

    [JsonPropertyName("recolhido")]
    public decimal? Recolhido { get; set; }
}

// -------------------------------------------------------
// Pagamentos
// -------------------------------------------------------

/// <summary>Pagamento realizado na DUIMP.</summary>
public class Pagamento
{
    /// <summary>
    /// Versão da DUIMP em que o pagamento foi realizado. Mínimo: 1, Máximo: 9999.
    /// Documentação define como string mas API retorna int — mapeado como int.
    /// </summary>
    [JsonPropertyName("versaoOrigem")]
    public int VersaoOrigem { get; set; }

    [JsonPropertyName("principal")]
    public PagamentoPrincipal? Principal { get; set; }
}

/// <summary>Dados principais do pagamento.</summary>
public class PagamentoPrincipal
{
    /// <summary>Data e hora do pagamento. Formato: yyyy-MM-dd'T'HH:mm:ssZ.</summary>
    [JsonPropertyName("dataPagamento")]
    public string DataPagamento { get; set; } = string.Empty;

    /// <summary>Código da receita. Tamanho: 4. Formato: NNNN.</summary>
    [JsonPropertyName("codigoReceita")]
    public string CodigoReceita { get; set; } = string.Empty;

    /// <summary>Código do banco. Máximo: 3 dígitos.</summary>
    [JsonPropertyName("banco")]
    public string Banco { get; set; } = string.Empty;

    /// <summary>Número da agência. Tamanho: 1-4.</summary>
    [JsonPropertyName("agencia")]
    public string Agencia { get; set; } = string.Empty;

    /// <summary>Número da conta. Tamanho: 1-10.</summary>
    [JsonPropertyName("conta")]
    public string Conta { get; set; } = string.Empty;

    [JsonPropertyName("tributo")]
    public TributoTipo? Tributo { get; set; }

    /// <summary>Valor pago. Tamanho: 17,2.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    [JsonPropertyName("juros")]
    public JurosPagamento? Juros { get; set; }
}

public class TributoTipo
{
    /// <summary>II, IPI, PIS, COFINS, CIDE, ANTIDUMPING, TAXA_UTILIZACAO etc.</summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;
}

/// <summary>Dados de juros do pagamento, quando houver.</summary>
public class JurosPagamento
{
    /// <summary>Código da receita de juros. Tamanho: 4.</summary>
    [JsonPropertyName("codigoReceita")]
    public string? CodigoReceita { get; set; }

    /// <summary>Valor de juros. Tamanho: 17,2.</summary>
    [JsonPropertyName("valor")]
    public decimal? Valor { get; set; }

    /// <summary>Data do pagamento de juros. Formato: yyyy-MM-dd'T'HH:mm:ssZ.</summary>
    [JsonPropertyName("dataPagamentoJuros")]
    public string? DataPagamentoJuros { get; set; }

    [JsonPropertyName("bancoJuros")]
    public string? BancoJuros { get; set; }

    [JsonPropertyName("agenciaJuros")]
    public string? AgenciaJuros { get; set; }

    [JsonPropertyName("contaJuros")]
    public string? ContaJuros { get; set; }
}

// -------------------------------------------------------
// Tratamento administrativo
// -------------------------------------------------------

/// <summary>Processo de diagnóstico do tratamento administrativo.</summary>
public class TratamentoAdministrativo
{
    [JsonPropertyName("resultadoProcessamentoTA")]
    public ResultadoProcessamentoTA? ResultadoProcessamentoTA { get; set; }

    [JsonPropertyName("itensTratamentoAdministrativo")]
    public List<ItemTratamentoAdministrativo> ItensTratamentoAdministrativo { get; set; } = [];
}

/// <summary>Resultado consolidado do tratamento administrativo.</summary>
public class ResultadoProcessamentoTA
{
    /// <summary>Data do diagnóstico. Formato: yyyy-MM-dd'T'HH:mm:ssZ.</summary>
    [JsonPropertyName("dataProcessamento")]
    public string DataProcessamento { get; set; } = string.Empty;

    /// <summary>DISPENSADO, DEFERIDO, ALERTA, PENDENTE ou IMPEDIDO.</summary>
    [JsonPropertyName("resultadoConsolidadoTA")]
    public string ResultadoConsolidadoTA { get; set; } = string.Empty;
}

/// <summary>Item do tratamento administrativo por órgão anuente.</summary>
public class ItemTratamentoAdministrativo
{
    /// <summary>Número do item da DUIMP. Tamanho: 15.</summary>
    [JsonPropertyName("numeroItemDuimp")]
    public decimal NumeroItemDuimp { get; set; }

    /// <summary>IMPEDE_REGISTRO, REQUER_LPCO ou ALERTA.</summary>
    [JsonPropertyName("tipoTratamento")]
    public string TipoTratamento { get; set; } = string.Empty;

    /// <summary>Descrição do retorno. Tamanho: 0-4000.</summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    /// <summary>Sigla do órgão anuente. Tamanho: 1-30.</summary>
    [JsonPropertyName("orgao")]
    public string Orgao { get; set; } = string.Empty;

    /// <summary>Número único do LPCO associado. Tamanho: 11.</summary>
    [JsonPropertyName("lpco")]
    public string? Lpco { get; set; }

    /// <summary>Observação do sistema TA/LPCO. Tamanho: 0-4000.</summary>
    [JsonPropertyName("observacoes")]
    public string? Observacoes { get; set; }
}