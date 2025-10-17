using Eventos.Controller;
using Eventos.DAO;
using Eventos.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Pkcs;
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

namespace Eventos.View
{
    public partial class frmItensOrcamentoView : Form
    {
        String mensagem = "";

        public frmItensOrcamentoView()
        {
            InitializeComponent();
            cmbProduto.Enabled = false;
            mskQuantidade.Enabled = false;
            CarregarDados();
            CarregarProdutosComboBox();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            cmbProduto.Enabled = true;
            mskQuantidade.Enabled = true;
            cmbProduto.ResetText();
            mskQuantidade.ResetText();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            cmbProduto.Enabled = false;
            mskQuantidade.Enabled = false;
            cmbProduto.ResetText();
            mskQuantidade.ResetText();
        }
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idOrcamento = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Orcamento"].Value);
                int produtoId = Convert.ToInt32(cmbProduto.SelectedValue);
                int quantidade = Convert.ToInt32(mskQuantidade.Text);

                // Pega a data do evento do orçamento usando idOrcamento
                DateTime dataEvento = (DateTime)orcamentoDAO.ObterDataEventoPorIdOrcamento(idOrcamento);

                ItensOrcamentoDAO itensOrcamentoDAO = new ItensOrcamentoDAO();

                // Busca estoque disponível para o produto nessa data
                int quantidadeReservada = itensOrcamentoDAO.SomarQuantidadeProdutoPorData(produtoId, dataEvento);

