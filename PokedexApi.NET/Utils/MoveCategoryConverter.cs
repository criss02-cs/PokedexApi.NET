using System.Text.Json;
using System.Text.Json.Serialization;
using PokedexApi.NET.Models;
using Type = System.Type;

namespace PokedexApi.NET.Utils;

internal class MoveCategoryConverter : JsonConverter<MoveCategory>
{
    public override MoveCategory Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new Exception("Il valore deve essere una stringa");
        var value = reader.GetString();
        return value is null
            ? throw new Exception("Il valore non può essere nullo")
            : value switch
        {
            "Special" => MoveCategory.Special,
            "Status" => MoveCategory.Status,
            "Physical" => MoveCategory.Physical,
            _ => throw new Exception("Valore non ammesso")
        };
    }

    public override void Write(Utf8JsonWriter writer, MoveCategory value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case MoveCategory.Physical:
                writer.WriteStringValue("Physical");
                break;
            case MoveCategory.Special:
                writer.WriteStringValue("Special");
                break;
            case MoveCategory.Status:
                writer.WriteStringValue("Status");
                break;
            default:
                writer.WriteStringValue("");
                break;
        }
    }
}