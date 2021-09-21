using BungieSharper.CodeGen.Entities.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Schema
{
    public class SchemaObject
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum Type { get; set; }

        [JsonPropertyName("enum")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long[]? Enum { get; set; }

        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }

        [JsonPropertyName("x-enum-values")]
        public XEnumValueClass[]? XEnumValues { get; set; }

        [JsonPropertyName("x-enum-is-bitmask")]
        public bool? XEnumIsBitmask { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("items")]
        public ItemClass? Items { get; set; }

        [JsonPropertyName("x-mobile-manifest-name")]
        public string? XMobileManifestName { get; set; }

        [JsonPropertyName("x-destiny-component-type-dependency")]
        public string? XDestinyComponentTypeDependency { get; set; }

        [JsonPropertyName("additionalProperties")]
        public AdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key")]
        public XDictionaryKeyClass? XDictionaryKey { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, Properties.PropertiesObject>? Properties { get; set; }
    }
}