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

    public class SingleComponentResponseOfDestinyVendorReceiptsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Profiles.DestinyVendorReceiptsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyInventoryComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Inventory.DestinyInventoryComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Profiles.DestinyProfileComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyPlatformSilverComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Inventory.DestinyPlatformSilverComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyKiosksComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Kiosks.DestinyKiosksComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyPlugSetsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.PlugSets.DestinyPlugSetsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileProgressionComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Profiles.DestinyProfileProgressionComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyPresentationNodesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Presentation.DestinyPresentationNodesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileRecordsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Records.DestinyProfileRecordsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileCollectiblesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Collectibles.DestinyProfileCollectiblesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileTransitoryComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Profiles.DestinyProfileTransitoryComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyMetricsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Metrics.DestinyMetricsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyStringVariablesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.StringVariables.DestinyStringVariablesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyInventoryComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Inventory.DestinyInventoryComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterProgressionComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterActivitiesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyKiosksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Kiosks.DestinyKiosksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.PlugSets.DestinyPlugSetsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyBaseItemComponentSetOfuint32
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent Objectives { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Presentation.DestinyPresentationNodesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Records.DestinyCharacterRecordsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Collectibles.DestinyCollectiblesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.StringVariables.DestinyStringVariablesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyBaseItemComponentSetOfint64
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent Objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyItemComponentSetOfint64
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent Instances { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent Perks { get; set; }

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
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemInstanceComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemStatsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemSocketsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Items.DestinyItemPlugComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<long, Destiny.Components.Inventory.DestinyCurrenciesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterProgressionComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterProgressionComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterRenderComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterRenderComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterActivitiesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Characters.DestinyCharacterActivitiesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterRecordsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Records.DestinyCharacterRecordsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyCollectiblesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Collectibles.DestinyCollectiblesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyCurrenciesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Inventory.DestinyCurrenciesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemInstanceComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemObjectivesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemPerksComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemRenderComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemStatsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemTalentGridComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Items.DestinyItemSocketsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Items.DestinyItemReusablePlugsComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Items.DestinyItemPlugObjectivesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorGroupComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Components.Vendors.DestinyVendorGroupComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyVendorComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Vendors.DestinyVendorComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Vendors.DestinyVendorCategoriesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent
    {
        [JsonPropertyName("saleItems")]
        public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Responses.PersonalDestinyVendorSaleItemSetComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyBaseItemComponentSetOfint32
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent Objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyItemComponentSetOfint32
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent Instances { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent Perks { get; set; }

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
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemInstanceComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemStatsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemSocketsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Vendors.DestinyVendorComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorCategoriesComponent
    {
        [JsonPropertyName("data")]
        public Destiny.Entities.Vendors.DestinyVendorCategoriesComponent Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Vendors.DestinyPublicVendorComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyVendorSaleItemSetComponentOfDestinyPublicVendorSaleItemComponent
    {
        [JsonPropertyName("saleItems")]
        public Dictionary<int, Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> SaleItems { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Responses.PublicDestinyVendorSaleItemSetComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DestinyItemComponentSetOfuint32
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent Instances { get; set; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent Perks { get; set; }

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
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemInstanceComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemRenderComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemStatsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemSocketsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent
    {
        [JsonPropertyName("data")]
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; set; }

        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

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
}