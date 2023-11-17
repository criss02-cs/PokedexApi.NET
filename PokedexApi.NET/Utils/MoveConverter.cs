using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PokedexApi.NET.Models;
using Type = System.Type;

namespace PokedexApi.NET.Utils
{
    internal class MoveConverter : JsonConverter<Move>
    {
        private HttpClientManager _client = HttpClientManager.Instance;
        public override Move? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new Exception("Il valore deve essere una stringa");
            var value = reader.GetString();
            //var move = _client.SendGetRequestSync<Move>($"moves/getById/{value}");
            return null;
        }

        public override void Write(Utf8JsonWriter writer, Move value, JsonSerializerOptions options)
        {
        }
    }
}
