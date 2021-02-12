using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class PathResponseMethodParameterClass
    {
        [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        [JsonPropertyName("in")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public ParameterInEnum In { get; set; }

        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        [JsonPropertyName("required"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Required { get; set; }

        [JsonPropertyName("deprecated"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Deprecated { get; set; }

        [JsonPropertyName("schema"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ParameterSchemaClass Schema { get; set; }
    }
}