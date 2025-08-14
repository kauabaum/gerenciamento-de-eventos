using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Eventos.Model;

namespace Eventos.DAO
{
    public class ItensOrcamentoDAO
    {
        private DbContext dbContext = new DbContext();

        // Adicionar um novo item ao orçamento
        public void Add(ItemOrcamento itemOrcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO itens_orcamento (quantidade, subtotal, id_orcamento, id_produto) " +
                               "VALUES (@quantidade, @subtotal, @id_orcamento, @id_produto);";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@quantidade", itemOrcamento.Quantidade);
                cmd.Parameters.AddWithValue("@subtotal", itemOrcamento.Subtotal);
                cmd.Parameters.AddWithValue("@id_orcamento", itemOrcamento.IdOrcamento);
                cmd.Parameters.AddWithValue("@id_produto", itemOrcamento.IdProduto);

                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar um item do orçamento
        public void Update(ItemOrcamento itemOrcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "UPDATE itens_orcamento SET " +
                               "quantidade = @quantidade, " +
                               "subtotal = @subtotal, " +
                               "id_orcamento = @id_orcamento, " +
                               "id_produto = @id_produto " +
                               "WHERE id_itens = @id_itens;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_itens", itemOrcamento.IdItens);
                cmd.Parameters.AddWithValue("@quantidade", itemOrcamento.Quantidade);
                cmd.Parameters.AddWithValue("@subtotal", itemOrcamento.Subtotal);
                cmd.Parameters.AddWithValue("@id_orcamento", itemOrcamento.IdOrcamento);
                cmd.Parameters.AddWithValue("@id_produto", itemOrcamento.IdProduto);

                cmd.ExecuteNonQuery();
            }
        }

        // Deletar um item do orçamento
        public void Delete(int idItens)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM itens_orcamento WHERE id_itens = @id_itens;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_itens", idItens);

                cmd.ExecuteNonQuery();
            }
        }

        // Buscar um item pelo ID do orçamento
        public List<ItemOrcamento> GetByOrcamentoId(int idOrcamento)
        {
            List<ItemOrcamento> itensOrcamento = new List<ItemOrcamento>();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT id_itens, quantidade, subtotal, id_orcamento, id_produto " +
                               "FROM itens_orcamento WHERE id_orcamento = @id_orcamento;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_orcamento", idOrcamento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemOrcamento item = new ItemOrcamento
                        {
                            IdItens = reader.GetInt32("id_itens"),
                            Quantidade = reader.GetInt32("quantidade"),
                            Subtotal = reader.GetDouble("subtotal"),
                            IdOrcamento = reader.GetInt32("id_orcamento"),
                            IdProduto = reader.GetInt32("id_produto")
                        };

                        itensOrcamento.Add(item);
                    }
                }
            }

            return itensOrcamento;
        }

        // Buscar todos os itens do orçamento
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT id_itens, quantidade, subtotal, id_orcamento, id_produto FROM itens_orcamento;";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}
