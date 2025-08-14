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

            CarregarDados();
            CarregarTema();
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
            try
            {
                string nome = txtNomeCliente.Text;
                string tipo = txtTipoOrcamento.Text;
                string total = mskTotalOrcamento.Text;
                string data_emissao = mskDataEvento.Text;
                string data_evento = mskDataEvento.Text;
                string local = txtLocalEvento.Text;
                string hora = mskHoraEvento.Text;
                string tema = cmbTemaEvento.Text;
                string validade = txtValidadeOrcamento.Text;
                string status = cmbStatusOrcamento.Text;

                if (string.IsNullOrEmpty(nome))
                {
                    MessageBox.Show("O Nome é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(tipo))
                {
                    MessageBox.Show("O Tipo é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(total))
                {
                    MessageBox.Show("O Total é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(data_emissao))
                {
                    MessageBox.Show("A Data de Emissão é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(local))
                {
                    MessageBox.Show("O Local do Evento é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(hora))
                {
                    MessageBox.Show("A Hora do Evento é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(tema))
                {
                    MessageBox.Show("O Tema é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(validade))
                {
                    MessageBox.Show("A Validade é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("O Status é obrigatório.");
                    return;
                }

                if (orcamentoIdSelecionado.HasValue)
                {
                    // Atualizar o cliente existente
                    Orcamento orcamentoAtualizado = new Orcamento()
                    {
                        IdOrcamento = orcamentoIdSelecionado.Value,
                        NomeCliente = nome,
                        Total = Convert.ToDouble(total),
                        TipoEvento = tipo,
                        DataEmissao = Convert.ToDateTime(data_emissao),
                        DataEvento = Convert.ToDateTime(data_evento),
                        HoraEvento = hora,
                        LocalEvento = local,
                        Tema = tema,
                        Validade = validade,
                        Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), status)
                    };

                    orcamentoDAO.Update(orcamentoAtualizado);
                    MessageBox.Show("Orcamento atualizado com sucesso!");
                }
                else
                {
                    // Adicionar novo cliente
                    Orcamento novoOrcamento = new Orcamento()
                    {
                        NomeCliente = nome,
                        TipoEvento = tipo,
                        Total = Convert.ToDouble(total),
                        DataEmissao = Convert.ToDateTime(data_emissao),
                        DataEvento = Convert.ToDateTime(data_evento),
                        HoraEvento = hora,
                        LocalEvento = local,
                        Tema = tema,
                        Validade = validade,
                        Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), status)
                    };

                    orcamentoDAO.Add(novoOrcamento);
                    MessageBox.Show("Orcamento salvo com sucesso!");
                }

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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}");
            }
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

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
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