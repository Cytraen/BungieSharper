using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FormatEnum
    {
        None,

        [EnumMember(Value = "byte")]
        Byte,

        [EnumMember(Value = "date-time")]
        DateTime,

        [EnumMember(Value = "double")]
        Double,

        [EnumMember(Value = "float")]
        Float,

        [EnumMember(Value = "int32")]
        Int32,

        [EnumMember(Value = "int64")]
        Int64,

        [EnumMember(Value = "int16")]
        Int16,

        [EnumMember(Value = "uint32")]
        Uint32
    }
}