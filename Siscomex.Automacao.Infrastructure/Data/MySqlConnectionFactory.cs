using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace Siscomex.Automacao.Infrastructure.Data
{
    public class MySqlConnectionFactory
    {
        private readonly string _connectionString;

        public MySqlConnectionFactory()
        {
            _connectionString = Environment.GetEnvironmentVariable("DB_CONN");

            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("Variável de ambiente DB_CONN não está configurada.");
        }

        public MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
