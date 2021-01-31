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
        public IEnumerable<Schema.Content.ContentItemPublicContract> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.Forum.PostResponse> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.GroupsV2.GroupV2Card> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.GroupsV2.GroupMember> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.GroupsV2.GroupBan> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.GroupsV2.GroupMemberApplication> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.GroupsV2.GroupMembership> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.GroupsV2.GroupPotentialMembership> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

        public string replacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorReceiptsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Profiles.DestinyVendorReceiptsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyInventoryComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Inventory.DestinyInventoryComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Profiles.DestinyProfileComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyPlatformSilverComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Inventory.DestinyPlatformSilverComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyKiosksComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Kiosks.DestinyKiosksComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyPlugSetsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.PlugSets.DestinyPlugSetsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileProgressionComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Profiles.DestinyProfileProgressionComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyPresentationNodesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Presentation.DestinyPresentationNodesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileRecordsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Records.DestinyProfileRecordsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileCollectiblesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Collectibles.DestinyProfileCollectiblesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyProfileTransitoryComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Profiles.DestinyProfileTransitoryComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyMetricsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Metrics.DestinyMetricsComponent data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Characters.DestinyCharacterComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyInventoryComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Inventory.DestinyInventoryComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Characters.DestinyCharacterProgressionComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Characters.DestinyCharacterRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Characters.DestinyCharacterActivitiesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyKiosksComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.Kiosks.DestinyKiosksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.PlugSets.DestinyPlugSetsComponent> data { get; set; }
    }

    public class DestinyBaseItemComponentSetOfuint32
    {
        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Items.DestinyItemObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.Presentation.DestinyPresentationNodesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.Records.DestinyCharacterRecordsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.Collectibles.DestinyCollectiblesComponent> data { get; set; }
    }

    public class DestinyBaseItemComponentSetOfint64
    {
        public Schema.DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Items.DestinyItemObjectivesComponent> data { get; set; }
    }

    public class DestinyItemComponentSetOfint64
    {
        public Schema.DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent instances { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemPerksComponent perks { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemRenderComponent renderData { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemStatsComponent stats { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent sockets { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent reusablePlugs { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent plugObjectives { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent talentGrids { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent plugStates { get; set; }

        public Schema.DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Items.DestinyItemInstanceComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemPerksComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Items.DestinyItemPerksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemRenderComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Items.DestinyItemRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemStatsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Items.DestinyItemStatsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Items.DestinyItemSocketsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.Items.DestinyItemReusablePlugsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.Items.DestinyItemPlugObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Entities.Items.DestinyItemTalentGridComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Components.Items.DestinyItemPlugComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<long, Schema.Destiny.Components.Inventory.DestinyCurrenciesComponent> data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Characters.DestinyCharacterComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterProgressionComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Characters.DestinyCharacterProgressionComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterRenderComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Characters.DestinyCharacterRenderComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterActivitiesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Characters.DestinyCharacterActivitiesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCharacterRecordsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Records.DestinyCharacterRecordsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCollectiblesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Collectibles.DestinyCollectiblesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyCurrenciesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Inventory.DestinyCurrenciesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemInstanceComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemInstanceComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemObjectivesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemPerksComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemPerksComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemRenderComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemRenderComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemStatsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemStatsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemTalentGridComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemTalentGridComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemSocketsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Items.DestinyItemSocketsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemReusablePlugsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Items.DestinyItemReusablePlugsComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyItemPlugObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Items.DestinyItemPlugObjectivesComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorGroupComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Components.Vendors.DestinyVendorGroupComponent data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyVendorComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Vendors.DestinyVendorComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Vendors.DestinyVendorCategoriesComponent> data { get; set; }
    }

    public class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent
    {
        public Dictionary<int, Schema.Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> saleItems { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Responses.PersonalDestinyVendorSaleItemSetComponent> data { get; set; }
    }

    public class DestinyBaseItemComponentSetOfint32
    {
        public Schema.DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Items.DestinyItemObjectivesComponent> data { get; set; }
    }

    public class DestinyItemComponentSetOfint32
    {
        public Schema.DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent instances { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemPerksComponent perks { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemRenderComponent renderData { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemStatsComponent stats { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent sockets { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent reusablePlugs { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent plugObjectives { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent talentGrids { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent plugStates { get; set; }

        public Schema.DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Items.DestinyItemInstanceComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemPerksComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Items.DestinyItemPerksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemRenderComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Items.DestinyItemRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemStatsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Items.DestinyItemStatsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Items.DestinyItemSocketsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Components.Items.DestinyItemReusablePlugsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Components.Items.DestinyItemPlugObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Items.DestinyItemTalentGridComponent> data { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Vendors.DestinyVendorComponent data { get; set; }
    }

    public class SingleComponentResponseOfDestinyVendorCategoriesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Schema.Destiny.Entities.Vendors.DestinyVendorCategoriesComponent data { get; set; }
    }

    public class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<int, Schema.Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Components.Vendors.DestinyPublicVendorComponent> data { get; set; }
    }

    public class DestinyVendorSaleItemSetComponentOfDestinyPublicVendorSaleItemComponent
    {
        public Dictionary<int, Schema.Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> saleItems { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Responses.PublicDestinyVendorSaleItemSetComponent> data { get; set; }
    }

    public class DestinyItemComponentSetOfuint32
    {
        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent instances { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent perks { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent renderData { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent stats { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent sockets { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent reusablePlugs { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent plugObjectives { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent talentGrids { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent plugStates { get; set; }

        public Schema.DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent objectives { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Items.DestinyItemInstanceComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Items.DestinyItemPerksComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Items.DestinyItemRenderComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Items.DestinyItemStatsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Items.DestinyItemSocketsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Components.Items.DestinyItemReusablePlugsComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Components.Items.DestinyItemPlugObjectivesComponent> data { get; set; }
    }

    public class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent : BungieSharper.Schema.Components.ComponentResponse
    {
        public Dictionary<uint, Schema.Destiny.Entities.Items.DestinyItemTalentGridComponent> data { get; set; }
    }

    public class SearchResultOfDestinyEntitySearchResultItem
    {
        public IEnumerable<Schema.Destiny.Definitions.DestinyEntitySearchResultItem> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.Trending.TrendingEntry> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.Fireteam.FireteamSummary> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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
        public IEnumerable<Schema.Fireteam.FireteamResponse> results { get; set; }

        public int totalResults { get; set; }

        public bool hasMore { get; set; }

        public Schema.Queries.PagedQuery query { get; set; }

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

        public Schema.GlobalAlertLevel AlertLevel { get; set; }

        public Schema.GlobalAlertType AlertType { get; set; }

        public Schema.StreamInfo StreamInfo { get; set; }
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