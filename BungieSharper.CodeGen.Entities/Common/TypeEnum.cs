using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TypeEnum
    {
        None,
        Array,
        Boolean,
        Integer,
        Number,
        Object,
        String
    }
}