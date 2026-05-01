using Siscomex.Automacao.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//O contrato da autenticação. 
//O Core define o que precisa, sem saber como é feito. 
//A Application e o Runner dependem apenas dessa interface, nunca da implementação concreta.
namespace Siscomex.Automacao.Core.Interfaces
{
    public interface IAuthTokenProvider
    {
        /// <summary>
        /// Retorna tokens válidos. Autentica automaticamente se necessário.
        /// </summary>
        Task<AuthTokens> ObterTokensAsync(CancellationToken ct = default);

        /// <summary>
        /// Atualiza o CSRF token após cada resposta do Portal Único.
        /// Deve ser chamado pelo DuimpApiClient a cada requisição.
        /// </summary>
        void AtualizarCsrfToken(string csrfToken, string csrfExpiration);

        /// <summary>
        /// Invalida a sessão, forçando nova autenticação no próximo uso.
        /// </summary>
        void Invalidar();
    }
}
