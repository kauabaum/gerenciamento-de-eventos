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
            this.btnLocalizarOrcamento = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnPesquisarOrcamento = new System.Windows.Forms.Button();
            this.btnSairOrcamento = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtTipoOrcamento = new System.Windows.Forms.TextBox();
            this.txtTemaOrcamento = new System.Windows.Forms.TextBox();
            this.btnMostrarTodosProduto = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTipoOrcamento = new System.Windows.Forms.Label();
            this.lblTemaOrcamento = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdicionarOrcamento
            // 
            this.btnAdicionarOrcamento.AccessibleDescription = "";
            this.btnAdicionarOrcamento.AccessibleName = "";
            this.btnAdicionarOrcamento.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarOrcamento.BackgroundImage = global::Eventos.Properties.Resources.adicionarverde;
            this.btnAdicionarOrcamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarOrcamento.Location = new System.Drawing.Point(13, 11);
            this.btnAdicionarOrcamento.Name = "btnAdicionarOrcamento";
            this.btnAdicionarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnAdicionarOrcamento.TabIndex = 0;
            this.btnAdicionarOrcamento.Tag = "";
            this.toolTip1.SetToolTip(this.btnAdicionarOrcamento, "Adicionar");
            this.btnAdicionarOrcamento.UseVisualStyleBackColor = false;
            this.btnAdicionarOrcamento.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnLocalizarOrcamento
            // 
            this.btnLocalizarOrcamento.BackColor = System.Drawing.Color.Transparent;
            this.btnLocalizarOrcamento.BackgroundImage = global::Eventos.Properties.Resources.selecionarcinz;
            this.btnLocalizarOrcamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocalizarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizarOrcamento.Location = new System.Drawing.Point(102, 11);
            this.btnLocalizarOrcamento.Name = "btnLocalizarOrcamento";
            this.btnLocalizarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnLocalizarOrcamento.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnLocalizarOrcamento, "Localizar");
            this.btnLocalizarOrcamento.UseVisualStyleBackColor = false;
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
            // btnPesquisarOrcamento
            // 
            this.btnPesquisarOrcamento.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarOrcamento.BackgroundImage = global::Eventos.Properties.Resources.pesquisarcinza;
            this.btnPesquisarOrcamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPesquisarOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarOrcamento.Location = new System.Drawing.Point(191, 11);
            this.btnPesquisarOrcamento.Name = "btnPesquisarOrcamento";
            this.btnPesquisarOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnPesquisarOrcamento.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnPesquisarOrcamento, "Pesquisar");
            this.btnPesquisarOrcamento.UseVisualStyleBackColor = false;
            this.btnPesquisarOrcamento.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnSairOrcamento
            // 
            this.btnSairOrcamento.BackColor = System.Drawing.Color.Transparent;
            this.btnSairOrcamento.BackgroundImage = global::Eventos.Properties.Resources.leave;
            this.btnSairOrcamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSairOrcamento.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairOrcamento.Location = new System.Drawing.Point(369, 11);
            this.btnSairOrcamento.Name = "btnSairOrcamento";
            this.btnSairOrcamento.Size = new System.Drawing.Size(83, 78);
            this.btnSairOrcamento.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnSairOrcamento, "Sair");
            this.btnSairOrcamento.UseVisualStyleBackColor = false;
            this.btnSairOrcamento.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 158);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(793, 328);
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
            // txtTipoOrcamento
            // 
            this.txtTipoOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoOrcamento.Location = new System.Drawing.Point(539, 15);
            this.txtTipoOrcamento.Name = "txtTipoOrcamento";
            this.txtTipoOrcamento.Size = new System.Drawing.Size(268, 30);
            this.txtTipoOrcamento.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtTipoOrcamento, "Digite aqui o E-mail");
            // 
            // txtTemaOrcamento
            // 
            this.txtTemaOrcamento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemaOrcamento.Location = new System.Drawing.Point(551, 57);
            this.txtTemaOrcamento.Name = "txtTemaOrcamento";
            this.txtTemaOrcamento.Size = new System.Drawing.Size(256, 30);
            this.txtTemaOrcamento.TabIndex = 21;
            this.toolTip1.SetToolTip(this.txtTemaOrcamento, "Digite aqui o E-mail");
            // 
            // btnMostrarTodosProduto
            // 
            this.btnMostrarTodosProduto.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarTodosProduto.BackgroundImage = global::Eventos.Properties.Resources.mostrarcinza;
            this.btnMostrarTodosProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMostrarTodosProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodosProduto.Location = new System.Drawing.Point(280, 11);
            this.btnMostrarTodosProduto.Name = "btnMostrarTodosProduto";
            this.btnMostrarTodosProduto.Size = new System.Drawing.Size(83, 78);
            this.btnMostrarTodosProduto.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnMostrarTodosProduto, "Mostrar Todos");
            this.btnMostrarTodosProduto.UseVisualStyleBackColor = false;
            this.btnMostrarTodosProduto.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(108, 108);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(218, 30);
            this.txtCliente.TabIndex = 25;
            this.toolTip1.SetToolTip(this.txtCliente, "Digite aqui o E-mail");
            // 
            // lblTipoOrcamento
            // 
            this.lblTipoOrcamento.AutoSize = true;
            this.lblTipoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoOrcamento.Location = new System.Drawing.Point(467, 16);
            this.lblTipoOrcamento.Name = "lblTipoOrcamento";
            this.lblTipoOrcamento.Size = new System.Drawing.Size(66, 25);
            this.lblTipoOrcamento.TabIndex = 18;
            this.lblTipoOrcamento.Text = "Tipo :";
            // 
            // lblTemaOrcamento
            // 
            this.lblTemaOrcamento.AutoSize = true;
            this.lblTemaOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemaOrcamento.Location = new System.Drawing.Point(467, 58);
            this.lblTemaOrcamento.Name = "lblTemaOrcamento";
            this.lblTemaOrcamento.Size = new System.Drawing.Size(78, 25);
            this.lblTemaOrcamento.TabIndex = 20;
            this.lblTemaOrcamento.Text = "Tema :";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(12, 109);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(90, 25);
            this.lblCliente.TabIndex = 23;
            this.lblCliente.Text = "Cliente :";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(573, 114);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(69, 25);
            this.lblData.TabIndex = 24;
            this.lblData.Text = "Data :";
            // 
            // mskData
            // 
            this.mskData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskData.Location = new System.Drawing.Point(648, 108);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(145, 38);
            this.mskData.TabIndex = 26;
            this.mskData.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Status :";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aprovado",
            "Reprovado",
            "Aguardando",
            "Vencido",
            "Cancelado"});
            this.cmbStatus.Location = new System.Drawing.Point(422, 106);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 32);
            this.cmbStatus.TabIndex = 28;
            // 
            // frmOrcamentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(821, 497);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnMostrarTodosProduto);
            this.Controls.Add(this.txtTemaOrcamento);
            this.Controls.Add(this.lblTemaOrcamento);
            this.Controls.Add(this.txtTipoOrcamento);
            this.Controls.Add(this.lblTipoOrcamento);
            this.Controls.Add(this.btnSairOrcamento);
            this.Controls.Add(this.btnPesquisarOrcamento);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnLocalizarOrcamento);
            this.Controls.Add(this.btnAdicionarOrcamento);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOrcamentoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orçamento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionarOrcamento;
        private System.Windows.Forms.Button btnLocalizarOrcamento;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnPesquisarOrcamento;
        private System.Windows.Forms.Button btnSairOrcamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTipoOrcamento;
        private System.Windows.Forms.TextBox txtTipoOrcamento;
        private System.Windows.Forms.Label lblTemaOrcamento;
        private System.Windows.Forms.TextBox txtTemaOrcamento;
        private System.Windows.Forms.Button btnMostrarTodosProduto;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}