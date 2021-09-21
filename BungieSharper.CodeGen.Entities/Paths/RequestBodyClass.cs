using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class RequestBodyClass
    {
        [JsonPropertyName("content")]
        public RequestBodyContentClass Content { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}