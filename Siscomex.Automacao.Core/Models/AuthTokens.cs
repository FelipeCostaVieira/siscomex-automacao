using System.Text.Json.Serialization;

namespace Siscomex.Automacao.Core.Models;

public class AuthTokens
{
    [JsonPropertyName("jwtToken")]
    public string JwtToken { get; init; } = string.Empty;

    [JsonPropertyName("csrfToken")]
    public string CsrfToken { get; init; } = string.Empty;

    [JsonPropertyName("csrfExpiration")]
    public DateTimeOffset CsrfExpiration { get; init; }

    [JsonPropertyName("ultimaAutenticacao")]
    public DateTimeOffset UltimaAutenticacao { get; init; }

    [JsonIgnore]
    public bool CsrfExpirado => DateTimeOffset.UtcNow >= CsrfExpiration;
}