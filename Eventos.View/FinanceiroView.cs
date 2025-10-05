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
    public partial class frmFinanceiroView : Form
    {
        String mensagem = "";
        private ParcelamentoDAO parcelamentoDAO;
        private ReceberDAO receberDAO;
        public frmFinanceiroView()
        {
            InitializeComponent();
            txtTipoOrcamento.Enabled = false;
            txtCliente.Enabled = false;
            mskData.Enabled = false;
            cmbStatus.Enabled = false;
            cmbStatus.ResetText();
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
            CarregarDados();
            parcelamentoDAO = new ParcelamentoDAO();
            receberDAO = new ReceberDAO();
            CarregarFinanceiro();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAdicionarOrcamentoView add = new frmAdicionarOrcamentoView();
            add.ShowDialog();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtTipoOrcamento.Enabled = true;
            txtCliente.Enabled = true;
            mskData.Enabled = true;
            cmbStatus.Enabled = true;
            cmbStatus.ResetText();
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
        }
        private void CarregarFinanceiro()
        {
            dataGridView2.DataSource = parcelamentoDAO.GetParcelasPendentes();
            dataGridView1.DataSource = receberDAO.GetRecebimentosPagos();

            if (dataGridView1.Columns.Contains("Id_Receber"))
                dataGridView1.Columns["Id_Receber"].Visible = false;
            if (dataGridView1.Columns.Contains("Id_Agendamento"))
                dataGridView1.Columns["Id_Agendamento"].Visible = false;

            if (dataGridView2.Columns.Contains("Id_Parcela"))
                dataGridView2.Columns["Id_Parcela"].Visible = false;
            if (dataGridView2.Columns.Contains("Id_Receber"))
                dataGridView2.Columns["Id_Receber"].Visible = false;

            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.CurrentCell = null;
        }

        private void btnMarcarComoPago_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int idParcela = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id_Parcela"].Value);
                int idReceber = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id_Receber"].Value);
                double valor = Convert.ToDouble(dataGridView2.CurrentRow.Cells["Valor"].Value);

                // 🔹 1. Pega o id_agendamento do receber
                int idAgendamento = receberDAO.GetIdAgendamentoPorReceber(idReceber);

                // 🔹 2. Cria o recebimento (já existe, mas adiciona novo registro histórico se quiser)
                receberDAO.InserirRecebimento(idAgendamento, valor);

                // 🔹 3. Atualiza status da parcela
                parcelamentoDAO.MarcarParcelaComoPaga(idParcela);

                // 🔹 4. Atualiza os grids
                CarregarFinanceiro();

                MessageBox.Show("Parcela marcada como paga com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione uma parcela para marcar como paga.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo_evento = txtTipoOrcamento.Text;
                string data_evento = mskData.Text;
                string status = cmbStatus.Text;
                string nome_cliente = txtCliente.Text;

                if (string.IsNullOrEmpty(tipo_evento) && string.IsNullOrEmpty(data_evento))
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
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
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
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
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
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Orçamento não encontrado.");
                    }
                }


                /*if (!string.IsNullOrEmpty(tema_evento))
                {
                    var orcamentotema = orcamentoDAO.GetByOrcamentoTema(tema_evento);
                    if (orcamentotema != null)
                    {
                        DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableTema(tema_evento);
                        dataGridView1.DataSource = dataTable;
                        txtTipoOrcamento.Enabled = false;
                        txtCliente.Enabled = false;
                        mskData.Enabled = false;
                        cmbStatus.Enabled = false;
                        cmbStatus.ResetText();
                        txtTipoOrcamento.ResetText();
                        txtCliente.ResetText();
                        mskData.ResetText();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Orçamento não encontrado.");
                    }
                }*/
                if (!string.IsNullOrEmpty(data_evento))
                {
                    DateTime dataConvertida;
                    if (DateTime.TryParseExact(data_evento, "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida))
                    {
                        string dataFormatoAmericano = dataConvertida.ToString("yyyy-MM-dd");

                        var orcamentodata = orcamentoDAO.GetByOrcamentoData(dataFormatoAmericano);
                        if (orcamentodata != null)
                        {
                            DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableData(dataFormatoAmericano);
                            dataGridView1.DataSource = dataTable;
                            txtTipoOrcamento.Enabled = false;
                            txtCliente.Enabled = false;
                            mskData.Enabled = false;
                            txtTipoOrcamento.ResetText();
                            txtCliente.ResetText();
                            mskData.ResetText();
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
                txtCliente.Enabled = false;
                mskData.Enabled = false;
                txtTipoOrcamento.ResetText();
                txtCliente.ResetText();
                mskData.ResetText();

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
            txtCliente.Enabled = false;
            mskData.Enabled = false;
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
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