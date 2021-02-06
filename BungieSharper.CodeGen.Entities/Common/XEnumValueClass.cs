using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    public class XEnumValueClass
    {
        [JsonPropertyName("numericValue")]
        public long NumericValue { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }
    }
}