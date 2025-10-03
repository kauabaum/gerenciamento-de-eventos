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
            mskDataEmissao.Text = orcamentoSelecionado.DataEmissao.ToShortDateString();
            mskDataEvento.Text = orcamentoSelecionado.DataEvento.ToShortDateString();
            txtLocalEvento.Text = orcamentoSelecionado.LocalEvento;
            txtTema.Text = orcamentoSelecionado.Tema;
            mskHoraEvento.Text = orcamentoSelecionado.HoraEvento;
            txtTipoEvento.Text = orcamentoSelecionado.TipoEvento;
            txtTotal.Text = orcamentoSelecionado.Total.ToString("C");
            mskDataEmissao.Enabled = false;
            mskDataEvento.Enabled = false;
            txtLocalEvento.Enabled = false;
            txtTema.Enabled = false;
            mskHoraEvento.Enabled = false;
            txtTotal.Enabled = false;
            txtTipoEvento.Enabled = false;

            txtTotal.Tag = orcamentoSelecionado.Total; // guarda o valor real
            txtTotal.Text = $"Total: {orcamentoSelecionado.Total:C} | 1x de {orcamentoSelecionado.Total:C}";

            // Inicializa o combo de parcelas
            cmbParcelas.SelectedItem = 1;
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
            if (txtTotal.Tag == null) return;

            // Converte o valor do Tag para decimal de forma segura
            decimal valorTotal;
            if (!decimal.TryParse(txtTotal.Tag.ToString(), out valorTotal))
                return;

            // Converte o número de parcelas selecionado
            int parcelas = 1;
            if (cmbParcelas.SelectedItem != null)
                int.TryParse(cmbParcelas.SelectedItem.ToString(), out parcelas);

            if (parcelas == 0) parcelas = 1; // evita divisão por zero

            // Calcula o valor da parcela
            decimal valorParcela = valorTotal / parcelas;

            // Atualiza o txtTotal
            txtTotal.Text = $"Total: {valorTotal:C} | {parcelas}x de {valorParcela:C}";
        }


        // Atualiza o txtTotal mostrando total e valor da parcela
        private void AtualizarTotal(int parcelas)
        {
            decimal total = Convert.ToDecimal(txtTotal.Tag); // pega o total original do Tag
            decimal valorParcela = total / parcelas;
            txtTotal.Text = $"Total: {total:C} | {parcelas}x de {valorParcela:C}";
        }

    }
}