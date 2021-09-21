using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class XDocumentationAttributesClass
    {
        [JsonPropertyName("ThrottleSecondsBetweenActionPerUser")]
        public float ThrottleSecondsBetweenActionPerUser { get; set; }
    }
}