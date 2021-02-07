using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class XDocumentationAttributesClass
    {
        [JsonPropertyName("ThrottleSecondsBetweenActionPerUser"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ThrottleSecondsBetweenActionPerUser { get; set; }
    }
}