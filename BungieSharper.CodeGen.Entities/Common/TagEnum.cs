using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TagEnum
    {
        None,

        [EnumMember(Value = "")]
        Core,

        App,
        User,
        Content,
        Forum,
        GroupV2,
        Tokens,
        Destiny2,
        CommunityContent,
        Trending,
        Fireteam,
        Preview
    }
}