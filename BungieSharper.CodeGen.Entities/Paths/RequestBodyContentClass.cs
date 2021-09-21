using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class RequestBodyContentClass
    {
        [JsonPropertyName("application/json")]
        public RequestBodyContentApplicationJsonClass ApplicationJson { get; set; }
    }
}