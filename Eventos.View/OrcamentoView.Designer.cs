namespace Eventos.View
{
    partial class frmOrcamentoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrcamentoView));
            this.btnAdicionarOrcamento = new System.Windows.Forms.Button();
            this.btnSalvarOrcamento = new System.Windows.Forms.Button();
            this.btnEditarOrcamento = new System.Windows.Forms.Button();
            this.btnLocalizarOrcamento = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnExcluirOrcamento = new System.Windows.Forms.Button();
            this.btnPesquisarOrcamento = new System.Windows.Forms.Button();
            this.btnSairOrcamento = new System.Windows.Forms.Button();
            this.btnLimparOrcamento = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMostrarTodosOrcamento = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtDescricaoOrcamento = new System.Windows.Forms.TextBox();
            this.txtTamanhoOrcamento = new System.Windows.Forms.TextBox();
            this.txtValorOrcamento = new System.Windows.Forms.TextBox();
            this.btnAdicionarCategoriaOrcamento = new System.Windows.Forms.Button();
            this.btnAdicionarCorOrcamento = new System.Windows.Forms.Button();
            this.btnAdicionarTemaOrcamento = new System.Windows.Forms.Button();
            this.txtQuantidadeOrcamento = new System.Windows.Forms.TextBox();
            this.lblTamanhoOrcamento = new System.Windows.Forms.Label();
            this.lblValorOrcamento = new System.Windows.Forms.Label();
            this.lblDescricaoOrcamento = new System.Windows.Forms.Label();
            this.lblQuantidadeOrcamento = new System.Windows.Forms.Label();
            this.lblCustoOrcamento = new System.Windows.Forms.Label();
            this.lblCategoriaOrcamento = new System.Windows.Forms.Label();
            this.lblTemaOrcamento = new System.Windows.Forms.Label();
            this.cmbTemaOrcamento = new System.Windows.Forms.ComboBox();
            this.lblCorOrcamento = new System.Windows.Forms.Label();
            this.cmbCorOrcamento = new System.Windows.Forms.ComboBox();
            this.cmbCategoriaOrcamento = new System.Windows.Forms.ComboBox();
            this.txtCustoOrcamento = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdicionarOrcamento
            // 
            this.btnAdicionarOrcamento.AccessibleDescription = "";
            this.btnAdicionarOrcamento.AccessibleName = "";
            this.btnAdicionarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarOrcamento.Image")));
            this.btnAdicionarOrcamento.Location = new System.Drawing.Point(13, 11);
            this.btnAdicionarOrcamento.Name = "btnAdicionarOrcamento";
            this.btnAdicionarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnAdicionarOrcamento.TabIndex = 0;
            this.btnAdicionarOrcamento.Tag = "";
            this.toolTip1.SetToolTip(this.btnAdicionarOrcamento, "Adicionar");
            this.btnAdicionarOrcamento.UseVisualStyleBackColor = true;
            this.btnAdicionarOrcamento.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnSalvarOrcamento
            // 
            this.btnSalvarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarOrcamento.Image")));
            this.btnSalvarOrcamento.Location = new System.Drawing.Point(369, 11);
            this.btnSalvarOrcamento.Name = "btnSalvarOrcamento";
            this.btnSalvarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnSalvarOrcamento.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnSalvarOrcamento, "Salvar");
            this.btnSalvarOrcamento.UseVisualStyleBackColor = true;
            this.btnSalvarOrcamento.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnEditarOrcamento
            // 
            this.btnEditarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarOrcamento.Image")));
            this.btnEditarOrcamento.Location = new System.Drawing.Point(280, 11);
            this.btnEditarOrcamento.Name = "btnEditarOrcamento";
            this.btnEditarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnEditarOrcamento.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnEditarOrcamento, "Editar");
            this.btnEditarOrcamento.UseVisualStyleBackColor = true;
            this.btnEditarOrcamento.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLocalizarOrcamento
            // 
            this.btnLocalizarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizarOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizarOrcamento.Image")));
            this.btnLocalizarOrcamento.Location = new System.Drawing.Point(102, 11);
            this.btnLocalizarOrcamento.Name = "btnLocalizarOrcamento";
            this.btnLocalizarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnLocalizarOrcamento.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnLocalizarOrcamento, "Localizar");
            this.btnLocalizarOrcamento.UseVisualStyleBackColor = true;
            this.btnLocalizarOrcamento.Click += new System.EventHandler(this.btnLocalizar_Click);
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
            // btnExcluirOrcamento
            // 
            this.btnExcluirOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirOrcamento.Image")));
            this.btnExcluirOrcamento.Location = new System.Drawing.Point(547, 11);
            this.btnExcluirOrcamento.Name = "btnExcluirOrcamento";
            this.btnExcluirOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnExcluirOrcamento.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnExcluirOrcamento, "Excluir");
            this.btnExcluirOrcamento.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPesquisarOrcamento
            // 
            this.btnPesquisarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarOrcamento.Image")));
            this.btnPesquisarOrcamento.Location = new System.Drawing.Point(191, 11);
            this.btnPesquisarOrcamento.Name = "btnPesquisarOrcamento";
            this.btnPesquisarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnPesquisarOrcamento.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnPesquisarOrcamento, "Pesquisar");
            this.btnPesquisarOrcamento.UseVisualStyleBackColor = true;
            this.btnPesquisarOrcamento.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnSairOrcamento
            // 
            this.btnSairOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnSairOrcamento.Image")));
            this.btnSairOrcamento.Location = new System.Drawing.Point(725, 11);
            this.btnSairOrcamento.Name = "btnSairOrcamento";
            this.btnSairOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnSairOrcamento.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnSairOrcamento, "Sair");
            this.btnSairOrcamento.UseVisualStyleBackColor = true;
            this.btnSairOrcamento.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnLimparOrcamento
            // 
            this.btnLimparOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparOrcamento.Image")));
            this.btnLimparOrcamento.Location = new System.Drawing.Point(458, 11);
            this.btnLimparOrcamento.Name = "btnLimparOrcamento";
            this.btnLimparOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnLimparOrcamento.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnLimparOrcamento, "Limpar");
            this.btnLimparOrcamento.UseVisualStyleBackColor = true;
            this.btnLimparOrcamento.Click += new System.EventHandler(this.btnLimpar_Click);
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
            // btnMostrarTodosOrcamento
            // 
            this.btnMostrarTodosOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodosOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarTodosOrcamento.Image")));
            this.btnMostrarTodosOrcamento.Location = new System.Drawing.Point(636, 11);
            this.btnMostrarTodosOrcamento.Name = "btnMostrarTodosOrcamento";
            this.btnMostrarTodosOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnMostrarTodosOrcamento.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnMostrarTodosOrcamento, "Mostrar Todos");
            this.btnMostrarTodosOrcamento.UseVisualStyleBackColor = true;
            this.btnMostrarTodosOrcamento.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // txtDescricaoOrcamento
            // 
            this.txtDescricaoOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoOrcamento.Location = new System.Drawing.Point(130, 111);
            this.txtDescricaoOrcamento.Name = "txtDescricaoOrcamento";
            this.txtDescricaoOrcamento.Size = new System.Drawing.Size(367, 30);
            this.txtDescricaoOrcamento.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtDescricaoOrcamento, "Digite aqui o E-mail");
            // 
            // txtTamanhoOrcamento
            // 
            this.txtTamanhoOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTamanhoOrcamento.Location = new System.Drawing.Point(622, 111);
            this.txtTamanhoOrcamento.Name = "txtTamanhoOrcamento";
            this.txtTamanhoOrcamento.Size = new System.Drawing.Size(185, 30);
            this.txtTamanhoOrcamento.TabIndex = 37;
            this.toolTip1.SetToolTip(this.txtTamanhoOrcamento, "Digite o Nome do Cliente");
            // 
            // txtValorOrcamento
            // 
            this.txtValorOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorOrcamento.Location = new System.Drawing.Point(583, 153);
            this.txtValorOrcamento.Name = "txtValorOrcamento";
            this.txtValorOrcamento.Size = new System.Drawing.Size(224, 30);
            this.txtValorOrcamento.TabIndex = 38;
            this.toolTip1.SetToolTip(this.txtValorOrcamento, "Digite o Nome do Cliente");
            // 
            // btnAdicionarCategoriaOrcamento
            // 
            this.btnAdicionarCategoriaOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarCategoriaOrcamento.Image")));
            this.btnAdicionarCategoriaOrcamento.Location = new System.Drawing.Point(292, 249);
            this.btnAdicionarCategoriaOrcamento.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarCategoriaOrcamento.Name = "btnAdicionarCategoriaOrcamento";
            this.btnAdicionarCategoriaOrcamento.Size = new System.Drawing.Size(49, 49);
            this.btnAdicionarCategoriaOrcamento.TabIndex = 39;
            this.toolTip1.SetToolTip(this.btnAdicionarCategoriaOrcamento, "Adicionar País");
            this.btnAdicionarCategoriaOrcamento.UseVisualStyleBackColor = true;
            this.btnAdicionarCategoriaOrcamento.Click += new System.EventHandler(this.btnAdicionarCategoriaOrcamento_Click);
            // 
            // btnAdicionarCorOrcamento
            // 
            this.btnAdicionarCorOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarCorOrcamento.Image")));
            this.btnAdicionarCorOrcamento.Location = new System.Drawing.Point(741, 249);
            this.btnAdicionarCorOrcamento.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarCorOrcamento.Name = "btnAdicionarCorOrcamento";
            this.btnAdicionarCorOrcamento.Size = new System.Drawing.Size(49, 49);
            this.btnAdicionarCorOrcamento.TabIndex = 45;
            this.toolTip1.SetToolTip(this.btnAdicionarCorOrcamento, "Adicionar País");
            this.btnAdicionarCorOrcamento.UseVisualStyleBackColor = true;
            this.btnAdicionarCorOrcamento.Click += new System.EventHandler(this.btnAdicionarCorOrcamento_Click);
            // 
            // btnAdicionarTemaOrcamento
            // 
            this.btnAdicionarTemaOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarTemaOrcamento.Image")));
            this.btnAdicionarTemaOrcamento.Location = new System.Drawing.Point(741, 195);
            this.btnAdicionarTemaOrcamento.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarTemaOrcamento.Name = "btnAdicionarTemaOrcamento";
            this.btnAdicionarTemaOrcamento.Size = new System.Drawing.Size(49, 50);
            this.btnAdicionarTemaOrcamento.TabIndex = 48;
            this.toolTip1.SetToolTip(this.btnAdicionarTemaOrcamento, "Adicionar País");
            this.btnAdicionarTemaOrcamento.UseVisualStyleBackColor = true;
            this.btnAdicionarTemaOrcamento.Click += new System.EventHandler(this.btnAdicionarTemaOrcamento_Click);
            // 
            // txtQuantidadeOrcamento
            // 
            this.txtQuantidadeOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidadeOrcamento.Location = new System.Drawing.Point(149, 152);
            this.txtQuantidadeOrcamento.Name = "txtQuantidadeOrcamento";
            this.txtQuantidadeOrcamento.Size = new System.Drawing.Size(348, 30);
            this.txtQuantidadeOrcamento.TabIndex = 25;
            // 
            // lblTamanhoOrcamento
            // 
            this.lblTamanhoOrcamento.AutoSize = true;
            this.lblTamanhoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamanhoOrcamento.Location = new System.Drawing.Point(503, 111);
            this.lblTamanhoOrcamento.Name = "lblTamanhoOrcamento";
            this.lblTamanhoOrcamento.Size = new System.Drawing.Size(113, 25);
            this.lblTamanhoOrcamento.TabIndex = 16;
            this.lblTamanhoOrcamento.Text = "Tamanho :";
            // 
            // lblValorOrcamento
            // 
            this.lblValorOrcamento.AutoSize = true;
            this.lblValorOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorOrcamento.Location = new System.Drawing.Point(503, 155);
            this.lblValorOrcamento.Name = "lblValorOrcamento";
            this.lblValorOrcamento.Size = new System.Drawing.Size(74, 25);
            this.lblValorOrcamento.TabIndex = 20;
            this.lblValorOrcamento.Text = "Valor :";
            // 
            // lblDescricaoOrcamento
            // 
            this.lblDescricaoOrcamento.AutoSize = true;
            this.lblDescricaoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoOrcamento.Location = new System.Drawing.Point(9, 111);
            this.lblDescricaoOrcamento.Name = "lblDescricaoOrcamento";
            this.lblDescricaoOrcamento.Size = new System.Drawing.Size(115, 25);
            this.lblDescricaoOrcamento.TabIndex = 18;
            this.lblDescricaoOrcamento.Text = "Descrição :";
            // 
            // lblQuantidadeOrcamento
            // 
            this.lblQuantidadeOrcamento.AutoSize = true;
            this.lblQuantidadeOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeOrcamento.Location = new System.Drawing.Point(9, 153);
            this.lblQuantidadeOrcamento.Name = "lblQuantidadeOrcamento";
            this.lblQuantidadeOrcamento.Size = new System.Drawing.Size(134, 25);
            this.lblQuantidadeOrcamento.TabIndex = 24;
            this.lblQuantidadeOrcamento.Text = "Quantidade :";
            // 
            // lblCustoOrcamento
            // 
            this.lblCustoOrcamento.AutoSize = true;
            this.lblCustoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoOrcamento.Location = new System.Drawing.Point(8, 205);
            this.lblCustoOrcamento.Name = "lblCustoOrcamento";
            this.lblCustoOrcamento.Size = new System.Drawing.Size(78, 25);
            this.lblCustoOrcamento.TabIndex = 26;
            this.lblCustoOrcamento.Text = "Custo :";
            // 
            // lblCategoriaOrcamento
            // 
            this.lblCategoriaOrcamento.AutoSize = true;
            this.lblCategoriaOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriaOrcamento.Location = new System.Drawing.Point(12, 258);
            this.lblCategoriaOrcamento.Name = "lblCategoriaOrcamento";
            this.lblCategoriaOrcamento.Size = new System.Drawing.Size(63, 25);
            this.lblCategoriaOrcamento.TabIndex = 40;
            this.lblCategoriaOrcamento.Text = "Cat. :";
            // 
            // lblTemaOrcamento
            // 
            this.lblTemaOrcamento.AutoSize = true;
            this.lblTemaOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemaOrcamento.Location = new System.Drawing.Point(296, 204);
            this.lblTemaOrcamento.Name = "lblTemaOrcamento";
            this.lblTemaOrcamento.Size = new System.Drawing.Size(78, 25);
            this.lblTemaOrcamento.TabIndex = 42;
            this.lblTemaOrcamento.Text = "Tema :";
            // 
            // cmbTemaOrcamento
            // 
            this.cmbTemaOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbTemaOrcamento.FormattingEnabled = true;
            this.cmbTemaOrcamento.Location = new System.Drawing.Point(380, 203);
            this.cmbTemaOrcamento.Name = "cmbTemaOrcamento";
            this.cmbTemaOrcamento.Size = new System.Drawing.Size(339, 31);
            this.cmbTemaOrcamento.TabIndex = 43;
            // 
            // lblCorOrcamento
            // 
            this.lblCorOrcamento.AutoSize = true;
            this.lblCorOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorOrcamento.Location = new System.Drawing.Point(364, 259);
            this.lblCorOrcamento.Name = "lblCorOrcamento";
            this.lblCorOrcamento.Size = new System.Drawing.Size(58, 25);
            this.lblCorOrcamento.TabIndex = 44;
            this.lblCorOrcamento.Text = "Cor :";
            // 
            // cmbCorOrcamento
            // 
            this.cmbCorOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbCorOrcamento.FormattingEnabled = true;
            this.cmbCorOrcamento.Location = new System.Drawing.Point(428, 258);
            this.cmbCorOrcamento.Name = "cmbCorOrcamento";
            this.cmbCorOrcamento.Size = new System.Drawing.Size(291, 31);
            this.cmbCorOrcamento.TabIndex = 46;
            // 
            // cmbCategoriaOrcamento
            // 
            this.cmbCategoriaOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbCategoriaOrcamento.FormattingEnabled = true;
            this.cmbCategoriaOrcamento.Location = new System.Drawing.Point(81, 257);
            this.cmbCategoriaOrcamento.Name = "cmbCategoriaOrcamento";
            this.cmbCategoriaOrcamento.Size = new System.Drawing.Size(193, 31);
            this.cmbCategoriaOrcamento.TabIndex = 47;
            // 
            // txtCustoOrcamento
            // 
            this.txtCustoOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustoOrcamento.Location = new System.Drawing.Point(92, 204);
            this.txtCustoOrcamento.Name = "txtCustoOrcamento";
            this.txtCustoOrcamento.Size = new System.Drawing.Size(198, 30);
            this.txtCustoOrcamento.TabIndex = 49;
            // 
            // frmOrcamentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 497);
            this.Controls.Add(this.txtCustoOrcamento);
            this.Controls.Add(this.btnAdicionarTemaOrcamento);
            this.Controls.Add(this.cmbCategoriaOrcamento);
            this.Controls.Add(this.cmbCorOrcamento);
            this.Controls.Add(this.btnAdicionarCorOrcamento);
            this.Controls.Add(this.lblCorOrcamento);
            this.Controls.Add(this.cmbTemaOrcamento);
            this.Controls.Add(this.lblTemaOrcamento);
            this.Controls.Add(this.lblCategoriaOrcamento);
            this.Controls.Add(this.btnAdicionarCategoriaOrcamento);
            this.Controls.Add(this.txtValorOrcamento);
            this.Controls.Add(this.txtTamanhoOrcamento);
            this.Controls.Add(this.lblCustoOrcamento);
            this.Controls.Add(this.txtQuantidadeOrcamento);
            this.Controls.Add(this.lblValorOrcamento);
            this.Controls.Add(this.txtDescricaoOrcamento);
            this.Controls.Add(this.lblDescricaoOrcamento);
            this.Controls.Add(this.lblTamanhoOrcamento);
            this.Controls.Add(this.btnMostrarTodosOrcamento);
            this.Controls.Add(this.btnLimparOrcamento);
            this.Controls.Add(this.btnSairOrcamento);
            this.Controls.Add(this.btnPesquisarOrcamento);
            this.Controls.Add(this.btnExcluirOrcamento);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnLocalizarOrcamento);
            this.Controls.Add(this.btnEditarOrcamento);
            this.Controls.Add(this.btnSalvarOrcamento);
            this.Controls.Add(this.btnAdicionarOrcamento);
            this.Controls.Add(this.lblQuantidadeOrcamento);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmOrcamentoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionarOrcamento;
        private System.Windows.Forms.Button btnSalvarOrcamento;
        private System.Windows.Forms.Button btnEditarOrcamento;
        private System.Windows.Forms.Button btnLocalizarOrcamento;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnExcluirOrcamento;
        private System.Windows.Forms.Button btnPesquisarOrcamento;
        private System.Windows.Forms.Button btnSairOrcamento;
        private System.Windows.Forms.Button btnLimparOrcamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnMostrarTodosOrcamento;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTamanhoOrcamento;
        private System.Windows.Forms.Label lblValorOrcamento;
        private System.Windows.Forms.TextBox txtDescricaoOrcamento;
        private System.Windows.Forms.Label lblDescricaoOrcamento;
        private System.Windows.Forms.Label lblQuantidadeOrcamento;
        private System.Windows.Forms.TextBox txtQuantidadeOrcamento;
        private System.Windows.Forms.Label lblCustoOrcamento;
        private System.Windows.Forms.TextBox txtTamanhoOrcamento;
        private System.Windows.Forms.TextBox txtValorOrcamento;
        private System.Windows.Forms.Button btnAdicionarCategoriaOrcamento;
        private System.Windows.Forms.Label lblCategoriaOrcamento;
        private System.Windows.Forms.Label lblTemaOrcamento;
        private System.Windows.Forms.ComboBox cmbTemaOrcamento;
        private System.Windows.Forms.Label lblCorOrcamento;
        private System.Windows.Forms.Button btnAdicionarCorOrcamento;
        private System.Windows.Forms.ComboBox cmbCorOrcamento;
        private System.Windows.Forms.ComboBox cmbCategoriaOrcamento;
        private System.Windows.Forms.Button btnAdicionarTemaOrcamento;
        private System.Windows.Forms.TextBox txtCustoOrcamento;
    }
}