using Siscomex.Automacao.Application.UseCases;
using Siscomex.Automacao.Core.Models.Duimp;

namespace Siscomex.Automacao.Runner.Forms;

/// <summary>
/// Formulário principal de consulta de DUIMP no Portal Único.
/// Exibe dados completos: capa, itens, tributos e pagamentos.
/// </summary>
public partial class FormConsultaDuimp : Form
{
    private readonly ConsultarDuimpUseCase _useCase;

    public FormConsultaDuimp(ConsultarDuimpUseCase useCase)
    {
        InitializeComponent();
        _useCase = useCase;
    }

    // -------------------------------------------------------
    // Eventos
    // -------------------------------------------------------

    private void txtNumeroDuimp_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) btnConsultar_Click(sender, e);
    }

    private void numVersao_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) btnConsultar_Click(sender, e);
    }

    private void chkVersaoEspecifica_CheckedChanged(object sender, EventArgs e)
    {
        numVersao.Enabled = chkVersaoEspecifica.Checked;
    }

    private async void btnConsultar_Click(object sender, EventArgs e)
    {
        var numero = txtNumeroDuimp.Text.Trim();
        if (string.IsNullOrWhiteSpace(numero))
        {
            MostrarStatus("Informe o número da DUIMP.", Color.OrangeRed);
            return;
        }

        SetarConsultando(true);
        LimparDados();

        var versao = chkVersaoEspecifica.Checked ? (int)numVersao.Value : 0;
        MostrarStatus(versao == 0
            ? "Buscando versão vigente..."
            : $"Consultando versão {versao}...", Color.Gray);

        try
        {
            var resultado = await _useCase.ExecutarAsync(numero, versao);
            PreencherCapa(resultado.Capa);
            PreencherItens(resultado.Itens);
            PreencherTributos(resultado.Itens);
            PreencherPagamentos(resultado.Capa);
            MostrarStatus(
                $"DUIMP {resultado.Capa.Identificacao?.Numero} " +
                $"v{resultado.Capa.Identificacao?.Versao} — " +
                $"{resultado.Itens.Count} item(ns) carregado(s).",
                Color.SeaGreen);
        }
        catch (Exception ex)
        {
            MostrarStatus($"Erro: {ex.Message}", Color.OrangeRed);
        }
        finally
        {
            SetarConsultando(false);
        }
    }

    // -------------------------------------------------------
    // Preenchimento das abas
    // -------------------------------------------------------

    /// <summary>Preenche a aba Capa com dados de identificação, situação e carga.</summary>
    private void PreencherCapa(DuimpConsultaResponse duimp)
    {
        var id = duimp.Identificacao;
        var sit = duimp.Situacao;
        var car = duimp.Carga;

        // Identificação
        lblNumero.Text = $"Número: {id?.Numero}";
        lblVersaoCapa.Text = $"Versão: {id?.Versao}";
        lblDataRegistro.Text = $"Data Registro: {id?.DataRegistro}";
        lblImportador.Text = $"Importador: {id?.Importador?.TipoImportador} — {id?.Importador?.Ni}";
        lblChaveAcesso.Text = $"Chave Acesso: {id?.ChaveAcesso}";
        lblResponsavel.Text = $"Responsável: {id?.ResponsavelRegistroNumero}";

        // Situação
        lblSituacaoDuimp.Text = $"Situação DUIMP: {sit?.SituacaoDuimp}";
        lblSituacaoLicenciamento.Text = $"Licenciamento: {sit?.SituacaoLicenciamento}";
        lblControleCarga.Text = $"Controle Carga: {sit?.ControleCarga}";
        lblSituacaoRetificacao.Text = $"Análise Retificação: {sit?.SituacaoAnaliseRetificacao}";

        // Carga
        lblTipoCarga.Text = $"Tipo: {car?.TipoIdentificacaoCarga}";
        lblCe.Text = $"CE Mercante: {car?.Identificacao}";
        lblPaisProcedencia.Text = $"País Procedência: {car?.PaisProcedencia?.Codigo}";
        lblFrete.Text = $"Frete: {car?.Frete?.CodigoMoeda} {car?.Frete?.Valor:N2}";
        lblSeguro.Text = $"Seguro: {car?.Seguro?.CodigoMoeda} {car?.Seguro?.Valor:N2}";
    }

    /// <summary>Preenche a aba Itens com os dados de cada item da DUIMP.</summary>
    private void PreencherItens(List<DuimpItemResponse> itens)
    {
        gridItens.Rows.Clear();
        foreach (var item in itens)
        {
            var m = item.Mercadoria;
            var v = item.CondicaoVenda;

            gridItens.Rows.Add(
                item.Identificacao?.NumeroItem,
                item.Produto?.Ncm,
                m?.Descricao,
                m?.QuantidadeComercial,
                m?.UnidadeComercial,
                m?.MoedaNegociada?.Codigo,
                m?.ValorUnitarioMoedaNegociada, //aqui
                v?.Incoterm?.Codigo,
                v?.ValorBRL,
                item.Status);
        }
    }

    //// <summary>
    /// Preenche a aba Tributos com os tributos calculados que já vêm
    /// dentro de cada item — sem precisar de endpoint separado.
    /// </summary>
    private void PreencherTributos(List<DuimpItemResponse> itens)
    {
        gridTributos.Rows.Clear();

        foreach (var item in itens)
        {
            var numeroItem = item.Identificacao?.NumeroItem;
            var tributos = item.Tributos?.TributosCalculados ?? [];

            foreach (var tributo in tributos)
            {
                var v = tributo.ValoresBRL;
                gridTributos.Rows.Add(
                    numeroItem,
                    tributo.Tipo,
                    v?.Calculado?.ToString("N2") ?? "-",
                    v?.Devido?.ToString("N2") ?? "-",
                    v?.ARecolher?.ToString("N2") ?? "-",
                    v?.AReduzir?.ToString("N2") ?? "-");
            }
        }
    }

    /// <summary>Preenche a aba Pagamentos com os pagamentos registrados na capa.</summary>
    private void PreencherPagamentos(DuimpConsultaResponse duimp)
    {
        gridPagamentos.Rows.Clear();
        foreach (var pag in duimp.Pagamentos)
        {
            var p = pag.Principal;
            gridPagamentos.Rows.Add(
                p?.Tributo?.Tipo,
                p?.CodigoReceita,
                p?.Valor.ToString("N2"),
                p?.DataPagamento,
                p?.Banco,
                p?.Agencia,
                p?.Conta);
        }
    }

    // -------------------------------------------------------
    // Auxiliares
    // -------------------------------------------------------

    private void LimparDados()
    {
        // Capa
        lblNumero.Text = lblVersaoCapa.Text = lblDataRegistro.Text =
        lblImportador.Text = lblChaveAcesso.Text = lblResponsavel.Text =
        lblSituacaoDuimp.Text = lblSituacaoLicenciamento.Text =
        lblControleCarga.Text = lblSituacaoRetificacao.Text =
        lblTipoCarga.Text = lblCe.Text = lblPaisProcedencia.Text =
        lblFrete.Text = lblSeguro.Text = string.Empty;

        // Grids
        gridItens.Rows.Clear();
        gridTributos.Rows.Clear();
        gridPagamentos.Rows.Clear();
    }

    private void SetarConsultando(bool consultando)
    {
        btnConsultar.Enabled = !consultando;
        txtNumeroDuimp.Enabled = !consultando;
        chkVersaoEspecifica.Enabled = !consultando;
        numVersao.Enabled = consultando ? false : chkVersaoEspecifica.Checked;
    }

    private void MostrarStatus(string mensagem, Color cor)
    {
        lblStatus.Text = mensagem;
        lblStatus.ForeColor = cor;
    }
}