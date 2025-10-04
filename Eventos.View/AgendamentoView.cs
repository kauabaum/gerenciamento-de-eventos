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
using static Eventos.Model.Agendamento;

namespace Eventos.View
{
    public partial class frmAgendamentoView : Form
    {
        String mensagem = "";

        public frmAgendamentoView()
        {
            InitializeComponent();
            txtTipoOrcamento.Enabled = false;
            txtTemaOrcamento.Enabled = false;
            txtCliente.Enabled = false;
            mskData.Enabled = false;
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
            CarregarDados();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtTipoOrcamento.Enabled = true;
            txtTemaOrcamento.Enabled = true;
            txtCliente.Enabled = true;
            mskData.Enabled = true;
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
                string nome_cliente = txtCliente.Text;

                if (string.IsNullOrEmpty(tipo_evento) && string.IsNullOrEmpty(tema_evento) && string.IsNullOrEmpty(data_evento) && string.IsNullOrEmpty(nome_cliente))
                {
                    MessageBox.Show("Preencha pelo menos um campo para pesquisar.");
                    return;
                }

                if (!string.IsNullOrEmpty(tipo_evento))
                {
                    var agendamento = agendamentoDAO.GetByAgendamento(tipo_evento);
                    if (agendamento != null)
                    {
                        DataTable dataTable = agendamentoDAO.GetAgendamentoAsDataTable(tipo_evento);
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
                if (!string.IsNullOrEmpty(nome_cliente))
                {
                    var agendamentocliente = agendamentoDAO.GetByAgendamentoCliente(nome_cliente);
                    if (agendamentocliente != null)
                    {
                        DataTable dataTable = agendamentoDAO.GetAgendamentoAsDataTableCliente(nome_cliente);
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

                if (!string.IsNullOrEmpty(tema_evento))
                {
                    var orcamentotema = agendamentoDAO.GetByAgendamentoTema(tema_evento);
                    if (orcamentotema != null)
                    {
                        DataTable dataTable = agendamentoDAO.GetAgendamentoAsDataTableTema(tema_evento);
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
                if (!string.IsNullOrEmpty(data_evento))
                {
                    DateTime dataConvertida;
                    if (DateTime.TryParseExact(data_evento, "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida))
                    {
                        string dataFormatoAmericano = dataConvertida.ToString("yyyy-MM-dd");

                        var orcamentodata = agendamentoDAO.GetByAgendamentoData(dataFormatoAmericano);
                        if (orcamentodata != null)
                        {
                            DataTable dataTable = agendamentoDAO.GetAgendamentoAsDataTableData(dataFormatoAmericano);
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
        private AgendamentoDAO agendamentoDAO = new AgendamentoDAO();
        private void CarregarDados()
        {
            try
            {
                DataTable dataTable = agendamentoDAO.GetAll();
                dataGridView1.DataSource = dataTable;

                dataGridView1.Columns["Id_Agendamento"].Visible = false;
                dataGridView1.Columns["Id_Cliente"].Visible = false;

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