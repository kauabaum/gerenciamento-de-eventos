using Eventos.Model;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Eventos.Model.Orcamento;

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

                string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                "   FROM \r\n" +
                "   orcamento \r\n" +
                "   ORDER BY \r\n" +
                "   orcamento.tipo_evento \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        public DataTable GetOrcamentosComProdutos()
        {
            DataTable dataTable = new DataTable();

            using (var dbContext = new DbContext())
            {
                string query = "SELECT " +
                               "    orcamento.nome_cliente AS Nome_Cliente, " +
                               "    produto.descricao AS Nome_Produto, " +
                               "    itens_orcamento.quantidade AS Quantidade, " +
                               "    itens_orcamento.subtotal AS Subtotal, " +
                               "    orcamento.id_orcamento AS Id_Orcamento, " +
                               "    itens_orcamento.id_itens AS Id_Itens, " +
                               "    produto.id_produto AS Id_Produto " +
                               "FROM orcamento " +
                               "JOIN itens_orcamento ON orcamento.id_orcamento = itens_orcamento.id_orcamento " +
                               "JOIN produto ON itens_orcamento.id_produto = produto.id_produto " +
                               "WHERE itens_orcamento.id_itens IS NOT NULL " +
                               "ORDER BY orcamento.data_emissao";

                MySqlCommand cmd = new MySqlCommand(query, dbContext.GetConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dataTable);
            }

            return dataTable;
        }





        // Carregar dados no Grid
        public DataTable GetOrcamentoAsDataTable(string tipo_evento)
        {

            string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   orcamento \r\n" +
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
        public DataTable GetOrcamentoAsDataTableCliente(string nome_cliente)
        {

            string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   orcamento \r\n" +
                "WHERE \r\n" +
                "    orcamento.nome_cliente LIKE CONCAT('%',@nome_cliente,'%') \r\n" +
                "ORDER BY \r\n" +
                "   orcamento.nome_cliente \r\n";


            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_cliente", nome_cliente);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable GetOrcamentoAsDataTableTema(string tema_evento)
        {

            string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   orcamento \r\n" +
                "WHERE \r\n" +
                "    orcamento.tema LIKE CONCAT('%',@tema_evento,'%') \r\n" +
                "ORDER BY \r\n" +
                "   orcamento.tema \r\n";


            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tema_evento", tema_evento);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable GetOrcamentoAsDataTableData(string data_evento)
        {

            string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   orcamento \r\n" +
                "WHERE \r\n" +
                "    orcamento.data_evento LIKE CONCAT('%',@data_evento,'%') \r\n" +
                "ORDER BY \r\n" +
                "   orcamento.data_evento \r\n";


            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data_evento", data_evento);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable GetOrcamentoAsDataTableStatus(string status)
        {

            string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   orcamento \r\n" +
                "WHERE \r\n" +
                "    orcamento.aprovacao LIKE CONCAT('%',@aprovacao,'%') \r\n" +
                "ORDER BY \r\n" +
                "   orcamento.aprovacao \r\n";


            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@aprovacao", status);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        // Carregar dados da Pesquisa pelo nome do cliente TALVEZ AQUI
        public Orcamento GetByOrcamento(string Tipo_evento)
        {
            Orcamento orcamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   orcamento \r\n" +
                    "WHERE \r\n" +
                    "   tipo_evento \r\n" +
                    "LIKE CONCAT('%',@tipo_evento,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   orcamento.tipo_evento \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_evento", Tipo_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orcamento = new Orcamento()
                        {
                            IdOrcamento = reader.GetInt32("Id_Orcamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), reader["Aprovacao"].ToString()),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema"),
                            Validade = reader.GetString("Validade")
                        };
                    }
                }
            }
            return orcamento;
        }
        public Orcamento GetByOrcamentoCliente(string Nome_cliente)
        {
            Orcamento orcamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   orcamento \r\n" +
                    "WHERE \r\n" +
                    "   nome_cliente \r\n" +
                    "LIKE CONCAT('%',@nome_cliente,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   orcamento.nome_cliente \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_cliente", Nome_cliente);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orcamento = new Orcamento()
                        {
                            IdOrcamento = reader.GetInt32("Id_Orcamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), reader["Aprovacao"].ToString()),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema"),
                            Validade = reader.GetString("Validade")
                        };
                    }
                }
            }
            return orcamento;
        }
        public Orcamento GetByOrcamentoTema(string Tema_evento)
        {
            Orcamento orcamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   orcamento \r\n" +
                    "WHERE \r\n" +
                    "   tema \r\n" +
                    "LIKE CONCAT('%',@tema_evento,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   orcamento.tema \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tema_evento", Tema_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orcamento = new Orcamento()
                        {
                            IdOrcamento = reader.GetInt32("Id_Orcamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            NomeCliente = reader.GetString("Nome_Cliente"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), reader["Aprovacao"].ToString()),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema"),
                            Validade = reader.GetString("Validade")
                        };
                    }
                }
            }
            return orcamento;
        }
        public Orcamento GetByOrcamentoData(string Data_evento)
        {
            Orcamento orcamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   orcamento \r\n" +
                    "WHERE \r\n" +
                    "   data_evento \r\n" +
                    "LIKE CONCAT('%',@data_evento,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   orcamento.data_evento \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data_evento", Data_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orcamento = new Orcamento()
                        {
                            IdOrcamento = reader.GetInt32("Id_Orcamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), reader["Aprovacao"].ToString()),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema"),
                            Validade = reader.GetString("Validade")
                        };
                    }
                }
            }
            return orcamento;
        }
        public Orcamento GetByOrcamentoStatus(string Status)
        {
            Orcamento orcamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT orcamento.id_orcamento AS Id_Orcamento, \r\n" +
                "   orcamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   orcamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   orcamento.total AS Total, \r\n" +
                "   orcamento.data_emissao AS Data_Emissao, \r\n" +
                "   orcamento.aprovacao AS Aprovacao, \r\n" +
                "   orcamento.local_evento AS Local_Evento, \r\n" +
                "   orcamento.data_evento AS Data_Evento, \r\n" +
                "   orcamento.hora_evento AS Hora_Evento, \r\n" +
                "   orcamento.validade AS Validade, \r\n" +
                "   orcamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   orcamento \r\n" +
                    "WHERE \r\n" +
                    "   aprovacao \r\n" +
                    "LIKE CONCAT('%',@aprovacao,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   orcamento.aprovacao \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@aprovacao", Status);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orcamento = new Orcamento()
                        {
                            IdOrcamento = reader.GetInt32("Id_Orcamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            NomeCliente = reader.GetString("Nome_Cliente"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            Aprovacao = (StatusAprovacao)Enum.Parse(typeof(StatusAprovacao), reader["Aprovacao"].ToString()),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema"),
                            Validade = reader.GetString("Validade")
                        };
                    }
                }
            }
            return orcamento;
        }

        // Adicionar novo Cliente
        public void Add(Orcamento orcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                // Insere na tabela cliente
                string query = "INSERT INTO \r\n" +
                    "orcamento \r\n" +
                        "(tipo_evento, total, nome_cliente, data_emissao, aprovacao, local_evento, data_evento, \r\n" +
                        " hora_evento, tema, validade) \r\n" +
                    "VALUES \r\n" +
                        "(@tipo_evento, @total, @nome_cliente, @data_emissao, @aprovacao, @local_evento, @data_evento, \r\n" +
                        " @hora_evento, @tema_evento, @validade);";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_evento", orcamento.TipoEvento);
                cmd.Parameters.AddWithValue("@total", orcamento.Total);
                cmd.Parameters.AddWithValue("@nome_cliente", orcamento.NomeCliente);
                cmd.Parameters.AddWithValue("@data_emissao", orcamento.DataEmissao);
                cmd.Parameters.AddWithValue("@aprovacao", orcamento.Aprovacao.ToString());
                cmd.Parameters.AddWithValue("@local_evento", orcamento.LocalEvento);
                cmd.Parameters.AddWithValue("@data_evento", orcamento.DataEvento);
                cmd.Parameters.AddWithValue("@hora_evento", orcamento.HoraEvento);
                cmd.Parameters.AddWithValue("@tema_evento", orcamento.Tema);
                cmd.Parameters.AddWithValue("@validade", orcamento.Validade);
                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar/editar dados
        public void Update(Orcamento orcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "UPDATE \r\n" +
                    "   orcamento \r\n" +
                    "SET \r\n" +
                    "   orcamento.tipo_evento = @tipo_evento, \r\n" +
                    "   orcamento.total = @total, \r\n" +
                    "   orcamento.nome_cliente = @nome_cliente, \r\n" +
                    "   orcamento.data_emissao = @data_emissao, \r\n" +
                    "   orcamento.aprovacao = @aprovacao, \r\n" +
                    "   orcamento.local_evento = @local_evento, \r\n" +
                    "   orcamento.data_evento = @data_evento, \r\n" +
                    "   orcamento.hora_evento = @hora_evento, \r\n" +
                    "   orcamento.tema = @tema_evento, \r\n" +
                    "   orcamento.validade = @validade \r\n" +
                    "WHERE \r\n" +
                    "   orcamento.id_orcamento = @id_orcamento\r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_orcamento", orcamento.IdOrcamento);
                cmd.Parameters.AddWithValue("@tipo_evento", orcamento.TipoEvento);
                cmd.Parameters.AddWithValue("@nome_cliente", orcamento.NomeCliente);
                cmd.Parameters.AddWithValue("@total", orcamento.Total);
                cmd.Parameters.AddWithValue("@data_emissao", orcamento.DataEmissao);
                cmd.Parameters.AddWithValue("@aprovacao", orcamento.Aprovacao.ToString());
                cmd.Parameters.AddWithValue("@local_evento", orcamento.LocalEvento);
                cmd.Parameters.AddWithValue("@data_evento", orcamento.DataEvento);
                cmd.Parameters.AddWithValue("@hora_evento", orcamento.HoraEvento);
                cmd.Parameters.AddWithValue("@tema_evento", orcamento.Tema);
                cmd.Parameters.AddWithValue("@validade", orcamento.Validade);
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir Dados
        public void Delete(Orcamento orcamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "DELETE \r\n" +
                    "FROM \r\n" +
                    "   orcamento \r\n" +
                    "WHERE \r\n" +
                    "   orcamento.id_orcamento = @id_orcamento";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_orcamento", orcamento.IdOrcamento);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
