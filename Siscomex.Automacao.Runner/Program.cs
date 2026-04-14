using Microsoft.Playwright;
using MySql.Data.MySqlClient;

namespace Siscomex.Automacao.Runner
{
    class Program
    {
        public static async Task Main()
        {
            using var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            var context = await browser.NewContextAsync(new()
            {
                IgnoreHTTPSErrors = true,
                ClientCertificates = new[]
                {
                new ClientCertificate
                {
                    Origin = "https://*.siscomex.gov.br", // ajustar conforme domínio real
                    PfxPath = Environment.GetEnvironmentVariable("CERT_PATH"),
                    Passphrase = Environment.GetEnvironmentVariable("CERT_PASS")
                }
            }
            });

            var page = await context.NewPageAsync();

            await page.GotoAsync("https://www1.siscomex.receita.fazenda.gov.br/siscomexImpweb-7/login_cert.jsp");

            await page.WaitForLoadStateAsync();

            Console.WriteLine("Página carregada com certificado!");
            Console.WriteLine("DB_CONN:");
            Console.WriteLine(Environment.GetEnvironmentVariable("DB_CONN"));

            var connString = Environment.GetEnvironmentVariable("DB_CONN");

            using var conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                Console.WriteLine("Conexão com MySQL OK!");

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO di (numero, status, data_consulta)
                    VALUES (@numero, @status, NOW())";

                cmd.Parameters.AddWithValue("@numero", "TESTE123");
                cmd.Parameters.AddWithValue("@status", "OK");

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:");
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Insert realizado com sucesso!");


            await browser.CloseAsync();
        }
    }

}