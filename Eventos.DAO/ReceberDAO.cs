using Eventos.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Eventos.DAO
{
    public class ReceberDAO
    {
        private DbContext dbContext = new DbContext();

        public int Add(Receber receber)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO receber (id_agendamento, data_emissao, valor_total)
                         VALUES (@id_agendamento, @data_emissao, @valor_total);";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", receber.IdAgendamento);
                cmd.Parameters.AddWithValue("@data_emissao", receber.DataEmissao);
                cmd.Parameters.AddWithValue("@valor_total", receber.ValorTotal);

                cmd.ExecuteNonQuery();

                // Retorna o ID gerado no AUTO_INCREMENT
                return (int)cmd.LastInsertedId;
            }
        }
        public DataTable GetRecebimentosPagos()
        {
            string query = @"
        SELECT 
            r.id_receber AS Id_Receber,
            r.id_agendamento AS Id_Agendamento,
            c.nome AS Nome_Cliente,
            r.data_emissao AS Data_Emissao,
            r.valor_total AS Valor_Total
        FROM 
            receber r
        INNER JOIN agendamento a ON r.id_agendamento = a.id_agendamento
        INNER JOIN cliente c ON a.id_cliente = c.id_cliente
        ORDER BY 
            r.data_emissao DESC;
    ";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public void InserirRecebimento(int idAgendamento, double valorTotal)
        {
            string query = @"
        INSERT INTO receber (id_agendamento, data_emissao, valor_total)
        VALUES (@idAgendamento, NOW(), @valorTotal)
    ";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idAgendamento", idAgendamento);
                    cmd.Parameters.AddWithValue("@valorTotal", valorTotal);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int GetIdAgendamentoPorReceber(int idReceber)
        {
            string query = "SELECT id_agendamento FROM receber WHERE id_receber = @idReceber";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idReceber", idReceber);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        return Convert.ToInt32(result);
                    else
                        return 0; // ou lance uma exceção se quiser tratar isso
                }
            }
        }



        // Busca o id_receber pelo id_agendamento
        public int GetIdByAgendamento(int idAgendamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT id_receber FROM receber WHERE id_agendamento = @id_agendamento LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", idAgendamento);

                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int idReceber))
                    return idReceber;

                throw new Exception("Não foi possível recuperar o id_receber para este agendamento.");
            }
        }
    }
}
