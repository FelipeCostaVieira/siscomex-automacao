using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscomex.Automacao.Infrastructure;
using Siscomex.Automacao.Infrastructure.Navegador;

namespace Siscomex.Automacao.Application.Siscomex
{
    public class ConsultaDiService
    {
        private readonly FabricaNavegador _browserFactory;

        public ConsultaDiService(FabricaNavegador browserFactory)
        {
            _browserFactory = browserFactory;
        }

        public async Task ConsultarAsync(string numeroDi)
        {
            var context = await _browserFactory.CriarContextoAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://www4.siscomex.gov.br");

            // TODO: navegar até consulta DI
            // TODO: preencher número
            // TODO: capturar dados

            var titulo = await page.TitleAsync();
            Console.WriteLine($"Título: {titulo}");
        }
    }
}
