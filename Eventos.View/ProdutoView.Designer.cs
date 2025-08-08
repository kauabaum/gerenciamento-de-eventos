namespace Eventos.View
{
    partial class frmProdutoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutoView));
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnLocalizarProduto = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnExcluirProduto = new System.Windows.Forms.Button();
            this.btnPesquisarProduto = new System.Windows.Forms.Button();
            this.btnSairProduto = new System.Windows.Forms.Button();
            this.btnLimparProduto = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMostrarTodosProduto = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.txtTamanhoProduto = new System.Windows.Forms.TextBox();
            this.txtValorProduto = new System.Windows.Forms.TextBox();
            this.btnAdicionarCategoriaProduto = new System.Windows.Forms.Button();
            this.btnAdicionarCorProduto = new System.Windows.Forms.Button();
            this.btnAdicionarTemaProduto = new System.Windows.Forms.Button();
            this.txtQuantidadeProduto = new System.Windows.Forms.TextBox();
            this.lblTamanhoProduto = new System.Windows.Forms.Label();
            this.lblValorProduto = new System.Windows.Forms.Label();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.lblQuantidadeProduto = new System.Windows.Forms.Label();
            this.lblCustoProduto = new System.Windows.Forms.Label();
            this.lblCategoriaProduto = new System.Windows.Forms.Label();
            this.lblTemaProduto = new System.Windows.Forms.Label();
            this.cmbTemaProduto = new System.Windows.Forms.ComboBox();
            this.lblCorProduto = new System.Windows.Forms.Label();
            this.cmbCorProduto = new System.Windows.Forms.ComboBox();
            this.cmbCategoriaProduto = new System.Windows.Forms.ComboBox();
            this.txtCustoProduto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.AccessibleDescription = "";
            this.btnAdicionarProduto.AccessibleName = "";
            this.btnAdicionarProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarProduto.Image")));
            this.btnAdicionarProduto.Location = new System.Drawing.Point(13, 11);
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
            this.btnSalvarProduto.Location = new System.Drawing.Point(369, 11);
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
            this.btnEditarProduto.Location = new System.Drawing.Point(280, 11);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(83, 78);
            this.btnEditarProduto.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnEditarProduto, "Editar");
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLocalizarProduto
            // 
            this.btnLocalizarProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizarProduto.Image")));
            this.btnLocalizarProduto.Location = new System.Drawing.Point(102, 11);
            this.btnLocalizarProduto.Name = "btnLocalizarProduto";
            this.btnLocalizarProduto.Size = new System.Drawing.Size(83, 78);
            this.btnLocalizarProduto.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnLocalizarProduto, "Localizar");
            this.btnLocalizarProduto.UseVisualStyleBackColor = true;
            this.btnLocalizarProduto.Click += new System.EventHandler(this.btnLocalizar_Click);
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
            this.btnExcluirProduto.Location = new System.Drawing.Point(547, 11);
            this.btnExcluirProduto.Name = "btnExcluirProduto";
            this.btnExcluirProduto.Size = new System.Drawing.Size(83, 78);
            this.btnExcluirProduto.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnExcluirProduto, "Excluir");
            this.btnExcluirProduto.UseVisualStyleBackColor = true;
            this.btnExcluirProduto.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarProduto.Image")));
            this.btnPesquisarProduto.Location = new System.Drawing.Point(191, 11);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(83, 78);
            this.btnPesquisarProduto.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnPesquisarProduto, "Pesquisar");
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            this.btnPesquisarProduto.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnSairProduto
            // 
            this.btnSairProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnSairProduto.Image")));
            this.btnSairProduto.Location = new System.Drawing.Point(725, 11);
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
            this.btnLimparProduto.Location = new System.Drawing.Point(458, 11);
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
            // btnMostrarTodosProduto
            // 
            this.btnMostrarTodosProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodosProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarTodosProduto.Image")));
            this.btnMostrarTodosProduto.Location = new System.Drawing.Point(636, 11);
            this.btnMostrarTodosProduto.Name = "btnMostrarTodosProduto";
            this.btnMostrarTodosProduto.Size = new System.Drawing.Size(83, 78);
            this.btnMostrarTodosProduto.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnMostrarTodosProduto, "Mostrar Todos");
            this.btnMostrarTodosProduto.UseVisualStyleBackColor = true;
            this.btnMostrarTodosProduto.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoProduto.Location = new System.Drawing.Point(130, 111);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(367, 30);
            this.txtDescricaoProduto.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtDescricaoProduto, "Digite aqui o E-mail");
            // 
            // txtTamanhoProduto
            // 
            this.txtTamanhoProduto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTamanhoProduto.Location = new System.Drawing.Point(622, 111);
            this.txtTamanhoProduto.Name = "txtTamanhoProduto";
            this.txtTamanhoProduto.Size = new System.Drawing.Size(185, 30);
            this.txtTamanhoProduto.TabIndex = 37;
            this.toolTip1.SetToolTip(this.txtTamanhoProduto, "Digite o Nome do Cliente");
            // 
            // txtValorProduto
            // 
            this.txtValorProduto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorProduto.Location = new System.Drawing.Point(583, 153);
            this.txtValorProduto.Name = "txtValorProduto";
            this.txtValorProduto.Size = new System.Drawing.Size(224, 30);
            this.txtValorProduto.TabIndex = 38;
            this.toolTip1.SetToolTip(this.txtValorProduto, "Digite o Nome do Cliente");
            // 
            // btnAdicionarCategoriaProduto
            // 
            this.btnAdicionarCategoriaProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarCategoriaProduto.Image")));
            this.btnAdicionarCategoriaProduto.Location = new System.Drawing.Point(292, 249);
            this.btnAdicionarCategoriaProduto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarCategoriaProduto.Name = "btnAdicionarCategoriaProduto";
            this.btnAdicionarCategoriaProduto.Size = new System.Drawing.Size(49, 49);
            this.btnAdicionarCategoriaProduto.TabIndex = 39;
            this.toolTip1.SetToolTip(this.btnAdicionarCategoriaProduto, "Adicionar País");
            this.btnAdicionarCategoriaProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarCategoriaProduto.Click += new System.EventHandler(this.btnAdicionarCategoriaProduto_Click);
            // 
            // btnAdicionarCorProduto
            // 
            this.btnAdicionarCorProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarCorProduto.Image")));
            this.btnAdicionarCorProduto.Location = new System.Drawing.Point(741, 249);
            this.btnAdicionarCorProduto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarCorProduto.Name = "btnAdicionarCorProduto";
            this.btnAdicionarCorProduto.Size = new System.Drawing.Size(49, 49);
            this.btnAdicionarCorProduto.TabIndex = 45;
            this.toolTip1.SetToolTip(this.btnAdicionarCorProduto, "Adicionar País");
            this.btnAdicionarCorProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarCorProduto.Click += new System.EventHandler(this.btnAdicionarCorProduto_Click);
            // 
            // btnAdicionarTemaProduto
            // 
            this.btnAdicionarTemaProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarTemaProduto.Image")));
            this.btnAdicionarTemaProduto.Location = new System.Drawing.Point(741, 195);
            this.btnAdicionarTemaProduto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarTemaProduto.Name = "btnAdicionarTemaProduto";
            this.btnAdicionarTemaProduto.Size = new System.Drawing.Size(49, 50);
            this.btnAdicionarTemaProduto.TabIndex = 48;
            this.toolTip1.SetToolTip(this.btnAdicionarTemaProduto, "Adicionar País");
            this.btnAdicionarTemaProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarTemaProduto.Click += new System.EventHandler(this.btnAdicionarTemaProduto_Click);
            // 
            // txtQuantidadeProduto
            // 
            this.txtQuantidadeProduto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidadeProduto.Location = new System.Drawing.Point(149, 152);
            this.txtQuantidadeProduto.Name = "txtQuantidadeProduto";
            this.txtQuantidadeProduto.Size = new System.Drawing.Size(348, 30);
            this.txtQuantidadeProduto.TabIndex = 25;
            // 
            // lblTamanhoProduto
            // 
            this.lblTamanhoProduto.AutoSize = true;
            this.lblTamanhoProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamanhoProduto.Location = new System.Drawing.Point(503, 111);
            this.lblTamanhoProduto.Name = "lblTamanhoProduto";
            this.lblTamanhoProduto.Size = new System.Drawing.Size(113, 25);
            this.lblTamanhoProduto.TabIndex = 16;
            this.lblTamanhoProduto.Text = "Tamanho :";
            // 
            // lblValorProduto
            // 
            this.lblValorProduto.AutoSize = true;
            this.lblValorProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorProduto.Location = new System.Drawing.Point(503, 155);
            this.lblValorProduto.Name = "lblValorProduto";
            this.lblValorProduto.Size = new System.Drawing.Size(74, 25);
            this.lblValorProduto.TabIndex = 20;
            this.lblValorProduto.Text = "Valor :";
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoProduto.Location = new System.Drawing.Point(9, 111);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(115, 25);
            this.lblDescricaoProduto.TabIndex = 18;
            this.lblDescricaoProduto.Text = "Descrição :";
            // 
            // lblQuantidadeProduto
            // 
            this.lblQuantidadeProduto.AutoSize = true;
            this.lblQuantidadeProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeProduto.Location = new System.Drawing.Point(9, 153);
            this.lblQuantidadeProduto.Name = "lblQuantidadeProduto";
            this.lblQuantidadeProduto.Size = new System.Drawing.Size(134, 25);
            this.lblQuantidadeProduto.TabIndex = 24;
            this.lblQuantidadeProduto.Text = "Quantidade :";
            // 
            // lblCustoProduto
            // 
            this.lblCustoProduto.AutoSize = true;
            this.lblCustoProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoProduto.Location = new System.Drawing.Point(8, 205);
            this.lblCustoProduto.Name = "lblCustoProduto";
            this.lblCustoProduto.Size = new System.Drawing.Size(78, 25);
            this.lblCustoProduto.TabIndex = 26;
            this.lblCustoProduto.Text = "Custo :";
            // 
            // lblCategoriaProduto
            // 
            this.lblCategoriaProduto.AutoSize = true;
            this.lblCategoriaProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriaProduto.Location = new System.Drawing.Point(12, 258);
            this.lblCategoriaProduto.Name = "lblCategoriaProduto";
            this.lblCategoriaProduto.Size = new System.Drawing.Size(63, 25);
            this.lblCategoriaProduto.TabIndex = 40;
            this.lblCategoriaProduto.Text = "Cat. :";
            // 
            // lblTemaProduto
            // 
            this.lblTemaProduto.AutoSize = true;
            this.lblTemaProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemaProduto.Location = new System.Drawing.Point(296, 204);
            this.lblTemaProduto.Name = "lblTemaProduto";
            this.lblTemaProduto.Size = new System.Drawing.Size(78, 25);
            this.lblTemaProduto.TabIndex = 42;
            this.lblTemaProduto.Text = "Tema :";
            // 
            // cmbTemaProduto
            // 
            this.cmbTemaProduto.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbTemaProduto.FormattingEnabled = true;
            this.cmbTemaProduto.Location = new System.Drawing.Point(380, 203);
            this.cmbTemaProduto.Name = "cmbTemaProduto";
            this.cmbTemaProduto.Size = new System.Drawing.Size(339, 31);
            this.cmbTemaProduto.TabIndex = 43;
            // 
            // lblCorProduto
            // 
            this.lblCorProduto.AutoSize = true;
            this.lblCorProduto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorProduto.Location = new System.Drawing.Point(364, 259);
            this.lblCorProduto.Name = "lblCorProduto";
            this.lblCorProduto.Size = new System.Drawing.Size(58, 25);
            this.lblCorProduto.TabIndex = 44;
            this.lblCorProduto.Text = "Cor :";
            // 
            // cmbCorProduto
            // 
            this.cmbCorProduto.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbCorProduto.FormattingEnabled = true;
            this.cmbCorProduto.Location = new System.Drawing.Point(428, 258);
            this.cmbCorProduto.Name = "cmbCorProduto";
            this.cmbCorProduto.Size = new System.Drawing.Size(291, 31);
            this.cmbCorProduto.TabIndex = 46;
            // 
            // cmbCategoriaProduto
            // 
            this.cmbCategoriaProduto.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbCategoriaProduto.FormattingEnabled = true;
            this.cmbCategoriaProduto.Location = new System.Drawing.Point(81, 257);
            this.cmbCategoriaProduto.Name = "cmbCategoriaProduto";
            this.cmbCategoriaProduto.Size = new System.Drawing.Size(193, 31);
            this.cmbCategoriaProduto.TabIndex = 47;
            // 
            // txtCustoProduto
            // 
            this.txtCustoProduto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustoProduto.Location = new System.Drawing.Point(92, 204);
            this.txtCustoProduto.Name = "txtCustoProduto";
            this.txtCustoProduto.Size = new System.Drawing.Size(198, 30);
            this.txtCustoProduto.TabIndex = 49;
            // 
            // frmProdutoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 497);
            this.Controls.Add(this.txtCustoProduto);
            this.Controls.Add(this.btnAdicionarTemaProduto);
            this.Controls.Add(this.cmbCategoriaProduto);
            this.Controls.Add(this.cmbCorProduto);
            this.Controls.Add(this.btnAdicionarCorProduto);
            this.Controls.Add(this.lblCorProduto);
            this.Controls.Add(this.cmbTemaProduto);
            this.Controls.Add(this.lblTemaProduto);
            this.Controls.Add(this.lblCategoriaProduto);
            this.Controls.Add(this.btnAdicionarCategoriaProduto);
            this.Controls.Add(this.txtValorProduto);
            this.Controls.Add(this.txtTamanhoProduto);
            this.Controls.Add(this.lblCustoProduto);
            this.Controls.Add(this.txtQuantidadeProduto);
            this.Controls.Add(this.lblValorProduto);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.lblDescricaoProduto);
            this.Controls.Add(this.lblTamanhoProduto);
            this.Controls.Add(this.btnMostrarTodosProduto);
            this.Controls.Add(this.btnLimparProduto);
            this.Controls.Add(this.btnSairProduto);
            this.Controls.Add(this.btnPesquisarProduto);
            this.Controls.Add(this.btnExcluirProduto);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnLocalizarProduto);
            this.Controls.Add(this.btnEditarProduto);
            this.Controls.Add(this.btnSalvarProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.lblQuantidadeProduto);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmProdutoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnLocalizarProduto;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnExcluirProduto;
        private System.Windows.Forms.Button btnPesquisarProduto;
        private System.Windows.Forms.Button btnSairProduto;
        private System.Windows.Forms.Button btnLimparProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnMostrarTodosProduto;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTamanhoProduto;
        private System.Windows.Forms.Label lblValorProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.Label lblQuantidadeProduto;
        private System.Windows.Forms.TextBox txtQuantidadeProduto;
        private System.Windows.Forms.Label lblCustoProduto;
        private System.Windows.Forms.TextBox txtTamanhoProduto;
        private System.Windows.Forms.TextBox txtValorProduto;
        private System.Windows.Forms.Button btnAdicionarCategoriaProduto;
        private System.Windows.Forms.Label lblCategoriaProduto;
        private System.Windows.Forms.Label lblTemaProduto;
        private System.Windows.Forms.ComboBox cmbTemaProduto;
        private System.Windows.Forms.Label lblCorProduto;
        private System.Windows.Forms.Button btnAdicionarCorProduto;
        private System.Windows.Forms.ComboBox cmbCorProduto;
        private System.Windows.Forms.ComboBox cmbCategoriaProduto;
        private System.Windows.Forms.Button btnAdicionarTemaProduto;
        private System.Windows.Forms.TextBox txtCustoProduto;
    }
}