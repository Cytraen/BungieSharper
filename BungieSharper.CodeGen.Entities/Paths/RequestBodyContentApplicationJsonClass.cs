using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class RequestBodyContentApplicationJsonClass
    {
        [JsonPropertyName("schema"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContentApplicationJsonSchemaClass Schema { get; set; }
    }
}