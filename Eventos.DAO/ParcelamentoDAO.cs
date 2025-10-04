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
        public DataTable GetParcelasPendentes()
        {
            string query = @"
        SELECT 
            p.id_parcela AS Id_Parcela,
            a.id_agendamento AS Id_Agendamento,
            c.nome AS Nome_Cliente,
            p.parcela AS Parcela,
            p.valor AS Valor,
            p.data_pagamento AS Data_Pagamento,
            p.vencimento AS Vencimento,
            p.tipo_pagamento AS Tipo_Pagamento
        FROM 
            parcelamento p
        INNER JOIN receber r ON p.id_receber = r.id_receber
        INNER JOIN agendamento a ON r.id_agendamento = a.id_agendamento
        INNER JOIN cliente c ON a.id_cliente = c.id_cliente
        WHERE 
            p.vencimento >= CURDATE()   -- só as que ainda não venceram
        ORDER BY 
            p.vencimento ASC;
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



    }
}
