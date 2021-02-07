using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TypeEnum
    {
        None,

        [EnumMember(Value = "array")]
        Array,

        [EnumMember(Value = "boolean")]
        Boolean,

        [EnumMember(Value = "integer")]
        Integer,

        [EnumMember(Value = "number")]
        Number,

        [EnumMember(Value = "object")]
        Object,

        [EnumMember(Value = "string")]
        String
    }
}