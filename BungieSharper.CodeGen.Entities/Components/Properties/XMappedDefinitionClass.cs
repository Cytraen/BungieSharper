using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Components.Properties
{
    public class XMappedDefinitionClass
    {
        [JsonPropertyName("$ref")]
        public string Ref { get; set; }
    }
}