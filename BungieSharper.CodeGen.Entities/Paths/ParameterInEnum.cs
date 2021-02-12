using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ParameterInEnum
    {
        None,

        [EnumMember(Value = "header")]
        Header,

        [EnumMember(Value = "path")]
        Path,

        [EnumMember(Value = "query")]
        Query
    }
}