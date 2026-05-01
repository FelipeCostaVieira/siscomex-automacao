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
            btnConsultar = new Button();
            numVersao = new NumericUpDown();
            lblVersao = new Label();
            txtNumeroDuimp = new TextBox();
            lblNumeroDuimp = new Label();
            lblStatus = new Label();
            grpDadosGerais = new GroupBox();
            lblResultNumeroDuimp = new Label();
            lblResultSituacao = new Label();
            lblResultDataRegistro = new Label();
            lblResultImportador = new Label();
            grpItens = new GroupBox();
            gridItens = new DataGridView();
            colItem = new DataGridViewTextBoxColumn();
            colDescricao = new DataGridViewTextBoxColumn();
            colNcm = new DataGridViewTextBoxColumn();
            colQuantidade = new DataGridViewTextBoxColumn();
            colValorUnit = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVersao).BeginInit();
            grpDadosGerais.SuspendLayout();
            grpItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridItens).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnConsultar);
            panel1.Controls.Add(numVersao);
            panel1.Controls.Add(lblVersao);
            panel1.Controls.Add(txtNumeroDuimp);
            panel1.Controls.Add(lblNumeroDuimp);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 55);
            panel1.TabIndex = 0;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(435, 13);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(100, 28);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += BtnConsultar_Click;
            // 
            // numVersao
            // 
            numVersao.Location = new Point(365, 15);
            numVersao.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numVersao.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numVersao.Name = "numVersao";
            numVersao.Size = new Size(55, 24);
            numVersao.TabIndex = 1;
            numVersao.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numVersao.KeyDown += numVersao_KeyDown;
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Location = new Point(315, 18);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(51, 17);
            lblVersao.TabIndex = 3;
            lblVersao.Text = "Versão:";
            // 
            // txtNumeroDuimp
            // 
            txtNumeroDuimp.CharacterCasing = CharacterCasing.Upper;
            txtNumeroDuimp.Location = new Point(120, 15);
            txtNumeroDuimp.Name = "txtNumeroDuimp";
            txtNumeroDuimp.PlaceholderText = "Ex: 24BR00001001899";
            txtNumeroDuimp.Size = new Size(180, 24);
            txtNumeroDuimp.TabIndex = 0;
            txtNumeroDuimp.KeyDown += txtNumeroDuimp_KeyDown;
            // 
            // lblNumeroDuimp
            // 
            lblNumeroDuimp.AutoSize = true;
            lblNumeroDuimp.Location = new Point(12, 18);
            lblNumeroDuimp.Name = "lblNumeroDuimp";
            lblNumeroDuimp.Size = new Size(103, 17);
            lblNumeroDuimp.TabIndex = 4;
            lblNumeroDuimp.Text = "Número DUIMP:";
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Top;
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(0, 55);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(8, 4, 0, 0);
            lblStatus.Size = new Size(884, 24);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Informe o número da DUIMP e clique em Consultar.";
            // 
            // grpDadosGerais
            // 
            grpDadosGerais.Controls.Add(lblResultNumeroDuimp);
            grpDadosGerais.Controls.Add(lblResultSituacao);
            grpDadosGerais.Controls.Add(lblResultDataRegistro);
            grpDadosGerais.Controls.Add(lblResultImportador);
            grpDadosGerais.Dock = DockStyle.Top;
            grpDadosGerais.Location = new Point(0, 79);
            grpDadosGerais.Name = "grpDadosGerais";
            grpDadosGerais.Padding = new Padding(12);
            grpDadosGerais.Size = new Size(884, 120);
            grpDadosGerais.TabIndex = 2;
            grpDadosGerais.TabStop = false;
            grpDadosGerais.Text = "Dados Gerais";
            grpDadosGerais.Visible = false;
            // 
            // lblResultNumeroDuimp
            // 
            lblResultNumeroDuimp.AutoSize = true;
            lblResultNumeroDuimp.Location = new Point(15, 25);
            lblResultNumeroDuimp.Name = "lblResultNumeroDuimp";
            lblResultNumeroDuimp.Size = new Size(59, 17);
            lblResultNumeroDuimp.TabIndex = 0;
            lblResultNumeroDuimp.Text = "Número:";
            // 
            // lblResultSituacao
            // 
            lblResultSituacao.AutoSize = true;
            lblResultSituacao.Location = new Point(15, 48);
            lblResultSituacao.Name = "lblResultSituacao";
            lblResultSituacao.Size = new Size(60, 17);
            lblResultSituacao.TabIndex = 1;
            lblResultSituacao.Text = "Situação:";
            // 
            // lblResultDataRegistro
            // 
            lblResultDataRegistro.AutoSize = true;
            lblResultDataRegistro.Location = new Point(15, 71);
            lblResultDataRegistro.Name = "lblResultDataRegistro";
            lblResultDataRegistro.Size = new Size(91, 17);
            lblResultDataRegistro.TabIndex = 2;
            lblResultDataRegistro.Text = "Data Registro:";
            // 
            // lblResultImportador
            // 
            lblResultImportador.AutoSize = true;
            lblResultImportador.Location = new Point(15, 94);
            lblResultImportador.Name = "lblResultImportador";
            lblResultImportador.Size = new Size(78, 17);
            lblResultImportador.TabIndex = 3;
            lblResultImportador.Text = "Importador:";
            // 
            // grpItens
            // 
            grpItens.Controls.Add(gridItens);
            grpItens.Dock = DockStyle.Fill;
            grpItens.Location = new Point(0, 199);
            grpItens.Name = "grpItens";
            grpItens.Padding = new Padding(8);
            grpItens.Size = new Size(884, 412);
            grpItens.TabIndex = 3;
            grpItens.TabStop = false;
            grpItens.Text = "Itens";
            // 
            // gridItens
            // 
            gridItens.AllowUserToAddRows = false;
            gridItens.AllowUserToDeleteRows = false;
            gridItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridItens.BackgroundColor = Color.White;
            gridItens.BorderStyle = BorderStyle.None;
            gridItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItens.Columns.AddRange(new DataGridViewColumn[] { colItem, colDescricao, colNcm, colQuantidade, colValorUnit });
            gridItens.Dock = DockStyle.Fill;
            gridItens.Location = new Point(8, 25);
            gridItens.Name = "gridItens";
            gridItens.ReadOnly = true;
            gridItens.RowHeadersVisible = false;
            gridItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItens.Size = new Size(868, 379);
            gridItens.TabIndex = 0;
            // 
            // colItem
            // 
            colItem.FillWeight = 5F;
            colItem.HeaderText = "Item";
            colItem.Name = "colItem";
            colItem.ReadOnly = true;
            // 
            // colDescricao
            // 
            colDescricao.FillWeight = 50F;
            colDescricao.HeaderText = "Descrição";
            colDescricao.Name = "colDescricao";
            colDescricao.ReadOnly = true;
            // 
            // colNcm
            // 
            colNcm.FillWeight = 15F;
            colNcm.HeaderText = "NCM";
            colNcm.Name = "colNcm";
            colNcm.ReadOnly = true;
            // 
            // colQuantidade
            // 
            colQuantidade.FillWeight = 15F;
            colQuantidade.HeaderText = "Quantidade";
            colQuantidade.Name = "colQuantidade";
            colQuantidade.ReadOnly = true;
            // 
            // colValorUnit
            // 
            colValorUnit.FillWeight = 15F;
            colValorUnit.HeaderText = "Vlr. Unit.";
            colValorUnit.Name = "colValorUnit";
            colValorUnit.ReadOnly = true;
            // 
            // FormConsultaDuimp
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 611);
            Controls.Add(grpItens);
            Controls.Add(grpDadosGerais);
            Controls.Add(lblStatus);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(800, 550);
            Name = "FormConsultaDuimp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta DUIMP — Portal Único";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVersao).EndInit();
            grpDadosGerais.ResumeLayout(false);
            grpDadosGerais.PerformLayout();
            grpItens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridItens).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblNumeroDuimp;
        private TextBox txtNumeroDuimp;
        private Label lblVersao;
        private NumericUpDown numVersao;
        private Button btnConsultar;
        private Label lblStatus;
        private GroupBox grpDadosGerais;
        private Label lblResultNumeroDuimp;
        private Label lblResultSituacao;
        private Label lblResultDataRegistro;
        private Label lblResultImportador;
        private GroupBox grpItens;
        private DataGridView gridItens;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colDescricao;
        private DataGridViewTextBoxColumn colNcm;
        private DataGridViewTextBoxColumn colQuantidade;
        private DataGridViewTextBoxColumn colValorUnit;
    }
}