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
            txtTipoOrcamento.ResetText();
            txtCliente.ResetText();
            mskData.ResetText();
        }
        private void CarregarFinanceiro()
        {
            // --- PENDENTES (parcelas) ---
            dataGridView2.DataSource = parcelamentoDAO.GetParcelasPendentes();

            // --- PAGOS (receber) ---
            DataTable dtPagos = receberDAO.GetRecebimentosPagos();

            // Filtra para mostrar apenas os que têm valor > 0
            if (dtPagos.Columns.Contains("Valor_Total"))
            {
                DataRow[] linhasValidas = dtPagos.Select("Valor_Total > 0");
                if (linhasValidas.Length > 0)
                    dataGridView1.DataSource = linhasValidas.CopyToDataTable();
                else
                    dataGridView1.DataSource = null;
            }

            // --- Esconde colunas ---
            if (dataGridView1.Columns.Contains("Id_Receber"))
                dataGridView1.Columns["Id_Receber"].Visible = false;
            if (dataGridView1.Columns.Contains("Id_Agendamento"))
                dataGridView1.Columns["Id_Agendamento"].Visible = false;

            if (dataGridView2.Columns.Contains("Id_Parcela"))
                dataGridView2.Columns["Id_Parcela"].Visible = false;
            if (dataGridView2.Columns.Contains("Id_Receber"))
                dataGridView2.Columns["Id_Receber"].Visible = false;
            if (dataGridView2.Columns.Contains("Status_Pagamento"))
                dataGridView2.Columns["Status_Pagamento"].Visible = false;
            // Configurações gerais do DataGridView
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;

            // Limpa seleção inicial
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            // Intercepta cliques do usuário para impedir seleção
            dataGridView1.CellMouseDown += (s, e) =>
            {
                dataGridView1.ClearSelection();  // Remove qualquer seleção que tente acontecer
                dataGridView1.CurrentCell = null;
            };

            dataGridView1.SelectionChanged += (s, e) =>
            {
                dataGridView1.ClearSelection();  // Garante que nada fique selecionado
                dataGridView1.CurrentCell = null;
            };

        }


        private void btnMarcarComoPago_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                // Pergunta de confirmação
                DialogResult resultado = MessageBox.Show(
                    "Tem certeza que deseja marcar esta parcela como paga?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    int idParcela = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id_Parcela"].Value);
                    int idReceber = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id_Receber"].Value);
                    double valor = Convert.ToDouble(dataGridView2.CurrentRow.Cells["Valor"].Value);

                    // 🔹 1. Pega o id_agendamento do receber
                    int idAgendamento = receberDAO.GetIdAgendamentoPorReceber(idReceber);

                    // 🔹 2. Cria o recebimento
                    receberDAO.InserirRecebimento(idAgendamento, valor);

                    // 🔹 3. Atualiza status da parcela
                    parcelamentoDAO.MarcarParcelaComoPaga(idParcela);

                    // 🔹 4. Atualiza os grids
                    CarregarFinanceiro();

                    MessageBox.Show("Parcela marcada como paga com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Se usuário clicar Não, não faz nada
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
                string tipoOrcamento = txtTipoOrcamento.Text.Trim();
                string cliente = txtCliente.Text.Trim();
                string dataEvento = mskData.Text.Trim();

                // Verifica se todos os campos estão vazios
                if (string.IsNullOrEmpty(tipoOrcamento) &&
                    string.IsNullOrEmpty(cliente) &&
                    string.IsNullOrEmpty(dataEvento))
                {
                    MessageBox.Show("Preencha pelo menos um campo para pesquisar.");
                    return;
                }

                // Monta os filtros individualmente (cada um é opcional)
                string filtroPagos = "";
                string filtroParcelas = "";

                // Cliente
                if (!string.IsNullOrEmpty(cliente))
                {
                    filtroPagos += $"Nome_Cliente LIKE '%{cliente}%' AND ";
                    filtroParcelas += $"Nome_Cliente LIKE '%{cliente}%' AND ";
                }

                // Tipo de orçamento
                if (!string.IsNullOrEmpty(tipoOrcamento))
                {
                    filtroParcelas += $"Tipo_Pagamento LIKE '%{tipoOrcamento}%' AND ";
                }

                // Data
                if (!string.IsNullOrEmpty(dataEvento))
                {
                    DateTime dataConvertida;
                    if (DateTime.TryParseExact(dataEvento, "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida))
                    {
                        string filtroData = dataConvertida.ToString("MM/dd/yyyy");
                        filtroPagos += $"Data_Emissao = #{filtroData}# AND ";
                        filtroParcelas += $"Data_Pagamento = #{filtroData}# AND ";
                    }
                }

                // Filtra apenas parcelas pendentes
                filtroParcelas += "Status_Pagamento = 0 AND ";

                // Remove último "AND" se existir
                if (filtroPagos.EndsWith(" AND ")) filtroPagos = filtroPagos.Substring(0, filtroPagos.Length - 5);
                if (filtroParcelas.EndsWith(" AND ")) filtroParcelas = filtroParcelas.Substring(0, filtroParcelas.Length - 5);

                // Aplica filtros
                DataView dvPagos = new DataView(receberDAO.GetAllReceber());
                try { dvPagos.RowFilter = filtroPagos; } catch { dvPagos.RowFilter = ""; }

                DataView dvParcelas = new DataView(parcelamentoDAO.GetAllParcelas());
                try { dvParcelas.RowFilter = filtroParcelas; } catch { dvParcelas.RowFilter = ""; }

                dataGridView1.DataSource = dvPagos;
                dataGridView2.DataSource = dvParcelas;
                if (dataGridView2.Columns.Contains("Status_Pagamento"))
                    dataGridView2.Columns["Status_Pagamento"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}");
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
        private ReceberDAO receber2DAO = new ReceberDAO();
        private ParcelamentoDAO parcelamento2DAO = new ParcelamentoDAO();
        private void CarregarDados()
        {
            try
            {
                // Grid de Recebimentos
                DataTable dataTable1 = receber2DAO.GetAllReceber();
                dataGridView1.DataSource = dataTable1;

                // Grid de Parcelamento
                DataTable dataTable2 = parcelamento2DAO.GetAllParcelas();

                // Cria DataView para aplicar filtro
                DataView dvParcelas = new DataView(dataTable2);

                // Filtra apenas parcelas pendentes (status_pagamento = 0)
                try
                {
                    dvParcelas.RowFilter = "Status_Pagamento = 0";
                }
                catch
                {
                    dvParcelas.RowFilter = ""; // Caso dê erro, mostra todos
                }

                dataGridView2.DataSource = dvParcelas;
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