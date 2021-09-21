using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Properties
{
    public class PropertiesObject
    {
        [JsonPropertyName("items")]
        public ItemClass? Items { get; set; }

        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }

        [JsonPropertyName("nullable")]
        public bool? Nullable { get; set; }

        [JsonPropertyName("x-enum-reference")]
        public XEnumReferenceClass? XEnumReference { get; set; }

        [JsonPropertyName("x-enum-is-bitmask")]
        public bool? XEnumIsBitmask { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("additionalProperties")]
        public AdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key")]
        public XDictionaryKeyClass? XDictionaryKey { get; set; }

        [JsonPropertyName("x-mapped-definition")]
        public XMappedDefinitionClass? XMappedDefinition { get; set; }

        [JsonPropertyName("allOf")]
        public AllOfElementClass[]? AllOf { get; set; }

        [JsonPropertyName("enum")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long[]? Enum { get; set; }

        [JsonPropertyName("x-enum-values")]
        public XEnumValueClass[]? XEnumValues { get; set; }

        [JsonPropertyName("x-destiny-component-type-dependency")]
        public string? XDestinyComponentTypeDependency { get; set; }
    }
}