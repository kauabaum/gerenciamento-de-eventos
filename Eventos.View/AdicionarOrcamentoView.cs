using Eventos.Control;
using Eventos.DAO;
using Eventos.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eventos.Model.Orcamento;

namespace Eventos.View
{
    public partial class frmAdicionarOrcamentoView : Form
    {
        String mensagem = "";

        public frmAdicionarOrcamentoView()
        {

            InitializeComponent();
            CarregarDados();
            txtNomeCliente.Enabled = false;
            txtTipoOrcamento.Enabled = false;
            mskTotalOrcamento.Enabled = false;
            mskDataEmissao.Enabled = false;
            mskDataEvento.Enabled = false;
            txtLocalEvento.Enabled = false;
            mskHoraEvento.Enabled = false;
            cmbTemaEvento.Enabled = false;
            txtValidadeOrcamento.Enabled = false;
            cmbStatusOrcamento.Enabled = false;
            txtNomeCliente.ResetText();
            txtTipoOrcamento.ResetText();
            mskTotalOrcamento.ResetText();
            mskDataEmissao.ResetText();
            mskDataEvento.ResetText();
            txtLocalEvento.ResetText();
            mskHoraEvento.ResetText();
            cmbTemaEvento.ResetText();
            txtValidadeOrcamento.ResetText();
            cmbStatusOrcamento.ResetText();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtNomeCliente.Enabled = true;
            txtTipoOrcamento.Enabled = true;
            mskTotalOrcamento.Enabled = true;
            mskDataEmissao.Enabled = true;
            mskDataEvento.Enabled = true;
            txtLocalEvento.Enabled = true;
            mskHoraEvento.Enabled = true;
            cmbTemaEvento.Enabled = true;
            txtValidadeOrcamento.Enabled = true;
            cmbStatusOrcamento.Enabled = true;
            txtNomeCliente.ResetText();
            txtTipoOrcamento.ResetText();
            mskTotalOrcamento.ResetText();
            mskDataEmissao.ResetText();
            mskDataEvento.ResetText();
            txtLocalEvento.ResetText();
            mskHoraEvento.ResetText();
            cmbTemaEvento.ResetText();
            txtValidadeOrcamento.ResetText();
            cmbStatusOrcamento.ResetText();
            CarregarTema();
            CarregarDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }



        private int? orcamentoIdSelecionado = null;

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obter o ID do cliente selecionado no DataGridView
                    orcamentoIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Orcamento"].Value);
                }
                else
                {
                    MessageBox.Show("Selecione um orcamento para editar.");
                }

