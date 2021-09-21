using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class RequestBodyContentApplicationJsonClass
    {
        [JsonPropertyName("schema")]
        public ContentApplicationJsonSchemaClass Schema { get; set; }
    }
}