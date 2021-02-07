using BungieSharper.CodeGen.Entities.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class ResponseMethodClass
    {
        [JsonPropertyName("tags"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TagEnum[] Tags { get; set; }

        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        [JsonPropertyName("operationId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OperationId { get; set; }

        [JsonPropertyName("parameters"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PathResponseMethodParameterClass[] Parameters { get; set; }

        [JsonPropertyName("requestBody"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RequestBodyClass RequestBody { get; set; }

        [JsonPropertyName("responses"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<short, ResponseClass> Responses { get; set; }

        [JsonPropertyName("deprecated"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Deprecated { get; set; }

        [JsonPropertyName("security"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SecurityClass[] Security { get; set; }

        [JsonPropertyName("x-preview"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? XPreview { get; set; }

        [JsonPropertyName("x-documentation-attributes"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XDocumentationAttributesClass XDocumentationAttributes { get; set; }
    }
}