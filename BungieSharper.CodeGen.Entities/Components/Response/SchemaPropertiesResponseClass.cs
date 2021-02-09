using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Response
{
    public class SchemaPropertiesResponseClass
    {
        [JsonPropertyName("$ref"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ref { get; set; }

        [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("items"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PropertiesResponseItemsClass Items { get; set; }

        [JsonPropertyName("format"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }

        [JsonPropertyName("additionalProperties"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PropertiesResponseAdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PropertiesResponseXDictionaryKeyClass? XDictionaryKey { get; set; }
    }

    public class PropertiesResponseItemsClass
    {
        [JsonPropertyName("$ref"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ref { get; set; }
    }

    public class PropertiesResponseAdditionalPropertiesClass
    {
        [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("$ref"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Ref { get; set; }

        [JsonPropertyName("additionalProperties"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PropertiesResponseAdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PropertiesResponseXDictionaryKeyClass? XDictionaryKey { get; set; }
    }

    public class PropertiesResponseXDictionaryKeyClass
    {
        [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("format"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }
    }
}