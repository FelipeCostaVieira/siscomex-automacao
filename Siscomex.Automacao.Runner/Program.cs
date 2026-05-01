using Microsoft.Playwright;
using MySql.Data.MySqlClient;
using Siscomex.Automacao.Application.UseCases;
using Siscomex.Automacao.Infrastructure.Http;
using Siscomex.Automacao.Runner.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Siscomex.Automacao.Runner;

class Program
{
    [STAThread] // obrigatório para WinForms
    public static async Task Main()
    {
        //Console.WriteLine("=== Siscomex Automação ===");
        //Console.WriteLine("Escolha o módulo:");
        //Console.WriteLine("  1 - Consulta DUIMP (Portal Único API)");
        //Console.WriteLine("  2 - Playwright (testes)");
        //Console.Write("Opção: ");

        //var opcao = Console.ReadLine();

        //switch (opcao)
        //{
        //    case "1":
        //        RodarFormulario();
        //        break;
        //    case "2":
        //        await RodarPlaywright();
        //        break;
        //    default:
        //        Console.WriteLine("Opção inválida.");
        //        break;
        //}

        //RodarPlaywright();
        RodarFormulario();
    }

    // -------------------------------------------------------
    // Módulo WinForms — Consulta DUIMP
    // -------------------------------------------------------
    private static void RodarFormulario()
    {
        var portalUrl = Environment.GetEnvironmentVariable("PORTAL_URL")
            ?? throw new InvalidOperationException("Variável PORTAL_URL não configurada.");

        var cpfCnpj = Environment.GetEnvironmentVariable("CERT_CPF_CNPJ")
            ?? throw new InvalidOperationException("Variável CERT_CPF_CNPJ não configurada.");

        var authService = new PortalUnicoAuthService(portalUrl, cpfCnpj);
        var duimpClient = new DuimpApiClient(authService, portalUrl);
        var consultarUseCase = new ConsultarDuimpUseCase(duimpClient);

        ApplicationConfiguration.Initialize();
        System.Windows.Forms.Application.Run(new FormConsultaDuimp(consultarUseCase));
    }

    // -------------------------------------------------------
    // Módulo Playwright — testes existentes preservados
    // -------------------------------------------------------
    private static async Task RodarPlaywright()
    {
        var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);

        foreach (var cert in store.Certificates)
        {
            var subject = cert.Subject;
            var match = Regex.Match(subject, @"\d{11}");
            if (match.Success)
            {
                Console.WriteLine($"Certificado: {subject}");
                Console.WriteLine($"CPF: {match.Value}");
            }
        }

        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });

        var context = await browser.NewContextAsync(new()
        {
            IgnoreHTTPSErrors = true,
            ClientCertificates =
            [
                new ClientCertificate
                {
                    Origin     = "https://*.siscomex.gov.br",
                    PfxPath    = Environment.GetEnvironmentVariable("CERT_PATH"),
                    Passphrase = Environment.GetEnvironmentVariable("CERT_PASS")
                }
            ]
        });

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://www1.siscomex.receita.fazenda.gov.br/siscomexImpweb-7/login_cert.jsp");
        await page.WaitForLoadStateAsync();

        Console.WriteLine("Página carregada com certificado!");

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

            Console.WriteLine("Insert realizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        await browser.CloseAsync();
    }
}