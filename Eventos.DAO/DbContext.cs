using MySql.Data.MySqlClient;
using System;

namespace Eventos
{
    public class DbContext : IDisposable
    {
        private string connectionString = "server=127.0.0.1;port=3306;database=eventos;user=root"; // Ajuste a senha conforme necessário
        private MySqlConnection _connection;

        // Propriedade para obter a conexão com o banco de dados
        public MySqlConnection GetConnection()
        {
            // Cria uma nova conexão, se necessário
            if (_connection == null || _connection.State == System.Data.ConnectionState.Closed)
            {
                _connection = new MySqlConnection(connectionString);
            }
            return _connection;
        }

        // Implementando IDisposable para garantir o fechamento da conexão
        public void Dispose()
        {
            // Fechar a conexão apenas quando não for mais necessária
            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}
