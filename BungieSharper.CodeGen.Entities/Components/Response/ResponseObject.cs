using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Response
{
    public class ResponseObject
    {
        [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("content"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseContentClass? Content { get; set; }
    }

    public class ResponseContentClass
    {
        [JsonPropertyName("application/json"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseContentApplicationJsonClass ApplicaionJson { get; set; }
    }

    public class ResponseContentApplicationJsonClass
    {
        [JsonPropertyName("schema"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContentApplicationJsonSchemaClass Schema { get; set; }
    }

    public class ContentApplicationJsonSchemaClass
    {
        [JsonPropertyName("type")]
        public TypeEnum Type { get; set; }

        [JsonPropertyName("properties"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ApplicationJsonSchemaPropertiesClass Properties { get; set; }
    }

    public class ApplicationJsonSchemaPropertiesClass
    {
        // TODO
        [JsonPropertyName("Response"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public dynamic Response { get; set; }

        [JsonPropertyName("ErrorCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public dynamic ErrorCode { get; set; }

        [JsonPropertyName("ThrottleSeconds"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public dynamic ThrottleSeconds { get; set; }

        [JsonPropertyName("ErrorStatus"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public dynamic ErrorStatus { get; set; }

        [JsonPropertyName("Message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public dynamic Message { get; set; }

        [JsonPropertyName("MessageData"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public dynamic MessageData { get; set; }

        [JsonPropertyName("DetailedErrorTrace"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public dynamic DetailedErrorTrace { get; set; }
    }
}