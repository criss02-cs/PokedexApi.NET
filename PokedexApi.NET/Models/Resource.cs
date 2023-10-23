using System.Text.Json.Serialization;

namespace PokedexApi.NET.Models;

public class Resource
{
    /// <summary>
    /// Rappresenta l'id mongo
    /// </summary>
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    /// <summary>
    /// Rappresenta il nome della risorsa
    /// </summary>
    public string? Name { get; set; }
}