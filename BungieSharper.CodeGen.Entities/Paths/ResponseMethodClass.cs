using BungieSharper.CodeGen.Entities.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class ResponseMethodClass
    {
        [JsonPropertyName("tags")]
        public TagEnum[] Tags { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("operationId")]
        public string OperationId { get; set; }

        [JsonPropertyName("parameters")]
        public PathResponseMethodParameterClass[] Parameters { get; set; }

        [JsonPropertyName("responses")]
        public Dictionary<short, ResponseClass> Responses { get; set; }

        [JsonPropertyName("deprecated")]
        public bool Deprecated { get; set; }

        [JsonPropertyName("security")]
        public SecurityClass[]? Security { get; set; }

        [JsonPropertyName("requestBody")]
        public RequestBodyClass? RequestBody { get; set; }

        [JsonPropertyName("x-documentation-attributes")]
        public XDocumentationAttributesClass? XDocumentationAttributes { get; set; }

        [JsonPropertyName("x-preview")]
        public bool? XPreview { get; set; }
    }
}