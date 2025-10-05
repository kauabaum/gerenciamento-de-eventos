using Eventos.Model;
using MySql.Data.MySqlClient;

namespace Eventos.DAO
{
    public class ItensAgendamentoDAO
    {
        private readonly DbContext dbContext = new DbContext();

        public void Add(ItemAgendamento item)
        {
            string query = @"
                INSERT INTO itens_agendamento 
                (quantidade, subtotal, id_produto, id_agendamento)
                VALUES (@quantidade, @subtotal, @id_produto, @id_agendamento)
            ";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@quantidade", item.Quantidade);
                    cmd.Parameters.AddWithValue("@subtotal", item.Subtotal);
                    cmd.Parameters.AddWithValue("@id_produto", item.IdProduto);
                    cmd.Parameters.AddWithValue("@id_agendamento", item.IdAgendamento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
