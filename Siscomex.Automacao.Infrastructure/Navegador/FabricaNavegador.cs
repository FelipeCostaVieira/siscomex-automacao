using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Siscomex.Automacao.Infrastructure.Navegador
{
    public class FabricaNavegador
    {
        public async Task<IBrowserContext> CriarContextoAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            return await browser.NewContextAsync(new()
            {
                IgnoreHTTPSErrors = true,
                ClientCertificates = new[]
                {
                new ClientCertificate
                {
                    Origin = "https://www4.siscomex.gov.br",
                    PfxPath = "certificado.pfx",
                    Passphrase = "senha"
                }
            }
            });
        }
    }
}
