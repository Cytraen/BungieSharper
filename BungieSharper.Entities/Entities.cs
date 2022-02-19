using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities
{
    /// <summary>
    /// The types of membership the Accounts system supports. This is the external facing enum used in place of the internal-only Bungie.SharedDefinitions.MembershipType.
    /// </summary>
    public enum BungieMembershipType : int
    {
        None = 0,
        TigerXbox = 1,
        TigerPsn = 2,
        TigerSteam = 3,
        TigerBlizzard = 4,
        TigerStadia = 5,
        TigerDemon = 10,
        BungieNext = 254,

        /// <summary>"All" is only valid for searching capabilities: you need to pass the actual matching BungieMembershipType for any query where you pass a known membershipId.</summary>
        All = -1
    }

    /// <summary>
    /// The types of credentials the Accounts system supports. This is the external facing enum used in place of the internal-only Bungie.SharedDefinitions.CredentialType.
    /// </summary>
    public enum BungieCredentialType : byte
    {
        None = 0,
        Xuid = 1,
        Psnid = 2,
        Wlid = 3,
        Fake = 4,
        Facebook = 5,
        Google = 8,
        Windows = 9,
        DemonId = 10,
        SteamId = 12,
        BattleNetId = 14,
        StadiaId = 16,
        TwitchId = 18
    }

    public class SearchResultOfContentItemPublicContract
    {
        [JsonPropertyName("results")]
        public IEnumerable<Content.ContentItemPublicContract> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfContentItemPublicContract))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfContentItemPublicContractJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfPostResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<Forum.PostResponse> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfPostResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfPostResponseJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfGroupV2Card
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupV2Card> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfGroupV2Card))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfGroupV2CardJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfGroupMember
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupMember> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfGroupMember))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfGroupMemberJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfGroupBan
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupBan> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfGroupBan))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfGroupBanJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfGroupMemberApplication
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupMemberApplication> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfGroupMemberApplication))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfGroupMemberApplicationJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfGroupMembership
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupMembership> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfGroupMembership))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfGroupMembershipJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfGroupPotentialMembership
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupPotentialMembership> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfGroupPotentialMembership))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfGroupPotentialMembershipJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyVendorReceiptsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Profiles.DestinyVendorReceiptsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyVendorReceiptsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyVendorReceiptsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyInventoryComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Inventory.DestinyInventoryComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyInventoryComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyInventoryComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyProfileComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Profiles.DestinyProfileComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyProfileComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyProfileComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyPlatformSilverComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Inventory.DestinyPlatformSilverComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyPlatformSilverComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyPlatformSilverComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyKiosksComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Kiosks.DestinyKiosksComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyKiosksComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyKiosksComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyPlugSetsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.PlugSets.DestinyPlugSetsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyPlugSetsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyPlugSetsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyProfileProgressionComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Profiles.DestinyProfileProgressionComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyProfileProgressionComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyProfileProgressionComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyPresentationNodesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Presentation.DestinyPresentationNodesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyPresentationNodesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyPresentationNodesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyProfileRecordsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Records.DestinyProfileRecordsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyProfileRecordsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyProfileRecordsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyProfileCollectiblesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Collectibles.DestinyProfileCollectiblesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyProfileCollectiblesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyProfileCollectiblesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyProfileTransitoryComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Profiles.DestinyProfileTransitoryComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyProfileTransitoryComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyProfileTransitoryComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyMetricsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Metrics.DestinyMetricsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyMetricsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyMetricsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyStringVariablesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.StringVariables.DestinyStringVariablesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyStringVariablesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyStringVariablesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCharacterComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCharacterComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCharacterComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyInventoryComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Inventory.DestinyInventoryComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyInventoryComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyInventoryComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterProgressionComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterActivitiesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyKiosksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Kiosks.DestinyKiosksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyKiosksComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyKiosksComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.PlugSets.DestinyPlugSetsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyPlugSetsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyBaseItemComponentSetOfuint32
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent Objectives { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent Perks { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyBaseItemComponentSetOfuint32))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyBaseItemComponentSetOfuint32JsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemPerksComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Presentation.DestinyPresentationNodesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Records.DestinyCharacterRecordsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Collectibles.DestinyCollectiblesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCollectiblesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.StringVariables.DestinyStringVariablesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyStringVariablesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCraftablesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Craftables.DestinyCraftablesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCraftablesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCraftablesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyBaseItemComponentSetOfint64
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent Objectives { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent Perks { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyBaseItemComponentSetOfint64))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyBaseItemComponentSetOfint64JsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemPerksComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemPerksComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyItemComponentSetOfint64
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent Instances { get; set; }

        [JsonPropertyName("renderData")]
        public DictionaryComponentResponseOfint64AndDestinyItemRenderComponent RenderData { get; set; }

        [JsonPropertyName("stats")]
        public DictionaryComponentResponseOfint64AndDestinyItemStatsComponent Stats { get; set; }

        [JsonPropertyName("sockets")]
        public DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent Sockets { get; set; }

        [JsonPropertyName("reusablePlugs")]
        public DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent ReusablePlugs { get; set; }

        [JsonPropertyName("plugObjectives")]
        public DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent PlugObjectives { get; set; }

        [JsonPropertyName("talentGrids")]
        public DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent TalentGrids { get; set; }

        [JsonPropertyName("plugStates")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent PlugStates { get; set; }

        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent Objectives { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent Perks { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyItemComponentSetOfint64))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyItemComponentSetOfint64JsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemInstanceComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemInstanceComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemRenderComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemRenderComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemStatsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemStatsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemStatsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemSocketsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemSocketsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Items.DestinyItemPlugComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemPlugComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Inventory.DestinyCurrenciesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint64AndDestinyCurrenciesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyCharacterComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyCharacterComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyCharacterComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyCharacterProgressionComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterProgressionComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyCharacterProgressionComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyCharacterProgressionComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyCharacterRenderComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterRenderComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyCharacterRenderComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyCharacterRenderComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyCharacterActivitiesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterActivitiesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyCharacterActivitiesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyCharacterActivitiesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyCharacterRecordsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Records.DestinyCharacterRecordsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyCharacterRecordsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyCharacterRecordsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyCollectiblesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Collectibles.DestinyCollectiblesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyCollectiblesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyCollectiblesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyCurrenciesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Inventory.DestinyCurrenciesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyCurrenciesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyCurrenciesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemInstanceComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemInstanceComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemInstanceComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemObjectivesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemPerksComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemPerksComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemPerksComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemRenderComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemRenderComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemRenderComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemStatsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemStatsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemStatsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemTalentGridComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemTalentGridComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemTalentGridComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemSocketsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemSocketsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemSocketsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Items.DestinyItemReusablePlugsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemReusablePlugsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemReusablePlugsComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Items.DestinyItemPlugObjectivesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyItemPlugObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyItemPlugObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyVendorGroupComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Vendors.DestinyVendorGroupComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyVendorGroupComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyVendorGroupComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyVendorComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Vendors.DestinyVendorComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyVendorComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyVendorComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Vendors.DestinyVendorCategoriesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent
    {
        [JsonPropertyName("saleItems")]
        public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Responses.PersonalDestinyVendorSaleItemSetComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyBaseItemComponentSetOfint32
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent Objectives { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent Perks { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyBaseItemComponentSetOfint32))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyBaseItemComponentSetOfint32JsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemPerksComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemPerksComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyItemComponentSetOfint32
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent Instances { get; set; }

        [JsonPropertyName("renderData")]
        public DictionaryComponentResponseOfint32AndDestinyItemRenderComponent RenderData { get; set; }

        [JsonPropertyName("stats")]
        public DictionaryComponentResponseOfint32AndDestinyItemStatsComponent Stats { get; set; }

        [JsonPropertyName("sockets")]
        public DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent Sockets { get; set; }

        [JsonPropertyName("reusablePlugs")]
        public DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent ReusablePlugs { get; set; }

        [JsonPropertyName("plugObjectives")]
        public DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent PlugObjectives { get; set; }

        [JsonPropertyName("talentGrids")]
        public DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent TalentGrids { get; set; }

        [JsonPropertyName("plugStates")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent PlugStates { get; set; }

        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent Objectives { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent Perks { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyItemComponentSetOfint32))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyItemComponentSetOfint32JsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemInstanceComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemInstanceComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemRenderComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemRenderComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemStatsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemStatsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemStatsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemSocketsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemSocketsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyVendorComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Vendors.DestinyVendorComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyVendorComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyVendorComponentJsonContext : JsonSerializerContext { }
#endif

    public class SingleComponentResponseOfDestinyVendorCategoriesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Vendors.DestinyVendorCategoriesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SingleComponentResponseOfDestinyVendorCategoriesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SingleComponentResponseOfDestinyVendorCategoriesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Vendors.DestinyPublicVendorComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyVendorSaleItemSetComponentOfDestinyPublicVendorSaleItemComponent
    {
        [JsonPropertyName("saleItems")]
        public Dictionary<int, Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> SaleItems { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyVendorSaleItemSetComponentOfDestinyPublicVendorSaleItemComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyVendorSaleItemSetComponentOfDestinyPublicVendorSaleItemComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Responses.PublicDestinyVendorSaleItemSetComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyItemComponentSetOfuint32
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent Instances { get; set; }

        [JsonPropertyName("renderData")]
        public DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent RenderData { get; set; }

        [JsonPropertyName("stats")]
        public DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent Stats { get; set; }

        [JsonPropertyName("sockets")]
        public DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent Sockets { get; set; }

        [JsonPropertyName("reusablePlugs")]
        public DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent ReusablePlugs { get; set; }

        [JsonPropertyName("plugObjectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent PlugObjectives { get; set; }

        [JsonPropertyName("talentGrids")]
        public DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent TalentGrids { get; set; }

        [JsonPropertyName("plugStates")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent PlugStates { get; set; }

        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent Objectives { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent Perks { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyItemComponentSetOfuint32))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyItemComponentSetOfuint32JsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemInstanceComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemRenderComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemStatsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemStatsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemSocketsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponentJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfDestinyEntitySearchResultItem
    {
        [JsonPropertyName("results")]
        public IEnumerable<Destiny.Definitions.DestinyEntitySearchResultItem> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfDestinyEntitySearchResultItem))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfDestinyEntitySearchResultItemJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfTrendingEntry
    {
        [JsonPropertyName("results")]
        public IEnumerable<Trending.TrendingEntry> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfTrendingEntry))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfTrendingEntryJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfFireteamSummary
    {
        [JsonPropertyName("results")]
        public IEnumerable<Fireteam.FireteamSummary> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfFireteamSummary))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfFireteamSummaryJsonContext : JsonSerializerContext { }
#endif

    public class SearchResultOfFireteamResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<Fireteam.FireteamResponse> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(SearchResultOfFireteamResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SearchResultOfFireteamResponseJsonContext : JsonSerializerContext { }
#endif

    public class GlobalAlert
    {
        [JsonPropertyName("AlertKey")]
        public string AlertKey { get; set; }

        [JsonPropertyName("AlertHtml")]
        public string AlertHtml { get; set; }

        [JsonPropertyName("AlertTimestamp")]
        public System.DateTime AlertTimestamp { get; set; }

        [JsonPropertyName("AlertLink")]
        public string AlertLink { get; set; }

        [JsonPropertyName("AlertLevel")]
        public GlobalAlertLevel AlertLevel { get; set; }

        [JsonPropertyName("AlertType")]
        public GlobalAlertType AlertType { get; set; }

        [JsonPropertyName("StreamInfo")]
        public StreamInfo StreamInfo { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(GlobalAlert))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class GlobalAlertJsonContext : JsonSerializerContext { }
#endif

    public enum GlobalAlertLevel : int
    {
        Unknown = 0,
        Blue = 1,
        Yellow = 2,
        Red = 3
    }

    public enum GlobalAlertType : int
    {
        GlobalAlert = 0,
        StreamingAlert = 1
    }

    public class StreamInfo
    {
        [JsonPropertyName("ChannelName")]
        public string ChannelName { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(StreamInfo))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class StreamInfoJsonContext : JsonSerializerContext { }
#endif
}