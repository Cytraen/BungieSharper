using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Properties
{
    public class XMappedDefinitionClass
    {
        [JsonPropertyName("$ref"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ref { get; set; }
    }
}