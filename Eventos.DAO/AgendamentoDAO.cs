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

                string query = @"
            SELECT 
                agendamento.id_agendamento AS Id_Agendamento,
                agendamento.id_cliente AS Id_Cliente,
                cliente.nome AS Nome_Cliente,
                agendamento.tipo_evento AS Tipo_Evento,
                agendamento.total AS Total,
                agendamento.data_emissao AS Data_Emissao,
                agendamento.local_evento AS Local_Evento,
                agendamento.data_evento AS Data_Evento,
                agendamento.hora_evento AS Hora_Evento,
                agendamento.tema AS Tema
            FROM agendamento
            INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
            ORDER BY agendamento.tipo_evento;
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        public int GetLastInsertedId()
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public DataTable GetAgendamentosDaSemana()
        {
            string query = @"
        SELECT 
            agendamento.id_agendamento AS Id_Agendamento,
            agendamento.id_cliente AS Id_Cliente,
            cliente.nome AS Nome_Cliente,
            agendamento.tipo_evento AS Tipo_Evento,
            agendamento.total AS Total,
            agendamento.data_emissao AS Data_Emissao,
            agendamento.local_evento AS Local_Evento,
            agendamento.data_evento AS Data_Evento,
            agendamento.hora_evento AS Hora_Evento,
            agendamento.tema AS Tema
        FROM 
            agendamento
        INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
        WHERE 
            agendamento.data_evento BETWEEN @inicioSemana AND @fimSemana
        ORDER BY 
            agendamento.data_evento ASC
    ";

            // Calcula a segunda-feira e domingo da semana atual
            DateTime hoje = DateTime.Today;
            int diffParaSegunda = (7 + (hoje.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime inicioSemana = hoje.AddDays(-diffParaSegunda); // segunda-feira
            DateTime fimSemana = inicioSemana.AddDays(6); // domingo

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@inicioSemana", inicioSemana.Date);
                    cmd.Parameters.AddWithValue("@fimSemana", fimSemana.Date);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }


        public Agendamento GetById(int idAgendamento)
        {
            Agendamento agendamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                agendamento.id_agendamento,
                agendamento.id_cliente,
                cliente.nome AS nome_cliente,
                agendamento.tipo_evento,
                agendamento.total,
                agendamento.data_emissao,
                agendamento.local_evento,
                agendamento.data_evento,
                agendamento.hora_evento,
                agendamento.tema
            FROM agendamento
            INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
            WHERE agendamento.id_agendamento = @id
        ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idAgendamento);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            agendamento = new Agendamento
                            {
                                IdAgendamento = reader.GetInt32("id_agendamento"),
                                IdCliente = reader.GetInt32("id_cliente"),
                                NomeCliente = reader.GetString("nome_cliente"), // adicionando nome do cliente
                                TipoEvento = reader.GetString("tipo_evento"),
                                Total = reader.GetDouble("total"),
                                DataEmissao = reader.GetDateTime("data_emissao"),
                                LocalEvento = reader.GetString("local_evento"),
                                DataEvento = reader.GetDateTime("data_evento"),
                                HoraEvento = reader.GetString("hora_evento"),
                                Tema = reader.GetString("tema"),
                            };
                        }
                    }
                }
            }

            return agendamento;
        }


        // Carregar dados no Grid
        public DataTable GetAgendamentoAsDataTable(string tipo_evento)
        {
            string query = @"
        SELECT 
            agendamento.id_agendamento AS Id_Agendamento,
            agendamento.id_cliente AS Id_Cliente,
            cliente.nome AS Nome_Cliente,
            agendamento.tipo_evento AS Tipo_Evento,
            agendamento.total AS Total,
            agendamento.data_emissao AS Data_Emissao,
            agendamento.local_evento AS Local_Evento,
            agendamento.data_evento AS Data_Evento,
            agendamento.hora_evento AS Hora_Evento,
            agendamento.tema AS Tema
        FROM 
            agendamento
        INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
        WHERE 
            agendamento.tipo_evento LIKE CONCAT('%', @tipo_evento, '%')
        ORDER BY 
            agendamento.tipo_evento
    ";

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

        public DataTable GetAgendamentoAsDataTableCliente(string nome_cliente)
        {
            string query = @"
        SELECT 
            agendamento.id_agendamento AS Id_Agendamento,
            agendamento.id_cliente AS Id_Cliente,
            cliente.nome AS Nome_Cliente,
            agendamento.tipo_evento AS Tipo_Evento,
            agendamento.total AS Total,
            agendamento.data_emissao AS Data_Emissao,
            agendamento.local_evento AS Local_Evento,
            agendamento.data_evento AS Data_Evento,
            agendamento.hora_evento AS Hora_Evento,
            agendamento.tema AS Tema
        FROM 
            agendamento
        INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
        WHERE 
            cliente.nome LIKE CONCAT('%', @nome_cliente, '%')
        ORDER BY 
            cliente.nome
    ";

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

        public DataTable GetAgendamentoAsDataTableTema(string tema_evento)
        {
            string query = @"
        SELECT 
            agendamento.id_agendamento AS Id_Agendamento,
            agendamento.id_cliente AS Id_Cliente,
            cliente.nome AS Nome_Cliente,
            agendamento.tipo_evento AS Tipo_Evento,
            agendamento.total AS Total,
            agendamento.data_emissao AS Data_Emissao,
            agendamento.local_evento AS Local_Evento,
            agendamento.data_evento AS Data_Evento,
            agendamento.hora_evento AS Hora_Evento,
            agendamento.tema AS Tema
        FROM 
            agendamento
        INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
        WHERE 
            agendamento.tema LIKE CONCAT('%', @tema_evento, '%')
        ORDER BY 
            agendamento.tema
    ";

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
            string query = @"
        SELECT 
            agendamento.id_agendamento AS Id_Agendamento,
            agendamento.id_cliente AS Id_Cliente,
            cliente.nome AS Nome_Cliente,
            agendamento.tipo_evento AS Tipo_Evento,
            agendamento.total AS Total,
            agendamento.data_emissao AS Data_Emissao,
            agendamento.local_evento AS Local_Evento,
            agendamento.data_evento AS Data_Evento,
            agendamento.hora_evento AS Hora_Evento,
            agendamento.tema AS Tema
        FROM 
            agendamento
        INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
        WHERE 
            agendamento.data_evento LIKE CONCAT('%', @data_evento, '%')
        ORDER BY 
            agendamento.data_evento
    ";

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

                string query = @"
            SELECT 
                agendamento.id_agendamento AS Id_Agendamento,
                agendamento.id_cliente AS Id_Cliente,
                cliente.nome AS Nome_Cliente,
                agendamento.tipo_evento AS Tipo_Evento,
                agendamento.total AS Total,
                agendamento.data_emissao AS Data_Emissao,
                agendamento.local_evento AS Local_Evento,
                agendamento.data_evento AS Data_Evento,
                agendamento.hora_evento AS Hora_Evento,
                agendamento.tema AS Tema
            FROM 
                agendamento
            INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
            WHERE 
                agendamento.tipo_evento LIKE CONCAT('%', @tipo_evento, '%')
            ORDER BY 
                agendamento.tipo_evento
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_evento", Tipo_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agendamento = new Agendamento()
                        {
                            IdAgendamento = reader.GetInt32("Id_Agendamento"),
                            IdCliente = reader.GetInt32("Id_Cliente"),
                            NomeCliente = reader.GetString("Nome_Cliente"),
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

                string query = @"
            SELECT 
                agendamento.id_agendamento AS Id_Agendamento,
                agendamento.id_cliente AS Id_Cliente,
                cliente.nome AS Nome_Cliente,
                agendamento.tipo_evento AS Tipo_Evento,
                agendamento.total AS Total,
                agendamento.data_emissao AS Data_Emissao,
                agendamento.local_evento AS Local_Evento,
                agendamento.data_evento AS Data_Evento,
                agendamento.hora_evento AS Hora_Evento,
                agendamento.tema AS Tema
            FROM 
                agendamento
            INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
            WHERE 
                cliente.nome LIKE CONCAT('%', @nome_cliente, '%')
            ORDER BY 
                cliente.nome
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_cliente", Nome_cliente.Trim());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agendamento = new Agendamento()
                        {
                            IdAgendamento = reader.GetInt32("Id_Agendamento"),
                            IdCliente = reader.GetInt32("Id_Cliente"),
                            NomeCliente = reader.GetString("Nome_Cliente"),
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

                string query = @"
            SELECT 
                agendamento.id_agendamento AS Id_Agendamento,
                agendamento.id_cliente AS Id_Cliente,
                cliente.nome AS Nome_Cliente,
                agendamento.tipo_evento AS Tipo_Evento,
                agendamento.total AS Total,
                agendamento.data_emissao AS Data_Emissao,
                agendamento.local_evento AS Local_Evento,
                agendamento.data_evento AS Data_Evento,
                agendamento.hora_evento AS Hora_Evento,
                agendamento.tema AS Tema
            FROM 
                agendamento
            INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
            WHERE 
                agendamento.tema LIKE CONCAT('%', @tema_evento, '%')
            ORDER BY 
                agendamento.tema
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tema_evento", Tema_evento);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agendamento = new Agendamento()
                        {
                            IdAgendamento = reader.GetInt32("Id_Agendamento"),
                            IdCliente = reader.GetInt32("Id_Cliente"),
                            NomeCliente = reader.GetString("Nome_Cliente"),
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

        public Agendamento GetByAgendamentoData(string Data_evento)
        {
            Agendamento agendamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                agendamento.id_agendamento AS Id_Agendamento,
                agendamento.id_cliente AS Id_Cliente,
                cliente.nome AS Nome_Cliente,
                agendamento.tipo_evento AS Tipo_Evento,
                agendamento.total AS Total,
                agendamento.data_emissao AS Data_Emissao,
                agendamento.local_evento AS Local_Evento,
                agendamento.data_evento AS Data_Evento,
                agendamento.hora_evento AS Hora_Evento,
                agendamento.tema AS Tema
            FROM 
                agendamento
            INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
            WHERE 
                agendamento.data_evento LIKE CONCAT('%', @data_evento, '%')
            ORDER BY 
                agendamento.data_evento
        ";

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
                            NomeCliente = reader.GetString("Nome_Cliente"),
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
        public int Add(Agendamento agendamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO agendamento
                         (tipo_evento, total, id_cliente, data_emissao, local_evento, data_evento, hora_evento, tema)
                         VALUES
                         (@tipo_evento, @total, @id_cliente, @data_emissao, @local_evento, @data_evento, @hora_evento, @tema);";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_evento", agendamento.TipoEvento);
                cmd.Parameters.AddWithValue("@total", agendamento.Total);
                cmd.Parameters.AddWithValue("@id_cliente", agendamento.IdCliente);
                cmd.Parameters.AddWithValue("@data_emissao", agendamento.DataEmissao);
                cmd.Parameters.AddWithValue("@local_evento", agendamento.LocalEvento);
                cmd.Parameters.AddWithValue("@data_evento", agendamento.DataEvento);
                cmd.Parameters.AddWithValue("@hora_evento", agendamento.HoraEvento);
                cmd.Parameters.AddWithValue("@tema", agendamento.Tema);

                cmd.ExecuteNonQuery();

                // Retorna o ID gerado automaticamente pelo banco
                cmd.CommandText = "SELECT LAST_INSERT_ID();";
                int idGerado = Convert.ToInt32(cmd.ExecuteScalar());

                return idGerado;
            }
        }
        public Agendamento GetByClienteDataTipo(int idCliente, DateTime dataEvento, string tipoEvento)
        {
            Agendamento agendamento = null;
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                string query = @"SELECT  id_cliente, tipo_evento, total, data_emissao, local_evento, data_evento, hora_evento, tema
                         FROM agendamento
                         WHERE id_cliente = @id_cliente
                           AND data_evento = @data_evento
                           AND tipo_evento = @tipo_evento
                         LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@data_evento", dataEvento);
                    cmd.Parameters.AddWithValue("@tipo_evento", tipoEvento);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            agendamento = new Agendamento()
                            {
                                IdAgendamento = reader.GetInt32("id_agendamento"),
                                IdCliente = reader.GetInt32("id_cliente"),
                                TipoEvento = reader.GetString("tipo_evento"),
                                Total = reader.GetDouble("total"),
                                DataEmissao = reader.GetDateTime("data_emissao"),
                                LocalEvento = reader.GetString("local_evento"),
                                DataEvento = reader.GetDateTime("data_evento"),
                                HoraEvento = reader.GetString("hora_evento"),
                                Tema = reader.GetString("tema")
                            };
                        }
                    }
                }
            }
            return agendamento;
        }





        // Atualizar/editar dados
        public void Update(Agendamento agendamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
            UPDATE agendamento
            SET 
                tipo_evento = @tipo_evento,
                total = @total,
                id_cliente = @id_cliente,
                data_emissao = @data_emissao,
                local_evento = @local_evento,
                data_evento = @data_evento,
                hora_evento = @hora_evento,
                tema = @tema
            WHERE 
                id_agendamento = @id_agendamento
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", agendamento.IdAgendamento);
                cmd.Parameters.AddWithValue("@tipo_evento", agendamento.TipoEvento);
                cmd.Parameters.AddWithValue("@id_cliente", agendamento.IdCliente); // <== corrigido
                cmd.Parameters.AddWithValue("@total", agendamento.Total);
                cmd.Parameters.AddWithValue("@data_emissao", agendamento.DataEmissao);
                cmd.Parameters.AddWithValue("@local_evento", agendamento.LocalEvento);
                cmd.Parameters.AddWithValue("@data_evento", agendamento.DataEvento);
                cmd.Parameters.AddWithValue("@hora_evento", agendamento.HoraEvento);
                cmd.Parameters.AddWithValue("@tema", agendamento.Tema); // <== padronizado
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