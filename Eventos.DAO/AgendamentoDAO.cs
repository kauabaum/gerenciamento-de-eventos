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
using static Eventos.Model.Agendamento;

// CONTINUAR CORRIGINDO AQUI!!!!
namespace Eventos.DAO
{
    public class AgendamentoDAO
    {
        private DbContext dbContext = new DbContext();

        //Carregar todos os dados
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                "   FROM \r\n" +
                "   agendamento \r\n" +
                "   ORDER BY \r\n" +
                "   agendamento.tipo_evento \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        public Agendamento GetById(int idAgendamento)
        {
            Agendamento orc = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"SELECT id_agendamento, id_cliente, tipo_evento, total, 
                                data_emissao, local_evento, data_evento, 
                                hora_evento, tema
                                FROM agendamento
                                WHERE id_agendamento = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idAgendamento);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            orc = new Agendamento
                            {
                                IdAgendamento = reader.GetInt32("Id_Agendamento"),
                                IdCliente = reader.GetInt32("Id_Cliente"),
                                TipoEvento = reader.GetString("Tipo_Evento"),
                                Total = reader.GetDouble("Total"),
                                DataEmissao = reader.GetDateTime("Data_Emissao"),
                                LocalEvento = reader.GetString("Local_Evento"),
                                DataEvento = reader.GetDateTime("Data_Evento"),
                                HoraEvento = reader.GetString("Hora_Evento"),
                                Tema = reader.GetString("Tema"),
                            };
                        }
                    }
                }
            }

            return orc;
        }

        // Carregar dados no Grid
        public DataTable GetAgendamentoAsDataTable(string tipo_evento)
        {

            string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   agendamento \r\n" +
                "WHERE \r\n" +
                "    agendamento.tipo_evento LIKE CONCAT('%',@tipo_evento,'%') \r\n" +
                "ORDER BY \r\n" +
                "   agendamento.tipo_evento \r\n";


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

        // BUSCAR VIA CLIENTE

        /*public DataTable GetAgendamentoAsDataTableCliente(string nome_cliente)
        {

            string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   agendamento \r\n" +
                "WHERE \r\n" +
                "    agendamento.nome_cliente LIKE CONCAT('%',@nome_cliente,'%') \r\n" +
                "ORDER BY \r\n" +
                "   agendamento.nome_cliente \r\n";


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
        */
        public DataTable GetAgendamentoAsDataTableTema(string tema_evento)
        {

            string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   agendamento \r\n" +
                "WHERE \r\n" +
                "    agendamento.tema LIKE CONCAT('%',@tema_evento,'%') \r\n" +
                "ORDER BY \r\n" +
                "   agendamento.tema \r\n";


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
        public DataTable GetAgendamentoAsDataTableData(string data_evento)
        {

            string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                "FROM \r\n" +
                "   agendamento \r\n" +
                "WHERE \r\n" +
                "    agendamento.data_evento LIKE CONCAT('%',@data_evento,'%') \r\n" +
                "ORDER BY \r\n" +
                "   agendamento.data_evento \r\n";


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
        // Carregar dados da Pesquisa pelo nome do cliente TALVEZ AQUI
        public Agendamento GetByAgendamento(string Tipo_evento)
        {
            Agendamento agendamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   agendamento \r\n" +
                    "WHERE \r\n" +
                    "   tipo_evento \r\n" +
                    "LIKE CONCAT('%',@tipo_evento,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   agendamento.tipo_evento \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_evento", Tipo_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agendamento = new Agendamento()
                        {
                            IdAgendamento = reader.GetInt32("Id_Agendamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema")
                        };
                    }
                }
            }
            return agendamento;
        }


        // BUSCAR PELO CLIENTE **FIXXX
        public Agendamento GetByAgendamentoCliente(string Nome_cliente)
        {
            Agendamento agendamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.aprovacao AS Aprovacao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.validade AS Validade, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   agendamento \r\n" +
                    "WHERE \r\n" +
                    "   nome_cliente \r\n" +
                    "LIKE CONCAT('%',@nome_cliente,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   agendamento.nome_cliente \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_cliente", Nome_cliente);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agendamento = new Agendamento()
                        {
                            IdAgendamento = reader.GetInt32("Id_Agendamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema")
                        };
                    }
                }
            }
            return agendamento;
        }
        public Agendamento GetByAgendamentoTema(string Tema_evento)
        {
            Agendamento agendamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   agendamento \r\n" +
                    "WHERE \r\n" +
                    "   tema \r\n" +
                    "LIKE CONCAT('%',@tema_evento,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   agendamento.tema \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tema_evento", Tema_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agendamento = new Agendamento()
                        {
                            IdAgendamento = reader.GetInt32("Id_Agendamento"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            IdCliente = reader.GetInt32("Id_Cliente"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema")
                        };
                    }
                }
            }
            return agendamento;
        }
        public Agendamento GetByAgendamentoData(string Data_evento)
        {
            Agendamento agendamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT agendamento.id_agendamento AS Id_Agendamento, \r\n" +
                "   agendamento.nome_cliente AS Nome_Cliente, \r\n" +
                "   agendamento.tipo_evento AS Tipo_Evento, \r\n" +
                "   agendamento.total AS Total, \r\n" +
                "   agendamento.data_emissao AS Data_Emissao, \r\n" +
                "   agendamento.local_evento AS Local_Evento, \r\n" +
                "   agendamento.data_evento AS Data_Evento, \r\n" +
                "   agendamento.hora_evento AS Hora_Evento, \r\n" +
                "   agendamento.tema AS Tema \r\n" +
                    "FROM \r\n" +
                    "   agendamento \r\n" +
                    "WHERE \r\n" +
                    "   data_evento \r\n" +
                    "LIKE CONCAT('%',@data_evento,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   agendamento.data_evento \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data_evento", Data_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agendamento = new Agendamento()
                        {
                            IdAgendamento = reader.GetInt32("Id_Agendamento"),
                            IdCliente = reader.GetInt32("Id_Cliente"),
                            TipoEvento = reader.GetString("Tipo_Evento"),
                            Total = reader.GetDouble("Total"),
                            DataEmissao = reader.GetDateTime("Data_Emissao"),
                            LocalEvento = reader.GetString("Local_Evento"),
                            DataEvento = reader.GetDateTime("Data_Evento"),
                            HoraEvento = reader.GetString("Hora_Evento"),
                            Tema = reader.GetString("Tema")
                        };
                    }
                }
            }
            return agendamento;
        }

        // Adicionar novo Cliente
        public void Add(Agendamento agendamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                // Insere na tabela cliente
                string query = "INSERT INTO \r\n" +
                    "agendamento \r\n" +
                        "(tipo_evento, total, nome_cliente, data_emissao, local_evento, data_evento, \r\n" +
                        " hora_evento, tema) \r\n" +
                    "VALUES \r\n" +
                        "(@tipo_evento, @total, @nome_cliente, @data_emissao, @local_evento, @data_evento, \r\n" +
                        " @hora_evento, @tema_evento);";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_evento", agendamento.TipoEvento);
                cmd.Parameters.AddWithValue("@total", agendamento.Total);
                cmd.Parameters.AddWithValue("@nome_cliente", agendamento.IdCliente);
                cmd.Parameters.AddWithValue("@data_emissao", agendamento.DataEmissao);
                cmd.Parameters.AddWithValue("@local_evento", agendamento.LocalEvento);
                cmd.Parameters.AddWithValue("@data_evento", agendamento.DataEvento);
                cmd.Parameters.AddWithValue("@hora_evento", agendamento.HoraEvento);
                cmd.Parameters.AddWithValue("@tema_evento", agendamento.Tema);
                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar/editar dados
        public void Update(Agendamento agendamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "UPDATE \r\n" +
                    "   agendamento \r\n" +
                    "SET \r\n" +
                    "   agendamento.tipo_evento = @tipo_evento, \r\n" +
                    "   agendamento.total = @total, \r\n" +
                    "   agendamento.id_cliente = @nome_cliente, \r\n" +
                    "   agendamento.data_emissao = @data_emissao, \r\n" +
                    "   agendamento.local_evento = @local_evento, \r\n" +
                    "   agendamento.data_evento = @data_evento, \r\n" +
                    "   agendamento.hora_evento = @hora_evento, \r\n" +
                    "   agendamento.tema = @tema_evento \r\n" +
                    "WHERE \r\n" +
                    "   agendamento.id_agendamento = @id_agendamento\r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", agendamento.IdAgendamento);
                cmd.Parameters.AddWithValue("@tipo_evento", agendamento.TipoEvento);
                cmd.Parameters.AddWithValue("@nome_cliente", agendamento.IdCliente);
                cmd.Parameters.AddWithValue("@total", agendamento.Total);
                cmd.Parameters.AddWithValue("@data_emissao", agendamento.DataEmissao);
                cmd.Parameters.AddWithValue("@local_evento", agendamento.LocalEvento);
                cmd.Parameters.AddWithValue("@data_evento", agendamento.DataEvento);
                cmd.Parameters.AddWithValue("@hora_evento", agendamento.HoraEvento);
                cmd.Parameters.AddWithValue("@tema_evento", agendamento.Tema);
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir Dados
        public void Delete(Agendamento agendamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "DELETE \r\n" +
                    "FROM \r\n" +
                    "   agendamento \r\n" +
                    "WHERE \r\n" +
                    "   agendamento.id_agendamento = @id_agendamento";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", agendamento.IdAgendamento);
                cmd.ExecuteNonQuery();
            }
        }
        public DateTime? ObterDataEventoPorIdAgendamento(int idAgendamento)
        {
            DateTime? dataEvento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT data_evento FROM agendamento WHERE id_agendamento = @id_agendamento LIMIT 1;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", idAgendamento);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    dataEvento = Convert.ToDateTime(result);
                }
            }

            return dataEvento;
        }
    }
}
