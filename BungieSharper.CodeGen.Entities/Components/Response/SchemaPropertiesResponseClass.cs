using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Response
{
    public class SchemaPropertiesResponseClass
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("items")]
        public PropertiesResponseItemsClass? Items { get; set; }

        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }

        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }

        [JsonPropertyName("additionalProperties")]
        public PropertiesResponseAdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key")]
        public PropertiesResponseXDictionaryKeyClass? XDictionaryKey { get; set; }
    }

    public class PropertiesResponseItemsClass
    {
        [JsonPropertyName("$ref")]
        public string Ref { get; set; }
    }

    public class PropertiesResponseAdditionalPropertiesClass
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }

        [JsonPropertyName("additionalProperties")]
        public PropertiesResponseAdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key")]
        public PropertiesResponseXDictionaryKeyClass? XDictionaryKey { get; set; }
    }

    public class PropertiesResponseXDictionaryKeyClass
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }
    }
}