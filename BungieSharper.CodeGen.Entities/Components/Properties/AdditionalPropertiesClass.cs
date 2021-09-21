using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Properties
{
    public class AdditionalPropertiesClass
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }

        [JsonPropertyName("x-enum-reference")]
        public XEnumReferenceClass? XEnumReference { get; set; }

        [JsonPropertyName("x-enum-is-bitmask")]
        public bool? XEnumIsBitmask { get; set; }

        [JsonPropertyName("additionalProperties")]
        public AdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key")]
        public XDictionaryKeyClass? XDictionaryKey { get; set; }

        [JsonPropertyName("items")]
        public ItemClass? Items { get; set; }

        [JsonPropertyName("x-destiny-component-type-dependency")]
        public string? XDestinyComponentTypeDependency { get; set; }
    }
}