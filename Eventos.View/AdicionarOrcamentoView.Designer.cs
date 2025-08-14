namespace Eventos.View
{
    partial class frmAdicionarOrcamentoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdicionarOrcamentoView));
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnExcluirProduto = new System.Windows.Forms.Button();
            this.btnSairProduto = new System.Windows.Forms.Button();
            this.btnLimparProduto = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtLocalEvento = new System.Windows.Forms.TextBox();
            this.txtTipoOrcamento = new System.Windows.Forms.TextBox();
            this.txtValidadeOrcamento = new System.Windows.Forms.TextBox();
            this.btnAdicionarTemaOrcamento = new System.Windows.Forms.Button();
            this.btnAdicionarProdutoOrcamento = new System.Windows.Forms.Button();
            this.lblTipoOrcamento = new System.Windows.Forms.Label();
            this.lblDataEmissaoOrcamento = new System.Windows.Forms.Label();
            this.lblClienteOrcamento = new System.Windows.Forms.Label();
            this.lblTotalOrcamento = new System.Windows.Forms.Label();
            this.lblStatusOrcamento = new System.Windows.Forms.Label();
            this.mskTotalOrcamento = new System.Windows.Forms.MaskedTextBox();
            this.mskDataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.cmbStatusOrcamento = new System.Windows.Forms.ComboBox();
            this.lblLocalOrcamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mskDataEvento = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskHoraEvento = new System.Windows.Forms.MaskedTextBox();
            this.lblTemaOrcamento = new System.Windows.Forms.Label();
            this.cmbTemaEvento = new System.Windows.Forms.ComboBox();
            this.lblValidadeOrcamento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.AccessibleDescription = "";
            this.btnAdicionarProduto.AccessibleName = "";
            this.btnAdicionarProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarProduto.Image")));
            this.btnAdicionarProduto.Location = new System.Drawing.Point(8, 8);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(83, 78);
            this.btnAdicionarProduto.TabIndex = 0;
            this.btnAdicionarProduto.Tag = "";
            this.toolTip1.SetToolTip(this.btnAdicionarProduto, "Adicionar");
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarProduto.Image")));
            this.btnSalvarProduto.Location = new System.Drawing.Point(366, 9);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(83, 78);
            this.btnSalvarProduto.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnSalvarProduto, "Salvar");
            this.btnSalvarProduto.UseVisualStyleBackColor = true;
            this.btnSalvarProduto.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarProduto.Image")));
            this.btnEditarProduto.Location = new System.Drawing.Point(249, 9);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(83, 78);
            this.btnEditarProduto.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnEditarProduto, "Editar");
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.Location = new System.Drawing.Point(314, 326);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(0, 23);
            this.lblMensagem.TabIndex = 6;
            // 
            // btnExcluirProduto
            // 
            this.btnExcluirProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirProduto.Image")));
            this.btnExcluirProduto.Location = new System.Drawing.Point(608, 9);
            this.btnExcluirProduto.Name = "btnExcluirProduto";
            this.btnExcluirProduto.Size = new System.Drawing.Size(83, 78);
            this.btnExcluirProduto.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnExcluirProduto, "Excluir");
            this.btnExcluirProduto.UseVisualStyleBackColor = true;
            this.btnExcluirProduto.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSairProduto
            // 
            this.btnSairProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnSairProduto.Image")));
            this.btnSairProduto.Location = new System.Drawing.Point(724, 9);
            this.btnSairProduto.Name = "btnSairProduto";
            this.btnSairProduto.Size = new System.Drawing.Size(83, 78);
            this.btnSairProduto.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnSairProduto, "Sair");
            this.btnSairProduto.UseVisualStyleBackColor = true;
            this.btnSairProduto.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnLimparProduto
            // 
            this.btnLimparProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparProduto.Image")));
            this.btnLimparProduto.Location = new System.Drawing.Point(485, 9);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(83, 78);
            this.btnLimparProduto.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnLimparProduto, "Limpar");
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 302);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(793, 184);
            this.dataGridView1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Target";
            this.dataGridViewTextBoxColumn1.HeaderText = "Target";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCliente.Location = new System.Drawing.Point(96, 112);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(367, 30);
            this.txtNomeCliente.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtNomeCliente, "Digite aqui o E-mail");
            // 
            // txtLocalEvento
            // 
            this.txtLocalEvento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalEvento.Location = new System.Drawing.Point(80, 208);
            this.txtLocalEvento.Name = "txtLocalEvento";
            this.txtLocalEvento.Size = new System.Drawing.Size(504, 30);
            this.txtLocalEvento.TabIndex = 56;
            this.toolTip1.SetToolTip(this.txtLocalEvento, "Digite aqui o E-mail");
            // 
            // txtTipoOrcamento
            // 
            this.txtTipoOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoOrcamento.Location = new System.Drawing.Point(552, 112);
            this.txtTipoOrcamento.Name = "txtTipoOrcamento";
            this.txtTipoOrcamento.Size = new System.Drawing.Size(248, 30);
            this.txtTipoOrcamento.TabIndex = 65;
            this.toolTip1.SetToolTip(this.txtTipoOrcamento, "Digite aqui o E-mail");
            // 
            // txtValidadeOrcamento
            // 
            this.txtValidadeOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidadeOrcamento.Location = new System.Drawing.Point(416, 256);
            this.txtValidadeOrcamento.Name = "txtValidadeOrcamento";
            this.txtValidadeOrcamento.Size = new System.Drawing.Size(88, 30);
            this.txtValidadeOrcamento.TabIndex = 66;
            this.toolTip1.SetToolTip(this.txtValidadeOrcamento, "Digite aqui o E-mail");
            // 
            // btnAdicionarTemaOrcamento
            // 
            this.btnAdicionarTemaOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarTemaOrcamento.Image")));
            this.btnAdicionarTemaOrcamento.Location = new System.Drawing.Point(240, 248);
            this.btnAdicionarTemaOrcamento.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarTemaOrcamento.Name = "btnAdicionarTemaOrcamento";
            this.btnAdicionarTemaOrcamento.Size = new System.Drawing.Size(49, 50);
            this.btnAdicionarTemaOrcamento.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btnAdicionarTemaOrcamento, "Adicionar País");
            this.btnAdicionarTemaOrcamento.UseVisualStyleBackColor = true;
            this.btnAdicionarTemaOrcamento.Click += new System.EventHandler(this.btnAdicionarTemaOrcamento_Click);
            // 
            // btnAdicionarProdutoOrcamento
            // 
            this.btnAdicionarProdutoOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarProdutoOrcamento.Image")));
            this.btnAdicionarProdutoOrcamento.Location = new System.Drawing.Point(127, 9);
            this.btnAdicionarProdutoOrcamento.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarProdutoOrcamento.Name = "btnAdicionarProdutoOrcamento";
            this.btnAdicionarProdutoOrcamento.Size = new System.Drawing.Size(83, 77);
            this.btnAdicionarProdutoOrcamento.TabIndex = 68;
            this.toolTip1.SetToolTip(this.btnAdicionarProdutoOrcamento, "Adicionar Produto");
            this.btnAdicionarProdutoOrcamento.UseVisualStyleBackColor = true;
            this.btnAdicionarProdutoOrcamento.Click += new System.EventHandler(this.btnAdicionarProdutoOrcamento_Click);
            // 
            // lblTipoOrcamento
            // 
            this.lblTipoOrcamento.AutoSize = true;
            this.lblTipoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoOrcamento.Location = new System.Drawing.Point(480, 112);
            this.lblTipoOrcamento.Name = "lblTipoOrcamento";
            this.lblTipoOrcamento.Size = new System.Drawing.Size(66, 25);
            this.lblTipoOrcamento.TabIndex = 16;
            this.lblTipoOrcamento.Text = "Tipo :";
            // 
            // lblDataEmissaoOrcamento
            // 
            this.lblDataEmissaoOrcamento.AutoSize = true;
            this.lblDataEmissaoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEmissaoOrcamento.Location = new System.Drawing.Point(216, 160);
            this.lblDataEmissaoOrcamento.Name = "lblDataEmissaoOrcamento";
            this.lblDataEmissaoOrcamento.Size = new System.Drawing.Size(151, 25);
            this.lblDataEmissaoOrcamento.TabIndex = 20;
            this.lblDataEmissaoOrcamento.Text = "Data Emissão :";
            // 
            // lblClienteOrcamento
            // 
            this.lblClienteOrcamento.AutoSize = true;
            this.lblClienteOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteOrcamento.Location = new System.Drawing.Point(9, 111);
            this.lblClienteOrcamento.Name = "lblClienteOrcamento";
            this.lblClienteOrcamento.Size = new System.Drawing.Size(80, 25);
            this.lblClienteOrcamento.TabIndex = 18;
            this.lblClienteOrcamento.Text = "Nome :";
            // 
            // lblTotalOrcamento
            // 
            this.lblTotalOrcamento.AutoSize = true;
            this.lblTotalOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrcamento.Location = new System.Drawing.Point(8, 160);
            this.lblTotalOrcamento.Name = "lblTotalOrcamento";
            this.lblTotalOrcamento.Size = new System.Drawing.Size(72, 25);
            this.lblTotalOrcamento.TabIndex = 24;
            this.lblTotalOrcamento.Text = "Total :";
            // 
            // lblStatusOrcamento
            // 
            this.lblStatusOrcamento.AutoSize = true;
            this.lblStatusOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusOrcamento.Location = new System.Drawing.Point(512, 256);
            this.lblStatusOrcamento.Name = "lblStatusOrcamento";
            this.lblStatusOrcamento.Size = new System.Drawing.Size(84, 25);
            this.lblStatusOrcamento.TabIndex = 26;
            this.lblStatusOrcamento.Text = "Status :";
            // 
            // mskTotalOrcamento
            // 
            this.mskTotalOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskTotalOrcamento.Location = new System.Drawing.Point(80, 160);
            this.mskTotalOrcamento.Mask = "0000000";
            this.mskTotalOrcamento.Name = "mskTotalOrcamento";
            this.mskTotalOrcamento.Size = new System.Drawing.Size(130, 31);
            this.mskTotalOrcamento.TabIndex = 52;
            // 
            // mskDataEmissao
            // 
            this.mskDataEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataEmissao.Location = new System.Drawing.Point(376, 160);
            this.mskDataEmissao.Mask = "00/00/0000";
            this.mskDataEmissao.Name = "mskDataEmissao";
            this.mskDataEmissao.Size = new System.Drawing.Size(128, 31);
            this.mskDataEmissao.TabIndex = 53;
            this.mskDataEmissao.ValidatingType = typeof(System.DateTime);
            // 
            // cmbStatusOrcamento
            // 
            this.cmbStatusOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbStatusOrcamento.FormattingEnabled = true;
            this.cmbStatusOrcamento.Items.AddRange(new object[] {
            "Aguardando",
            "Aprovado",
            "Reprovado",
            "Vencido",
            "Cancelado"});
            this.cmbStatusOrcamento.Location = new System.Drawing.Point(608, 256);
            this.cmbStatusOrcamento.Name = "cmbStatusOrcamento";
            this.cmbStatusOrcamento.Size = new System.Drawing.Size(192, 31);
            this.cmbStatusOrcamento.TabIndex = 54;
            // 
            // lblLocalOrcamento
            // 
            this.lblLocalOrcamento.AutoSize = true;
            this.lblLocalOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalOrcamento.Location = new System.Drawing.Point(8, 208);
            this.lblLocalOrcamento.Name = "lblLocalOrcamento";
            this.lblLocalOrcamento.Size = new System.Drawing.Size(73, 25);
            this.lblLocalOrcamento.TabIndex = 55;
            this.lblLocalOrcamento.Text = "Local :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(512, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 57;
            this.label1.Text = "Data Evento :";
            // 
            // mskDataEvento
            // 
            this.mskDataEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataEvento.Location = new System.Drawing.Point(656, 160);
            this.mskDataEvento.Mask = "00/00/0000";
            this.mskDataEvento.Name = "mskDataEvento";
            this.mskDataEvento.Size = new System.Drawing.Size(144, 31);
            this.mskDataEvento.TabIndex = 58;
            this.mskDataEvento.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(592, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 59;
            this.label2.Text = "Hora Evento :";
            // 
            // mskHoraEvento
            // 
            this.mskHoraEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskHoraEvento.Location = new System.Drawing.Point(736, 208);
            this.mskHoraEvento.Mask = "90:00";
            this.mskHoraEvento.Name = "mskHoraEvento";
            this.mskHoraEvento.Size = new System.Drawing.Size(64, 31);
            this.mskHoraEvento.TabIndex = 60;
            // 
            // lblTemaOrcamento
            // 
            this.lblTemaOrcamento.AutoSize = true;
            this.lblTemaOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemaOrcamento.Location = new System.Drawing.Point(8, 256);
            this.lblTemaOrcamento.Name = "lblTemaOrcamento";
            this.lblTemaOrcamento.Size = new System.Drawing.Size(78, 25);
            this.lblTemaOrcamento.TabIndex = 61;
            this.lblTemaOrcamento.Text = "Tema :";
            // 
            // cmbTemaEvento
            // 
            this.cmbTemaEvento.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbTemaEvento.FormattingEnabled = true;
            this.cmbTemaEvento.Location = new System.Drawing.Point(88, 256);
            this.cmbTemaEvento.Name = "cmbTemaEvento";
            this.cmbTemaEvento.Size = new System.Drawing.Size(136, 31);
            this.cmbTemaEvento.TabIndex = 62;
            // 
            // lblValidadeOrcamento
            // 
            this.lblValidadeOrcamento.AutoSize = true;
            this.lblValidadeOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidadeOrcamento.Location = new System.Drawing.Point(304, 256);
            this.lblValidadeOrcamento.Name = "lblValidadeOrcamento";
            this.lblValidadeOrcamento.Size = new System.Drawing.Size(106, 25);
            this.lblValidadeOrcamento.TabIndex = 63;
            this.lblValidadeOrcamento.Text = "Validade :";
            // 
            // frmAdicionarOrcamentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 497);
            this.Controls.Add(this.btnAdicionarProdutoOrcamento);
            this.Controls.Add(this.btnAdicionarTemaOrcamento);
            this.Controls.Add(this.txtValidadeOrcamento);
            this.Controls.Add(this.txtTipoOrcamento);
            this.Controls.Add(this.lblValidadeOrcamento);
            this.Controls.Add(this.cmbTemaEvento);
            this.Controls.Add(this.lblTemaOrcamento);
            this.Controls.Add(this.mskHoraEvento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDataEvento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalEvento);
            this.Controls.Add(this.lblLocalOrcamento);
            this.Controls.Add(this.cmbStatusOrcamento);
            this.Controls.Add(this.mskDataEmissao);
            this.Controls.Add(this.mskTotalOrcamento);
            this.Controls.Add(this.lblStatusOrcamento);
            this.Controls.Add(this.lblDataEmissaoOrcamento);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.lblClienteOrcamento);
            this.Controls.Add(this.lblTipoOrcamento);
            this.Controls.Add(this.btnLimparProduto);
            this.Controls.Add(this.btnSairProduto);
            this.Controls.Add(this.btnExcluirProduto);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnEditarProduto);
            this.Controls.Add(this.btnSalvarProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.lblTotalOrcamento);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmAdicionarOrcamentoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Orçamento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnExcluirProduto;
        private System.Windows.Forms.Button btnSairProduto;
        private System.Windows.Forms.Button btnLimparProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTipoOrcamento;
        private System.Windows.Forms.Label lblDataEmissaoOrcamento;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label lblClienteOrcamento;
        private System.Windows.Forms.Label lblTotalOrcamento;
        private System.Windows.Forms.Label lblStatusOrcamento;
        private System.Windows.Forms.MaskedTextBox mskTotalOrcamento;
        private System.Windows.Forms.MaskedTextBox mskDataEmissao;
        private System.Windows.Forms.ComboBox cmbStatusOrcamento;
        private System.Windows.Forms.Label lblLocalOrcamento;
        private System.Windows.Forms.TextBox txtLocalEvento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskDataEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskHoraEvento;
        private System.Windows.Forms.Label lblTemaOrcamento;
        private System.Windows.Forms.ComboBox cmbTemaEvento;
        private System.Windows.Forms.Label lblValidadeOrcamento;
        private System.Windows.Forms.TextBox txtTipoOrcamento;
        private System.Windows.Forms.TextBox txtValidadeOrcamento;
        private System.Windows.Forms.Button btnAdicionarTemaOrcamento;
        private System.Windows.Forms.Button btnAdicionarProdutoOrcamento;
    }
}