                using (var dbContext = new DbContext())
                {
                    var connection = dbContext.GetConnection();
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    string queryProduto = "SELECT * FROM produto WHERE id_produto = @idProduto";
                    MySqlCommand cmdProduto = new MySqlCommand(queryProduto, connection);
                    cmdProduto.Parameters.AddWithValue("@idProduto", produtoId);

                    MySqlDataReader reader = cmdProduto.ExecuteReader();
                    Produto produto = null;
                    if (reader.Read())
                    {
                        produto = new Produto
                        {
                            IdProduto = reader.GetInt32("id_produto"),
                            Descricao = reader.GetString("descricao"),
                            Quantidade = reader.GetDouble("quantidade"),
                            Valor = reader.GetDouble("valor")
                        };
                    }
                    reader.Close();

                    if (produto != null)
                    {
                        double estoqueDisponivel = produto.Quantidade - quantidadeReservada;

                        if (estoqueDisponivel >= quantidade)
                        {
                            // Adiciona o item no orçamento
                            double subtotal = quantidade * produto.Valor;

                            string insertItemQuery = @"
                    INSERT INTO itens_orcamento (quantidade, subtotal, id_orcamento, id_produto)
                    VALUES (@quantidade, @subtotal, @idOrcamento, @idProduto)";

                            MySqlCommand insertCmd = new MySqlCommand(insertItemQuery, connection);
                            insertCmd.Parameters.AddWithValue("@quantidade", quantidade);
                            insertCmd.Parameters.AddWithValue("@subtotal", subtotal);
                            insertCmd.Parameters.AddWithValue("@idOrcamento", idOrcamento);
                            insertCmd.Parameters.AddWithValue("@idProduto", produtoId);
                            insertCmd.ExecuteNonQuery();

                            MessageBox.Show("Produto adicionado ao orçamento com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show($"Quantidade insuficiente para este produto na data do evento. Estoque disponível: {estoqueDisponivel}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Selecione um orçamento para adicionar o produto.");
            }
            CarregarDados();
            CarregarProdutosComboBox();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private OrcamentoDAO orcamentoDAO = new OrcamentoDAO();
        private void CarregarDados()
        {
            try
            {
                // Orçamentos - apenas os que estão "Aguardando"
                DataTable dataTable = orcamentoDAO.GetAll();
                DataView dv = new DataView(dataTable);
                dv.RowFilter = "Aprovacao = 'Aguardando'";
                dataGridView1.DataSource = dv;

                // Produtos - apenas os vinculados a orçamentos "Aguardando"
                DataTable dataTable2 = orcamentoDAO.GetOrcamentosComProdutos();
                DataView dv2 = new DataView(dataTable2);
                dv2.RowFilter = "Aprovacao = 'Aguardando'";
                dataGridView2.DataSource = dv2;

                // esconder IDs
                dataGridView1.Columns["Id_Orcamento"].Visible = false;
                dataGridView2.Columns["Id_Orcamento"].Visible = false;
                dataGridView2.Columns["Id_Itens"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }


        private void CarregarProdutosComboBox()

        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            var produtos = produtoDAO.GetProdutosParaComboBox();

            cmbProduto.DataSource = produtos;
            cmbProduto.DisplayMember = "DescricaoComQuantidadeValor";
            cmbProduto.ValueMember = "IdProduto";
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
            CarregarProdutosComboBox();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int idOrcamento = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id_Orcamento"].Value);

                int itemId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id_Itens"].Value);

                using (var dbContext = new DbContext()) 
                {
                    var connection = dbContext.GetConnection();

                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    string queryItem = "SELECT * FROM itens_orcamento WHERE id_itens = @itemId";
                    MySqlCommand cmdItem = new MySqlCommand(queryItem, connection);
                    cmdItem.Parameters.AddWithValue("@itemId", itemId);

                    MySqlDataReader readerItem = cmdItem.ExecuteReader();
                    ItemOrcamento itemOrcamento = null;

                    if (readerItem.Read())
                    {
                        itemOrcamento = new ItemOrcamento
                        {
                            IdItens = readerItem.GetInt32("id_itens"),
                            Quantidade = readerItem.GetInt32("quantidade"),
                            IdProduto = readerItem.GetInt32("id_produto")
                        };
                    }

                    readerItem.Close();

                    if (itemOrcamento != null)
                    {

                        string queryProduto = "SELECT * FROM produto WHERE id_produto = @idProduto";
                        MySqlCommand cmdProduto = new MySqlCommand(queryProduto, connection);
                        cmdProduto.Parameters.AddWithValue("@idProduto", itemOrcamento.IdProduto);

                        MySqlDataReader readerProduto = cmdProduto.ExecuteReader();
                        Produto produto = null;

                        if (readerProduto.Read())
                        {
                            produto = new Produto
                            {
                                IdProduto = readerProduto.GetInt32("id_produto"),
                                Quantidade = readerProduto.GetDouble("quantidade"),
                                Valor = readerProduto.GetDouble("valor")
                            };
                        }

                        readerProduto.Close();

                        if (produto != null)
                        {
                            produto.Quantidade += itemOrcamento.Quantidade;

                            string deleteItemQuery = "DELETE FROM itens_orcamento WHERE id_itens = @itemId";
                            MySqlCommand deleteItemCmd = new MySqlCommand(deleteItemQuery, connection);
                            deleteItemCmd.Parameters.AddWithValue("@itemId", itemOrcamento.IdItens);

                            deleteItemCmd.ExecuteNonQuery();

                            MessageBox.Show("Produto removido do orçamento e estoque atualizado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado no estoque.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Item não encontrado no orçamento.");
                    }

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Selecione um item do orçamento para excluir.");
            }
            CarregarDados();
            CarregarProdutosComboBox();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome_cliente = txtPesquisa.Text;

            if (string.IsNullOrEmpty(nome_cliente))
            {
                MessageBox.Show("Preencha pelo menos um campo para pesquisar.");
                return;
            }

            if (!string.IsNullOrEmpty(nome_cliente))
            {
                var orcamentocliente = orcamentoDAO.GetByOrcamentoCliente(nome_cliente);
                if (orcamentocliente != null)
                {
                    DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableCliente(nome_cliente);
                    dataGridView1.DataSource = dataTable;
                    return;
                }
                else
                {
                    MessageBox.Show("Orçamento não encontrado.");
                }
            }
        }
        private void btnPesquisarItem_Click(object sender, EventArgs e)
        {
            string nome_cliente = txtPesquisaItem.Text;

            if (string.IsNullOrEmpty(nome_cliente))
            {
                MessageBox.Show("Preencha pelo menos um campo para pesquisar.");
                return;
            }

            if (!string.IsNullOrEmpty(nome_cliente))
            {
                var orcamentocliente = orcamentoDAO.GetByOrcamentoCliente(nome_cliente);
                if (orcamentocliente != null)
                {
                    DataTable dataTable = orcamentoDAO.GetOrcamentoAsDataTableCliente(nome_cliente);
                    dataGridView2.DataSource = dataTable;
                    return;
                }
                else
                {
                    MessageBox.Show("Orçamento não encontrado.");
                }
            }
        }
    }
}
