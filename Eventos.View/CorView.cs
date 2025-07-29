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

namespace Eventos.View
{
    public partial class frmCorView : Form
    {
        String mensagem = "";

        public frmCorView()
        {
            InitializeComponent();
            txtCor.Enabled = false;
            txtCodCor.Enabled = false;
            CarregarDados();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtCor.Enabled = true;
            txtCodCor.Enabled = true;
            txtCodCor.ResetText();
            txtCor.ResetText();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtCor.Enabled = true;
            txtCodCor.Enabled = true;
            txtCodCor.ResetText();
            txtCor.ResetText();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtCor.Text;
                string cod_cor = txtCodCor.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }
                if (string.IsNullOrEmpty(cod_cor))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }

                if (corIdSelecionado.HasValue)
                {
                    // Atualizar o cor existente
                    Cor corAtualizado = new Cor()
                    {
                        IdCor = corIdSelecionado.Value,
                        CorNome = descricao,
                        CodCor = cod_cor
                    };

                    corDAO.Update(corAtualizado);
                    MessageBox.Show("Cor atualizado com sucesso!");
                }
                else
                {
                    // Adicionar novo cor
                    Cor novoCor = new Cor()
                    {
                        CorNome = descricao,
                        CodCor = cod_cor
                    };

                    corDAO.Add(novoCor);
                    MessageBox.Show("Cor salvo com sucesso!");
                }

                // Limpar o TextBox
                txtCor.Text = string.Empty;
                txtCor.Enabled = false;
                corIdSelecionado = null;

                // Recarregar os dados no DataGridView após salvar
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cor: {ex.Message}");
            }
        }

        private int? corIdSelecionado = null;

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtCor.Text;
                string cod_cor = txtCor.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }
                if (string.IsNullOrEmpty(cod_cor))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }

                if (corIdSelecionado.HasValue)
                {
                    // Excluir o Cor
                    Cor corAtualizado = new Cor()
                    {
                        IdCor = corIdSelecionado.Value,
                        CorNome = descricao,
                        CodCor = cod_cor
                    };

                    corDAO.Delete(corAtualizado);
                    MessageBox.Show("Cor Excluído com sucesso!");

                    // Limpar o TextBox
                    txtCor.Text = string.Empty;
                    txtCor.Enabled = false;
                    corIdSelecionado = null;
                    txtCodCor.Enabled = false;
                    txtCodCor.ResetText();
                    txtCor.ResetText();

                    // Recarregar os dados no DataGridView após salvar
                    CarregarDados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Excluir cor: {ex.Message}");
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtCor.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }

                string cod_cor = txtCodCor.Text;

                if (string.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("A descrição é obrigatória.");
                    return;
                }

                var cor = corDAO.GetByCor(descricao);
                var codcor = corDAO.GetByCor(cod_cor);

                if (cor != null)
                {
                    // Se o cor for encontrado, mostrar os dados no DataGridView
                    DataTable dataTable = corDAO.GetCorAsDataTable(descricao);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Cor não encontrado.");
                }

                txtCor.Text = string.Empty;
                txtCor.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cor: {ex.Message}");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCor.Enabled = false;
            txtCodCor.Enabled = false;
            txtCodCor.ResetText();
            txtCor.ResetText();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private CorDAO corDAO = new CorDAO();
        private void CarregarDados()
        {
            try
            {
                DataTable dataTable = corDAO.GetAll();
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
                // Obter o ID do cor selecionado no DataGridView
                corIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Obter a descrição do cor e carregar no TextBox
                string descricao = dataGridView1.SelectedRows[0].Cells["Cor"].Value.ToString();
                txtCor.Text = descricao;
                string cod_cor = dataGridView1.SelectedRows[0].Cells["Cod_Cor"].Value.ToString();
                txtCodCor.Text = cod_cor;

                txtCor.Enabled = true;
                txtCodCor.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecione um cor para editar.");
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void lblTema_Click(object sender, EventArgs e)
        {

        }
    }
}
