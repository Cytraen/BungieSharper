using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    public class XEnumValueClass
    {
        [JsonPropertyName("numericValue")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long NumericValue { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}