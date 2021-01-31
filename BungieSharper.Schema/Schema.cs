using System;
using System.Collections.Generic;

namespace BungieSharper.Schema
{
    /// <summary>
    /// The types of membership the Accounts system supports. This is the external facing enum used in place of the internal-only Bungie.SharedDefinitions.MembershipType.
    /// </summary>
    public enum BungieMembershipType
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
        public IEnumerable<Content.ContentItemPublicContract> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfPostResponse
    {
        public IEnumerable<Forum.PostResponse> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfGroupV2Card
    {
        public IEnumerable<GroupsV2.GroupV2Card> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfGroupMember
    {
        public IEnumerable<GroupsV2.GroupMember> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfGroupBan
    {
        public IEnumerable<GroupsV2.GroupBan> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfGroupMemberApplication
    {
        public IEnumerable<GroupsV2.GroupMemberApplication> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfGroupMembership
    {
        public IEnumerable<GroupsV2.GroupMembership> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfGroupPotentialMembership
    {
        public IEnumerable<GroupsV2.GroupPotentialMembership> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorReceiptsComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Profiles.DestinyVendorReceiptsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyInventoryComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Inventory.DestinyInventoryComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Profiles.DestinyProfileComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyPlatformSilverComponent : Components.ComponentResponse
    {
        public Destiny.Components.Inventory.DestinyPlatformSilverComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyKiosksComponent : Components.ComponentResponse
    {
        public Destiny.Components.Kiosks.DestinyKiosksComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyPlugSetsComponent : Components.ComponentResponse
    {
        public Destiny.Components.PlugSets.DestinyPlugSetsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileProgressionComponent : Components.ComponentResponse
    {
        public Destiny.Components.Profiles.DestinyProfileProgressionComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyPresentationNodesComponent : Components.ComponentResponse
    {
        public Destiny.Components.Presentation.DestinyPresentationNodesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileRecordsComponent : Components.ComponentResponse
    {
        public Destiny.Components.Records.DestinyProfileRecordsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileCollectiblesComponent : Components.ComponentResponse
    {
        public Destiny.Components.Collectibles.DestinyProfileCollectiblesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileTransitoryComponent : Components.ComponentResponse
    {
        public Destiny.Components.Profiles.DestinyProfileTransitoryComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyMetricsComponent : Components.ComponentResponse
    {
        public Destiny.Components.Metrics.DestinyMetricsComponent data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyInventoryComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Inventory.DestinyInventoryComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterProgressionComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterActivitiesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyKiosksComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.Kiosks.DestinyKiosksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.PlugSets.DestinyPlugSetsComponent> data { get; set; }
    }

    public class DestinyBaseItemComponentSetOfuint32
    {
        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.Presentation.DestinyPresentationNodesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.Records.DestinyCharacterRecordsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.Collectibles.DestinyCollectiblesComponent> data { get; set; }
    }

    public class DestinyBaseItemComponentSetOfint64
    {
        public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Items.DestinyItemObjectivesComponent> data { get; set; }
    }

    public class DestinyItemComponentSetOfint64
    {
        public DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent instances { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent perks { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemRenderComponent renderData { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemStatsComponent stats { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent sockets { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent reusablePlugs { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent plugObjectives { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent talentGrids { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent plugStates { get; set; }

        public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Items.DestinyItemInstanceComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemPerksComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Items.DestinyItemPerksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemRenderComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Items.DestinyItemRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemStatsComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Items.DestinyItemStatsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Items.DestinyItemSocketsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.Items.DestinyItemReusablePlugsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Entities.Items.DestinyItemTalentGridComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Components.Items.DestinyItemPlugComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent : Components.ComponentResponse
    {
        public Dictionary<long, Destiny.Components.Inventory.DestinyCurrenciesComponent> data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Characters.DestinyCharacterComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterProgressionComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Characters.DestinyCharacterProgressionComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterRenderComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Characters.DestinyCharacterRenderComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterActivitiesComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Characters.DestinyCharacterActivitiesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterRecordsComponent : Components.ComponentResponse
    {
        public Destiny.Components.Records.DestinyCharacterRecordsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCollectiblesComponent : Components.ComponentResponse
    {
        public Destiny.Components.Collectibles.DestinyCollectiblesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCurrenciesComponent : Components.ComponentResponse
    {
        public Destiny.Components.Inventory.DestinyCurrenciesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemInstanceComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemInstanceComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemObjectivesComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemObjectivesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemPerksComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemPerksComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemRenderComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemRenderComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemStatsComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemStatsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemTalentGridComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemTalentGridComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemSocketsComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Items.DestinyItemSocketsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemReusablePlugsComponent : Components.ComponentResponse
    {
        public Destiny.Components.Items.DestinyItemReusablePlugsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemPlugObjectivesComponent : Components.ComponentResponse
    {
        public Destiny.Components.Items.DestinyItemPlugObjectivesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorGroupComponent : Components.ComponentResponse
    {
        public Destiny.Components.Vendors.DestinyVendorGroupComponent data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyVendorComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Vendors.DestinyVendorComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Vendors.DestinyVendorCategoriesComponent> data { get; set; }
    }

    public class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent
    {
        public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> saleItems { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Responses.PersonalDestinyVendorSaleItemSetComponent> data { get; set; }
    }

    public class DestinyBaseItemComponentSetOfint32
    {
        public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Items.DestinyItemObjectivesComponent> data { get; set; }
    }

    public class DestinyItemComponentSetOfint32
    {
        public DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent instances { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent perks { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemRenderComponent renderData { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemStatsComponent stats { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent sockets { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent reusablePlugs { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent plugObjectives { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent talentGrids { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent plugStates { get; set; }

        public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Items.DestinyItemInstanceComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemPerksComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Items.DestinyItemPerksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemRenderComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Items.DestinyItemRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemStatsComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Items.DestinyItemStatsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Items.DestinyItemSocketsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Components.Items.DestinyItemReusablePlugsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Items.DestinyItemTalentGridComponent> data { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Vendors.DestinyVendorComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorCategoriesComponent : Components.ComponentResponse
    {
        public Destiny.Entities.Vendors.DestinyVendorCategoriesComponent data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent : Components.ComponentResponse
    {
        public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Components.Vendors.DestinyPublicVendorComponent> data { get; set; }
    }

    public class DestinyVendorSaleItemSetComponentOfDestinyPublicVendorSaleItemComponent
    {
        public Dictionary<int, Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> saleItems { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Responses.PublicDestinyVendorSaleItemSetComponent> data { get; set; }
    }

    public class DestinyItemComponentSetOfuint32
    {
        public DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent instances { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent perks { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent renderData { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent stats { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent sockets { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent reusablePlugs { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent plugObjectives { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent talentGrids { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent plugStates { get; set; }

        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemInstanceComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemPerksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemStatsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemSocketsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Components.Items.DestinyItemReusablePlugsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent : Components.ComponentResponse
    {
        public Dictionary<uint, Destiny.Entities.Items.DestinyItemTalentGridComponent> data { get; set; }
    }

    public class SearchResultOfDestinyEntitySearchResultItem
    {
        public IEnumerable<Destiny.Definitions.DestinyEntitySearchResultItem> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfTrendingEntry
    {
        public IEnumerable<Trending.TrendingEntry> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfFireteamSummary
    {
        public IEnumerable<Fireteam.FireteamSummary> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SearchResultOfFireteamResponse
    {
        public IEnumerable<Fireteam.FireteamResponse> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class GlobalAlert
    {
        public string AlertKey { get; set; }

        public string AlertHtml { get; set; }

        public DateTime AlertTimestamp { get; set; }

        public string AlertLink { get; set; }

        public GlobalAlertLevel AlertLevel { get; set; }

        public GlobalAlertType AlertType { get; set; }

        public StreamInfo StreamInfo { get; set; }
    }

    public enum GlobalAlertLevel
    {
        Unknown = 0,

        Blue = 1,

        Yellow = 2,

        Red = 3
    }

    public enum GlobalAlertType
    {
        GlobalAlert = 0,

        StreamingAlert = 1
    }

    public class StreamInfo
    {
        public string ChannelName { get; set; }
    }
}