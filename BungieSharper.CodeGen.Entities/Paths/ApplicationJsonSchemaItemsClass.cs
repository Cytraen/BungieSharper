using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class ApplicationJsonSchemaItemsClass
    {
        [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TypeEnum? Type { get; set; }

        [JsonPropertyName("format"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public FormatEnum? Format { get; set; }
    }
}