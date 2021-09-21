using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    public class ItemClass
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum Type { get; set; }

        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }

        [JsonPropertyName("x-enum-reference")]
        public XEnumReferenceClass? XEnumReference { get; set; }

        [JsonPropertyName("x-enum-is-bitmask")]
        public bool? XEnumIsBitmask { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }
    }
}