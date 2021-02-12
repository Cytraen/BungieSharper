using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class ResponseClass
    {
        [JsonPropertyName("$ref"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ref { get; set; }
    }
}