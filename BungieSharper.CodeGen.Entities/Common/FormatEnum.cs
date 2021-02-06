using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FormatEnum
    {
        None,
        Byte,

        [EnumMember(Value = "date-time")]
        DateTime,

        Double,
        Float,
        Int32,
        Int64,
        Uint32
    }
}