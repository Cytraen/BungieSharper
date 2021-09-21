using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class ResponseClass
    {
        [JsonPropertyName("$ref")]
        public string Ref { get; set; }
    }
}