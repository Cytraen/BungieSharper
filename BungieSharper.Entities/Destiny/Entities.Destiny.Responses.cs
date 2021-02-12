using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Responses
{
    /// <summary>
    /// I know what you seek. You seek linked accounts. Found them, you have.
    /// This contract returns a minimal amount of data about Destiny Accounts that are linked through your Bungie.Net account. We will not return accounts in this response whose
    /// </summary>
    public class DestinyLinkedProfilesResponse
    {
        /// <summary>Any Destiny account for whom we could successfully pull characters will be returned here, as the Platform-level summary of user data. (no character data, no Destiny account data other than the Membership ID and Type so you can make further queries)</summary>
        [JsonPropertyName("profiles")]
        public IEnumerable<Destiny.Responses.DestinyProfileUserInfoCard> Profiles { get; set; }

        /// <summary>
        /// If the requested membership had a linked Bungie.Net membership ID, this is the basic information about that BNet account.
        /// I know, Tetron; I know this is mixing UserServices concerns with DestinyServices concerns. But it's so damn convenient! https://www.youtube.com/watch?v=X5R-bB-gKVI
        /// </summary>
        [JsonPropertyName("bnetMembership")]
        public User.UserInfoCard BnetMembership { get; set; }

        /// <summary>This is brief summary info for profiles that we believe have valid Destiny info, but who failed to return data for some other reason and thus we know that subsequent calls for their info will also fail.</summary>
        [JsonPropertyName("profilesWithErrors")]
        public IEnumerable<Destiny.Responses.DestinyErrorProfile> ProfilesWithErrors { get; set; }
    }

    public class DestinyProfileUserInfoCard
    {
        [JsonPropertyName("dateLastPlayed")]
        public System.DateTime DateLastPlayed { get; set; }

        /// <summary>If this profile is being overridden/obscured by Cross Save, this will be set to true. We will still return the profile for display purposes where users need to know the info: it is up to any given area of the app/site to determine if this profile should still be shown.</summary>
        [JsonPropertyName("isOverridden")]
        public bool IsOverridden { get; set; }

        /// <summary>If true, this account is hooked up as the "Primary" cross save account for one or more platforms.</summary>
        [JsonPropertyName("isCrossSavePrimary")]
        public bool IsCrossSavePrimary { get; set; }

        /// <summary>
        /// This is the silver available on this Profile across any platforms on which they have purchased silver.
        /// This is only available if you are requesting yourself.
        /// </summary>
        [JsonPropertyName("platformSilver")]
        public Destiny.Components.Inventory.DestinyPlatformSilverComponent PlatformSilver { get; set; }

        /// <summary>
        /// If this profile is not in a cross save pairing, this will return the game versions that we believe this profile has access to.
        /// For the time being, we will not return this information for any membership that is in a cross save pairing. The gist is that, once the pairing occurs, we do not currently have a consistent way to get that information for the profile's original Platform, and thus gameVersions would be too inconsistent (based on the last platform they happened to play on) for the info to be useful.
        /// If we ever can get this data, this field will be deprecated and replaced with data on the DestinyLinkedProfileResponse itself, with game versions per linked Platform. But since we can't get that, we have this as a stop-gap measure for getting the data in the only situation that we currently need it.
        /// </summary>
        [JsonPropertyName("unpairedGameVersions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UnpairedGameVersions { get; set; }

        /// <summary>A platform specific additional display name - ex: psn Real Name, bnet Unique Name, etc.</summary>
        [JsonPropertyName("supplementalDisplayName")]
        public string SupplementalDisplayName { get; set; }

        /// <summary>URL the Icon if available.</summary>
        [JsonPropertyName("iconPath")]
        public string IconPath { get; set; }

        /// <summary>If there is a cross save override in effect, this value will tell you the type that is overridding this one.</summary>
        [JsonPropertyName("crossSaveOverride")]
        public BungieMembershipType CrossSaveOverride { get; set; }

        /// <summary>
        /// The list of Membership Types indicating the platforms on which this Membership can be used.
        /// Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and its original membership type Cross Save Overridden = Empty list
        /// </summary>
        [JsonPropertyName("applicableMembershipTypes")]
        public IEnumerable<BungieMembershipType> ApplicableMembershipTypes { get; set; }

        /// <summary>If True, this is a public user membership.</summary>
        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; }

        /// <summary>Type of the membership. Not necessarily the native type.</summary>
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }

        /// <summary>Membership ID as they user is known in the Accounts service</summary>
        [JsonPropertyName("membershipId")]
        public long MembershipId { get; set; }

        /// <summary>Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.</summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }

    /// <summary>
    /// If a Destiny Profile can't be returned, but we're pretty certain it's a valid Destiny account, this will contain as much info as we can get about the profile for your use.
    /// Assume that the most you'll get is the Error Code, the Membership Type and the Membership ID.
    /// </summary>
    public class DestinyErrorProfile
    {
        /// <summary>The error that we encountered. You should be able to look up localized text to show to the user for these failures.</summary>
        [JsonPropertyName("errorCode")]
        public Exceptions.PlatformErrorCodes ErrorCode { get; set; }

        /// <summary>Basic info about the account that failed. Don't expect anything other than membership ID, Membership Type, and displayName to be populated.</summary>
        [JsonPropertyName("infoCard")]
        public User.UserInfoCard InfoCard { get; set; }
    }

    /// <summary>
    /// The response for GetDestinyProfile, with components for character and item-level data.
    /// </summary>
    public class DestinyProfileResponse
    {
        /// <summary>
        /// Recent, refundable purchases you have made from vendors. When will you use it? Couldn't say...
        /// COMPONENT TYPE: VendorReceipts
        /// </summary>
        [JsonPropertyName("vendorReceipts")]
        public SingleComponentResponseOfDestinyVendorReceiptsComponent VendorReceipts { get; set; }

        /// <summary>
        /// The profile-level inventory of the Destiny Profile.
        /// COMPONENT TYPE: ProfileInventories
        /// </summary>
        [JsonPropertyName("profileInventory")]
        public SingleComponentResponseOfDestinyInventoryComponent ProfileInventory { get; set; }

        /// <summary>
        /// The profile-level currencies owned by the Destiny Profile.
        /// COMPONENT TYPE: ProfileCurrencies
        /// </summary>
        [JsonPropertyName("profileCurrencies")]
        public SingleComponentResponseOfDestinyInventoryComponent ProfileCurrencies { get; set; }

        /// <summary>
        /// The basic information about the Destiny Profile (formerly "Account").
        /// COMPONENT TYPE: Profiles
        /// </summary>
        [JsonPropertyName("profile")]
        public SingleComponentResponseOfDestinyProfileComponent Profile { get; set; }

        /// <summary>
        /// Silver quantities for any platform on which this Profile plays destiny.
        /// COMPONENT TYPE: PlatformSilver
        /// </summary>
        [JsonPropertyName("platformSilver")]
        public SingleComponentResponseOfDestinyPlatformSilverComponent PlatformSilver { get; set; }

        /// <summary>
        /// Items available from Kiosks that are available Profile-wide (i.e. across all characters)
        /// This component returns information about what Kiosk items are available to you on a *Profile* level. It is theoretically possible for Kiosks to have items gated by specific Character as well. If you ever have those, you will find them on the characterKiosks property.
        /// COMPONENT TYPE: Kiosks
        /// </summary>
        [JsonPropertyName("profileKiosks")]
        public SingleComponentResponseOfDestinyKiosksComponent ProfileKiosks { get; set; }

        /// <summary>
        /// When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states that are profile-scoped.
        /// This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
        /// COMPONENT TYPE: ItemSockets
        /// </summary>
        [JsonPropertyName("profilePlugSets")]
        public SingleComponentResponseOfDestinyPlugSetsComponent ProfilePlugSets { get; set; }

        /// <summary>
        /// When we have progression information - such as Checklists - that may apply profile-wide, it will be returned here rather than in the per-character progression data.
        /// COMPONENT TYPE: ProfileProgression
        /// </summary>
        [JsonPropertyName("profileProgression")]
        public SingleComponentResponseOfDestinyProfileProgressionComponent ProfileProgression { get; set; }

        /// <summary>COMPONENT TYPE: PresentationNodes</summary>
        [JsonPropertyName("profilePresentationNodes")]
        public SingleComponentResponseOfDestinyPresentationNodesComponent ProfilePresentationNodes { get; set; }

        /// <summary>COMPONENT TYPE: Records</summary>
        [JsonPropertyName("profileRecords")]
        public SingleComponentResponseOfDestinyProfileRecordsComponent ProfileRecords { get; set; }

        /// <summary>COMPONENT TYPE: Collectibles</summary>
        [JsonPropertyName("profileCollectibles")]
        public SingleComponentResponseOfDestinyProfileCollectiblesComponent ProfileCollectibles { get; set; }

        /// <summary>COMPONENT TYPE: Transitory</summary>
        [JsonPropertyName("profileTransitoryData")]
        public SingleComponentResponseOfDestinyProfileTransitoryComponent ProfileTransitoryData { get; set; }

        /// <summary>COMPONENT TYPE: Metrics</summary>
        [JsonPropertyName("metrics")]
        public SingleComponentResponseOfDestinyMetricsComponent Metrics { get; set; }

        /// <summary>
        /// Basic information about each character, keyed by the CharacterId.
        /// COMPONENT TYPE: Characters
        /// </summary>
        [JsonPropertyName("characters")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterComponent Characters { get; set; }

        /// <summary>
        /// The character-level non-equipped inventory items, keyed by the Character's Id.
        /// COMPONENT TYPE: CharacterInventories
        /// </summary>
        [JsonPropertyName("characterInventories")]
        public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterInventories { get; set; }

        /// <summary>
        /// Character-level progression data, keyed by the Character's Id.
        /// COMPONENT TYPE: CharacterProgressions
        /// </summary>
        [JsonPropertyName("characterProgressions")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent CharacterProgressions { get; set; }

        /// <summary>
        /// Character rendering data - a minimal set of info needed to render a character in 3D - keyed by the Character's Id.
        /// COMPONENT TYPE: CharacterRenderData
        /// </summary>
        [JsonPropertyName("characterRenderData")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent CharacterRenderData { get; set; }

        /// <summary>
        /// Character activity data - the activities available to this character and its status, keyed by the Character's Id.
        /// COMPONENT TYPE: CharacterActivities
        /// </summary>
        [JsonPropertyName("characterActivities")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent CharacterActivities { get; set; }

        /// <summary>
        /// The character's equipped items, keyed by the Character's Id.
        /// COMPONENT TYPE: CharacterEquipment
        /// </summary>
        [JsonPropertyName("characterEquipment")]
        public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterEquipment { get; set; }

        /// <summary>
        /// Items available from Kiosks that are available to a specific character as opposed to the account as a whole. It must be combined with data from the profileKiosks property to get a full picture of the character's available items to check out of a kiosk.
        /// This component returns information about what Kiosk items are available to you on a *Character* level. Usually, kiosk items will be earned for the entire Profile (all characters) at once. To find those, look in the profileKiosks property.
        /// COMPONENT TYPE: Kiosks
        /// </summary>
        [JsonPropertyName("characterKiosks")]
        public DictionaryComponentResponseOfint64AndDestinyKiosksComponent CharacterKiosks { get; set; }

        /// <summary>
        /// When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states, per character, that are character-scoped.
        /// This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
        /// COMPONENT TYPE: ItemSockets
        /// </summary>
        [JsonPropertyName("characterPlugSets")]
        public DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent CharacterPlugSets { get; set; }

        /// <summary>
        /// Do you ever get the feeling that a system was designed *too* flexibly? That it can be used in so many different ways that you end up being unable to provide an easy to use abstraction for the mess that's happening under the surface?
        /// Let's talk about character-specific data that might be related to items without instances. These two statements are totally unrelated, I promise.
        /// At some point during D2, it was decided that items - such as Bounties - could be given to characters and *not* have instance data, but that *could* display and even use relevant state information on your account and character.
        /// Up to now, any item that had meaningful dependencies on character or account state had to be instanced, and thus "itemComponents" was all that you needed: it was keyed by item's instance IDs and provided the stateful information you needed inside.
        /// Unfortunately, we don't live in such a magical world anymore. This is information held on a per-character basis about non-instanced items that the characters have in their inventory - or that reference character-specific state information even if it's in Account-level inventory - and the values related to that item's state in relation to the given character.
        /// To give a concrete example, look at a Moments of Triumph bounty. They exist in a character's inventory, and show/care about a character's progression toward completing the bounty. But the bounty itself is a non-instanced item, like a mod or a currency. This returns that data for the characters who have the bounty in their inventory.
        /// I'm not crying, you're crying Okay we're both crying but it's going to be okay I promise Actually I shouldn't promise that, I don't know if it's going to be okay
        /// </summary>
        [JsonPropertyName("characterUninstancedItemComponents")]
        public Dictionary<long, DestinyBaseItemComponentSetOfuint32> CharacterUninstancedItemComponents { get; set; }

        /// <summary>COMPONENT TYPE: PresentationNodes</summary>
        [JsonPropertyName("characterPresentationNodes")]
        public DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent CharacterPresentationNodes { get; set; }

        /// <summary>COMPONENT TYPE: Records</summary>
        [JsonPropertyName("characterRecords")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent CharacterRecords { get; set; }

        /// <summary>COMPONENT TYPE: Collectibles</summary>
        [JsonPropertyName("characterCollectibles")]
        public DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent CharacterCollectibles { get; set; }

        /// <summary>
        /// Information about instanced items across all returned characters, keyed by the item's instance ID.
        /// COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
        /// </summary>
        [JsonPropertyName("itemComponents")]
        public DestinyItemComponentSetOfint64 ItemComponents { get; set; }

        /// <summary>
        /// A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
        /// COMPONENT TYPE: CurrencyLookups
        /// </summary>
        [JsonPropertyName("characterCurrencyLookups")]
        public DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent CharacterCurrencyLookups { get; set; }
    }

    /// <summary>
    /// The response contract for GetDestinyCharacter, with components that can be returned for character and item-level data.
    /// </summary>
    public class DestinyCharacterResponse
    {
        /// <summary>
        /// The character-level non-equipped inventory items.
        /// COMPONENT TYPE: CharacterInventories
        /// </summary>
        [JsonPropertyName("inventory")]
        public SingleComponentResponseOfDestinyInventoryComponent Inventory { get; set; }

        /// <summary>
        /// Base information about the character in question.
        /// COMPONENT TYPE: Characters
        /// </summary>
        [JsonPropertyName("character")]
        public SingleComponentResponseOfDestinyCharacterComponent Character { get; set; }

        /// <summary>
        /// Character progression data, including Milestones.
        /// COMPONENT TYPE: CharacterProgressions
        /// </summary>
        [JsonPropertyName("progressions")]
        public SingleComponentResponseOfDestinyCharacterProgressionComponent Progressions { get; set; }

        /// <summary>
        /// Character rendering data - a minimal set of information about equipment and dyes used for rendering.
        /// COMPONENT TYPE: CharacterRenderData
        /// </summary>
        [JsonPropertyName("renderData")]
        public SingleComponentResponseOfDestinyCharacterRenderComponent RenderData { get; set; }

        /// <summary>
        /// Activity data - info about current activities available to the player.
        /// COMPONENT TYPE: CharacterActivities
        /// </summary>
        [JsonPropertyName("activities")]
        public SingleComponentResponseOfDestinyCharacterActivitiesComponent Activities { get; set; }

        /// <summary>
        /// Equipped items on the character.
        /// COMPONENT TYPE: CharacterEquipment
        /// </summary>
        [JsonPropertyName("equipment")]
        public SingleComponentResponseOfDestinyInventoryComponent Equipment { get; set; }

        /// <summary>
        /// Items available from Kiosks that are available to this specific character.
        /// COMPONENT TYPE: Kiosks
        /// </summary>
        [JsonPropertyName("kiosks")]
        public SingleComponentResponseOfDestinyKiosksComponent Kiosks { get; set; }

        /// <summary>
        /// When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states that are scoped to this character.
        /// This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
        /// COMPONENT TYPE: ItemSockets
        /// </summary>
        [JsonPropertyName("plugSets")]
        public SingleComponentResponseOfDestinyPlugSetsComponent PlugSets { get; set; }

        /// <summary>COMPONENT TYPE: PresentationNodes</summary>
        [JsonPropertyName("presentationNodes")]
        public SingleComponentResponseOfDestinyPresentationNodesComponent PresentationNodes { get; set; }

        /// <summary>COMPONENT TYPE: Records</summary>
        [JsonPropertyName("records")]
        public SingleComponentResponseOfDestinyCharacterRecordsComponent Records { get; set; }

        /// <summary>COMPONENT TYPE: Collectibles</summary>
        [JsonPropertyName("collectibles")]
        public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; set; }

        /// <summary>
        /// The set of components belonging to the player's instanced items.
        /// COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
        /// </summary>
        [JsonPropertyName("itemComponents")]
        public DestinyItemComponentSetOfint64 ItemComponents { get; set; }

        /// <summary>
        /// The set of components belonging to the player's UNinstanced items. Because apparently now those too can have information relevant to the character's state.
        /// COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
        /// </summary>
        [JsonPropertyName("uninstancedItemComponents")]
        public DestinyBaseItemComponentSetOfuint32 UninstancedItemComponents { get; set; }

        /// <summary>
        /// A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
        /// COMPONENT TYPE: CurrencyLookups
        /// </summary>
        [JsonPropertyName("currencyLookups")]
        public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; set; }
    }

    /// <summary>
    /// The response object for retrieving an individual instanced item. None of these components are relevant for an item that doesn't have an "itemInstanceId": for those, get your information from the DestinyInventoryDefinition.
    /// </summary>
    public class DestinyItemResponse
    {
        /// <summary>If the item is on a character, this will return the ID of the character that is holding the item.</summary>
        [JsonPropertyName("characterId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? CharacterId { get; set; }

        /// <summary>
        /// Common data for the item relevant to its non-instanced properties.
        /// COMPONENT TYPE: ItemCommonData
        /// </summary>
        [JsonPropertyName("item")]
        public SingleComponentResponseOfDestinyItemComponent Item { get; set; }

        /// <summary>
        /// Basic instance data for the item.
        /// COMPONENT TYPE: ItemInstances
        /// </summary>
        [JsonPropertyName("instance")]
        public SingleComponentResponseOfDestinyItemInstanceComponent Instance { get; set; }

        /// <summary>
        /// Information specifically about the item's objectives.
        /// COMPONENT TYPE: ItemObjectives
        /// </summary>
        [JsonPropertyName("objectives")]
        public SingleComponentResponseOfDestinyItemObjectivesComponent Objectives { get; set; }

        /// <summary>
        /// Information specifically about the perks currently active on the item.
        /// COMPONENT TYPE: ItemPerks
        /// </summary>
        [JsonPropertyName("perks")]
        public SingleComponentResponseOfDestinyItemPerksComponent Perks { get; set; }

        /// <summary>
        /// Information about how to render the item in 3D.
        /// COMPONENT TYPE: ItemRenderData
        /// </summary>
        [JsonPropertyName("renderData")]
        public SingleComponentResponseOfDestinyItemRenderComponent RenderData { get; set; }

        /// <summary>
        /// Information about the computed stats of the item: power, defense, etc...
        /// COMPONENT TYPE: ItemStats
        /// </summary>
        [JsonPropertyName("stats")]
        public SingleComponentResponseOfDestinyItemStatsComponent Stats { get; set; }

        /// <summary>
        /// Information about the talent grid attached to the item. Talent nodes can provide a variety of benefits and abilities, and in Destiny 2 are used almost exclusively for the character's "Builds".
        /// COMPONENT TYPE: ItemTalentGrids
        /// </summary>
        [JsonPropertyName("talentGrid")]
        public SingleComponentResponseOfDestinyItemTalentGridComponent TalentGrid { get; set; }

        /// <summary>
        /// Information about the sockets of the item: which are currently active, what potential sockets you could have and the stats/abilities/perks you can gain from them.
        /// COMPONENT TYPE: ItemSockets
        /// </summary>
        [JsonPropertyName("sockets")]
        public SingleComponentResponseOfDestinyItemSocketsComponent Sockets { get; set; }

        /// <summary>
        /// Information about the Reusable Plugs for sockets on an item. These are plugs that you can insert into the given socket regardless of if you actually own an instance of that plug: they are logic-driven plugs rather than inventory-driven.
        /// These may need to be combined with Plug Set component data to get a full picture of available plugs on a given socket.
        /// COMPONENT TYPE: ItemReusablePlugs
        /// </summary>
        [JsonPropertyName("reusablePlugs")]
        public SingleComponentResponseOfDestinyItemReusablePlugsComponent ReusablePlugs { get; set; }

        /// <summary>
        /// Information about objectives on Plugs for a given item. See the component's documentation for more info.
        /// COMPONENT TYPE: ItemPlugObjectives
        /// </summary>
        [JsonPropertyName("plugObjectives")]
        public SingleComponentResponseOfDestinyItemPlugObjectivesComponent PlugObjectives { get; set; }
    }

    /// <summary>
    /// A response containing all of the components for all requested vendors.
    /// </summary>
    public class DestinyVendorsResponse
    {
        /// <summary>
        /// For Vendors being returned, this will give you the information you need to group them and order them in the same way that the Bungie Companion app performs grouping. It will automatically be returned if you request the Vendors component.
        /// COMPONENT TYPE: Vendors
        /// </summary>
        [JsonPropertyName("vendorGroups")]
        public SingleComponentResponseOfDestinyVendorGroupComponent VendorGroups { get; set; }

        /// <summary>
        /// The base properties of the vendor. These are keyed by the Vendor Hash, so you will get one Vendor Component per vendor returned.
        /// COMPONENT TYPE: Vendors
        /// </summary>
        [JsonPropertyName("vendors")]
        public DictionaryComponentResponseOfuint32AndDestinyVendorComponent Vendors { get; set; }

        /// <summary>
        /// Categories that the vendor has available, and references to the sales therein. These are keyed by the Vendor Hash, so you will get one Categories Component per vendor returned.
        /// COMPONENT TYPE: VendorCategories
        /// </summary>
        [JsonPropertyName("categories")]
        public DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent Categories { get; set; }

        /// <summary>
        /// Sales, keyed by the vendorItemIndex of the item being sold. These are keyed by the Vendor Hash, so you will get one Sale Item Set Component per vendor returned.
        /// Note that within the Sale Item Set component, the sales are themselves keyed by the vendorSaleIndex, so you can relate it to the corrent sale item definition within the Vendor's definition.
        /// COMPONENT TYPE: VendorSales
        /// </summary>
        [JsonPropertyName("sales")]
        public DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent Sales { get; set; }

        /// <summary>
        /// The set of item detail components, one set of item components per Vendor. These are keyed by the Vendor Hash, so you will get one Item Component Set per vendor returned.
        /// The components contained inside are themselves keyed by the vendorSaleIndex, and will have whatever item-level components you requested (Sockets, Stats, Instance data etc...) per item being sold by the vendor.
        /// </summary>
        [JsonPropertyName("itemComponents")]
        public Dictionary<uint, DestinyItemComponentSetOfint32> ItemComponents { get; set; }

        /// <summary>
        /// A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
        /// COMPONENT TYPE: CurrencyLookups
        /// </summary>
        [JsonPropertyName("currencyLookups")]
        public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; set; }
    }

    public class PersonalDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("saleItems")]
        public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; set; }
    }

    /// <summary>
    /// A response containing all of the components for a vendor.
    /// </summary>
    public class DestinyVendorResponse
    {
        /// <summary>
        /// The base properties of the vendor.
        /// COMPONENT TYPE: Vendors
        /// </summary>
        [JsonPropertyName("vendor")]
        public SingleComponentResponseOfDestinyVendorComponent Vendor { get; set; }

        /// <summary>
        /// Categories that the vendor has available, and references to the sales therein.
        /// COMPONENT TYPE: VendorCategories
        /// </summary>
        [JsonPropertyName("categories")]
        public SingleComponentResponseOfDestinyVendorCategoriesComponent Categories { get; set; }

        /// <summary>
        /// Sales, keyed by the vendorItemIndex of the item being sold.
        /// COMPONENT TYPE: VendorSales
        /// </summary>
        [JsonPropertyName("sales")]
        public DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent Sales { get; set; }

        /// <summary>
        /// Item components, keyed by the vendorItemIndex of the active sale items.
        /// COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
        /// </summary>
        [JsonPropertyName("itemComponents")]
        public DestinyItemComponentSetOfint32 ItemComponents { get; set; }

        /// <summary>
        /// A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
        /// COMPONENT TYPE: CurrencyLookups
        /// </summary>
        [JsonPropertyName("currencyLookups")]
        public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; set; }
    }

    /// <summary>
    /// A response containing all valid components for the public Vendors endpoint.
    /// It is a decisively smaller subset of data compared to what we can get when we know the specific user making the request.
    /// If you want any of the other data - item details, whether or not you can buy it, etc... you'll have to call in the context of a character. I know, sad but true.
    /// </summary>
    public class DestinyPublicVendorsResponse
    {
        /// <summary>
        /// For Vendors being returned, this will give you the information you need to group them and order them in the same way that the Bungie Companion app performs grouping. It will automatically be returned if you request the Vendors component.
        /// COMPONENT TYPE: Vendors
        /// </summary>
        [JsonPropertyName("vendorGroups")]
        public SingleComponentResponseOfDestinyVendorGroupComponent VendorGroups { get; set; }

        /// <summary>
        /// The base properties of the vendor. These are keyed by the Vendor Hash, so you will get one Vendor Component per vendor returned.
        /// COMPONENT TYPE: Vendors
        /// </summary>
        [JsonPropertyName("vendors")]
        public DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent Vendors { get; set; }

        /// <summary>
        /// Categories that the vendor has available, and references to the sales therein. These are keyed by the Vendor Hash, so you will get one Categories Component per vendor returned.
        /// COMPONENT TYPE: VendorCategories
        /// </summary>
        [JsonPropertyName("categories")]
        public DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent Categories { get; set; }

        /// <summary>
        /// Sales, keyed by the vendorItemIndex of the item being sold. These are keyed by the Vendor Hash, so you will get one Sale Item Set Component per vendor returned.
        /// Note that within the Sale Item Set component, the sales are themselves keyed by the vendorSaleIndex, so you can relate it to the corrent sale item definition within the Vendor's definition.
        /// COMPONENT TYPE: VendorSales
        /// </summary>
        [JsonPropertyName("sales")]
        public DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent Sales { get; set; }
    }

    public class PublicDestinyVendorSaleItemSetComponent
    {
        [JsonPropertyName("saleItems")]
        public Dictionary<int, Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> SaleItems { get; set; }
    }

    /// <summary>
    /// Returns the detailed information about a Collectible Presentation Node and any Collectibles that are direct descendants.
    /// </summary>
    public class DestinyCollectibleNodeDetailResponse
    {
        /// <summary>COMPONENT TYPE: Collectibles</summary>
        [JsonPropertyName("collectibles")]
        public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; set; }

        /// <summary>
        /// Item components, keyed by the item hash of the items pointed at collectibles found under the requested Presentation Node.
        /// NOTE: I had a lot of hemming and hawing about whether these should be keyed by collectible hash or item hash... but ultimately having it be keyed by item hash meant that UI that already uses DestinyItemComponentSet data wouldn't have to have a special override to do the collectible -> item lookup once you delve into an item's details, and it also meant that you didn't have to remember that the Hash being used as the key for plugSets was different from the Hash being used for the other Dictionaries. As a result, using the Item Hash felt like the least crappy solution.
        /// We may all come to regret this decision. We will see.
        /// COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
        /// </summary>
        [JsonPropertyName("collectibleItemComponents")]
        public DestinyItemComponentSetOfuint32 CollectibleItemComponents { get; set; }
    }

    /// <summary>
    /// A response containing all of the components for all requested vendors.
    /// </summary>
    public class InventoryChangedResponse
    {
        /// <summary>Items that appeared in the inventory possibly as a result of an action.</summary>
        [JsonPropertyName("addedInventoryItems")]
        public IEnumerable<Destiny.Entities.Items.DestinyItemComponent> AddedInventoryItems { get; set; }

        /// <summary>Items that disappeared from the inventory possibly as a result of an action.</summary>
        [JsonPropertyName("removedInventoryItems")]
        public IEnumerable<Destiny.Entities.Items.DestinyItemComponent> RemovedInventoryItems { get; set; }
    }

    public class DestinyItemChangeResponse
    {
        [JsonPropertyName("item")]
        public Destiny.Responses.DestinyItemResponse Item { get; set; }

        /// <summary>Items that appeared in the inventory possibly as a result of an action.</summary>
        [JsonPropertyName("addedInventoryItems")]
        public IEnumerable<Destiny.Entities.Items.DestinyItemComponent> AddedInventoryItems { get; set; }

        /// <summary>Items that disappeared from the inventory possibly as a result of an action.</summary>
        [JsonPropertyName("removedInventoryItems")]
        public IEnumerable<Destiny.Entities.Items.DestinyItemComponent> RemovedInventoryItems { get; set; }
    }
}