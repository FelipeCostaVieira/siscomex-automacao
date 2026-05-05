using System.Text.Json.Serialization;

namespace Siscomex.Automacao.Core.Models.Duimp;

/// <summary>
/// Representa a resposta do endpoint de consulta da versão vigente de uma DUIMP.
/// Endpoint: GET /duimp-api/api/ext/duimp/{numero}/versoes
/// </summary>
public class DuimpVersaoVigenteResponse
{
    /// <summary>Número da DUIMP. Formato: AABRSSSSSSSSSSD</summary>
    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;

    /// <summary>Número da versão vigente da DUIMP. Retornado como inteiro pelo Portal.</summary>
    [JsonPropertyName("versao")]
    public int Versao { get; set; }

    /// <summary>Data e hora do registro. Formato: yyyy-MM-dd'T'HH:mm:ssZ</summary>
    [JsonPropertyName("dataRegistro")]
    public string DataRegistro { get; set; } = string.Empty;
}