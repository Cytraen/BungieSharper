using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Schema
{
    public class AdditionalPropertiesClass
    {
        [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("additionalProperties"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AdditionalPropertiesClass AdditionalProperties { get; set; }

        [JsonPropertyName("x-dictionary-key"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XDictionaryKeyClass XDictionaryKey { get; set; }

        [JsonPropertyName("$ref"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ref { get; set; }
    }
}