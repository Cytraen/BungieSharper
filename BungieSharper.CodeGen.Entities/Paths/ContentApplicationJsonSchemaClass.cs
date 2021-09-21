using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class ContentApplicationJsonSchemaClass
    {
        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("items")]
        public ItemClass? Items { get; set; }
    }
}