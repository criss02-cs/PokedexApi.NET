using System.Text.Json.Serialization;
using PokedexApi.NET.Utils;

namespace PokedexApi.NET.Models;

public class PokemonList : Resource
{
    public int PokedexId { get; set; }
    public string? Categoria { get; set; }
    [JsonConverter(typeof(TypeListConverter))]
    public List<Type> Types { get; set; }
}