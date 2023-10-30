using System.Text.Json.Serialization;
using PokedexApi.NET.Utils;

namespace PokedexApi.NET.Models;

public class PokemonResource : Resource
{
    public int PokedexId { get; set; }
    public string? Categoria { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public string? PokedexDescription { get; set; }
    [JsonPropertyName("stats")]
    public Statistiche? Statistiche { get; set; }
    public List<AbilitaPokemon>? Abilita { get; set; }
    public List<MossaPokemon>? Moves { get; set; }
    [JsonConverter(typeof(TypeListConverter))]
    public List<Type>? Types { get; set; }
    public string? ArtworkImage { get; set; }
}

public class MossaPokemon
{
    public string? MoveId { get; set; }
    public string? Method { get; set; }
    public int Level { get; set; }
}

public class AbilitaPokemon
{
    public string? AbilityId { get; set; }
    public bool IsHidden { get; set; }
}