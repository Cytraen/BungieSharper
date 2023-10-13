using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Response
{
    public class ResponseObject
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("content")]
        public ResponseContentClass Content { get; set; }
    }

    public class ResponseContentClass
    {
        [JsonPropertyName("application/json")]
        public ResponseContentApplicationJsonClass ApplicationJson { get; set; }
    }

    public class ResponseContentApplicationJsonClass
    {
        [JsonPropertyName("schema")]
        public ContentApplicationJsonSchemaClass Schema { get; set; }
    }

    public class ContentApplicationJsonSchemaClass
    {
        [JsonPropertyName("type")]
        public TypeEnum Type { get; set; }

        [JsonPropertyName("properties")]
        public ApplicationJsonSchemaPropertiesClass Properties { get; set; }
    }

    public class ApplicationJsonSchemaPropertiesClass
    {
        [JsonPropertyName("Response")]
        public SchemaPropertiesResponseClass Response { get; set; }

        [JsonPropertyName("ErrorCode")]
        public object ErrorCode { get; set; }

        [JsonPropertyName("ThrottleSeconds")]
        public object ThrottleSeconds { get; set; }

        [JsonPropertyName("ErrorStatus")]
        public object ErrorStatus { get; set; }

        [JsonPropertyName("Message")]
        public object Message { get; set; }

        [JsonPropertyName("MessageData")]
        public object MessageData { get; set; }

        [JsonPropertyName("DetailedErrorTrace")]
        public object DetailedErrorTrace { get; set; }
    }
}