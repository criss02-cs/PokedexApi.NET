using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokedexApi.NET.Utils;

internal class StringToTypeConverter : JsonConverter<Models.Type>
{
    public override Models.Type? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new Exception("Impossibile convertire la stringa in un oggetto Type.");
        var jsonString = reader.GetString();
        if (jsonString != null)
        {
            var type = new Models.Type(jsonString);
            return type;
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Models.Type value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Id);
    }
}

internal class TypeListConverter : JsonConverter<List<Models.Type>>
{
    public override List<Models.Type> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new Exception("Impossibile convertire la stringa in una lista di Type.");
        var typeList = new List<Models.Type>();
        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                {
                    var jsonString = reader.GetString();
                    if (jsonString != null)
                    {
                        var type = new Models.Type(jsonString);
                        typeList.Add(type);
                    }

                    break;
                }
                case JsonTokenType.EndArray:
                    return typeList;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return new List<Models.Type>();
    }

    public override void Write(Utf8JsonWriter writer, List<Models.Type> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var item in value)
        {
            writer.WriteStringValue(item.Id);
        }
        writer.WriteEndArray();
    }
}