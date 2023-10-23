using System.Text.Json.Serialization;
using PokedexApi.NET.Utils;

namespace PokedexApi.NET.Models;

public class Move : Resource
{
    public string? Description { get; set; }
    [JsonConverter(typeof(MoveCategoryConverter))]
    public MoveCategory Category { get; set; }
    public int Pp { get; set; }
    public int PpMax { get; set; }
    public int Power { get; set; }
    public int Accuracy { get; set; }
    [JsonPropertyName("typeId"), JsonConverter(typeof(StringToTypeConverter))]
    public Type? Type { get; set; }
}