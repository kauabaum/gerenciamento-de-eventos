using Eventos.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Eventos.DAO
{
    public class ParcelamentoDAO
    {
        private DbContext dbContext = new DbContext();

        // Adicionar nova parcela
        public void Add(Parcelamento parcelamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO parcelamento
                        (id_agendamento, tipo_pagamento, data_pagamento, valor, vencimento)
                    VALUES
                        (@id_agendamento, @tipo_pagamento, @data_pagamento, @valor, @vencimento);
                ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", parcelamento.IdAgendamento);
                cmd.Parameters.AddWithValue("@tipo_pagamento", parcelamento.TipoPagamento);
                cmd.Parameters.AddWithValue("@data_pagamento", parcelamento.DataPagamento);
                cmd.Parameters.AddWithValue("@valor", parcelamento.Valor);
                cmd.Parameters.AddWithValue("@vencimento", parcelamento.Vencimento);

                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar parcela
        public void Update(Parcelamento parcelamento)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE parcelamento
                    SET 
                        id_agendamento = @id_agendamento,
                        tipo_pagamento = @tipo_pagamento,
                        data_pagamento = @data_pagamento,
                        valor = @valor,
                        vencimento = @vencimento
                    WHERE id = @id;
                ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", parcelamento.IdParcelamento);
                cmd.Parameters.AddWithValue("@id_agendamento", parcelamento.IdAgendamento);
                cmd.Parameters.AddWithValue("@tipo_pagamento", parcelamento.TipoPagamento);
                cmd.Parameters.AddWithValue("@data_pagamento", parcelamento.DataPagamento);
                cmd.Parameters.AddWithValue("@valor", parcelamento.Valor);
                cmd.Parameters.AddWithValue("@vencimento", parcelamento.Vencimento);

                cmd.ExecuteNonQuery();
            }
        }

        // Deletar parcela
        public void Delete(int id)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM parcelamento WHERE id = @id;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        // Buscar parcelas por agendamento
        public DataTable GetParcelasPorAgendamento(int idAgendamento)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT id, id_agendamento, tipo_pagamento, data_pagamento, valor, vencimento
                    FROM parcelamento
                    WHERE id_agendamento = @id_agendamento
                    ORDER BY vencimento;
                ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_agendamento", idAgendamento);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        // Buscar uma parcela pelo ID
        public Parcelamento GetById(int id)
        {
            Parcelamento parcelamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT id, id_agendamento, tipo_pagamento, data_pagamento, valor, vencimento
                    FROM parcelamento
                    WHERE id = @id
                    LIMIT 1;
                ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        parcelamento = new Parcelamento()
                        {
                            IdParcelamento = reader.GetInt32("id"),
                            IdAgendamento = reader.GetInt32("id_agendamento"),
                            TipoPagamento = reader.GetString("tipo_pagamento"),
                            DataPagamento = reader.GetDateTime("data_pagamento"),
                            Valor = reader.GetDouble("valor"),
                            Vencimento = reader.GetDateTime("vencimento")
                        };
                    }
                }
            }

            return parcelamento;
        }
    }
}
