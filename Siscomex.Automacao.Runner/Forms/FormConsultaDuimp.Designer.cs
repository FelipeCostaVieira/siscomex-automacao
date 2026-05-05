namespace Siscomex.Automacao.Runner.Forms
{
    partial class FormConsultaDuimp
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblNumeroDuimp = new Label();
            txtNumeroDuimp = new TextBox();
            chkVersaoEspecifica = new CheckBox();
            lblVersao = new Label();
            numVersao = new NumericUpDown();
            btnConsultar = new Button();
            lblStatus = new Label();
            tabControl = new TabControl();
            tabCapa = new TabPage();
            grpIdentificacao = new GroupBox();
            lblNumero = new Label();
            lblVersaoCapa = new Label();
            lblDataRegistro = new Label();
            lblImportador = new Label();
            lblChaveAcesso = new Label();
            lblResponsavel = new Label();
            grpSituacao = new GroupBox();
            lblSituacaoDuimp = new Label();
            lblSituacaoLicenciamento = new Label();
            lblControleCarga = new Label();
            lblSituacaoRetificacao = new Label();
            grpCarga = new GroupBox();
            lblTipoCarga = new Label();
            lblCe = new Label();
            lblPaisProcedencia = new Label();
            lblFrete = new Label();
            lblSeguro = new Label();
            tabItens = new TabPage();
            gridItens = new DataGridView();
            colItem = new DataGridViewTextBoxColumn();
            colNcm = new DataGridViewTextBoxColumn();
            colDescricao = new DataGridViewTextBoxColumn();
            colQuantidade = new DataGridViewTextBoxColumn();
            colUnidade = new DataGridViewTextBoxColumn();
            colMoeda = new DataGridViewTextBoxColumn();
            colValorUnit = new DataGridViewTextBoxColumn();
            colIncoterm = new DataGridViewTextBoxColumn();
            colValorBRL = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            tabTributos = new TabPage();
            gridTributos = new DataGridView();
            colTribItemNum = new DataGridViewTextBoxColumn();
            colTribTipo = new DataGridViewTextBoxColumn();
            colTribCalculado = new DataGridViewTextBoxColumn();
            colTribDevido = new DataGridViewTextBoxColumn();
            colTribARecolher = new DataGridViewTextBoxColumn();
            colTribRecolhido = new DataGridViewTextBoxColumn();
            tabPagamentos = new TabPage();
            gridPagamentos = new DataGridView();
            colPagTributo = new DataGridViewTextBoxColumn();
            colPagReceita = new DataGridViewTextBoxColumn();
            colPagValor = new DataGridViewTextBoxColumn();
            colPagData = new DataGridViewTextBoxColumn();
            colPagBanco = new DataGridViewTextBoxColumn();
            colPagAgencia = new DataGridViewTextBoxColumn();
            colPagConta = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVersao).BeginInit();
            tabControl.SuspendLayout();
            tabCapa.SuspendLayout();
            grpIdentificacao.SuspendLayout();
            grpSituacao.SuspendLayout();
            grpCarga.SuspendLayout();
            tabItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridItens).BeginInit();
            tabTributos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridTributos).BeginInit();
            tabPagamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPagamentos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNumeroDuimp);
            panel1.Controls.Add(txtNumeroDuimp);
            panel1.Controls.Add(chkVersaoEspecifica);
            panel1.Controls.Add(lblVersao);
            panel1.Controls.Add(numVersao);
            panel1.Controls.Add(btnConsultar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 50);
            panel1.TabIndex = 0;
            // 
            // lblNumeroDuimp
            // 
            lblNumeroDuimp.AutoSize = true;
            lblNumeroDuimp.Location = new Point(12, 16);
            lblNumeroDuimp.Name = "lblNumeroDuimp";
            lblNumeroDuimp.Size = new Size(103, 17);
            lblNumeroDuimp.TabIndex = 0;
            lblNumeroDuimp.Text = "Número DUIMP:";
            // 
            // txtNumeroDuimp
            // 
            txtNumeroDuimp.CharacterCasing = CharacterCasing.Upper;
            txtNumeroDuimp.Location = new Point(120, 13);
            txtNumeroDuimp.Name = "txtNumeroDuimp";
            txtNumeroDuimp.PlaceholderText = "Ex: 26BR00005061513";
            txtNumeroDuimp.Size = new Size(180, 24);
            txtNumeroDuimp.TabIndex = 0;
            txtNumeroDuimp.KeyDown += txtNumeroDuimp_KeyDown;
            // 
            // chkVersaoEspecifica
            // 
            chkVersaoEspecifica.AutoSize = true;
            chkVersaoEspecifica.Location = new Point(315, 15);
            chkVersaoEspecifica.Name = "chkVersaoEspecifica";
            chkVersaoEspecifica.Size = new Size(128, 21);
            chkVersaoEspecifica.TabIndex = 1;
            chkVersaoEspecifica.Text = "Versão específica";
            chkVersaoEspecifica.CheckedChanged += chkVersaoEspecifica_CheckedChanged;
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Location = new Point(435, 16);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(51, 17);
            lblVersao.TabIndex = 2;
            lblVersao.Text = "Versão:";
            // 
            // numVersao
            // 
            numVersao.Enabled = false;
            numVersao.Location = new Point(485, 13);
            numVersao.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numVersao.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numVersao.Name = "numVersao";
            numVersao.Size = new Size(60, 24);
            numVersao.TabIndex = 2;
            numVersao.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numVersao.KeyDown += numVersao_KeyDown;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(560, 11);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(100, 28);
            btnConsultar.TabIndex = 3;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Top;
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(0, 50);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(8, 4, 0, 0);
            lblStatus.Size = new Size(1400, 22);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Informe o número da DUIMP e clique em Consultar.";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabCapa);
            tabControl.Controls.Add(tabItens);
            tabControl.Controls.Add(tabTributos);
            tabControl.Controls.Add(tabPagamentos);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 72);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1400, 828);
            tabControl.TabIndex = 1;
            // 
            // tabCapa
            // 
            tabCapa.Controls.Add(grpIdentificacao);
            tabCapa.Controls.Add(grpSituacao);
            tabCapa.Controls.Add(grpCarga);
            tabCapa.Location = new Point(4, 26);
            tabCapa.Name = "tabCapa";
            tabCapa.Padding = new Padding(8);
            tabCapa.Size = new Size(1392, 798);
            tabCapa.TabIndex = 0;
            tabCapa.Text = "Capa";
            // 
            // grpIdentificacao
            // 
            grpIdentificacao.Controls.Add(lblNumero);
            grpIdentificacao.Controls.Add(lblVersaoCapa);
            grpIdentificacao.Controls.Add(lblDataRegistro);
            grpIdentificacao.Controls.Add(lblImportador);
            grpIdentificacao.Controls.Add(lblChaveAcesso);
            grpIdentificacao.Controls.Add(lblResponsavel);
            grpIdentificacao.Location = new Point(8, 8);
            grpIdentificacao.Name = "grpIdentificacao";
            grpIdentificacao.Size = new Size(650, 160);
            grpIdentificacao.TabIndex = 0;
            grpIdentificacao.TabStop = false;
            grpIdentificacao.Text = "Identificação";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(12, 25);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(59, 17);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Número:";
            // 
            // lblVersaoCapa
            // 
            lblVersaoCapa.AutoSize = true;
            lblVersaoCapa.Location = new Point(12, 48);
            lblVersaoCapa.Name = "lblVersaoCapa";
            lblVersaoCapa.Size = new Size(51, 17);
            lblVersaoCapa.TabIndex = 1;
            lblVersaoCapa.Text = "Versão:";
            // 
            // lblDataRegistro
            // 
            lblDataRegistro.AutoSize = true;
            lblDataRegistro.Location = new Point(12, 71);
            lblDataRegistro.Name = "lblDataRegistro";
            lblDataRegistro.Size = new Size(91, 17);
            lblDataRegistro.TabIndex = 2;
            lblDataRegistro.Text = "Data Registro:";
            // 
            // lblImportador
            // 
            lblImportador.AutoSize = true;
            lblImportador.Location = new Point(12, 94);
            lblImportador.Name = "lblImportador";
            lblImportador.Size = new Size(78, 17);
            lblImportador.TabIndex = 3;
            lblImportador.Text = "Importador:";
            // 
            // lblChaveAcesso
            // 
            lblChaveAcesso.AutoSize = true;
            lblChaveAcesso.Location = new Point(12, 117);
            lblChaveAcesso.Name = "lblChaveAcesso";
            lblChaveAcesso.Size = new Size(91, 17);
            lblChaveAcesso.TabIndex = 4;
            lblChaveAcesso.Text = "Chave Acesso:";
            // 
            // lblResponsavel
            // 
            lblResponsavel.AutoSize = true;
            lblResponsavel.Location = new Point(12, 140);
            lblResponsavel.Name = "lblResponsavel";
            lblResponsavel.Size = new Size(84, 17);
            lblResponsavel.TabIndex = 5;
            lblResponsavel.Text = "Responsável:";
            // 
            // grpSituacao
            // 
            grpSituacao.Controls.Add(lblSituacaoDuimp);
            grpSituacao.Controls.Add(lblSituacaoLicenciamento);
            grpSituacao.Controls.Add(lblControleCarga);
            grpSituacao.Controls.Add(lblSituacaoRetificacao);
            grpSituacao.Location = new Point(670, 8);
            grpSituacao.Name = "grpSituacao";
            grpSituacao.Size = new Size(400, 160);
            grpSituacao.TabIndex = 1;
            grpSituacao.TabStop = false;
            grpSituacao.Text = "Situação";
            // 
            // lblSituacaoDuimp
            // 
            lblSituacaoDuimp.AutoSize = true;
            lblSituacaoDuimp.Location = new Point(12, 25);
            lblSituacaoDuimp.Name = "lblSituacaoDuimp";
            lblSituacaoDuimp.Size = new Size(104, 17);
            lblSituacaoDuimp.TabIndex = 0;
            lblSituacaoDuimp.Text = "Situação DUIMP:";
            // 
            // lblSituacaoLicenciamento
            // 
            lblSituacaoLicenciamento.AutoSize = true;
            lblSituacaoLicenciamento.Location = new Point(12, 48);
            lblSituacaoLicenciamento.Name = "lblSituacaoLicenciamento";
            lblSituacaoLicenciamento.Size = new Size(93, 17);
            lblSituacaoLicenciamento.TabIndex = 1;
            lblSituacaoLicenciamento.Text = "Licenciamento:";
            // 
            // lblControleCarga
            // 
            lblControleCarga.AutoSize = true;
            lblControleCarga.Location = new Point(12, 71);
            lblControleCarga.Name = "lblControleCarga";
            lblControleCarga.Size = new Size(100, 17);
            lblControleCarga.TabIndex = 2;
            lblControleCarga.Text = "Controle Carga:";
            // 
            // lblSituacaoRetificacao
            // 
            lblSituacaoRetificacao.AutoSize = true;
            lblSituacaoRetificacao.Location = new Point(12, 94);
            lblSituacaoRetificacao.Name = "lblSituacaoRetificacao";
            lblSituacaoRetificacao.Size = new Size(119, 17);
            lblSituacaoRetificacao.TabIndex = 3;
            lblSituacaoRetificacao.Text = "Análise Retificação:";
            // 
            // grpCarga
            // 
            grpCarga.Controls.Add(lblTipoCarga);
            grpCarga.Controls.Add(lblCe);
            grpCarga.Controls.Add(lblPaisProcedencia);
            grpCarga.Controls.Add(lblFrete);
            grpCarga.Controls.Add(lblSeguro);
            grpCarga.Location = new Point(8, 180);
            grpCarga.Name = "grpCarga";
            grpCarga.Size = new Size(500, 160);
            grpCarga.TabIndex = 2;
            grpCarga.TabStop = false;
            grpCarga.Text = "Carga";
            // 
            // lblTipoCarga
            // 
            lblTipoCarga.AutoSize = true;
            lblTipoCarga.Location = new Point(12, 25);
            lblTipoCarga.Name = "lblTipoCarga";
            lblTipoCarga.Size = new Size(37, 17);
            lblTipoCarga.TabIndex = 0;
            lblTipoCarga.Text = "Tipo:";
            // 
            // lblCe
            // 
            lblCe.AutoSize = true;
            lblCe.Location = new Point(12, 48);
            lblCe.Name = "lblCe";
            lblCe.Size = new Size(85, 17);
            lblCe.TabIndex = 1;
            lblCe.Text = "CE Mercante:";
            // 
            // lblPaisProcedencia
            // 
            lblPaisProcedencia.AutoSize = true;
            lblPaisProcedencia.Location = new Point(12, 71);
            lblPaisProcedencia.Name = "lblPaisProcedencia";
            lblPaisProcedencia.Size = new Size(109, 17);
            lblPaisProcedencia.TabIndex = 2;
            lblPaisProcedencia.Text = "País Procedência:";
            // 
            // lblFrete
            // 
            lblFrete.AutoSize = true;
            lblFrete.Location = new Point(12, 94);
            lblFrete.Name = "lblFrete";
            lblFrete.Size = new Size(40, 17);
            lblFrete.TabIndex = 3;
            lblFrete.Text = "Frete:";
            // 
            // lblSeguro
            // 
            lblSeguro.AutoSize = true;
            lblSeguro.Location = new Point(12, 117);
            lblSeguro.Name = "lblSeguro";
            lblSeguro.Size = new Size(53, 17);
            lblSeguro.TabIndex = 4;
            lblSeguro.Text = "Seguro:";
            // 
            // tabItens
            // 
            tabItens.Controls.Add(gridItens);
            tabItens.Location = new Point(4, 26);
            tabItens.Name = "tabItens";
            tabItens.Padding = new Padding(8);
            tabItens.Size = new Size(1392, 798);
            tabItens.TabIndex = 1;
            tabItens.Text = "Itens";
            // 
            // gridItens
            // 
            gridItens.AllowUserToAddRows = false;
            gridItens.AllowUserToDeleteRows = false;
            gridItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridItens.BackgroundColor = Color.White;
            gridItens.BorderStyle = BorderStyle.None;
            gridItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItens.Columns.AddRange(new DataGridViewColumn[] { colItem, colNcm, colDescricao, colQuantidade, colUnidade, colMoeda, colValorUnit, colIncoterm, colValorBRL, colStatus });
            gridItens.Dock = DockStyle.Fill;
            gridItens.Location = new Point(8, 8);
            gridItens.Name = "gridItens";
            gridItens.ReadOnly = true;
            gridItens.RowHeadersVisible = false;
            gridItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItens.Size = new Size(1376, 782);
            gridItens.TabIndex = 0;
            // 
            // colItem
            // 
            colItem.FillWeight = 5F;
            colItem.HeaderText = "Item";
            colItem.Name = "colItem";
            colItem.ReadOnly = true;
            // 
            // colNcm
            // 
            colNcm.FillWeight = 10F;
            colNcm.HeaderText = "NCM";
            colNcm.Name = "colNcm";
            colNcm.ReadOnly = true;
            // 
            // colDescricao
            // 
            colDescricao.FillWeight = 30F;
            colDescricao.HeaderText = "Descrição";
            colDescricao.Name = "colDescricao";
            colDescricao.ReadOnly = true;
            // 
            // colQuantidade
            // 
            colQuantidade.FillWeight = 8F;
            colQuantidade.HeaderText = "Qtd";
            colQuantidade.Name = "colQuantidade";
            colQuantidade.ReadOnly = true;
            // 
            // colUnidade
            // 
            colUnidade.FillWeight = 8F;
            colUnidade.HeaderText = "Unid";
            colUnidade.Name = "colUnidade";
            colUnidade.ReadOnly = true;
            // 
            // colMoeda
            // 
            colMoeda.FillWeight = 7F;
            colMoeda.HeaderText = "Moeda";
            colMoeda.Name = "colMoeda";
            colMoeda.ReadOnly = true;
            // 
            // colValorUnit
            // 
            colValorUnit.FillWeight = 10F;
            colValorUnit.HeaderText = "Vlr Unit";
            colValorUnit.Name = "colValorUnit";
            colValorUnit.ReadOnly = true;
            // 
            // colIncoterm
            // 
            colIncoterm.FillWeight = 8F;
            colIncoterm.HeaderText = "Incoterm";
            colIncoterm.Name = "colIncoterm";
            colIncoterm.ReadOnly = true;
            // 
            // colValorBRL
            // 
            colValorBRL.FillWeight = 10F;
            colValorBRL.HeaderText = "Vlr BRL";
            colValorBRL.Name = "colValorBRL";
            colValorBRL.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 8F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // tabTributos
            // 
            tabTributos.Controls.Add(gridTributos);
            tabTributos.Location = new Point(4, 26);
            tabTributos.Name = "tabTributos";
            tabTributos.Padding = new Padding(8);
            tabTributos.Size = new Size(1392, 798);
            tabTributos.TabIndex = 2;
            tabTributos.Text = "Tributos";
            // 
            // gridTributos
            // 
            gridTributos.AllowUserToAddRows = false;
            gridTributos.AllowUserToDeleteRows = false;
            gridTributos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTributos.BackgroundColor = Color.White;
            gridTributos.BorderStyle = BorderStyle.None;
            gridTributos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTributos.Columns.AddRange(new DataGridViewColumn[] { colTribItemNum, colTribTipo, colTribCalculado, colTribDevido, colTribARecolher, colTribRecolhido });
            gridTributos.Dock = DockStyle.Fill;
            gridTributos.Location = new Point(8, 8);
            gridTributos.Name = "gridTributos";
            gridTributos.ReadOnly = true;
            gridTributos.RowHeadersVisible = false;
            gridTributos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridTributos.Size = new Size(1376, 782);
            gridTributos.TabIndex = 0;
            // 
            // colTribItemNum
            // 
            colTribItemNum.FillWeight = 8F;
            colTribItemNum.HeaderText = "Item Nº";
            colTribItemNum.Name = "colTribItemNum";
            colTribItemNum.ReadOnly = true;
            // 
            // colTribTipo
            // 
            colTribTipo.FillWeight = 12F;
            colTribTipo.HeaderText = "Tributo";
            colTribTipo.Name = "colTribTipo";
            colTribTipo.ReadOnly = true;
            // 
            // colTribCalculado
            // 
            colTribCalculado.FillWeight = 20F;
            colTribCalculado.HeaderText = "Calculado (R$)";
            colTribCalculado.Name = "colTribCalculado";
            colTribCalculado.ReadOnly = true;
            // 
            // colTribDevido
            // 
            colTribDevido.FillWeight = 20F;
            colTribDevido.HeaderText = "Devido (R$)";
            colTribDevido.Name = "colTribDevido";
            colTribDevido.ReadOnly = true;
            // 
            // colTribARecolher
            // 
            colTribARecolher.FillWeight = 20F;
            colTribARecolher.HeaderText = "A Recolher (R$)";
            colTribARecolher.Name = "colTribARecolher";
            colTribARecolher.ReadOnly = true;
            // 
            // colTribRecolhido
            // 
            colTribRecolhido.FillWeight = 20F;
            colTribRecolhido.HeaderText = "Recolhido (R$)";
            colTribRecolhido.Name = "colTribRecolhido";
            colTribRecolhido.ReadOnly = true;
            // 
            // tabPagamentos
            // 
            tabPagamentos.Controls.Add(gridPagamentos);
            tabPagamentos.Location = new Point(4, 26);
            tabPagamentos.Name = "tabPagamentos";
            tabPagamentos.Padding = new Padding(8);
            tabPagamentos.Size = new Size(1392, 798);
            tabPagamentos.TabIndex = 3;
            tabPagamentos.Text = "Pagamentos";
            // 
            // gridPagamentos
            // 
            gridPagamentos.AllowUserToAddRows = false;
            gridPagamentos.AllowUserToDeleteRows = false;
            gridPagamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPagamentos.BackgroundColor = Color.White;
            gridPagamentos.BorderStyle = BorderStyle.None;
            gridPagamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPagamentos.Columns.AddRange(new DataGridViewColumn[] { colPagTributo, colPagReceita, colPagValor, colPagData, colPagBanco, colPagAgencia, colPagConta });
            gridPagamentos.Dock = DockStyle.Fill;
            gridPagamentos.Location = new Point(8, 8);
            gridPagamentos.Name = "gridPagamentos";
            gridPagamentos.ReadOnly = true;
            gridPagamentos.RowHeadersVisible = false;
            gridPagamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPagamentos.Size = new Size(1376, 782);
            gridPagamentos.TabIndex = 0;
            // 
            // colPagTributo
            // 
            colPagTributo.FillWeight = 12F;
            colPagTributo.HeaderText = "Tributo";
            colPagTributo.Name = "colPagTributo";
            colPagTributo.ReadOnly = true;
            // 
            // colPagReceita
            // 
            colPagReceita.FillWeight = 12F;
            colPagReceita.HeaderText = "Cód. Receita";
            colPagReceita.Name = "colPagReceita";
            colPagReceita.ReadOnly = true;
            // 
            // colPagValor
            // 
            colPagValor.FillWeight = 15F;
            colPagValor.HeaderText = "Valor (R$)";
            colPagValor.Name = "colPagValor";
            colPagValor.ReadOnly = true;
            // 
            // colPagData
            // 
            colPagData.FillWeight = 20F;
            colPagData.HeaderText = "Data Pagamento";
            colPagData.Name = "colPagData";
            colPagData.ReadOnly = true;
            // 
            // colPagBanco
            // 
            colPagBanco.FillWeight = 10F;
            colPagBanco.HeaderText = "Banco";
            colPagBanco.Name = "colPagBanco";
            colPagBanco.ReadOnly = true;
            // 
            // colPagAgencia
            // 
            colPagAgencia.FillWeight = 10F;
            colPagAgencia.HeaderText = "Agência";
            colPagAgencia.Name = "colPagAgencia";
            colPagAgencia.ReadOnly = true;
            // 
            // colPagConta
            // 
            colPagConta.FillWeight = 10F;
            colPagConta.HeaderText = "Conta";
            colPagConta.Name = "colPagConta";
            colPagConta.ReadOnly = true;
            // 
            // FormConsultaDuimp
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 900);
            Controls.Add(tabControl);
            Controls.Add(lblStatus);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1000, 700);
            Name = "FormConsultaDuimp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta DUIMP — Portal Único";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVersao).EndInit();
            tabControl.ResumeLayout(false);
            tabCapa.ResumeLayout(false);
            grpIdentificacao.ResumeLayout(false);
            grpIdentificacao.PerformLayout();
            grpSituacao.ResumeLayout(false);
            grpSituacao.PerformLayout();
            grpCarga.ResumeLayout(false);
            grpCarga.PerformLayout();
            tabItens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridItens).EndInit();
            tabTributos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridTributos).EndInit();
            tabPagamentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridPagamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblNumeroDuimp;
        private TextBox txtNumeroDuimp;
        private CheckBox chkVersaoEspecifica;
        private Label lblVersao;
        private NumericUpDown numVersao;
        private Button btnConsultar;
        private Label lblStatus;
        private TabControl tabControl;
        private TabPage tabCapa;
        private GroupBox grpIdentificacao;
        private Label lblNumero;
        private Label lblVersaoCapa;
        private Label lblDataRegistro;
        private Label lblImportador;
        private Label lblChaveAcesso;
        private Label lblResponsavel;
        private GroupBox grpSituacao;
        private Label lblSituacaoDuimp;
        private Label lblSituacaoLicenciamento;
        private Label lblControleCarga;
        private Label lblSituacaoRetificacao;
        private GroupBox grpCarga;
        private Label lblTipoCarga;
        private Label lblCe;
        private Label lblPaisProcedencia;
        private Label lblFrete;
        private Label lblSeguro;
        private TabPage tabItens;
        private DataGridView gridItens;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colNcm;
        private DataGridViewTextBoxColumn colDescricao;
        private DataGridViewTextBoxColumn colQuantidade;
        private DataGridViewTextBoxColumn colUnidade;
        private DataGridViewTextBoxColumn colMoeda;
        private DataGridViewTextBoxColumn colValorUnit;
        private DataGridViewTextBoxColumn colIncoterm;
        private DataGridViewTextBoxColumn colValorBRL;
        private DataGridViewTextBoxColumn colStatus;
        private TabPage tabTributos;
        private DataGridView gridTributos;
        private DataGridViewTextBoxColumn colTribItemNum;
        private DataGridViewTextBoxColumn colTribTipo;
        private DataGridViewTextBoxColumn colTribCalculado;
        private DataGridViewTextBoxColumn colTribDevido;
        private DataGridViewTextBoxColumn colTribARecolher;
        private DataGridViewTextBoxColumn colTribRecolhido;
        private TabPage tabPagamentos;
        private DataGridView gridPagamentos;
        private DataGridViewTextBoxColumn colPagTributo;
        private DataGridViewTextBoxColumn colPagReceita;
        private DataGridViewTextBoxColumn colPagValor;
        private DataGridViewTextBoxColumn colPagData;
        private DataGridViewTextBoxColumn colPagBanco;
        private DataGridViewTextBoxColumn colPagAgencia;
        private DataGridViewTextBoxColumn colPagConta;
    }
}