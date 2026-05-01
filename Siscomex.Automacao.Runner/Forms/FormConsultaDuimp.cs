using Siscomex.Automacao.Application.UseCases;
using Siscomex.Automacao.Core.Models.Duimp;

namespace Siscomex.Automacao.Runner.Forms;

public partial class FormConsultaDuimp : Form
{
    private readonly ConsultarDuimpUseCase _useCase;

    public FormConsultaDuimp(ConsultarDuimpUseCase useCase)
    {
        InitializeComponent();
        _useCase = useCase;

        grpDadosGerais.Visible = false;
    }

    private async void BtnConsultar_Click(object? sender, EventArgs e)
    {
        var numero = txtNumeroDuimp.Text.Trim().Replace("-", "");
        if (string.IsNullOrWhiteSpace(numero))
        {
            MostrarStatus("Informe o número da DUIMP.", Color.OrangeRed);
            return;
        }

        SetarConsultando(true);
        MostrarStatus("Consultando...", Color.Gray);
        grpDadosGerais.Visible = false;
        gridItens.Rows.Clear();

        try
        {
            var versao = (int)numVersao.Value;
            var resultado = await _useCase.ExecutarAsync(numero, versao);
            PreencherResultado(resultado);
            MostrarStatus($"DUIMP {resultado.Identificacao} consultada com sucesso.", Color.SeaGreen);
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

    private void PreencherResultado(DuimpConsultaResponse duimp)
    {
        var id = duimp.Identificacao;
        var sit = duimp.Situacao;

        lblResultNumeroDuimp.Text = $"Número: {id?.Numero} — Versão: {id?.Versao}";
        lblResultSituacao.Text = $"Situação: {sit?.SituacaoDuimp} | Carga: {sit?.ControleCarga}";
        lblResultDataRegistro.Text = $"Data Registro: {id?.DataRegistro}";
        lblResultImportador.Text = $"Importador: {id?.Importador?.TipoImportador} {id?.Importador?.Ni}";

        grpDadosGerais.Visible = true;

        // Grid de tributos (mais útil que itens nessa primeira tela)
        gridItens.Rows.Clear();
        foreach (var tributo in duimp.Tributos?.TributosCalculados ?? [])
        {
            gridItens.Rows.Add(
                tributo.Tipo,
                tributo.ValoresBRL?.Calculado?.ToString("N2") ?? "-",
                tributo.ValoresBRL?.Devido?.ToString("N2") ?? "-",
                tributo.ValoresBRL?.ARecolher?.ToString("N2") ?? "-",
                tributo.ValoresBRL?.Recolhido?.ToString("N2") ?? "-"
            );
        }
    }

    private void SetarConsultando(bool consultando)
    {
        btnConsultar.Enabled = !consultando;
        txtNumeroDuimp.Enabled = !consultando;
        numVersao.Enabled = !consultando;
    }

    private void MostrarStatus(string mensagem, Color cor)
    {
        lblStatus.Text = mensagem;
        lblStatus.ForeColor = cor;
    }

    private void numVersao_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) BtnConsultar_Click(sender, e);
    }

    private void txtNumeroDuimp_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) this.numVersao.Focus();
    }
}