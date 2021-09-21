using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    public class XEnumReferenceClass
    {
        [JsonPropertyName("$ref")]
        public string Ref { get; set; }
    }
}