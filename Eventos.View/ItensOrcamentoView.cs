using Eventos.Control;
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

                using (var dbContext = new DbContext())
                {
                    // Obter a conexão
                    var connection = dbContext.GetConnection();

                    // Abrir a conexão se ela não estiver aberta
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // Buscar o produto no banco
                    string query = "SELECT * FROM produto WHERE id_produto = @idProduto";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idProduto", produtoId);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    Produto produto = null;

                    // Ler os dados do produto
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

                    reader.Close(); // Fechar o reader após ler os dados

                    // Se o produto foi encontrado e a quantidade for suficiente
                    if (produto != null && produto.Quantidade >= quantidade)
                    {
                        // Atualizar a quantidade do produto no estoque
                        produto.Quantidade -= quantidade;

                        // Atualizar a quantidade no banco
                        string updateQuery = "UPDATE produto SET quantidade = @quantidade WHERE id_produto = @idProduto";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
                        updateCmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                        updateCmd.Parameters.AddWithValue("@idProduto", produto.IdProduto);

                        updateCmd.ExecuteNonQuery();

                        // Calcular o subtotal
                        double subtotal = produto.Valor * quantidade;

                        // Inserir o item no orçamento
                        string insertItemQuery = "INSERT INTO itens_orcamento (quantidade, subtotal, id_orcamento, id_produto) " +
                                                 "VALUES (@quantidade, @subtotal, @idOrcamento, @idProduto)";
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
                        MessageBox.Show("Quantidade insuficiente no estoque!");
                    }

                    // Fechar a conexão após todas as operações
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
                DataTable dataTable = orcamentoDAO.GetAll();
                dataGridView1.DataSource = dataTable;

                DataTable dataTable2 = orcamentoDAO.GetOrcamentosComProdutos();
                dataGridView2.DataSource = dataTable2;
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
            cmbProduto.DisplayMember = "DescricaoComQuantidadeValor"; // Nome a ser exibido
            cmbProduto.ValueMember = "IdProduto"; // O ID do produto
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
            CarregarProdutosComboBox();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se um item foi selecionado no DataGrid (Orçamento)
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Obter o ID do orçamento da linha selecionada no DataGrid
                int idOrcamento = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id_Orcamento"].Value);

                // Obter o ID do item selecionado no orçamento
                int itemId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id_Itens"].Value);

                using (var dbContext = new DbContext())  // Usando o DbContext para acessar o banco de dados
                {
                    var connection = dbContext.GetConnection();

                    // Abrir a conexão uma única vez
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // Buscar o item do orçamento no banco de dados
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

                    readerItem.Close(); // Fechar o reader depois de usar

                    if (itemOrcamento != null)
                    {
                        // Buscar o produto associado ao item do orçamento
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

                        readerProduto.Close(); // Fechar o reader depois de usar

                        if (produto != null)
                        {
                            // Atualiza a quantidade do produto no estoque (retorna a quantidade excluída ao estoque)
                            produto.Quantidade += itemOrcamento.Quantidade;

                            // Atualizar o estoque no banco de dados
                            string updateEstoqueQuery = "UPDATE produto SET quantidade = @quantidade WHERE id_produto = @idProduto";
                            MySqlCommand updateEstoqueCmd = new MySqlCommand(updateEstoqueQuery, connection);
                            updateEstoqueCmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                            updateEstoqueCmd.Parameters.AddWithValue("@idProduto", produto.IdProduto);

                            updateEstoqueCmd.ExecuteNonQuery();

                            // Excluir o item do orçamento
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

                    // Fechar a conexão após todas as operações
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
    }
   }
