using System.Text.Json.Serialization;
using PokedexApi.NET.Models;

namespace PokedexApi.NET;
public class ResourceListRequest
{
    [JsonPropertyName("offset")]
    public int Offset { get; set; }
    [JsonPropertyName("limit")]
    public int Limit { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class TypesListRequest : ResourceListRequest
{
    [JsonPropertyName("types")]
    public List<string>? Types { get; set; }
}

public class MoveListRequest : TypesListRequest
{
    [JsonPropertyName("moveCategory")]
    public string? MoveCategory { get; set; }
    [JsonPropertyName("onlyMt")]
    public bool OnlyMt { get; set; }
}