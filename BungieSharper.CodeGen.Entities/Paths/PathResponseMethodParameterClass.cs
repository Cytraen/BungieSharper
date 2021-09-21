using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class PathResponseMethodParameterClass
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("in")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public ParameterInEnum In { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("required")]
        public bool? Required { get; set; }

        [JsonPropertyName("schema")]
        public ParameterSchemaClass Schema { get; set; }
    }
}