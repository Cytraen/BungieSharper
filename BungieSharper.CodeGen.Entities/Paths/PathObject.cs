using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class PathObject
    {
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("post")]
        public ResponseMethodClass? Post { get; set; }

        [JsonPropertyName("get")]
        public ResponseMethodClass? Get { get; set; }
    }
}