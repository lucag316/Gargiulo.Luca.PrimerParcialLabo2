using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class GolosinaConverter : JsonConverter<Golosina>
    {
        public override Golosina Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                string type = root.GetProperty("Tipo").GetString();

                switch (type)
                {
                    case "Chocolate":
                        return JsonSerializer.Deserialize<Chocolate>(root.GetRawText(), options);
                    case "Chicle":
                        return JsonSerializer.Deserialize<Chicle>(root.GetRawText(), options);
                    case "Chupetin":
                        return JsonSerializer.Deserialize<Chupetin>(root.GetRawText(), options);
                    default:
                        throw new JsonException("Tipo de golosina desconocido.");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, Golosina value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}

