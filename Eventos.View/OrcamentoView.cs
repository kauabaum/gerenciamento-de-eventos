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
    public partial class frmOrcamentoView : Form
    {
        String mensagem = "";

        public frmOrcamentoView()
        {
            InitializeComponent();
            txtDescricaoOrcamento.Enabled = false;
            txtQuantidadeOrcamento.Enabled = false;
            txtCustoOrcamento.Enabled = false;
            txtTamanhoOrcamento.Enabled = false;
            txtValorOrcamento.Enabled = false;
            cmbCategoriaOrcamento.Enabled = false;
            cmbCorOrcamento.Enabled = false;
            cmbTemaOrcamento.Enabled = false;
            CarregarDados();
            CarregarCategoria();
            CarregarTema();
            CarregarCor();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtDescricaoOrcamento.Enabled = true;
            txtQuantidadeOrcamento.Enabled = true;
            txtCustoOrcamento.Enabled = true;
            txtTamanhoOrcamento.Enabled = true;
            txtValorOrcamento.Enabled = true;
            cmbCategoriaOrcamento.Enabled = true;
            cmbCorOrcamento.Enabled = true;
            cmbTemaOrcamento.Enabled = true;
            cmbTemaOrcamento.ResetText();
            cmbCorOrcamento.ResetText();
            cmbCategoriaOrcamento.ResetText();
            txtValorOrcamento.ResetText();
            txtTamanhoOrcamento.ResetText();
            txtCustoOrcamento.ResetText();
            txtQuantidadeOrcamento.ResetText();
            txtDescricaoOrcamento.ResetText();
            CarregarCategoria();
            CarregarTema();
            CarregarCor();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtDescricaoOrcamento.Enabled = true;
            txtQuantidadeOrcamento.Enabled = false;
            txtCustoOrcamento.Enabled = false;
            txtTamanhoOrcamento.Enabled = false;
            txtValorOrcamento.Enabled = false;
            cmbCategoriaOrcamento.Enabled = false;
            cmbCorOrcamento.Enabled = false;
            cmbTemaOrcamento.Enabled = false;
            cmbTemaOrcamento.ResetText();
            cmbCorOrcamento.ResetText();
            cmbCategoriaOrcamento.ResetText();
            txtValorOrcamento.ResetText();
            txtTamanhoOrcamento.ResetText();
            txtCustoOrcamento.ResetText();
            txtQuantidadeOrcamento.ResetText();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtDescricaoOrcamento.Text;
                string custo = txtCustoOrcamento.Text;
                string tamanho = txtTamanhoOrcamento.Text;
                string quantidade = txtQuantidadeOrcamento.Text;
                string valor = txtValorOrcamento.Text;

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

                if (produtoIdOrcamento.HasValue)
                {
                    // Atualizar o cliente existente
                    Orcamento produtoAtualizado = new Orcamento()
                    {
                        IdOrcamento = produtoIdOrcamento.Value,
                        Descricao = descricao,
                        Tamanho = tamanho,
                        Quantidade = Convert.ToDouble(quantidade),
                        Custo = Convert.ToDouble(custo),
                        Valor = Convert.ToDouble(valor),
                        IdTema = cmbTemaOrcamento.SelectedValue.GetHashCode(),
                        IdCategoria = cmbCategoriaOrcamento.SelectedValue.GetHashCode(),
                        IdCor = cmbCorOrcamento.SelectedValue.GetHashCode()

                    };

                    produtoDAO.Update(produtoAtualizado);
                    MessageBox.Show("Orcamento atualizado com sucesso!");
                }
                else
                {
                    // Adicionar novo cliente
                    Orcamento novoOrcamento = new Orcamento()
                    {
                        Descricao = descricao,
                        Tamanho = tamanho,
                        Quantidade = Convert.ToDouble(quantidade),
                        Custo = Convert.ToDouble(custo),
                        Valor = Convert.ToDouble(valor),
                        IdTema = Convert.ToInt32(cmbTemaOrcamento.SelectedValue),
                        IdCategoria = Convert.ToInt32(cmbCategoriaOrcamento.SelectedValue),
                        IdCor = Convert.ToInt32(cmbCorOrcamento.SelectedValue)
                    };

                    produtoDAO.Add(novoOrcamento);
                    MessageBox.Show("Orcamento salvo com sucesso!");
                }

                // Limpar o TextBox
                txtDescricaoOrcamento.Text = string.Empty;
                txtDescricaoOrcamento.Enabled = false;
                txtQuantidadeOrcamento.Text = string.Empty;
                txtQuantidadeOrcamento.Enabled = false;
                txtCustoOrcamento.Text = string.Empty;
                txtCustoOrcamento.Enabled = false;
                produtoIdOrcamento = null;
                cmbTemaOrcamento.ResetText();
                cmbCorOrcamento.ResetText();
                cmbCategoriaOrcamento.ResetText();
                txtValorOrcamento.ResetText();
                txtTamanhoOrcamento.ResetText();
                txtCustoOrcamento.ResetText();
                txtQuantidadeOrcamento.ResetText();
                txtDescricaoOrcamento.ResetText();

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

        private int? produtoIdOrcamento = null;

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obter o ID do cliente selecionado no DataGridView
                    produtoIdOrcamento = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Orcamento"].Value);
                }
                else
                {
                    MessageBox.Show("Selecione um produto para editar.");
                }

                if (produtoIdOrcamento.HasValue)
                {
                    // Excluir o Cliente
                    Orcamento produtoAtualizado = new Orcamento()
                    {
                        IdOrcamento = produtoIdOrcamento.Value,
                    };

                    produtoDAO.Delete(produtoAtualizado);
                    MessageBox.Show("Orcamento Excluído com sucesso!");

                    // Limpar o TextBox
                    txtDescricaoOrcamento.Text = string.Empty;
                    txtDescricaoOrcamento.Enabled = false;
                    txtQuantidadeOrcamento.Text = string.Empty;
                    txtQuantidadeOrcamento.Enabled = false;
                    txtCustoOrcamento.Text = string.Empty;
                    txtCustoOrcamento.Enabled = false;
                    produtoIdOrcamento = null;
                    cmbTemaOrcamento.ResetText();
                    cmbCorOrcamento.ResetText();
                    cmbCategoriaOrcamento.ResetText();
                    txtValorOrcamento.ResetText();
                    txtTamanhoOrcamento.ResetText();
                    txtCustoOrcamento.ResetText();
                    txtQuantidadeOrcamento.ResetText();
                    txtDescricaoOrcamento.ResetText();

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
                string descricao = txtDescricaoOrcamento.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }

                var produto = produtoDAO.GetByOrcamento(descricao);

                if (produto != null)
                {
                    // Se o cliente for encontrado, mostrar os dados no DataGridView
                    DataTable dataTable = produtoDAO.GetOrcamentoAsDataTable(descricao);
                    dataGridView1.DataSource = dataTable;

                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.");
                }

                // Limpar o TextBox
                txtDescricaoOrcamento.Enabled = false;
                txtQuantidadeOrcamento.Enabled = false;
                txtCustoOrcamento.Enabled = false;
                txtTamanhoOrcamento.Enabled = false;
                txtValorOrcamento.Enabled = false;
                cmbCategoriaOrcamento.Enabled = false;
                cmbCorOrcamento.Enabled = false;
                cmbTemaOrcamento.Enabled = false;
                cmbTemaOrcamento.ResetText();
                cmbCorOrcamento.ResetText();
                cmbCategoriaOrcamento.ResetText();
                txtValorOrcamento.ResetText();
                txtTamanhoOrcamento.ResetText();
                txtCustoOrcamento.ResetText();
                txtQuantidadeOrcamento.ResetText();
                txtDescricaoOrcamento.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cliente: {ex.Message}");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar o TextBox
            txtDescricaoOrcamento.Enabled = false;
            txtQuantidadeOrcamento.Enabled = false;
            txtCustoOrcamento.Enabled = false;
            txtTamanhoOrcamento.Enabled = false;
            txtValorOrcamento.Enabled = false;
            cmbCategoriaOrcamento.Enabled = false;
            cmbCorOrcamento.Enabled = false;
            cmbTemaOrcamento.Enabled = false;
            cmbTemaOrcamento.ResetText();
            cmbCorOrcamento.ResetText();
            cmbCategoriaOrcamento.ResetText();
            txtValorOrcamento.ResetText();
            txtTamanhoOrcamento.ResetText();
            txtCustoOrcamento.ResetText();
            txtQuantidadeOrcamento.ResetText();
            txtDescricaoOrcamento.ResetText();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Carrega dados no GRID
        private OrcamentoDAO produtoDAO = new OrcamentoDAO();
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
                produtoIdOrcamento = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Orcamento"].Value);

                // Obter a descrição do cliente e carregar no TextBox
                string descricao = dataGridView1.SelectedRows[0].Cells["Descrição"].Value.ToString();
                string quantidade = dataGridView1.SelectedRows[0].Cells["Quantidade"].Value.ToString();
                string custo = dataGridView1.SelectedRows[0].Cells["Custo"].Value.ToString();
                string tamanho = dataGridView1.SelectedRows[0].Cells["Tamanho"].Value.ToString();
                string valor = dataGridView1.SelectedRows[0].Cells["Valor"].Value.ToString();
                string id_cor = dataGridView1.SelectedRows[0].Cells["Cod_Cor"].Value.ToString();
                string id_categoria = dataGridView1.SelectedRows[0].Cells["Nome_Categoria"].Value.ToString();
                string id_tema = dataGridView1.SelectedRows[0].Cells["Nome_Tema"].Value.ToString();

                txtDescricaoOrcamento.Text = descricao;
                txtQuantidadeOrcamento.Text = quantidade;
                txtCustoOrcamento.Text = custo;
                txtTamanhoOrcamento.Text = tamanho;
                txtValorOrcamento.Text = valor;
                cmbCategoriaOrcamento.Text = id_categoria;
                cmbCorOrcamento.Text = id_cor;
                cmbTemaOrcamento.Text = id_tema;

                txtDescricaoOrcamento.Enabled = true;
                txtQuantidadeOrcamento.Enabled = true;
                txtCustoOrcamento.Enabled = true;
                txtTamanhoOrcamento.Enabled = true;
                txtValorOrcamento.Enabled = true;
                cmbCategoriaOrcamento.Enabled = true;
                cmbCorOrcamento.Enabled = true;
                cmbTemaOrcamento.Enabled = true;
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
            cmbTemaOrcamento.ResetText();
            cmbCorOrcamento.ResetText();
            cmbCategoriaOrcamento.ResetText();
            txtValorOrcamento.ResetText();
            txtTamanhoOrcamento.ResetText();
            txtCustoOrcamento.ResetText();
            txtQuantidadeOrcamento.ResetText();
            txtDescricaoOrcamento.ResetText();
        }

        private void btnAdicionarCategoriaOrcamento_Click(object sender, EventArgs e)
        {
                frmCategoriaView add = new frmCategoriaView();
                add.ShowDialog();
        }

        private void btnAdicionarCorOrcamento_Click(object sender, EventArgs e)
        {
            frmCorView add = new frmCorView();
            add.ShowDialog();
        }

        private void btnAdicionarTemaOrcamento_Click(object sender, EventArgs e)
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
                    cmbTemaOrcamento.DataSource = dataTable;
                    cmbTemaOrcamento.DisplayMember = "Tema";
                    cmbTemaOrcamento.ValueMember = "Id";
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
                    cmbCorOrcamento.DataSource = dataTable;
                    cmbCorOrcamento.DisplayMember = "Cor";
                    cmbCorOrcamento.ValueMember = "Id";
                    cmbCorOrcamento.DisplayMember = "Cod_Cor";
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
                    cmbCategoriaOrcamento.DataSource = dataTable;
                    cmbCategoriaOrcamento.DisplayMember = "Categoria";
                    cmbCategoriaOrcamento.ValueMember = "Id";
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