using BungieSharper.CodeGen.Entities.Components;
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
        public dynamic Info { get; set; }

        // Don't care
        [JsonPropertyName("servers")]
        public List<dynamic> Servers { get; set; }

        [JsonPropertyName("paths")]
        public Dictionary<string, dynamic> Paths { get; set; }

        [JsonPropertyName("components")]
        public ComponentsObject Components { get; set; }

        // Don't care
        [JsonPropertyName("tags")]
        public List<dynamic> Tags { get; set; }

        // Don't care
        [JsonPropertyName("externalDocs")]
        public dynamic ExternalDocs { get; set; }
    }
}