using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscomex.Automacao.Infrastructure.Data
{
    public class DiRepository
    {
        private readonly MySqlConnectionFactory _factory;

        public DiRepository(MySqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public void Salvar(string numero, string status)
        {
            using var conn = _factory.CreateConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO di (numero, status, data_consulta) 
                            VALUES (@numero, @status, NOW())";

            cmd.Parameters.AddWithValue("@numero", numero);
            cmd.Parameters.AddWithValue("@status", status);

            cmd.ExecuteNonQuery();
        }
    }
}
