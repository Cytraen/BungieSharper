using BungieSharper.CodeGen.Entities.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Schema
{
    public class SchemaObject
    {
        [JsonPropertyName("enum")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long[]? Enum { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum Type { get; set; }

        [JsonPropertyName("properties"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, Properties.PropertiesObject>? Properties { get; set; }

        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("format"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }

        [JsonPropertyName("x-enum-values"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XEnumValueClass[]? XEnumValues { get; set; }

        [JsonPropertyName("x-enum-is-bitmask"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? XEnumIsBitmask { get; set; }

        [JsonPropertyName("items"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ItemClass? Items { get; set; }

        [JsonPropertyName("x-mobile-manifest-name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? XMobileManifestName { get; set; }

        [JsonPropertyName("x-destiny-component-type-dependency"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? XDestinyComponentTypeDependency { get; set; }

        [JsonPropertyName("additionalProperties"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XDictionaryKeyClass? XDictionaryKey { get; set; }
    }
}