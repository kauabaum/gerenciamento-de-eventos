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
using Eventos.DAO;
using Eventos.Control;

namespace Eventos.View
{
    public partial class frmProdutoView : Form
    {
        String mensagem = "";

        public frmProdutoView()
        {
            InitializeComponent();
            txtDescricaoProduto.Enabled = false;
            txtQuantidadeProduto.Enabled = false;
            txtCustoProduto.Enabled = false;
            txtTamanhoProduto.Enabled = false;
            txtValorProduto.Enabled = false;
            cmbCategoriaProduto.Enabled = false;
            cmbCorProduto.Enabled = false;
            cmbTemaProduto.Enabled = false;
            CarregarDados();

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtDescricaoProduto.Enabled = true;
            txtQuantidadeProduto.Enabled = true;
            txtCustoProduto.Enabled = true;
            txtTamanhoProduto.Enabled = true;
            txtValorProduto.Enabled = true;
            cmbCategoriaProduto.Enabled = true;
            cmbCorProduto.Enabled = true;
            cmbTemaProduto.Enabled = true;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtDescricaoProduto.Enabled = false;
            txtQuantidadeProduto.Enabled = false;
            txtCustoProduto.Enabled = false;
            txtTamanhoProduto.Enabled = false;
            txtValorProduto.Enabled = false;
            cmbCategoriaProduto.Enabled = false;
            cmbCorProduto.Enabled = false;
            cmbTemaProduto.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtDescricaoProduto.Text;
                string custo = txtCustoProduto.Text;
                string tamanho = txtTamanhoProduto.Text;
                string quantidade = txtQuantidadeProduto.Text;
                string valor = txtValorProduto.Text;
                string idcor = cmbCorProduto.Text;
                string idtema = cmbTemaProduto.Text;
                string idcategoria = cmbCategoriaProduto.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A Descrição é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(tamanho))
                {
                    MessageBox.Show("O Tamanho é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(custo))
                {
                    MessageBox.Show("O Custo é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(quantidade))
                {
                    MessageBox.Show("A Quantidade é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(valor))
                {
                    MessageBox.Show("O Valor é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(idcor))
                {
                    MessageBox.Show("A Cor é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(idtema))
                {
                    MessageBox.Show("O Tema é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(idcategoria))
                {
                    MessageBox.Show("A Categoria é obrigatório.");
                    return;
                }

                if (produtoIdSelecionado.HasValue)
                {
                    // Atualizar o cliente existente
                    Produto produtoAtualizado = new Produto()
                    {
                        IdProduto = produtoIdSelecionado.Value,
                        Descricao = descricao,
                        Tamanho = tamanho,
                        Quantidade = Convert.ToInt32(quantidade),
                        Custo = Convert.ToInt32(custo),
                        Valor = Convert.ToInt32(valor),
                        IdTema = Convert.ToInt32(idtema),
                        IdCategoria = Convert.ToInt32(idcategoria),
                        IdCor = Convert.ToInt32(idcor)

                    };

                    produtoDAO.Update(produtoAtualizado);
                    MessageBox.Show("Produto atualizado com sucesso!");
                }
                else
                {
                    // Adicionar novo cliente
                    Produto novoProduto = new Produto()
                    {
                        IdProduto = produtoIdSelecionado.Value,
                        Descricao = descricao,
                        Tamanho = tamanho,
                        Quantidade = Convert.ToInt32(quantidade),
                        Custo = Convert.ToInt32(custo),
                        Valor = Convert.ToInt32(valor),
                        IdTema = Convert.ToInt32(idtema),
                        IdCategoria = Convert.ToInt32(idcategoria),
                        IdCor = Convert.ToInt32(idcor)
                    };

                    produtoDAO.Add(novoProduto);
                    MessageBox.Show("Produto salvo com sucesso!");
                }

                // Limpar o TextBox
                txtDescricaoProduto.Text = string.Empty;
                txtDescricaoProduto.Enabled = false;
                txtQuantidadeProduto.Text = string.Empty;
                txtQuantidadeProduto.Enabled = false;
                txtCustoProduto.Text = string.Empty;
                txtCustoProduto.Enabled = false;
                produtoIdSelecionado = null;

                // Recarregar os dados no DataGridView após salvar
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}");
            }
        }

        private int? produtoIdSelecionado = null;

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtDescricaoProduto.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }

                if (produtoIdSelecionado.HasValue)
                {
                    // Excluir o Cliente
                    Produto produtoAtualizado = new Produto()
                    {
                        IdProduto = produtoIdSelecionado.Value,
                        Descricao = descricao,
                    };

                    produtoDAO.Delete(produtoAtualizado);
                    MessageBox.Show("Produto Excluído com sucesso!");

                    // Limpar o TextBox
                    txtDescricaoProduto.Text = string.Empty;
                    txtDescricaoProduto.Enabled = false;
                    txtQuantidadeProduto.Text = string.Empty;
                    txtQuantidadeProduto.Enabled = false;
                    txtCustoProduto.Text = string.Empty;
                    txtCustoProduto.Enabled = false;
                    produtoIdSelecionado = null;

                    // Recarregar os dados no DataGridView após salvar
                    CarregarDados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Excluir cliente: {ex.Message}");
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtDescricaoProduto.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }

                var produto = produtoDAO.GetByProduto(descricao);

                if (produto != null)
                {
                    // Se o cliente for encontrado, mostrar os dados no DataGridView
                    DataTable dataTable = produtoDAO.GetProdutoAsDataTable(descricao);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.");
                }

                // Limpar o TextBox
                txtDescricaoProduto.Enabled = false;
                txtQuantidadeProduto.Enabled = false;
                txtCustoProduto.Enabled = false;
                txtTamanhoProduto.Enabled = false;
                txtValorProduto.Enabled = false;
                cmbCategoriaProduto.Enabled = false;
                cmbCorProduto.Enabled = false;
                cmbTemaProduto.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cliente: {ex.Message}");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar o TextBox
            txtDescricaoProduto.Enabled = false;
            txtQuantidadeProduto.Enabled = false;
            txtCustoProduto.Enabled = false;
            txtTamanhoProduto.Enabled = false;
            txtValorProduto.Enabled = false;
            cmbCategoriaProduto.Enabled = false;
            cmbCorProduto.Enabled = false;
            cmbTemaProduto.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Carrega dados no GRID
        private ProdutoDAO produtoDAO = new ProdutoDAO();
        private void CarregarDados()
        {
            try
            {
                DataTable dataTable = produtoDAO.GetAll();
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
                produtoIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Obter a descrição do cliente e carregar no TextBox
                string descricao = dataGridView1.SelectedRows[0].Cells["Descrição"].Value.ToString();
                string quantidade = dataGridView1.SelectedRows[0].Cells["Quantidade"].Value.ToString();
                string custo = dataGridView1.SelectedRows[0].Cells["Custo"].Value.ToString();
                string tamanho = dataGridView1.SelectedRows[0].Cells["Tamanho"].Value.ToString();
                string valor = dataGridView1.SelectedRows[0].Cells["Valor"].Value.ToString();
                string id_cor = dataGridView1.SelectedRows[0].Cells["Id_Cor"].Value.ToString();
                string id_categoria = dataGridView1.SelectedRows[0].Cells["Id_Categoria"].Value.ToString();
                string id_tema = dataGridView1.SelectedRows[0].Cells["Id_Tema"].Value.ToString();

                txtDescricaoProduto.Text = descricao;
                txtQuantidadeProduto.Text = quantidade;
                txtCustoProduto.Text = descricao;
                txtTamanhoProduto.Text = tamanho;
                txtValorProduto.Text = valor;
                cmbCategoriaProduto.Text = id_categoria;
                cmbCorProduto.Text = id_cor;
                cmbTemaProduto.Text = id_tema;

                txtDescricaoProduto.Enabled = false;
                txtQuantidadeProduto.Enabled = false;
                txtCustoProduto.Enabled = false;
                txtTamanhoProduto.Enabled = false;
                txtValorProduto.Enabled = false;
                cmbCategoriaProduto.Enabled = false;
                cmbCorProduto.Enabled = false;
                cmbTemaProduto.Enabled = false;
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.");
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btnAdicionarCategoriaProduto_Click(object sender, EventArgs e)
        {
                frmCategoriaView add = new frmCategoriaView();
                add.ShowDialog();
        }

        private void btnAdicionarCorProduto_Click(object sender, EventArgs e)
        {
        }

        private void btnAdicionarTemaProduto_Click(object sender, EventArgs e)
        {
            frmTemaView add = new frmTemaView();
            add.ShowDialog();
        }
        private CategoriaDAO categoriaDAO = new CategoriaDAO();
        public void CarregarCategoria()
        {
            try
            {
                // Obtém os dados do banco de dados usando o CidadeDAO
                DataTable dataTable = categoriaDAO.GetAll();

                // Verifica se as colunas necessárias estão presentes
                if (!dataTable.Columns.Contains("Categoria") || !dataTable.Columns.Contains("Id"))
                {
                    MessageBox.Show("Não foram encontrados os dados de categoria");
                    return;
                }

                // Cria uma lista de objetos CidadeEstado a partir do DataTable
                List<Categoria> listaDeCategorias = new List<Categoria>();
                foreach (DataRow row in dataTable.Rows)
                {
                    // Obtém os valores das colunas Cidade, Id e Estado
                    int IdCategoria = Convert.ToInt32(row["Id"]);
                    string Categoria_nome = row["Cidade"].ToString();

                    // Adiciona o objeto CidadeEstado à lista
                    listaDeCategorias.Add(Categoria);
                }

                // Limpa os itens anteriores do ComboBox e define a nova fonte de dados
                cmbCategoriaProduto.DataSource = null;

                // Define a fonte de dados do ComboBox, exibindo o cidade e estado com o id como valor
                cmbCategoriaProduto.DataSource = listaDeCategorias;
                cmbCategoriaProduto.DisplayMember = "CategoriaConcatenado";  // Exibirá o nome do cidade e do Estado no ComboBox
                cmbCategoriaProduto.ValueMember = "IdCategoria";       // Associará o IdCidade como valor

                // Acessa o id_cidade selecionado diretamente pelo SelectedValue
                int categoriaSelecionado = Convert.ToInt32(cmbCategoriaProduto.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
    }
}