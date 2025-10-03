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
                        (id_receber, tipo_pagamento, data_pagamento, valor, parcela, vencimento)
                    VALUES
                        (@id_receber, @tipo_pagamento, @data_pagamento, @valor, @parcela, @vencimento);
                ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipo_pagamento", parcelamento.TipoPagamento);
                cmd.Parameters.AddWithValue("@id_receber", parcelamento.IdReceber);
                cmd.Parameters.AddWithValue("@data_pagamento", parcelamento.DataPagamento);
                cmd.Parameters.AddWithValue("@parcela", parcelamento.Parcela);
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
                        tipo_pagamento = @tipo_pagamento,
                        data_pagamento = @data_pagamento,
                        valor = @valor,
                        vencimento = @vencimento
                    WHERE id = @id;
                ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", parcelamento.IdParcelamento);
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

        // Buscar uma parcela pelo ID
        public Parcelamento GetById(int id)
        {
            Parcelamento parcelamento = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT id, tipo_pagamento, data_pagamento, valor, vencimento
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
