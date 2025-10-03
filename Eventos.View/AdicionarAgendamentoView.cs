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
    public partial class frmAdicionarAgendamentoView : Form
    {
        String mensagem = "";
        private Orcamento orcamentoSelecionado;
        private ClienteDAO clienteDAO = new ClienteDAO();

        public frmAdicionarAgendamentoView(Orcamento orcamento)
        {
            InitializeComponent();
            orcamentoSelecionado = orcamento;
            CarregarCliente();
            PreencherCampos();
        }

        private void CarregarCliente()
        {

            try
            {
                // Obtém os dados do banco de dados usando o EstadoDAO
                DataTable dataTable = clienteDAO.GetAll();

                // Verifica se as colunas necessárias estão presentes
                if (dataTable.Columns.Contains("Nome") && dataTable.Columns.Contains("Id"))
                {
                    cmbCliente.DataSource = dataTable;
                    cmbCliente.DisplayMember = "Nome";
                    cmbCliente.ValueMember = "Id";
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

        private void PreencherCampos()
        {
            // Pegar os itens do orçamento selecionado
            ItensOrcamentoDAO itensDAO = new ItensOrcamentoDAO();
            List<ItemOrcamento> itens = itensDAO.GetByOrcamentoId(orcamentoSelecionado.IdOrcamento);

            // Somar todos os subtotais
            double totalItens = itens.Sum(i => i.Subtotal);

            // Somar o valor do orçamento em si (se houver diferença)
            double totalOrcamento = orcamentoSelecionado.Total + totalItens;

            // Guardar o valor real no Tag
            txtTotal.Tag = totalOrcamento;

            // Exibir 1x por padrão
            txtTotal.Text = $"Total: {totalOrcamento:C} | 1x de {totalOrcamento:C}";

            mskDataEmissao.Text = orcamentoSelecionado.DataEmissao.ToShortDateString();
            mskDataEvento.Text = orcamentoSelecionado.DataEvento.ToShortDateString();
            txtLocalEvento.Text = orcamentoSelecionado.LocalEvento;
            txtTema.Text = orcamentoSelecionado.Tema;
            mskHoraEvento.Text = orcamentoSelecionado.HoraEvento;
            txtTipoEvento.Text = orcamentoSelecionado.TipoEvento;
            mskDataEmissao.Enabled = false;
            mskDataEvento.Enabled = false;
            txtLocalEvento.Enabled = false;
            txtTema.Enabled = false;
            mskHoraEvento.Enabled = false;
            txtTipoEvento.Enabled = false;
            txtTotal.Enabled = false;

            // Configura combo de parcelas
            cmbParcelas.SelectedIndex = 0; // 1x
        }




        private void cmbTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cmbTipos.SelectedItem.ToString();

            if (tipo == "Cartão de Crédito" || tipo == "Crediário" || tipo == "Boleto" || tipo == "Transferência Bancária")
            {
                cmbParcelas.Enabled = true;
            }
            else
            {
                cmbParcelas.Enabled = false;
                cmbParcelas.SelectedItem = 1;
                AtualizarTotal(1);
            }
        }

        // Quando a quantidade de parcelas mudar
        private void cmbParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTotal.Tag == null)
                return;

            // Pegar o valor total real
            double total = Convert.ToDouble(txtTotal.Tag);

            // Pegar o número de parcelas selecionado
            int parcelas = 1;

            if (cmbParcelas.SelectedItem != null)
            {
                // Se estiver no formato "1x", "2x" etc.
                string selected = cmbParcelas.SelectedItem.ToString();
                selected = selected.Replace("x", "").Trim();
                int.TryParse(selected, out parcelas);
            }

            // Calcular valor da parcela
            double valorParcela = total / parcelas;

            // Mostrar no txtTotal
            txtTotal.Text = $"Total: {total:C} | {parcelas}x de {valorParcela:C}";
        }




        // Atualiza o txtTotal mostrando total e valor da parcela
        private void AtualizarTotal(int parcelas)
        {
            decimal total = Convert.ToDecimal(txtTotal.Tag); // pega o total original do Tag
            decimal valorParcela = total / parcelas;
            txtTotal.Text = $"Total: {total:C} | {parcelas}x de {valorParcela:C}";
        }

        private void btnAdicionarAgendamento_Click(object sender, EventArgs e)
        {
            try
            {
                var culture = CultureInfo.GetCultureInfo("pt-BR");

                // --- 1) ID do cliente ---
                if (cmbCliente.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um cliente.");
                    return;
                }
                int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);

                // --- 2) Total ---
                decimal total;
                string raw = txtTotal.Text ?? "";
                int idxR = raw.IndexOf('R');
                string currencyPart = idxR >= 0 ? raw.Substring(idxR) : raw;
                int idxPipe = currencyPart.IndexOf('|');
                if (idxPipe >= 0) currencyPart = currencyPart.Substring(0, idxPipe).Trim();

                if (!decimal.TryParse(currencyPart, NumberStyles.Currency, culture, out total))
                {
                    string digits = new string(currencyPart.Where(ch => char.IsDigit(ch) || ch == ',' || ch == '.').ToArray());
                    if (!decimal.TryParse(digits, NumberStyles.Number, culture, out total))
                    {
                        MessageBox.Show("Valor total inválido. Verifique o campo Total.");
                        return;
                    }
                }

                if (total <= 0)
                {
                    MessageBox.Show("Valor total precisa ser maior que zero.");
                    return;
                }

                // --- 3) Datas ---
                DateTime dataEvento;
                if (!DateTime.TryParseExact(mskDataEvento.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out dataEvento))
                {
                    MessageBox.Show("Data do evento inválida.");
                    return;
                }
                DateTime dataEmissao = DateTime.Now;

                DateTime dataPagamentoBase, vencimentoBase;
                if (!DateTime.TryParseExact(mskPagamento.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out dataPagamentoBase))
                    dataPagamentoBase = DateTime.Now;
                if (!DateTime.TryParseExact(mskVencimento.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out vencimentoBase))
                    vencimentoBase = dataPagamentoBase;

                // --- 4) Parcelas ---
                int parcelas = 1;
                if (cmbParcelas.SelectedItem != null)
                {
                    string sel = cmbParcelas.SelectedItem.ToString().Replace("x", "").Trim();
                    if (!int.TryParse(sel, out parcelas) || parcelas <= 0) parcelas = 1;
                }

                // --- 5) Cria Agendamento ---
                Agendamento agendamento = new Agendamento
                {
                    IdCliente = idCliente,
                    TipoEvento = txtTipoEvento.Text,
                    Total = Convert.ToDouble(total),
                    DataEmissao = dataEmissao,
                    LocalEvento = txtLocalEvento.Text,
                    DataEvento = dataEvento,
                    HoraEvento = mskHoraEvento.Text,
                    Tema = txtTema.Text
                };
                AgendamentoDAO agendamentoDAO = new AgendamentoDAO();
                int idAgendamento = agendamentoDAO.Add(agendamento); // retorna ID gerado

                // --- 6) Cria Receber ---
                Receber receber = new Receber
                {
                    IdAgendamento = idAgendamento,
                    DataEmissao = DateTime.Now,
                    ValorTotal = Convert.ToDouble(total)
                };
                ReceberDAO receberDAO = new ReceberDAO();
                int idReceber = receberDAO.Add(receber); // retorna ID do receber

                // --- 7) Se houver mais de 1 parcela, cria Parcelamento ---
                if (parcelas > 1)
                {
                    decimal valorParcela = Math.Round(total / parcelas, 2);
                    decimal somaParc = valorParcela * parcelas;
                    decimal diferenca = total - somaParc;
                    decimal[] parcelasValores = new decimal[parcelas];
                    for (int i = 0; i < parcelas; i++) parcelasValores[i] = valorParcela;
                    if (diferenca != 0) parcelasValores[parcelas - 1] += diferenca;

                    ParcelamentoDAO parcelamentoDAO = new ParcelamentoDAO();
                    string tipoPagamento = cmbTipos.Text;

                    for (int i = 0; i < parcelas; i++)
                    {
                        Parcelamento p = new Parcelamento
                        {
                            IdReceber = idReceber,
                            TipoPagamento = tipoPagamento,
                            Valor = Convert.ToDouble(parcelasValores[i]),
                            DataPagamento = dataPagamentoBase.AddMonths(i),
                            Vencimento = vencimentoBase.AddMonths(i),
                            Parcela = $"{i + 1}-{parcelas}" // rótulo dinâmico
                        };
                        parcelamentoDAO.Add(p);
                    }

                }

                MessageBox.Show("Agendamento, receber e parcelamento adicionados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }



    }
}
