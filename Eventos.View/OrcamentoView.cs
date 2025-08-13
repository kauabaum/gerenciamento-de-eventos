using Eventos.Control;
using Eventos.DAO;
using Eventos.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eventos.Model.Orcamento;

namespace Eventos.View
{
    public partial class frmOrcamentoView : Form
    {
        String mensagem = "";

        public frmOrcamentoView()
        {
            InitializeComponent();
            txtTipoOrcamento.Enabled = false;
            txtTemaOrcamento.Enabled = false;
            txtCliente.Enabled = false;
            mskData.Enabled = false;
            cmbStatus.Enabled = false;
            cmbStatus.ResetText();
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
            CarregarDados();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAdicionarOrcamentoView add = new frmAdicionarOrcamentoView();
            add.ShowDialog();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtTipoOrcamento.Enabled = true;
            txtTemaOrcamento.Enabled = true;
            txtCliente.Enabled = true;
            mskData.Enabled = true;
            cmbStatus.Enabled = true;
            cmbStatus.ResetText();
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
            txtTemaOrcamento.ResetText();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo_evento = txtTipoOrcamento.Text;
                string tema_evento = txtTemaOrcamento.Text;
                string data_evento = mskData.Text;
                string status = cmbStatus.Text;
                string nome_cliente = txtCliente.Text;

                if (string.IsNullOrEmpty(tipo_evento) && string.IsNullOrEmpty(tema_evento) && string.IsNullOrEmpty(data_evento))
                {
                    MessageBox.Show("Preencha pelo menos um campo para pesquisar.");
                    return;
                }

                if (!string.IsNullOrEmpty(tipo_evento))
                {
                    var orcamento = orcamentoDAO.GetByOrcamento(tipo_evento);
                    if (orcamento != null)
                    {
                        DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTable(tipo_evento);
                        dataGridView1.DataSource = dataTable;
                        txtTipoOrcamento.Enabled = false;
                        txtTemaOrcamento.Enabled = false;
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
                        txtTemaOrcamento.ResetText();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Orçamento não encontrado.");
                    }
                }
                if (!string.IsNullOrEmpty(nome_cliente))
                {
                    var orcamentocliente = orcamentoDAO.GetByOrcamentoCliente(nome_cliente);
                    if (orcamentocliente != null)
                    {
                        DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableCliente(nome_cliente);
                        dataGridView1.DataSource = dataTable;
                        txtTipoOrcamento.Enabled = false;
                        txtTemaOrcamento.Enabled = false;
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
                        txtTemaOrcamento.ResetText();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Orçamento não encontrado.");
                    }
                }

                if (!string.IsNullOrEmpty(status))
                {
                    var orcamentostatus = orcamentoDAO.GetByOrcamentoStatus(status);
                    if (orcamentostatus != null)
                    {
                        DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableStatus(status);
                        dataGridView1.DataSource = dataTable;
                        txtTipoOrcamento.Enabled = false;
                        txtTemaOrcamento.Enabled = false;
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
                        txtTemaOrcamento.ResetText();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Orçamento não encontrado.");
                    }
                }


                if (!string.IsNullOrEmpty(tema_evento))
                {
                    var orcamentotema = orcamentoDAO.GetByOrcamentoTema(tema_evento);
                    if (orcamentotema != null)
                    {
                        DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableTema(tema_evento);
                        dataGridView1.DataSource = dataTable;
                        txtTipoOrcamento.Enabled = false;
                        txtTemaOrcamento.Enabled = false;
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
                        txtTemaOrcamento.ResetText();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Orçamento não encontrado.");
                    }
                }
                if (!string.IsNullOrEmpty(data_evento))
                {
                    DateTime dataConvertida;
                    // Verifica se a data fornecida está no formato esperado (dd/MM/yyyy)
                    if (DateTime.TryParseExact(data_evento, "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida))
                    {
                        // Converter a data para o formato americano (yyyy-MM-dd) para enviar ao banco
                        string dataFormatoAmericano = dataConvertida.ToString("yyyy-MM-dd");

                        // Agora, você usa a data no formato americano para fazer a pesquisa no banco
                        var orcamentodata = orcamentoDAO.GetByOrcamentoData(dataFormatoAmericano);
                        if (orcamentodata != null)
                        {
                            DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableData(dataFormatoAmericano);
                            dataGridView1.DataSource = dataTable;
                            txtTipoOrcamento.Enabled = false;
                            txtTemaOrcamento.Enabled = false;
                            txtCliente.Enabled = false;
                            mskData.Enabled = false;
                            txtTipoOrcamento.ResetText();
                            txtCliente.ResetText();
                            mskData.ResetText();
                            txtTemaOrcamento.ResetText();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Orçamento não encontrado.");
                        }

                    }
                }


                // Limpar o TextBox
                txtTipoOrcamento.Enabled = false;
                txtTemaOrcamento.Enabled = false;
                txtCliente.Enabled = false;
                mskData.Enabled = false;
                txtTipoOrcamento.ResetText();
                txtCliente.ResetText();
                mskData.ResetText();
                txtTemaOrcamento.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cliente: {ex.Message}");
            }
        }


        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar o TextBox
            txtTipoOrcamento.Enabled = false;
            txtTemaOrcamento.Enabled = false;
            txtCliente.Enabled = false;
            mskData.Enabled = false;
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
            txtTemaOrcamento.ResetText();
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
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();

        }
    }
}