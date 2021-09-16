using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities
{
    public class OpenApiObject
    {
        // Pretty much always 3.0.0 but whatever
        [JsonPropertyName("openapi")]
        public string OpenApi { get; set; }

        // Don't care
        [JsonPropertyName("info")]
        public object Info { get; set; }

        // Don't care
        [JsonPropertyName("servers")]
        public List<object> Servers { get; set; }

        [JsonPropertyName("paths")]
        public Dictionary<string, Paths.PathObject> Paths { get; set; }

        [JsonPropertyName("components")]
        public Components.ComponentsObject Components { get; set; }

        // Don't care
        [JsonPropertyName("tags")]
        public List<object> Tags { get; set; }

        // Don't care
        [JsonPropertyName("externalDocs")]
        public object ExternalDocs { get; set; }
    }
}