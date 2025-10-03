namespace Eventos.View
{
    partial class frmAdicionarAgendamentoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdicionarAgendamentoView));
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnSairProduto = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtLocalEvento = new System.Windows.Forms.TextBox();
            this.txtTipoEvento = new System.Windows.Forms.TextBox();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTipoOrcamento = new System.Windows.Forms.Label();
            this.lblDataEmissaoOrcamento = new System.Windows.Forms.Label();
            this.lblClienteOrcamento = new System.Windows.Forms.Label();
            this.lblTotalOrcamento = new System.Windows.Forms.Label();
            this.mskDataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.lblLocalOrcamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mskDataEvento = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskHoraEvento = new System.Windows.Forms.MaskedTextBox();
            this.lblTemaOrcamento = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbParcelas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarProduto.Image")));
            this.btnSalvarProduto.Location = new System.Drawing.Point(17, 12);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(83, 78);
            this.btnSalvarProduto.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnSalvarProduto, "Salvar");
            this.btnSalvarProduto.UseVisualStyleBackColor = true;
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
            // btnSairProduto
            // 
            this.btnSairProduto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnSairProduto.Image")));
            this.btnSairProduto.Location = new System.Drawing.Point(489, 12);
            this.btnSairProduto.Name = "btnSairProduto";
            this.btnSairProduto.Size = new System.Drawing.Size(83, 78);
            this.btnSairProduto.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnSairProduto, "Sair");
            this.btnSairProduto.UseVisualStyleBackColor = true;
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
            // txtLocalEvento
            // 
            this.txtLocalEvento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalEvento.Location = new System.Drawing.Point(80, 208);
            this.txtLocalEvento.Name = "txtLocalEvento";
            this.txtLocalEvento.Size = new System.Drawing.Size(504, 30);
            this.txtLocalEvento.TabIndex = 56;
            this.toolTip1.SetToolTip(this.txtLocalEvento, "Digite aqui o E-mail");
            // 
            // txtTipoEvento
            // 
            this.txtTipoEvento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoEvento.Location = new System.Drawing.Point(92, 297);
            this.txtTipoEvento.Name = "txtTipoEvento";
            this.txtTipoEvento.Size = new System.Drawing.Size(173, 30);
            this.txtTipoEvento.TabIndex = 65;
            this.toolTip1.SetToolTip(this.txtTipoEvento, "Digite aqui o E-mail");
            // 
            // txtTema
            // 
            this.txtTema.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTema.Location = new System.Drawing.Point(92, 256);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(206, 30);
            this.txtTema.TabIndex = 69;
            this.toolTip1.SetToolTip(this.txtTema, "Digite aqui o E-mail");
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(92, 469);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(492, 30);
            this.txtTotal.TabIndex = 75;
            this.toolTip1.SetToolTip(this.txtTotal, "Digite aqui o E-mail");
            // 
            // lblTipoOrcamento
            // 
            this.lblTipoOrcamento.AutoSize = true;
            this.lblTipoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoOrcamento.Location = new System.Drawing.Point(12, 298);
            this.lblTipoOrcamento.Name = "lblTipoOrcamento";
            this.lblTipoOrcamento.Size = new System.Drawing.Size(66, 25);
            this.lblTipoOrcamento.TabIndex = 16;
            this.lblTipoOrcamento.Text = "Tipo :";
            // 
            // lblDataEmissaoOrcamento
            // 
            this.lblDataEmissaoOrcamento.AutoSize = true;
            this.lblDataEmissaoOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEmissaoOrcamento.Location = new System.Drawing.Point(12, 162);
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
            this.lblClienteOrcamento.Size = new System.Drawing.Size(90, 25);
            this.lblClienteOrcamento.TabIndex = 18;
            this.lblClienteOrcamento.Text = "Cliente :";
            // 
            // lblTotalOrcamento
            // 
            this.lblTotalOrcamento.AutoSize = true;
            this.lblTotalOrcamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrcamento.Location = new System.Drawing.Point(14, 470);
            this.lblTotalOrcamento.Name = "lblTotalOrcamento";
            this.lblTotalOrcamento.Size = new System.Drawing.Size(72, 25);
            this.lblTotalOrcamento.TabIndex = 24;
            this.lblTotalOrcamento.Text = "Total :";
            // 
            // mskDataEmissao
            // 
            this.mskDataEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataEmissao.Location = new System.Drawing.Point(160, 160);
            this.mskDataEmissao.Mask = "00/00/0000";
            this.mskDataEmissao.Name = "mskDataEmissao";
            this.mskDataEmissao.Size = new System.Drawing.Size(128, 31);
            this.mskDataEmissao.TabIndex = 53;
            this.mskDataEmissao.ValidatingType = typeof(System.DateTime);
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
            this.label1.Location = new System.Drawing.Point(294, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 57;
            this.label1.Text = "Data Evento :";
            // 
            // mskDataEvento
            // 
            this.mskDataEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataEvento.Location = new System.Drawing.Point(435, 160);
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
            this.label2.Location = new System.Drawing.Point(313, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 59;
            this.label2.Text = "Hora Evento :";
            // 
            // mskHoraEvento
            // 
            this.mskHoraEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskHoraEvento.Location = new System.Drawing.Point(461, 255);
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
            // cmbCliente
            // 
            this.cmbCliente.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(105, 110);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(467, 31);
            this.cmbCliente.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 25);
            this.label4.TabIndex = 71;
            this.label4.Text = "Forma de Pagamento :";
            // 
            // cmbTipos
            // 
            this.cmbTipos.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbTipos.FormattingEnabled = true;
            this.cmbTipos.Items.AddRange(new object[] {
            "Pix",
            "Cartão de Debito",
            "Cartão de Crédito",
            "Boleto",
            "Transferência Bancária",
            "Crediário"});
            this.cmbTipos.Location = new System.Drawing.Point(247, 354);
            this.cmbTipos.Name = "cmbTipos";
            this.cmbTipos.Size = new System.Drawing.Size(325, 31);
            this.cmbTipos.TabIndex = 72;
            this.cmbTipos.SelectedIndexChanged += new System.EventHandler(this.cmbTipos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 73;
            this.label3.Text = "Parcelamento :";
            // 
            // cmbParcelas
            // 
            this.cmbParcelas.AutoCompleteCustomSource.AddRange(new string[] {
            "1x",
            "2x",
            "3x",
            "4x",
            "5x",
            "6x",
            "7x",
            "8x",
            "9x",
            "10x ",
            "11x",
            "12x",
            "13x",
            "14x",
            "15x",
            "16x",
            "17x",
            "18x",
            "19x",
            "20x",
            "21x",
            "22x",
            "23x",
            "24x",
            "25x"});
            this.cmbParcelas.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cmbParcelas.FormattingEnabled = true;
            this.cmbParcelas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbParcelas.Location = new System.Drawing.Point(171, 405);
            this.cmbParcelas.Name = "cmbParcelas";
            this.cmbParcelas.Size = new System.Drawing.Size(153, 31);
            this.cmbParcelas.TabIndex = 74;
            this.cmbParcelas.SelectedIndexChanged += new System.EventHandler(this.cmbParcelas_SelectedIndexChanged);
            // 
            // frmAdicionarAgendamentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 503);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.cmbParcelas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.txtTipoEvento);
            this.Controls.Add(this.lblTemaOrcamento);
            this.Controls.Add(this.mskHoraEvento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDataEvento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalEvento);
            this.Controls.Add(this.lblLocalOrcamento);
            this.Controls.Add(this.mskDataEmissao);
            this.Controls.Add(this.lblDataEmissaoOrcamento);
            this.Controls.Add(this.lblClienteOrcamento);
            this.Controls.Add(this.lblTipoOrcamento);
            this.Controls.Add(this.btnSairProduto);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnSalvarProduto);
            this.Controls.Add(this.lblTotalOrcamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmAdicionarAgendamentoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Agendamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnSairProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTipoOrcamento;
        private System.Windows.Forms.Label lblDataEmissaoOrcamento;
        private System.Windows.Forms.Label lblClienteOrcamento;
        private System.Windows.Forms.Label lblTotalOrcamento;
        private System.Windows.Forms.MaskedTextBox mskDataEmissao;
        private System.Windows.Forms.Label lblLocalOrcamento;
        private System.Windows.Forms.TextBox txtLocalEvento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskDataEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskHoraEvento;
        private System.Windows.Forms.Label lblTemaOrcamento;
        private System.Windows.Forms.TextBox txtTipoEvento;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbParcelas;
        private System.Windows.Forms.TextBox txtTotal;
    }
}