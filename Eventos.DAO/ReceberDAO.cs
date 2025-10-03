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
