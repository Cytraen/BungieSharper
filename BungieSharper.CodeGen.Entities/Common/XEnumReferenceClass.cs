using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    public class XEnumReferenceClass
    {
        [JsonPropertyName("$ref"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ref { get; set; }
    }
}