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
            CarregarCategoria();
            CarregarTema();
            CarregarCor();
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
            cmbTemaProduto.ResetText();
            cmbCorProduto.ResetText();
            cmbCategoriaProduto.ResetText();
            txtValorProduto.ResetText();
            txtTamanhoProduto.ResetText();
            txtCustoProduto.ResetText();
            txtQuantidadeProduto.ResetText();
            txtDescricaoProduto.ResetText();
            CarregarCategoria();
            CarregarTema();
            CarregarCor();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtDescricaoProduto.Enabled = true;
            txtQuantidadeProduto.Enabled = false;
            txtCustoProduto.Enabled = false;
            txtTamanhoProduto.Enabled = false;
            txtValorProduto.Enabled = false;
            cmbCategoriaProduto.Enabled = false;
            cmbCorProduto.Enabled = false;
            cmbTemaProduto.Enabled = false;
            cmbTemaProduto.ResetText();
            cmbCorProduto.ResetText();
            cmbCategoriaProduto.ResetText();
            txtValorProduto.ResetText();
            txtTamanhoProduto.ResetText();
            txtCustoProduto.ResetText();
            txtQuantidadeProduto.ResetText();
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

                if (produtoIdSelecionado.HasValue)
                {
                    // Atualizar o cliente existente
                    Produto produtoAtualizado = new Produto()
                    {
                        IdProduto = produtoIdSelecionado.Value,
                        Descricao = descricao,
                        Tamanho = tamanho,
                        Quantidade = Convert.ToDouble(quantidade),
                        Custo = Convert.ToDouble(custo),
                        Valor = Convert.ToDouble(valor),
                        IdTema = cmbTemaProduto.SelectedValue.GetHashCode(),
                        IdCategoria = cmbCategoriaProduto.SelectedValue.GetHashCode(),
                        IdCor = cmbCorProduto.SelectedValue.GetHashCode()

                    };

                    produtoDAO.Update(produtoAtualizado);
                    MessageBox.Show("Produto atualizado com sucesso!");
                }
                else
                {
                    // Adicionar novo cliente
                    Produto novoProduto = new Produto()
                    {
                        Descricao = descricao,
                        Tamanho = tamanho,
                        Quantidade = Convert.ToDouble(quantidade),
                        Custo = Convert.ToDouble(custo),
                        Valor = Convert.ToDouble(valor),
                        IdTema = Convert.ToInt32(cmbTemaProduto.SelectedValue),
                        IdCategoria = Convert.ToInt32(cmbCategoriaProduto.SelectedValue),
                        IdCor = Convert.ToInt32(cmbCorProduto.SelectedValue)
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
                cmbTemaProduto.ResetText();
                cmbCorProduto.ResetText();
                cmbCategoriaProduto.ResetText();
                txtValorProduto.ResetText();
                txtTamanhoProduto.ResetText();
                txtCustoProduto.ResetText();
                txtQuantidadeProduto.ResetText();
                txtDescricaoProduto.ResetText();

                // Recarregar os dados no DataGridView após salvar
                CarregarDados();
                CarregarCategoria();
                CarregarCor();
                CarregarTema();
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
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obter o ID do cliente selecionado no DataGridView
                    produtoIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Produto"].Value);
                }
                else
                {
                    MessageBox.Show("Selecione um produto para editar.");
                }

                if (produtoIdSelecionado.HasValue)
                {
                    // Excluir o Cliente
                    Produto produtoAtualizado = new Produto()
                    {
                        IdProduto = produtoIdSelecionado.Value,
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
                    cmbTemaProduto.ResetText();
                    cmbCorProduto.ResetText();
                    cmbCategoriaProduto.ResetText();
                    txtValorProduto.ResetText();
                    txtTamanhoProduto.ResetText();
                    txtCustoProduto.ResetText();
                    txtQuantidadeProduto.ResetText();
                    txtDescricaoProduto.ResetText();

                    // Recarregar os dados no DataGridView após salvar
                    CarregarDados();
                    CarregarCategoria();
                    CarregarTema();
                    CarregarCor();
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
                cmbTemaProduto.ResetText();
                cmbCorProduto.ResetText();
                cmbCategoriaProduto.ResetText();
                txtValorProduto.ResetText();
                txtTamanhoProduto.ResetText();
                txtCustoProduto.ResetText();
                txtQuantidadeProduto.ResetText();
                txtDescricaoProduto.ResetText();

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
            cmbTemaProduto.ResetText();
            cmbCorProduto.ResetText();
            cmbCategoriaProduto.ResetText();
            txtValorProduto.ResetText();
            txtTamanhoProduto.ResetText();
            txtCustoProduto.ResetText();
            txtQuantidadeProduto.ResetText();
            txtDescricaoProduto.ResetText();
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
                produtoIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Produto"].Value);

                // Obter a descrição do cliente e carregar no TextBox
                string descricao = dataGridView1.SelectedRows[0].Cells["Descrição"].Value.ToString();
                string quantidade = dataGridView1.SelectedRows[0].Cells["Quantidade"].Value.ToString();
                string custo = dataGridView1.SelectedRows[0].Cells["Custo"].Value.ToString();
                string tamanho = dataGridView1.SelectedRows[0].Cells["Tamanho"].Value.ToString();
                string valor = dataGridView1.SelectedRows[0].Cells["Valor"].Value.ToString();
                string id_cor = dataGridView1.SelectedRows[0].Cells["Cod_Cor"].Value.ToString();
                string id_categoria = dataGridView1.SelectedRows[0].Cells["Nome_Categoria"].Value.ToString();
                string id_tema = dataGridView1.SelectedRows[0].Cells["Nome_Tema"].Value.ToString();

                txtDescricaoProduto.Text = descricao;
                txtQuantidadeProduto.Text = quantidade;
                txtCustoProduto.Text = custo;
                txtTamanhoProduto.Text = tamanho;
                txtValorProduto.Text = valor;
                cmbCategoriaProduto.Text = id_categoria;
                cmbCorProduto.Text = id_cor;
                cmbTemaProduto.Text = id_tema;

                txtDescricaoProduto.Enabled = true;
                txtQuantidadeProduto.Enabled = true;
                txtCustoProduto.Enabled = true;
                txtTamanhoProduto.Enabled = true;
                txtValorProduto.Enabled = true;
                cmbCategoriaProduto.Enabled = true;
                cmbCorProduto.Enabled = true;
                cmbTemaProduto.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.");
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
            CarregarCategoria();
            CarregarTema();
            CarregarCor();
            cmbTemaProduto.ResetText();
            cmbCorProduto.ResetText();
            cmbCategoriaProduto.ResetText();
            txtValorProduto.ResetText();
            txtTamanhoProduto.ResetText();
            txtCustoProduto.ResetText();
            txtQuantidadeProduto.ResetText();
            txtDescricaoProduto.ResetText();
        }

        private void btnAdicionarCategoriaProduto_Click(object sender, EventArgs e)
        {
                frmCategoriaView add = new frmCategoriaView();
                add.ShowDialog();
        }

        private void btnAdicionarCorProduto_Click(object sender, EventArgs e)
        {
            frmCorView add = new frmCorView();
            add.ShowDialog();
        }

        private void btnAdicionarTemaProduto_Click(object sender, EventArgs e)
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
                    cmbTemaProduto.DataSource = dataTable;
                    cmbTemaProduto.DisplayMember = "Tema";
                    cmbTemaProduto.ValueMember = "Id";
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
        private CorDAO corDAO = new CorDAO();
        private void CarregarCor()
        {
            try
            {
                // Obtém os dados do banco de dados usando o EstadoDAO

                DataTable dataTable = corDAO.GetAll();

                // Verifica se as colunas necessárias estão presentes
                if (dataTable.Columns.Contains("Cor") && dataTable.Columns.Contains("Id") && dataTable.Columns.Contains("Cod_Cor"))
                {
                    cmbCorProduto.DataSource = dataTable;
                    cmbCorProduto.DisplayMember = "Cor";
                    cmbCorProduto.ValueMember = "Id";
                    cmbCorProduto.DisplayMember = "Cod_Cor";
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

        private CategoriaDAO categoriaDAO = new CategoriaDAO();
        private void CarregarCategoria()
        {
            try
            {
                // Obtém os dados do banco de dados usando o EstadoDAO
                DataTable dataTable = categoriaDAO.GetAll();

                // Verifica se as colunas necessárias estão presentes
                if (dataTable.Columns.Contains("Categoria") && dataTable.Columns.Contains("Id"))
                {
                    cmbCategoriaProduto.DataSource = dataTable;
                    cmbCategoriaProduto.DisplayMember = "Categoria";
                    cmbCategoriaProduto.ValueMember = "Id";
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
    }
}