                if (orcamentoIdSelecionado.HasValue)
                {
                    // Excluir o Cliente
                    Orcamento orcamentoAtualizado = new Orcamento()
                    {
                        IdOrcamento = orcamentoIdSelecionado.Value,
                    };

                    orcamentoDAO.Delete(orcamentoAtualizado);
                    MessageBox.Show("Orcamento Excluído com sucesso!");

                    // Limpar o TextBox
                    txtNomeCliente.Text = string.Empty;
                    txtTipoOrcamento.Text = string.Empty;
                    mskTotalOrcamento.Text = string.Empty;
                    mskDataEmissao.Text = string.Empty;
                    mskDataEvento.Text = string.Empty;
                    txtLocalEvento.Text = string.Empty;
                    mskHoraEvento.Text = string.Empty;
                    cmbTemaEvento.Text = string.Empty;
                    txtValidadeOrcamento.Text = string.Empty;
                    cmbStatusOrcamento.Text = string.Empty;
                    txtNomeCliente.Enabled = false;
                    txtTipoOrcamento.Enabled = false;
                    mskTotalOrcamento.Enabled = false;
                    mskDataEmissao.Enabled = false;
                    mskDataEvento.Enabled = false;
                    txtLocalEvento.Enabled = false;
                    mskHoraEvento.Enabled = false;
                    cmbTemaEvento.Enabled = false;
                    txtValidadeOrcamento.Enabled = false;
                    cmbStatusOrcamento.Enabled = false;
                    txtNomeCliente.ResetText();
                    txtTipoOrcamento.ResetText();
                    mskTotalOrcamento.ResetText();
                    mskDataEmissao.ResetText();
                    mskDataEvento.ResetText();
                    txtLocalEvento.ResetText();
                    mskHoraEvento.ResetText();
                    cmbTemaEvento.ResetText();
                    txtValidadeOrcamento.ResetText();
                    cmbStatusOrcamento.ResetText();


                    // Recarregar os dados no DataGridView após salvar
                    CarregarDados();
                    CarregarTema();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Excluir cliente: {ex.Message}");
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar o TextBox
            txtNomeCliente.Enabled = false;
            txtTipoOrcamento.Enabled = false;
            mskTotalOrcamento.Enabled = false;
            mskDataEmissao.Enabled = false;
            mskDataEvento.Enabled = false;
            txtLocalEvento.Enabled = false;
            mskHoraEvento.Enabled = false;
            cmbTemaEvento.Enabled = false;
            txtValidadeOrcamento.Enabled = false;
            cmbStatusOrcamento.Enabled = false;
            txtNomeCliente.ResetText();
            txtTipoOrcamento.ResetText();
            mskTotalOrcamento.ResetText();
            mskDataEmissao.ResetText();
            mskDataEvento.ResetText();
            txtLocalEvento.ResetText();
            mskHoraEvento.ResetText();
            cmbTemaEvento.ResetText();
            txtValidadeOrcamento.ResetText();
            cmbStatusOrcamento.ResetText();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Carrega dados no GRID
        private OrcamentoDAO orcamentoDAO = new OrcamentoDAO();
        private void CarregarDados()
        {
            try
            {
                DataTable dataTable = orcamentoDAO.GetAll();
                dataGridView1.DataSource = dataTable;

                // Colore as linhas de acordo com o status
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Aprovacao"].Value != null)
                    {
                        string status = row.Cells["Aprovacao"].Value.ToString();

                        switch (status)
                        {
                            case "Aprovado":
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                                row.ReadOnly = true; // trava edição
                                break;

                            case "Reprovado":
                                row.DefaultCellStyle.BackColor = Color.LightCoral;
                                break;

                            case "Cancelado":
                                row.DefaultCellStyle.BackColor = Color.LightGray;
                                break;

                            case "Vencido":
                                row.DefaultCellStyle.BackColor = Color.LightGray;
                                break;

                            default:
                                // Aguardando = mantém cor padrão
                                break;
                        }

                        row.Selected = false;
                    }
                }

                // Evitar múltiplos binds no SelectionChanged
                dataGridView1.SelectionChanged -= DataGridView1_SelectionChanged;
                dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells["Aprovacao"].Value != null &&
                    row.Cells["Aprovacao"].Value.ToString() == "Aprovado")
                {
                    row.Selected = false; // remove a seleção na hora
                }
            }
        }
        private void AbrirAgendamento() { }
        private void SalvarOrcamento()
        {
            try
            {
                // 1️⃣ Captura valores dos campos
                string nome = txtNomeCliente.Text.Trim();
                string tipo = txtTipoOrcamento.Text.Trim();
                string totalStr = mskTotalOrcamento.Text.Trim();
                string dataEmissaoStr = mskDataEmissao.Text.Trim();
                string dataEventoStr = mskDataEvento.Text.Trim();
                string local = txtLocalEvento.Text.Trim();
                string hora = mskHoraEvento.Text.Trim();
                string tema = cmbTemaEvento.Text.Trim();
                string validade = txtValidadeOrcamento.Text.Trim();
                string statusStr = cmbStatusOrcamento.Text.Trim();

                // 2️⃣ Validações básicas
                if (string.IsNullOrEmpty(nome)) { MessageBox.Show("O Nome é obrigatório."); return; }
                if (string.IsNullOrEmpty(tipo)) { MessageBox.Show("O Tipo é obrigatório."); return; }
                if (string.IsNullOrEmpty(totalStr)) { MessageBox.Show("O Total é obrigatório."); return; }
                if (string.IsNullOrEmpty(dataEmissaoStr)) { MessageBox.Show("A Data de Emissão é obrigatória."); return; }
                if (string.IsNullOrEmpty(local)) { MessageBox.Show("O Local do Evento é obrigatório."); return; }
                if (string.IsNullOrEmpty(hora)) { MessageBox.Show("A Hora do Evento é obrigatória."); return; }
                if (string.IsNullOrEmpty(tema)) { MessageBox.Show("O Tema é obrigatório."); return; }
                if (string.IsNullOrEmpty(validade)) { MessageBox.Show("A Validade é obrigatória."); return; }
                if (string.IsNullOrEmpty(statusStr)) { MessageBox.Show("O Status é obrigatório."); return; }

                // 3️⃣ Cria o objeto Orcamento
                Orcamento orcamento = new Orcamento()
                {
                    NomeCliente = nome,
                    TipoEvento = tipo,
                    Total = Convert.ToDouble(totalStr),
                    DataEmissao = Convert.ToDateTime(dataEmissaoStr),
                    DataEvento = Convert.ToDateTime(dataEventoStr),
                    HoraEvento = hora,
                    LocalEvento = local,
                    Tema = tema,
                    Validade = validade,
                    Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), statusStr.Trim(), true)
                };

                if (orcamentoIdSelecionado.HasValue)
                {
                    orcamentoDAO.Update(orcamento);
                    MessageBox.Show("Orçamento atualizado com sucesso!");
                }
                else
                {
                    orcamentoDAO.Add(orcamento);
                    MessageBox.Show("Orçamento salvo com sucesso!");
                }

                // 6️⃣ Limpar e desabilitar campos
                txtNomeCliente.Clear();
                txtTipoOrcamento.Clear();
                mskTotalOrcamento.Clear();
                mskDataEmissao.Clear();
                mskDataEvento.Clear();
                txtLocalEvento.Clear();
                mskHoraEvento.Clear();
                cmbTemaEvento.SelectedIndex = -1;
                txtValidadeOrcamento.Clear();

                txtNomeCliente.Enabled = false;
                txtTipoOrcamento.Enabled = false;
                mskTotalOrcamento.Enabled = false;
                mskDataEmissao.Enabled = false;
                mskDataEvento.Enabled = false;
                txtLocalEvento.Enabled = false;
                mskHoraEvento.Enabled = false;
                cmbTemaEvento.Enabled = false;
                txtValidadeOrcamento.Enabled = false;
                cmbStatusOrcamento.Enabled = false;

                // 7️⃣ Recarrega dados e temas
                CarregarDados();
                CarregarTema();

                // 8️⃣ Reseta ID selecionado
                orcamentoIdSelecionado = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}");
            }
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obter o ID do cliente selecionado no DataGridView
                orcamentoIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Orcamento"].Value);

                // Obter a descrição do cliente e carregar no TextBox
                string nome = dataGridView1.SelectedRows[0].Cells["Nome_Cliente"].Value.ToString();
                string tipo = dataGridView1.SelectedRows[0].Cells["Tipo_Evento"].Value.ToString();
                string total = dataGridView1.SelectedRows[0].Cells["Total"].Value.ToString();
                string data_emissao = dataGridView1.SelectedRows[0].Cells["Data_Emissao"].Value.ToString();
                string data_evento = dataGridView1.SelectedRows[0].Cells["Data_Evento"].Value.ToString();
                string local = dataGridView1.SelectedRows[0].Cells["Local_Evento"].Value.ToString();
                string hora = dataGridView1.SelectedRows[0].Cells["Hora_Evento"].Value.ToString();
                string tema = dataGridView1.SelectedRows[0].Cells["Tema"].Value.ToString();
                string validade = dataGridView1.SelectedRows[0].Cells["Validade"].Value.ToString();
                string status = dataGridView1.SelectedRows[0].Cells["Aprovacao"].Value.ToString();

                txtNomeCliente.Text = nome;
                txtTipoOrcamento.Text = tipo;
                mskTotalOrcamento.Text = total;
                mskDataEmissao.Text = data_emissao;
                mskDataEvento.Text = data_evento;
                txtLocalEvento.Text = local;
                mskHoraEvento.Text = hora;
                cmbTemaEvento.Text = tema;
                txtValidadeOrcamento.Text = validade;
                cmbStatusOrcamento.Text = status;

                txtNomeCliente.Enabled = true;
                txtTipoOrcamento.Enabled = true;
                mskTotalOrcamento.Enabled = true;
                mskDataEmissao.Enabled = true;
                mskDataEvento.Enabled = true;
                txtLocalEvento.Enabled = true;
                mskHoraEvento.Enabled = true;
                cmbTemaEvento.Enabled = true;
                txtValidadeOrcamento.Enabled = true;
                cmbStatusOrcamento.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecione um orcamento para editar.");
            }
        }

        private void btnAdicionarTemaOrcamento_Click(object sender, EventArgs e)
        {
            frmTemaView add = new frmTemaView();
            add.ShowDialog();
        }

        private TemaDAO temaDAO = new TemaDAO();
        private void CarregarTema()
        {
            try
            {
                // Obtém os dados do banco de dados usando o EstadoDAO
                DataTable dataTable = temaDAO.GetAll();

                // Verifica se as colunas necessárias estão presentes
                if (dataTable.Columns.Contains("Tema") && dataTable.Columns.Contains("Id"))
                {
                    cmbTemaEvento.DataSource = dataTable;
                    cmbTemaEvento.DisplayMember = "Tema";
                    cmbTemaEvento.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("Não Localizado!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private void btnAdicionarProdutoOrcamento_Click(object sender, EventArgs e)
        {
            frmItensOrcamentoView add = new frmItensOrcamentoView();
            add.ShowDialog();
        }
    }
    }