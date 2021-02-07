using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Common
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum OAuthScopeEnum
    {
        None,
        ReadBasicUserProfile,
        ReadGroups,
        WriteGroups,
        AdminGroups,
        BnetWrite,
        MoveEquipDestinyItems,
        ReadDestinyInventoryAndVault,
        ReadUserData,
        EditUserData,
        ReadDestinyVendorsAndAdvisors,
        ReadAndApplyTokens,
        AdvancedWriteActions,
        PartnerOfferGrant
    }
}