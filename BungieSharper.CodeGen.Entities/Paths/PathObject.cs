using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class PathObject
    {
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("get"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseMethodClass? Get { get; set; }

        [JsonPropertyName("post"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseMethodClass? Post { get; set; }
    }
}