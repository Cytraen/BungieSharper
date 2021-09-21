using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Schema
{
    public class AdditionalPropertiesClass
    {
        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("additionalProperties")]
        public AdditionalPropertiesClass? AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key")]
        public XDictionaryKeyClass? XDictionaryKey { get; set; }
    }
}