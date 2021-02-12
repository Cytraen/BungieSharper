using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class RequestBodyContentClass
    {
        [JsonPropertyName("application/json"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RequestBodyContentApplicationJsonClass ApplicationJson { get; set; }
    }
}