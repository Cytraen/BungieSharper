using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components
{
    public class ComponentsObject
    {
        [JsonPropertyName("schemas")]
        public Dictionary<string, Schema.SchemaObject> Schemas { get; set; }

        [JsonPropertyName("responses")]
        public Dictionary<string, Response.ResponseObject> Responses { get; set; }

        // Don't care
        [JsonPropertyName("headers")]
        public Dictionary<string, object> Headers { get; set; }

        // Don't care
        [JsonPropertyName("securitySchemes")]
        public Dictionary<string, object> SecuritySchemes { get; set; }
    }
}