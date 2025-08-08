using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Model;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

// CONTINUAR CORRIGINDO AQUI!!!!
namespace Eventos.DAO
{
    public class OrcamentoDAO
    {
        private DbContext dbContext = new DbContext();

        //Carregar todos os dados
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT Orcamento.id_Orcamento AS Id_Orcamento, \r\n" +
                    "   Orcamento.descricao AS Descrição, \r\n" +
                    "   Orcamento.tamanho AS Tamanho, \r\n" +
                    "   Orcamento.quantidade AS Quantidade, \r\n" +
                    "   Orcamento.valor AS Valor, \r\n" +
                    "   Orcamento.custo AS Custo, \r\n" +
                    "   cor.cor_nome AS Nome_Cor, \r\n" +
                    "   cor.cod_rgb_hexa_cmyk AS Cod_Cor, \r\n" +
                    "   tema.tema_nome AS Nome_Tema, \r\n" +
                    "   categoria.categoria_nome AS Nome_Categoria \r\n" +
                    "FROM \r\n" +
                    "   Orcamento \r\n" +
                    "INNER JOIN \r\n" +
                    "   cor ON Orcamento.id_cor = cor.id_cor \r\n" +
                    "INNER JOIN \r\n" +
                    "    tema ON Orcamento.id_tema = tema.id_tema \r\n" +
                    "INNER JOIN \r\n" +
                    "   categoria ON Orcamento.id_categoria = categoria.id_categoria \r\n" +
                    "ORDER BY \r\n" +
                    "   Orcamento.descricao \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        // Carregar dados no Grid
        public DataTable GetOrcamentoAsDataTable(string tipo_evento)
        {

            string query = "SELECT Orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   tema.tema_nome AS Nome_Tema, \r\n" +
                "   categoria.categoria_nome AS Nome_Categoria \r\n" +
                "FROM \r\n" +
                "   orcamento \r\n" +
                "INNER JOIN \r\n" +
                "    tema ON Orcamento.id_tema = tema.id_tema \r\n" +
                "WHERE \r\n" +
                "    orcamento.tipo_evento LIKE CONCAT('%',@tipo_evento,'%') \r\n" +
                "ORDER BY \r\n" +
                "   orcamento.tipo_evento \r\n";


            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_evento", tipo_evento);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // Carregar dados da Pesquisa pelo nome do cliente TALVEZ AQUI
        public Orcamento GetByOrcamento(string Tipo_evento)
        {
            Orcamento Orcamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT Orcamento.id_Orcamento AS Id_Orcamento, \r\n" +
                    "   Orcamento.descricao AS Descrição, \r\n" +
                    "   Orcamento.tamanho AS Tamanho, \r\n" +
                    "   Orcamento.quantidade AS Quantidade, \r\n" +
                    "   Orcamento.valor AS Valor, \r\n" +
                    "   Orcamento.custo AS Custo, \r\n" +
                    "   cor.cod_rgb_hexa_cmyk AS Cod_Cor, \r\n" +
                    "   cor.cor_nome AS Nome_Cor, \r\n" + 
                    "   tema.tema_nome AS Nome_Tema, \r\n" +
                    "   categoria.categoria_nome AS Nome_Categoria \r\n" +
                    "FROM \r\n" +
                    "   Orcamento \r\n" +
                    "INNER JOIN \r\n" +
                    "   categoria ON Orcamento.id_categoria = categoria.id_categoria \r\n" +
                    "INNER JOIN \r\n" +
                    "   cor ON Orcamento.id_cor = cor.id_cor \r\n" +
                    "INNER JOIN \r\n" +
                    "   tema ON Orcamento.id_tema = tema.id_tema \r\n" +
                    "WHERE \r\n" +
                    "   descricao \r\n" +
                    "LIKE CONCAT('%',@descricao,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   Orcamento.descricao \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@descricao", Tipo_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Orcamento = new Orcamento()
                        {
                            IdOrcamento = reader.GetInt32("Id_Orcamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            Aprovacao = reader.GetString("Aprovacao"),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            IdTema = reader.GetInt32("IdTema"),
                            TemaNome = reader.GetString("Nome_Tema"),
                            Validade = reader.GetString("Validade")
                        };
                    }
                }
            }
            return Orcamento;
        }

        // Adicionar novo Cliente
        public void Add(Orcamento Orcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                // Insere na tabela cliente
                string query = "INSERT INTO \r\n" +
                    "Orcamento \r\n" +
                        "(descricao, tamanho, quantidade, valor, custo, id_cor, \r\n" +
                        " id_tema, id_categoria) \r\n" +
                    "VALUES \r\n" +
                        "(@descricao, @tamanho, @quantidade, @valor, @custo, @id_cor, \r\n" +
                        " @id_tema, @id_categoria);";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@descricao", Orcamento.Descricao);
                cmd.Parameters.AddWithValue("@tamanho", Orcamento.Tamanho);
                cmd.Parameters.AddWithValue("@quantidade", Orcamento.Quantidade);
                cmd.Parameters.AddWithValue("@valor", Orcamento.Valor);
                cmd.Parameters.AddWithValue("@custo", Orcamento.Custo);
                cmd.Parameters.AddWithValue("@id_cor", Orcamento.IdCor);
                cmd.Parameters.AddWithValue("@id_tema", Orcamento.IdTema);
                cmd.Parameters.AddWithValue("@id_categoria", Orcamento.IdCategoria);
                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar/editar dados
        public void Update(Orcamento Orcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "UPDATE \r\n" +
                    "   Orcamento \r\n" +
                    "SET \r\n" +
                    "   Orcamento.descricao = @descricao, \r\n" +
                    "   Orcamento.tamanho = @tamanho, \r\n" +
                    "   Orcamento.quantidade = @quantidade, \r\n" +
                    "   Orcamento.valor = @valor, \r\n" +
                    "   Orcamento.custo = @custo, \r\n" +
                    "   Orcamento.id_cor = @id_cor, \r\n" +
                    "   Orcamento.id_tema = @id_tema, \r\n" +
                    "   Orcamento.id_categoria = @id_categoria \r\n" +
                    "WHERE \r\n" +
                    "   Orcamento.id_Orcamento = @id_Orcamento\r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_Orcamento", Orcamento.IdOrcamento);
                cmd.Parameters.AddWithValue("@descricao", Orcamento.Descricao);
                cmd.Parameters.AddWithValue("@tamanho", Orcamento.Tamanho);
                cmd.Parameters.AddWithValue("@quantidade", Orcamento.Quantidade);
                cmd.Parameters.AddWithValue("@valor", Orcamento.Valor);
                cmd.Parameters.AddWithValue("@custo", Orcamento.Custo);
                cmd.Parameters.AddWithValue("@id_cor", Orcamento.IdCor);
                cmd.Parameters.AddWithValue("@id_tema", Orcamento.IdTema);
                cmd.Parameters.AddWithValue("@id_categoria", Orcamento.IdCategoria);
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir Dados
        public void Delete(Orcamento Orcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "DELETE \r\n" +
                    "FROM \r\n" +
                    "   Orcamento \r\n" +
                    "WHERE \r\n" +
                    "   Orcamento.id_Orcamento = @id_Orcamento";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_Orcamento", Orcamento.IdOrcamento);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
