using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny
{
    /// <summary>
    /// Information about a current character's status with a Progression. A progression is a value that can increase with activity and has levels. Think Character Level and Reputation Levels. Combine this "live" data with the related DestinyProgressionDefinition for a full picture of the Progression.
    /// </summary>
    public class DestinyProgression
    {
        /// <summary>The hash identifier of the Progression in question. Use it to look up the DestinyProgressionDefinition in static data.</summary>
        [JsonPropertyName("progressionHash")]
        public uint ProgressionHash { get; set; }

        /// <summary>The amount of progress earned today for this progression.</summary>
        [JsonPropertyName("dailyProgress")]
        public int DailyProgress { get; set; }

        /// <summary>If this progression has a daily limit, this is that limit.</summary>
        [JsonPropertyName("dailyLimit")]
        public int DailyLimit { get; set; }

        /// <summary>The amount of progress earned toward this progression in the current week.</summary>
        [JsonPropertyName("weeklyProgress")]
        public int WeeklyProgress { get; set; }

        /// <summary>If this progression has a weekly limit, this is that limit.</summary>
        [JsonPropertyName("weeklyLimit")]
        public int WeeklyLimit { get; set; }

        /// <summary>This is the total amount of progress obtained overall for this progression (for instance, the total amount of Character Level experience earned)</summary>
        [JsonPropertyName("currentProgress")]
        public int CurrentProgress { get; set; }

        /// <summary>This is the level of the progression (for instance, the Character Level).</summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>This is the maximum possible level you can achieve for this progression (for example, the maximum character level obtainable)</summary>
        [JsonPropertyName("levelCap")]
        public int LevelCap { get; set; }

        /// <summary>Progressions define their levels in "steps". Since the last step may be repeatable, the user may be at a higher level than the actual Step achieved in the progression. Not necessarily useful, but potentially interesting for those cruising the API. Relate this to the "steps" property of the DestinyProgression to see which step the user is on, if you care about that. (Note that this is Content Version dependent since it refers to indexes.)</summary>
        [JsonPropertyName("stepIndex")]
        public int StepIndex { get; set; }

        /// <summary>The amount of progression (i.e. "Experience") needed to reach the next level of this Progression. Jeez, progression is such an overloaded word.</summary>
        [JsonPropertyName("progressToNextLevel")]
        public int ProgressToNextLevel { get; set; }

        /// <summary>The total amount of progression (i.e. "Experience") needed in order to reach the next level.</summary>
        [JsonPropertyName("nextLevelAt")]
        public int NextLevelAt { get; set; }

        /// <summary>The number of resets of this progression you've executed this season, if applicable to this progression.</summary>
        [JsonPropertyName("currentResetCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CurrentResetCount { get; set; }

        /// <summary>Information about historical resets of this progression, if there is any data for it.</summary>
        [JsonPropertyName("seasonResets")]
        public IEnumerable<Destiny.DestinyProgressionResetEntry> SeasonResets { get; set; }

        /// <summary>Information about historical rewards for this progression, if there is any data for it.</summary>
        [JsonPropertyName("rewardItemStates")]
        public IEnumerable<Destiny.DestinyProgressionRewardItemState> RewardItemStates { get; set; }
    }

    /// <summary>
    /// Represents a season and the number of resets you had in that season.
    /// We do not necessarily - even for progressions with resets - track it over all seasons. So be careful and check the season numbers being returned.
    /// </summary>
    public class DestinyProgressionResetEntry
    {
        [JsonPropertyName("season")]
        public int Season { get; set; }

        [JsonPropertyName("resets")]
        public int Resets { get; set; }
    }

    /// <summary>
    /// Represents the different states a progression reward item can be in.
    /// </summary>
    [Flags]
    public enum DestinyProgressionRewardItemState : int
    {
        None = 0,

        /// <summary>If this is set, the reward should be hidden.</summary>
        Invisible = 1,

        /// <summary>If this is set, the reward has been earned.</summary>
        Earned = 2,

        /// <summary>If this is set, the reward has been claimed.</summary>
        Claimed = 4,

        /// <summary>If this is set, the reward is allowed to be claimed by this Character. An item can be earned but still can't be claimed in certain circumstances, like if it's only allowed for certain subclasses. It also might not be able to be claimed if you already claimed it!</summary>
        ClaimAllowed = 8
    }

    /// <summary>
    /// There are many Progressions in Destiny (think Character Level, or Reputation). These are the various "Scopes" of Progressions, which affect many things: * Where/if they are stored * How they are calculated * Where they can be used in other game logic
    /// </summary>
    public enum DestinyProgressionScope : int
    {
        Account = 0,
        Character = 1,
        Clan = 2,
        Item = 3,
        ImplicitFromEquipment = 4,
        Mapped = 5,
        MappedAggregate = 6,
        MappedStat = 7,
        MappedUnlockValue = 8
    }

    /// <summary>
    /// If progression is earned, this determines whether the progression shows visual effects on the character or its item - or neither.
    /// </summary>
    public enum DestinyProgressionStepDisplayEffect : int
    {
        None = 0,
        Character = 1,
        Item = 2
    }

    /// <summary>
    /// Used in a number of Destiny contracts to return data about an item stack and its quantity. Can optionally return an itemInstanceId if the item is instanced - in which case, the quantity returned will be 1. If it's not... uh, let me know okay? Thanks.
    /// </summary>
    public class DestinyItemQuantity
    {
        /// <summary>The hash identifier for the item in question. Use it to look up the item's DestinyInventoryItemDefinition.</summary>
        [JsonPropertyName("itemHash")]
        public uint ItemHash { get; set; }

        /// <summary>If this quantity is referring to a specific instance of an item, this will have the item's instance ID. Normally, this will be null.</summary>
        [JsonPropertyName("itemInstanceId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ItemInstanceId { get; set; }

        /// <summary>The amount of the item needed/available depending on the context of where DestinyItemQuantity is being used.</summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>Indicates that this item quantity may be conditionally shown or hidden, based on various sources of state. For example: server flags, account state, or character progress.</summary>
        [JsonPropertyName("hasConditionalVisibility")]
        public bool HasConditionalVisibility { get; set; }
    }

    public enum TierType : int
    {
        Unknown = 0,
        Currency = 1,
        Basic = 2,
        Common = 3,
        Rare = 4,
        Superior = 5,
        Exotic = 6
    }

    public enum BucketScope : int
    {
        Character = 0,
        Account = 1
    }

    public enum BucketCategory : int
    {
        Invisible = 0,
        Item = 1,
        Currency = 2,
        Equippable = 3,
        Ignored = 4
    }

    public enum ItemLocation : int
    {
        Unknown = 0,
        Inventory = 1,
        Vault = 2,
        Vendor = 3,
        Postmaster = 4
    }

    /// <summary>
    /// When a Stat (DestinyStatDefinition) is aggregated, this is the rules used for determining the level and formula used for aggregation.
    /// * CharacterAverage = apply a weighted average using the related DestinyStatGroupDefinition on the DestinyInventoryItemDefinition across the character's equipped items. See both of those definitions for details. * Character = don't aggregate: the stat should be located and used directly on the character. * Item = don't aggregate: the stat should be located and used directly on the item.
    /// </summary>
    public enum DestinyStatAggregationType : int
    {
        CharacterAverage = 0,
        Character = 1,
        Item = 2
    }

    /// <summary>
    /// At last, stats have categories. Use this for whatever purpose you might wish.
    /// </summary>
    public enum DestinyStatCategory : int
    {
        Gameplay = 0,
        Weapon = 1,
        Defense = 2,
        Primary = 3
    }

    [Flags]
    public enum EquippingItemBlockAttributes : int
    {
        None = 0,
        EquipOnAcquire = 1
    }

    public enum DestinyAmmunitionType : int
    {
        None = 0,
        Primary = 1,
        Special = 2,
        Heavy = 3,
        Unknown = 4
    }

    public class DyeReference
    {
        [JsonPropertyName("channelHash")]
        public uint ChannelHash { get; set; }

        [JsonPropertyName("dyeHash")]
        public uint DyeHash { get; set; }
    }

    /// <summary>
    /// Describes the type of progression that a vendor has.
    /// </summary>
    public enum DestinyVendorProgressionType : int
    {
        /// <summary>The original rank progression from token redemption.</summary>
        Default = 0,

        /// <summary>Progression from ranks in ritual content. For example: Crucible (Shaxx), Gambit (Drifter), and Season 13 Battlegrounds (War Table).</summary>
        Ritual = 1,

        /// <summary>A vendor progression with no seasonal refresh. For example: Xur in the Eternity destination for the 30th Anniversary.</summary>
        NoSeasonalRefresh = 2
    }

    /// <summary>
    /// Display categories can have custom sort orders. These are the possible options.
    /// </summary>
    public enum VendorDisplayCategorySortOrder : int
    {
        Default = 0,
        SortByTier = 1
    }

    /// <summary>
    /// When a Vendor Interaction provides rewards, they'll either let you choose one or let you have all of them. This determines which it will be.
    /// </summary>
    public enum DestinyVendorInteractionRewardSelection : int
    {
        None = 0,
        One = 1,
        All = 2
    }

    /// <summary>
    /// This determines the type of reply that a Vendor will have during an Interaction.
    /// </summary>
    public enum DestinyVendorReplyType : int
    {
        Accept = 0,
        Decline = 1,
        Complete = 2
    }

    /// <summary>
    /// An enumeration of the known UI interactions for Vendors.
    /// </summary>
    public enum VendorInteractionType : int
    {
        Unknown = 0,

        /// <summary>An empty interaction. If this ends up in content, it is probably a game bug.</summary>
        Undefined = 1,

        /// <summary>An interaction shown when you complete a quest and receive a reward.</summary>
        QuestComplete = 2,

        /// <summary>An interaction shown when you talk to a Vendor as an intermediary step of a quest.</summary>
        QuestContinue = 3,

        /// <summary>An interaction shown when you are previewing the vendor's reputation rewards.</summary>
        ReputationPreview = 4,

        /// <summary>An interaction shown when you rank up with the vendor.</summary>
        RankUpReward = 5,

        /// <summary>An interaction shown when you have tokens to turn in for the vendor.</summary>
        TokenTurnIn = 6,

        /// <summary>An interaction shown when you're accepting a new quest.</summary>
        QuestAccept = 7,

        /// <summary>Honestly, this doesn't seem consistent to me. It is used to give you choices in the Cryptarch as well as some reward prompts by the Eververse vendor. I'll have to look into that further at some point.</summary>
        ProgressTab = 8,

        /// <summary>These seem even less consistent. I don't know what these are.</summary>
        End = 9,

        /// <summary>Also seem inconsistent. I also don't know what these are offhand.</summary>
        Start = 10
    }

    /// <summary>
    /// Determines how items are sorted in an inventory bucket.
    /// </summary>
    public enum DestinyItemSortType : int
    {
        ItemId = 0,
        Timestamp = 1,
        StackSize = 2
    }

    /// <summary>
    /// The action that happens when the user attempts to refund an item.
    /// </summary>
    public enum DestinyVendorItemRefundPolicy : int
    {
        NotRefundable = 0,
        DeletesItem = 1,
        RevokesLicense = 2
    }

    /// <summary>
    /// This enumeration represents the most restrictive type of gating that is being performed by an entity. This is useful as a shortcut to avoid a lot of lookups when determining whether the gating on an Entity applies to everyone equally, or to their specific Profile or Character states.
    /// None = There is no gating on this item.
    /// Global = The gating on this item is based entirely on global game state. It will be gated the same for everyone.
    /// Clan = The gating on this item is at the Clan level. For instance, if you're gated by Clan level this will be the case.
    /// Profile = The gating includes Profile-specific checks, but not on the Profile's characters. An example of this might be when you acquire an Emblem: the Emblem will be available in your Kiosk for all characters in your Profile from that point onward.
    /// Character = The gating includes Character-specific checks, including character level restrictions. An example of this might be an item that you can't purchase from a Vendor until you reach a specific Character Level.
    /// Item = The gating includes item-specific checks. For BNet, this generally implies that we'll show this data only on a character level or deeper.
    /// AssumedWorstCase = The unlocks and checks being used for this calculation are of an unknown type and are used for unknown purposes. For instance, if some great person decided that an unlock value should be globally scoped, but then the game changes it using character-specific data in a way that BNet doesn't know about. Because of the open-ended potential for this to occur, many unlock checks for "globally" scoped unlock data may be assumed as the worst case unless it has been specifically whitelisted as otherwise. That sucks, but them's the breaks.
    /// </summary>
    public enum DestinyGatingScope : int
    {
        None = 0,
        Global = 1,
        Clan = 2,
        Profile = 3,
        Character = 4,
        Item = 5,
        AssumedWorstCase = 6
    }

    /// <summary>
    /// Indicates the type of actions that can be performed
    /// </summary>
    public enum SocketTypeActionType : int
    {
        InsertPlug = 0,
        InfuseItem = 1,
        ReinitializeSocket = 2
    }

    public enum DestinySocketVisibility : int
    {
        Visible = 0,
        Hidden = 1,
        HiddenWhenEmpty = 2,
        HiddenIfNoPlugsAvailable = 3
    }

    /// <summary>
    /// Represents the possible and known UI styles used by the game for rendering Socket Categories.
    /// </summary>
    public enum DestinySocketCategoryStyle : int
    {
        Unknown = 0,
        Reusable = 1,
        Consumable = 2,
        Unlockable = 3,
        Intrinsic = 4,
        EnergyMeter = 5,
        LargePerk = 6,
        Abilities = 7,
        Supers = 8
    }

    /// <summary>
    /// The various known UI styles in which an item can be highlighted. It'll be up to you to determine what you want to show based on this highlighting, BNet doesn't have any assets that correspond to these states. And yeah, RiseOfIron and Comet have their own special highlight states. Don't ask me, I can't imagine they're still used.
    /// </summary>
    public enum ActivityGraphNodeHighlightType : int
    {
        None = 0,
        Normal = 1,
        Hyper = 2,
        Comet = 3,
        RiseOfIron = 4
    }

    /// <summary>
    /// If you're showing an unlock value in the UI, this is the format in which it should be shown. You'll have to build your own algorithms on the client side to determine how best to render these options.
    /// </summary>
    public enum DestinyUnlockValueUIStyle : int
    {
        /// <summary>Generally, Automatic means "Just show the number"</summary>
        Automatic = 0,

        /// <summary>Show the number as a fractional value. For this to make sense, the value being displayed should have a comparable upper bound, like the progress to the next level of a Progression.</summary>
        Fraction = 1,

        /// <summary>Show the number as a checkbox. 0 Will mean unchecked, any other value will mean checked.</summary>
        Checkbox = 2,

        /// <summary>Show the number as a percentage. For this to make sense, the value being displayed should have a comparable upper bound, like the progress to the next level of a Progression.</summary>
        Percentage = 3,

        /// <summary>Show the number as a date and time. The number will be the number of seconds since the Unix Epoch (January 1st, 1970 at midnight UTC). It'll be up to you to convert this into a date and time format understandable to the user in their time zone.</summary>
        DateTime = 4,

        /// <summary>Show the number as a floating point value that represents a fraction, where 0 is min and 1 is max. For this to make sense, the value being displayed should have a comparable upper bound, like the progress to the next level of a Progression.</summary>
        FractionFloat = 5,

        /// <summary>Show the number as a straight-up integer.</summary>
        Integer = 6,

        /// <summary>Show the number as a time duration. The value will be returned as seconds.</summary>
        TimeDuration = 7,

        /// <summary>Don't bother showing the value at all, it's not easily human-interpretable, and used for some internal purpose.</summary>
        Hidden = 8,

        /// <summary>Example: "1.5x"</summary>
        Multiplier = 9,

        /// <summary>Show the value as a series of green pips, like the wins in a Trials of Osiris score card.</summary>
        GreenPips = 10,

        /// <summary>Show the value as a series of red pips, like the losses in a Trials of Osiris score card.</summary>
        RedPips = 11,

        /// <summary>Show the value as a percentage. For example: "51%" - Does no division, only appends '%'</summary>
        ExplicitPercentage = 12,

        /// <summary>Show the value as a floating-point number. For example: "4.52" NOTE: Passed along from Investment as whole number with last two digits as decimal values (452 -> 4.52)</summary>
        RawFloat = 13
    }

    /// <summary>
    /// Some Objectives provide perks, generally as part of providing some kind of interesting modifier for a Challenge or Quest. This indicates when the Perk is granted.
    /// </summary>
    public enum DestinyObjectiveGrantStyle : int
    {
        WhenIncomplete = 0,
        WhenComplete = 1,
        Always = 2
    }

    public enum DamageType : int
    {
        None = 0,
        Kinetic = 1,
        Arc = 2,
        Thermal = 3,
        Void = 4,
        Raid = 5,
        Stasis = 6
    }

    public enum DestinyActivityNavPointType : int
    {
        Inactive = 0,
        PrimaryObjective = 1,
        SecondaryObjective = 2,
        TravelObjective = 3,
        PublicEventObjective = 4,
        AmmoCache = 5,
        PointTypeFlag = 6,
        CapturePoint = 7,
        DefensiveEncounter = 8,
        GhostInteraction = 9,
        KillAi = 10,
        QuestItem = 11,
        PatrolMission = 12,
        Incoming = 13,
        ArenaObjective = 14,
        AutomationHint = 15,
        TrackedQuest = 16
    }

    /// <summary>
    /// Activity Modes are grouped into a few possible broad categories.
    /// </summary>
    public enum DestinyActivityModeCategory : int
    {
        /// <summary>Activities that are neither PVP nor PVE, such as social activities.</summary>
        None = 0,

        /// <summary>PvE activities, where you shoot aliens in the face.</summary>
        PvE = 1,

        /// <summary>PvP activities, where you shoot your "friends".</summary>
        PvP = 2,

        /// <summary>PVE competitive activities, where you shoot whoever you want whenever you want. Or run around collecting small glowing triangles.</summary>
        PvECompetitive = 3
    }

    /// <summary>
    /// This Enumeration further classifies items by more specific categorizations than DestinyItemType. The "Sub-Type" is where we classify and categorize items one step further in specificity: "Auto Rifle" instead of just "Weapon" for example, or "Vanguard Bounty" instead of merely "Bounty".
    /// These sub-types are provided for historical compatibility with Destiny 1, but an ideal alternative is to use DestinyItemCategoryDefinitions and the DestinyItemDefinition.itemCategories property instead. Item Categories allow for arbitrary hierarchies of specificity, and for items to belong to multiple categories across multiple hierarchies simultaneously. For this enum, we pick a single type as a "best guess" fit.
    /// NOTE: This is not all of the item types available, and some of these are holdovers from Destiny 1 that may or may not still exist.
    /// </summary>
    public enum DestinyItemSubType : int
    {
        None = 0,

        /// <summary>DEPRECATED. Items can be both "Crucible" and something else interesting.</summary>
        Crucible = 1,

        /// <summary>DEPRECATED. An item can both be "Vanguard" and something else.</summary>
        Vanguard = 2,

        /// <summary>DEPRECATED. An item can both be Exotic and something else.</summary>
        Exotic = 5,
        AutoRifle = 6,
        Shotgun = 7,
        Machinegun = 8,
        HandCannon = 9,
        RocketLauncher = 10,
        FusionRifle = 11,
        SniperRifle = 12,
        PulseRifle = 13,
        ScoutRifle = 14,

        /// <summary>DEPRECATED. An item can both be CRM and something else.</summary>
        Crm = 16,
        Sidearm = 17,
        Sword = 18,
        Mask = 19,
        Shader = 20,
        Ornament = 21,
        FusionRifleLine = 22,
        GrenadeLauncher = 23,
        SubmachineGun = 24,
        TraceRifle = 25,
        HelmetArmor = 26,
        GauntletsArmor = 27,
        ChestArmor = 28,
        LegArmor = 29,
        ClassArmor = 30,
        Bow = 31,
        DummyRepeatableBounty = 32
    }

    /// <summary>
    /// Represents a potential state of an Activity Graph node.
    /// </summary>
    public enum DestinyGraphNodeState : int
    {
        Hidden = 0,
        Visible = 1,
        Teaser = 2,
        Incomplete = 3,
        Completed = 4
    }

    public enum DestinyPresentationNodeType : int
    {
        Default = 0,
        Category = 1,
        Collectibles = 2,
        Records = 3,
        Metric = 4
    }

    /// <summary>
    /// There's a lot of places where we need to know scope on more than just a profile or character level. For everything else, there's this more generic sense of scope.
    /// </summary>
    public enum DestinyScope : int
    {
        Profile = 0,
        Character = 1
    }

    /// <summary>
    /// A hint for how the presentation node should be displayed when shown in a list. How you use this is your UI is up to you.
    /// </summary>
    public enum DestinyPresentationDisplayStyle : int
    {
        /// <summary>Display the item as a category, through which sub-items are filtered.</summary>
        Category = 0,
        Badge = 1,
        Medals = 2,
        Collectible = 3,
        Record = 4
    }

    public enum DestinyRecordValueStyle : int
    {
        Integer = 0,
        Percentage = 1,
        Milliseconds = 2,
        Boolean = 3,
        Decimal = 4
    }

    public enum DestinyGender : int
    {
        Male = 0,
        Female = 1,
        Unknown = 2
    }

    public enum DestinyRecordToastStyle : int
    {
        None = 0,
        Record = 1,
        Lore = 2,
        Badge = 3,
        MetaRecord = 4,
        MedalComplete = 5,
        SeasonChallengeComplete = 6,
        GildedTitleComplete = 7
    }

    /// <summary>
    /// A hint for what screen should be shown when this presentation node is clicked into. How you use this is your UI is up to you.
    /// </summary>
    public enum DestinyPresentationScreenStyle : int
    {
        /// <summary>Use the "default" view for the presentation nodes.</summary>
        Default = 0,

        /// <summary>Show sub-items as "category sets". In-game, you'd see these as a vertical list of child presentation nodes - armor sets for example - and the icons of items within those sets displayed horizontally.</summary>
        CategorySets = 1,

        /// <summary>Show sub-items as Badges. (I know, I know. We don't need no stinkin' badges har har har)</summary>
        Badge = 2
    }

    /// <summary>
    /// If the plug has a specific custom style, this enumeration will represent that style/those styles.
    /// </summary>
    [Flags]
    public enum PlugUiStyles : int
    {
        None = 0,
        Masterwork = 1
    }

    /// <summary>
    /// This enum determines whether the plug is available to be inserted.
    /// - Normal means that all existing rules for plug insertion apply.
    /// - UnavailableIfSocketContainsMatchingPlugCategory means that the plug is only available if the socket does NOT match the plug category.
    /// - AvailableIfSocketContainsMatchingPlugCategory means that the plug is only available if the socket DOES match the plug category.
    /// For category matching, use the plug's "plugCategoryIdentifier" property, comparing it to
    /// </summary>
    public enum PlugAvailabilityMode : int
    {
        Normal = 0,
        UnavailableIfSocketContainsMatchingPlugCategory = 1,
        AvailableIfSocketContainsMatchingPlugCategory = 2
    }

    /// <summary>
    /// Represents the socket energy types for Armor 2.0, Ghosts 2.0, and Stasis subclasses.
    /// </summary>
    public enum DestinyEnergyType : int
    {
        Any = 0,
        Arc = 1,
        Thermal = 2,
        Void = 3,
        Ghost = 4,
        Subclass = 5,
        Stasis = 6
    }

    /// <summary>
    /// Indicates how a socket is populated, and where you should look for valid plug data.
    /// This is a flags enumeration/bitmask field, as you may have to look in multiple sources across multiple components for valid plugs.
    /// For instance, a socket could have plugs that are sourced from its own definition, as well as plugs that are sourced from Character-scoped AND profile-scoped Plug Sets. Only by combining plug data for every indicated source will you be able to know all of the plugs available for a socket.
    /// </summary>
    [Flags]
    public enum SocketPlugSources : int
    {
        /// <summary>If there's no way we can detect to insert new plugs.</summary>
        None = 0,

        /// <summary>
        /// Use plugs found in the player's inventory, based on the socket type rules (see DestinySocketTypeDefinition for more info)
        /// Note that a socket - like Shaders - can have *both* reusable plugs and inventory items inserted theoretically.
        /// </summary>
        InventorySourced = 1,

        /// <summary>
        /// Use the DestinyItemSocketsComponent.sockets.reusablePlugs property to determine which plugs are valid for this socket. This may have to be combined with other sources, such as plug sets, if those flags are set.
        /// Note that "Reusable" plugs may not necessarily come from a plug set, nor from the "reusablePlugItems" in the socket's Definition data. They can sometimes be "randomized" in which case the only source of truth at the moment is still the runtime DestinyItemSocketsComponent.sockets.reusablePlugs property.
        /// </summary>
        ReusablePlugItems = 2,

        /// <summary>Use the ProfilePlugSets (DestinyProfileResponse.profilePlugSets) component data to determine which plugs are valid for this socket.</summary>
        ProfilePlugSet = 4,

        /// <summary>Use the CharacterPlugSets (DestinyProfileResponse.characterPlugSets) component data to determine which plugs are valid for this socket.</summary>
        CharacterPlugSet = 8
    }

    /// <summary>
    /// Indicates how a perk should be shown, or if it should be, in the game UI. Maybe useful for those of you trying to filter out internal-use-only perks (or for those of you trying to figure out what they do!)
    /// </summary>
    public enum ItemPerkVisibility : int
    {
        Visible = 0,
        Disabled = 1,
        Hidden = 2
    }

    /// <summary>
    /// As you run into items that need to be classified for Milestone purposes in ways that we cannot infer via direct data, add a new classification here and use a string constant to represent it in the local item config file.
    /// NOTE: This is not all of the item types available, and some of these are holdovers from Destiny 1 that may or may not still exist.
    /// </summary>
    public enum SpecialItemType : int
    {
        None = 0,
        SpecialCurrency = 1,
        Armor = 8,
        Weapon = 9,
        Engram = 23,
        Consumable = 24,
        ExchangeMaterial = 25,
        MissionReward = 27,
        Currency = 29
    }

    /// <summary>
    /// An enumeration that indicates the high-level "type" of the item, attempting to iron out the context specific differences for specific instances of an entity. For instance, though a weapon may be of various weapon "Types", in DestinyItemType they are all classified as "Weapon". This allows for better filtering on a higher level of abstraction for the concept of types.
    /// This enum is provided for historical compatibility with Destiny 1, but an ideal alternative is to use DestinyItemCategoryDefinitions and the DestinyItemDefinition.itemCategories property instead. Item Categories allow for arbitrary hierarchies of specificity, and for items to belong to multiple categories across multiple hierarchies simultaneously. For this enum, we pick a single type as a "best guess" fit.
    /// NOTE: This is not all of the item types available, and some of these are holdovers from Destiny 1 that may or may not still exist.
    /// I keep updating these because they're so damn convenient. I guess I shouldn't fight it.
    /// </summary>
    public enum DestinyItemType : int
    {
        None = 0,
        Currency = 1,
        Armor = 2,
        Weapon = 3,
        Message = 7,
        Engram = 8,
        Consumable = 9,
        ExchangeMaterial = 10,
        MissionReward = 11,
        QuestStep = 12,
        QuestStepComplete = 13,
        Emblem = 14,
        Quest = 15,
        Subclass = 16,
        ClanBanner = 17,
        Aura = 18,
        Mod = 19,
        Dummy = 20,
        Ship = 21,
        Vehicle = 22,
        Emote = 23,
        Ghost = 24,
        Package = 25,
        Bounty = 26,
        Wrapper = 27,
        SeasonalArtifact = 28,
        Finisher = 29
    }

    public enum DestinyClass : int
    {
        Titan = 0,
        Hunter = 1,
        Warlock = 2,
        Unknown = 3
    }

    /// <summary>
    /// A plug can optionally have a "Breaker Type": a special ability that can affect units in unique ways. Activating this plug can grant one of these types.
    /// </summary>
    public enum DestinyBreakerType : int
    {
        None = 0,
        ShieldPiercing = 1,
        Disruption = 2,
        Stagger = 3
    }

    /// <summary>
    /// Represents the different kinds of acquisition behavior for progression reward items.
    /// </summary>
    public enum DestinyProgressionRewardItemAcquisitionBehavior : int
    {
        Instant = 0,
        PlayerClaimRequired = 1
    }

    public enum ItemBindStatus : int
    {
        NotBound = 0,
        BoundToCharacter = 1,
        BoundToAccount = 2,
        BoundToGuild = 3
    }

    /// <summary>
    /// Whether you can transfer an item, and why not if you can't.
    /// </summary>
    [Flags]
    public enum TransferStatuses : int
    {
        /// <summary>The item can be transferred.</summary>
        CanTransfer = 0,

        /// <summary>You can't transfer the item because it is equipped on a character.</summary>
        ItemIsEquipped = 1,

        /// <summary>The item is defined as not transferrable in its DestinyInventoryItemDefinition.nonTransferrable property.</summary>
        NotTransferrable = 2,

        /// <summary>You could transfer the item, but the place you're trying to put it has run out of room! Check your remaining Vault and/or character space.</summary>
        NoRoomInDestination = 4
    }

    /// <summary>
    /// A flags enumeration/bitmask where each bit represents a different possible state that the item can be in that may effect how the item is displayed to the user and what actions can be performed against it.
    /// </summary>
    [Flags]
    public enum ItemState : int
    {
        None = 0,

        /// <summary>If this bit is set, the item has been "locked" by the user and cannot be deleted. You may want to represent this visually with a "lock" icon.</summary>
        Locked = 1,

        /// <summary>If this bit is set, the item is a quest that's being tracked by the user. You may want a visual indicator to show that this is a tracked quest.</summary>
        Tracked = 2,

        /// <summary>If this bit is set, the item has a Masterwork plug inserted. This usually coincides with having a special "glowing" effect applied to the item's icon.</summary>
        Masterwork = 4
    }

    /// <summary>
    /// A flags enumeration/bitmask indicating the versions of the game that a given user has purchased.
    /// </summary>
    [Flags]
    public enum DestinyGameVersions : int
    {
        None = 0,
        Destiny2 = 1,
        DLC1 = 2,
        DLC2 = 4,
        Forsaken = 8,
        YearTwoAnnualPass = 16,
        Shadowkeep = 32,
        BeyondLight = 64,
        Anniversary30th = 128,
        TheWitchQueen = 256
    }

    /// <summary>
    /// Represents the possible components that can be returned from Destiny "Get" calls such as GetProfile, GetCharacter, GetVendor etc...
    /// When making one of these requests, you will pass one or more of these components as a comma separated list in the "?components=" querystring parameter. For instance, if you want baseline Profile data, Character Data, and character progressions, you would pass "?components=Profiles,Characters,CharacterProgressions" You may use either the numerical or string values.
    /// </summary>
    public enum DestinyComponentType : int
    {
        None = 0,

        /// <summary>Profiles is the most basic component, only relevant when calling GetProfile. This returns basic information about the profile, which is almost nothing: a list of characterIds, some information about the last time you logged in, and that most sobering statistic: how long you've played.</summary>
        Profiles = 100,

        /// <summary>Only applicable for GetProfile, this will return information about receipts for refundable vendor items.</summary>
        VendorReceipts = 101,

        /// <summary>Asking for this will get you the profile-level inventories, such as your Vault buckets (yeah, the Vault is really inventory buckets located on your Profile)</summary>
        ProfileInventories = 102,

        /// <summary>This will get you a summary of items on your Profile that we consider to be "currencies", such as Glimmer. I mean, if there's Glimmer in Destiny 2. I didn't say there was Glimmer.</summary>
        ProfileCurrencies = 103,

        /// <summary>This will get you any progression-related information that exists on a Profile-wide level, across all characters.</summary>
        ProfileProgression = 104,

        /// <summary>
        /// This will get you information about the silver that this profile has on every platform on which it plays.
        /// You may only request this component for the logged in user's Profile, and will not recieve it if you request it for another Profile.
        /// </summary>
        PlatformSilver = 105,

        /// <summary>This will get you summary info about each of the characters in the profile.</summary>
        Characters = 200,

        /// <summary>This will get you information about any non-equipped items on the character or character(s) in question, if you're allowed to see it. You have to either be authenticated as that user, or that user must allow anonymous viewing of their non-equipped items in Bungie.Net settings to actually get results.</summary>
        CharacterInventories = 201,

        /// <summary>This will get you information about the progression (faction, experience, etc... "levels") relevant to each character, if you are the currently authenticated user or the user has elected to allow anonymous viewing of its progression info.</summary>
        CharacterProgressions = 202,

        /// <summary>This will get you just enough information to be able to render the character in 3D if you have written a 3D rendering library for Destiny Characters, or "borrowed" ours. It's okay, I won't tell anyone if you're using it. I'm no snitch. (actually, we don't care if you use it - go to town)</summary>
        CharacterRenderData = 203,

        /// <summary>This will return info about activities that a user can see and gating on it, if you are the currently authenticated user or the user has elected to allow anonymous viewing of its progression info. Note that the data returned by this can be unfortunately problematic and relatively unreliable in some cases. We'll eventually work on making it more consistently reliable.</summary>
        CharacterActivities = 204,

        /// <summary>This will return info about the equipped items on the character(s). Everyone can see this.</summary>
        CharacterEquipment = 205,

        /// <summary>This will return basic info about instanced items - whether they can be equipped, their tracked status, and some info commonly needed in many places (current damage type, primary stat value, etc)</summary>
        ItemInstances = 300,

        /// <summary>Items can have Objectives (DestinyObjectiveDefinition) bound to them. If they do, this will return info for items that have such bound objectives.</summary>
        ItemObjectives = 301,

        /// <summary>Items can have perks (DestinyPerkDefinition). If they do, this will return info for what perks are active on items.</summary>
        ItemPerks = 302,

        /// <summary>If you just want to render the weapon, this is just enough info to do that rendering.</summary>
        ItemRenderData = 303,

        /// <summary>Items can have stats, like rate of fire. Asking for this component will return requested item's stats if they have stats.</summary>
        ItemStats = 304,

        /// <summary>Items can have sockets, where plugs can be inserted. Asking for this component will return all info relevant to the sockets on items that have them.</summary>
        ItemSockets = 305,

        /// <summary>Items can have talent grids, though that matters a lot less frequently than it used to. Asking for this component will return all relevant info about activated Nodes and Steps on this talent grid, like the good ol' days.</summary>
        ItemTalentGrids = 306,

        /// <summary>Items that *aren't* instanced still have important information you need to know: how much of it you have, the itemHash so you can look up their DestinyInventoryItemDefinition, whether they're locked, etc... Both instanced and non-instanced items will have these properties. You will get this automatically with Inventory components - you only need to pass this when calling GetItem on a specific item.</summary>
        ItemCommonData = 307,

        /// <summary>Items that are "Plugs" can be inserted into sockets. This returns statuses about those plugs and why they can/can't be inserted. I hear you giggling, there's nothing funny about inserting plugs. Get your head out of the gutter and pay attention!</summary>
        ItemPlugStates = 308,

        /// <summary>Sometimes, plugs have objectives on them. This data can get really large, so we split it into its own component. Please, don't grab it unless you need it.</summary>
        ItemPlugObjectives = 309,

        /// <summary>
        /// Sometimes, designers create thousands of reusable plugs and suddenly your response sizes are almost 3MB, and something has to give.
        /// Reusable Plugs were split off as their own component, away from ItemSockets, as a result of the Plug changes in Shadowkeep that made plug data infeasibly large for the most common use cases.
        /// Request this component if and only if you need to know what plugs *could* be inserted into a socket, and need to know it before "drilling" into the details of an item in your application (for instance, if you're doing some sort of interesting sorting or aggregation based on available plugs.
        /// When you get this, you will also need to combine it with "Plug Sets" data if you want a full picture of all of the available plugs: this component will only return plugs that have state data that is per-item. See Plug Sets for available plugs that have Character, Profile, or no state-specific restrictions.
        /// </summary>
        ItemReusablePlugs = 310,

        /// <summary>When obtaining vendor information, this will return summary information about the Vendor or Vendors being returned.</summary>
        Vendors = 400,

        /// <summary>When obtaining vendor information, this will return information about the categories of items provided by the Vendor.</summary>
        VendorCategories = 401,

        /// <summary>When obtaining vendor information, this will return the information about items being sold by the Vendor.</summary>
        VendorSales = 402,

        /// <summary>Asking for this component will return you the account's Kiosk statuses: that is, what items have been filled out/acquired. But only if you are the currently authenticated user or the user has elected to allow anonymous viewing of its progression info.</summary>
        Kiosks = 500,

        /// <summary>A "shortcut" component that will give you all of the item hashes/quantities of items that the requested character can use to determine if an action (purchasing, socket insertion) has the required currency. (recall that all currencies are just items, and that some vendor purchases require items that you might not traditionally consider to be a "currency", like plugs/mods!)</summary>
        CurrencyLookups = 600,

        /// <summary>Returns summary status information about all "Presentation Nodes". See DestinyPresentationNodeDefinition for more details, but the gist is that these are entities used by the game UI to bucket Collectibles and Records into a hierarchy of categories. You may ask for and use this data if you want to perform similar bucketing in your own UI: or you can skip it and roll your own.</summary>
        PresentationNodes = 700,

        /// <summary>Returns summary status information about all "Collectibles". These are records of what items you've discovered while playing Destiny, and some other basic information. For detailed information, you will have to call a separate endpoint devoted to the purpose.</summary>
        Collectibles = 800,

        /// <summary>Returns summary status information about all "Records" (also known in the game as "Triumphs". I know, it's confusing because there's also "Moments of Triumph" that will themselves be represented as "Triumphs.")</summary>
        Records = 900,

        /// <summary>Returns information that Bungie considers to be "Transitory": data that may change too frequently or come from a non-authoritative source such that we don't consider the data to be fully trustworthy, but that might prove useful for some limited use cases. We can provide no guarantee of timeliness nor consistency for this data: buyer beware with the Transitory component.</summary>
        Transitory = 1000,

        /// <summary>Returns summary status information about all "Metrics" (also known in the game as "Stat Trackers").</summary>
        Metrics = 1100,

        /// <summary>Returns a mapping of localized string variable hashes to values, on a per-account or per-character basis.</summary>
        StringVariables = 1200
    }

    /// <summary>
    /// I know this doesn't look like a Flags Enumeration/bitmask right now, but I assure you it is. This is the possible states that a Presentation Node can be in, and it is almost certain that its potential states will increase in the future. So don't treat it like a straight up enumeration.
    /// </summary>
    [Flags]
    public enum DestinyPresentationNodeState : int
    {
        None = 0,

        /// <summary>If this is set, the game recommends that you not show this node. But you know your life, do what you've got to do.</summary>
        Invisible = 1,

        /// <summary>Turns out Presentation Nodes can also be obscured. If they are, this is set.</summary>
        Obscured = 2
    }

    /// <summary>
    /// A Flags enumeration/bitmask where each bit represents a possible state that a Record/Triumph can be in.
    /// </summary>
    [Flags]
    public enum DestinyRecordState : int
    {
        /// <summary>If there are no flags set, the record is in a state where it *could* be redeemed, but it has not been yet.</summary>
        None = 0,

        /// <summary>If this is set, the completed record has been redeemed.</summary>
        RecordRedeemed = 1,

        /// <summary>If this is set, there's a reward available from this Record but it's unavailable for redemption.</summary>
        RewardUnavailable = 2,

        /// <summary>If this is set, the objective for this Record has not yet been completed.</summary>
        ObjectiveNotCompleted = 4,

        /// <summary>If this is set, the game recommends that you replace the display text of this Record with DestinyRecordDefinition.stateInfo.obscuredString.</summary>
        Obscured = 8,

        /// <summary>If this is set, the game recommends that you not show this record. Do what you will with this recommendation.</summary>
        Invisible = 16,

        /// <summary>If this is set, you can't complete this record because you lack some permission that's required to complete it.</summary>
        EntitlementUnowned = 32,

        /// <summary>If this is set, the record has a title (check DestinyRecordDefinition for title info) and you can equip it.</summary>
        CanEquipTitle = 64
    }

    /// <summary>
    /// A Flags Enumeration/bitmask where each bit represents a different state that the Collectible can be in. A collectible can be in any number of these states, and you can choose to use or ignore any or all of them when making your own UI that shows Collectible info. Our displays are going to honor them, but we're also the kind of people who only pretend to inhale before quickly passing it to the left. So, you know, do what you got to do.
    /// (All joking aside, please note the caveat I mention around the Invisible flag: there are cases where it is in the best interest of your users to honor these flags even if you're a "show all the data" person. Collector-oriented compulsion is a very unfortunate and real thing, and I would hate to instill that compulsion in others through showing them items that they cannot earn. Please consider this when you are making your own apps/sites.)
    /// </summary>
    [Flags]
    public enum DestinyCollectibleState : int
    {
        None = 0,

        /// <summary>If this flag is set, you have not yet obtained this collectible.</summary>
        NotAcquired = 1,

        /// <summary>If this flag is set, the item is "obscured" to you: you can/should use the alternate item hash found in DestinyCollectibleDefinition.stateInfo.obscuredOverrideItemHash when displaying this collectible instead of the default display info.</summary>
        Obscured = 2,

        /// <summary>
        /// If this flag is set, the collectible should not be shown to the user.
        /// Please do consider honoring this flag. It is used - for example - to hide items that a person didn't get from the Eververse. I can't prevent these from being returned in definitions, because some people may have acquired them and thus they should show up: but I would hate for people to start feeling some variant of a Collector's Remorse about these items, and thus increasing their purchasing based on that compulsion. That would be a very unfortunate outcome, and one that I wouldn't like to see happen. So please, whether or not I'm your mom, consider honoring this flag and don't show people invisible collectibles.
        /// </summary>
        Invisible = 4,

        /// <summary>If this flag is set, the collectible requires payment for creating an instance of the item, and you are lacking in currency. Bring the benjamins next time. Or spinmetal. Whatever.</summary>
        CannotAffordMaterialRequirements = 8,

        /// <summary>If this flag is set, you can't pull this item out of your collection because there's no room left in your inventory.</summary>
        InventorySpaceUnavailable = 16,

        /// <summary>If this flag is set, you already have one of these items and can't have a second one.</summary>
        UniquenessViolation = 32,

        /// <summary>If this flag is set, the ability to pull this item out of your collection has been disabled.</summary>
        PurchaseDisabled = 64
    }

    /// <summary>
    /// A flags enumeration that represents a Fireteam Member's status.
    /// </summary>
    [Flags]
    public enum DestinyPartyMemberStates : int
    {
        None = 0,

        /// <summary>This one's pretty obvious - they're on your Fireteam.</summary>
        FireteamMember = 1,

        /// <summary>I don't know what it means to be in a 'Posse', but apparently this is it.</summary>
        PosseMember = 2,

        /// <summary>
        /// Nor do I understand the difference between them being in a 'Group' vs. a 'Fireteam'.
        /// I'll update these docs once I get more info. If I get more info. If you're reading this, I never got more info. You're on your own, kid.
        /// </summary>
        GroupMember = 4,

        /// <summary>This person is the party leader.</summary>
        PartyLeader = 8
    }

    /// <summary>
    /// A player can choose to restrict requests to join their Fireteam to specific states. These are the possible states a user can choose.
    /// </summary>
    public enum DestinyGamePrivacySetting : int
    {
        Open = 0,
        ClanAndFriendsOnly = 1,
        FriendsOnly = 2,
        InvitationOnly = 3,
        Closed = 4
    }

    /// <summary>
    /// A Flags enumeration representing the reasons why a person can't join this user's fireteam.
    /// </summary>
    [Flags]
    public enum DestinyJoinClosedReasons : int
    {
        None = 0,

        /// <summary>The user is currently in matchmaking.</summary>
        InMatchmaking = 1,

        /// <summary>The user is currently in a loading screen.</summary>
        Loading = 2,

        /// <summary>The user is in an activity that requires solo play.</summary>
        SoloMode = 4,

        /// <summary>The user can't be joined for one of a variety of internal reasons. Basically, the game can't let you join at this time, but for reasons that aren't under the control of this user.</summary>
        InternalReasons = 8,

        /// <summary>The user's current activity/quest/other transitory game state is preventing joining.</summary>
        DisallowedByGameState = 16,

        /// <summary>The user appears to be offline.</summary>
        Offline = 32768
    }

    public enum DestinyRace : int
    {
        Human = 0,
        Awoken = 1,
        Exo = 2,
        Unknown = 3
    }

    /// <summary>
    /// Represents the "Live" data that we can obtain about a Character's status with a specific Activity. This will tell you whether the character can participate in the activity, as well as some other basic mutable information.
    /// Meant to be combined with static DestinyActivityDefinition data for a full picture of the Activity.
    /// </summary>
    public class DestinyActivity
    {
        /// <summary>The hash identifier of the Activity. Use this to look up the DestinyActivityDefinition of the activity.</summary>
        [JsonPropertyName("activityHash")]
        public uint ActivityHash { get; set; }

        /// <summary>If true, then the activity should have a "new" indicator in the Director UI.</summary>
        [JsonPropertyName("isNew")]
        public bool IsNew { get; set; }

        /// <summary>If true, the user is allowed to lead a Fireteam into this activity.</summary>
        [JsonPropertyName("canLead")]
        public bool CanLead { get; set; }

        /// <summary>If true, the user is allowed to join with another Fireteam in this activity.</summary>
        [JsonPropertyName("canJoin")]
        public bool CanJoin { get; set; }

        /// <summary>If true, we both have the ability to know that the user has completed this activity and they have completed it. Unfortunately, we can't necessarily know this for all activities. As such, this should probably only be used if you already know in advance which specific activities you wish to check.</summary>
        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; set; }

        /// <summary>If true, the user should be able to see this activity.</summary>
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; set; }

        /// <summary>The difficulty level of the activity, if applicable.</summary>
        [JsonPropertyName("displayLevel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DisplayLevel { get; set; }

        /// <summary>The recommended light level for the activity, if applicable.</summary>
        [JsonPropertyName("recommendedLight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RecommendedLight { get; set; }

        /// <summary>A DestinyActivityDifficultyTier enum value indicating the difficulty of the activity.</summary>
        [JsonPropertyName("difficultyTier")]
        public Destiny.DestinyActivityDifficultyTier DifficultyTier { get; set; }

        [JsonPropertyName("challenges")]
        public IEnumerable<Destiny.Challenges.DestinyChallengeStatus> Challenges { get; set; }

        /// <summary>
        /// If the activity has modifiers, this will be the list of modifiers that all variants have in common. Perform lookups against DestinyActivityModifierDefinition which defines the modifier being applied to get at the modifier data.
        /// Note that, in the DestiyActivityDefinition, you will see many more modifiers than this being referred to: those are all *possible* modifiers for the activity, not the active ones. Use only the active ones to match what's really live.
        /// </summary>
        [JsonPropertyName("modifierHashes")]
        public IEnumerable<uint> ModifierHashes { get; set; }

        /// <summary>
        /// The set of activity options for this activity, keyed by an identifier that's unique for this activity (not guaranteed to be unique between or across all activities, though should be unique for every *variant* of a given *conceptual* activity: for instance, the original D2 Raid has many variant DestinyActivityDefinitions. While other activities could potentially have the same option hashes, for any given D2 base Raid variant the hash will be unique).
        /// As a concrete example of this data, the hashes you get for Raids will correspond to the currently active "Challenge Mode".
        /// We don't have any human readable information for these, but saavy 3rd party app users could manually associate the key (a hash identifier for the "option" that is enabled/disabled) and the value (whether it's enabled or disabled presently)
        /// On our side, we don't necessarily even know what these are used for (the game designers know, but we don't), and we have no human readable data for them. In order to use them, you will have to do some experimentation.
        /// </summary>
        [JsonPropertyName("booleanActivityOptions")]
        public Dictionary<uint, bool> BooleanActivityOptions { get; set; }

        /// <summary>If returned, this is the index into the DestinyActivityDefinition's "loadouts" property, indicating the currently active loadout requirements.</summary>
        [JsonPropertyName("loadoutRequirementIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? LoadoutRequirementIndex { get; set; }
    }

    /// <summary>
    /// An enumeration representing the potential difficulty levels of an activity. Their names are... more qualitative than quantitative.
    /// </summary>
    public enum DestinyActivityDifficultyTier : int
    {
        Trivial = 0,
        Easy = 1,
        Normal = 2,
        Challenging = 3,
        Hard = 4,
        Brave = 5,
        AlmostImpossible = 6,
        Impossible = 7
    }

    /// <summary>
    /// Represents a stat on an item *or* Character (NOT a Historical Stat, but a physical attribute stat like Attack, Defense etc...)
    /// </summary>
    public class DestinyStat
    {
        /// <summary>The hash identifier for the Stat. Use it to look up the DestinyStatDefinition for static data about the stat.</summary>
        [JsonPropertyName("statHash")]
        public uint StatHash { get; set; }

        /// <summary>The current value of the Stat.</summary>
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    /// <summary>
    /// The reasons why an item cannot be equipped, if any. Many flags can be set, or "None" if
    /// </summary>
    [Flags]
    public enum EquipFailureReason : int
    {
        /// <summary>The item is/was able to be equipped.</summary>
        None = 0,

        /// <summary>This is not the kind of item that can be equipped. Did you try equipping Glimmer or something?</summary>
        ItemUnequippable = 1,

        /// <summary>This item is part of a "unique set", and you can't have more than one item of that same set type equipped at once. For instance, if you already have an Exotic Weapon equipped, you can't equip a second one in another weapon slot.</summary>
        ItemUniqueEquipRestricted = 2,

        /// <summary>This item has state-based gating that prevents it from being equipped in certain circumstances. For instance, an item might be for Warlocks only and you're a Titan, or it might require you to have beaten some special quest that you haven't beaten yet. Use the additional failure data passed on the item itself to get more information about what the specific failure case was (See DestinyInventoryItemDefinition and DestinyItemInstanceComponent)</summary>
        ItemFailedUnlockCheck = 4,

        /// <summary>This item requires you to have reached a specific character level in order to equip it, and you haven't reached that level yet.</summary>
        ItemFailedLevelCheck = 8,

        /// <summary>This item can't be equipped on the character requested, because it must be in that character's inventory first. Transfer the item to the character you want to equip it before you attempt to equip it.</summary>
        ItemNotOnCharacter = 16
    }

    /// <summary>
    /// I see you've come to find out more about Talent Nodes. I'm so sorry. Talent Nodes are the conceptual, visual nodes that appear on Talent Grids. Talent Grids, in Destiny 1, were found on almost every instanced item: they had Nodes that could be activated to change the properties of the item. In Destiny 2, Talent Grids only exist for Builds/Subclasses, and while the basic concept is the same (Nodes can be activated once you've gained sufficient Experience on the Item, and provide effects), there are some new concepts from Destiny 1. Examine DestinyTalentGridDefinition and its subordinates for more information. This is the "Live" information for the current status of a Talent Node on a specific item. Talent Nodes have many Steps, but only one can be active at any one time: and it is the Step that determines both the visual and the game state-changing properties that the Node provides. Examine this and DestinyTalentNodeStepDefinition carefully. *IMPORTANT NOTE* Talent Nodes are, unfortunately, Content Version DEPENDENT. Though they refer to hashes for Nodes and Steps, those hashes are not guaranteed to be immutable across content versions. This is a source of great exasperation for me, but as a result anyone using Talent Grid data must ensure that the content version of their static content matches that of the server responses before showing or making decisions based on talent grid data.
    /// </summary>
    public class DestinyTalentNode
    {
        /// <summary>The index of the Talent Node being referred to (an index into DestinyTalentGridDefinition.nodes[]). CONTENT VERSION DEPENDENT.</summary>
        [JsonPropertyName("nodeIndex")]
        public int NodeIndex { get; set; }

        /// <summary>The hash of the Talent Node being referred to (in DestinyTalentGridDefinition.nodes). Deceptively CONTENT VERSION DEPENDENT. We have no guarantee of the hash's immutability between content versions.</summary>
        [JsonPropertyName("nodeHash")]
        public uint NodeHash { get; set; }

        /// <summary>An DestinyTalentNodeState enum value indicating the node's state: whether it can be activated or swapped, and why not if neither can be performed.</summary>
        [JsonPropertyName("state")]
        public Destiny.DestinyTalentNodeState State { get; set; }

        /// <summary>If true, the node is activated: it's current step then provides its benefits.</summary>
        [JsonPropertyName("isActivated")]
        public bool IsActivated { get; set; }

        /// <summary>The currently relevant Step for the node. It is this step that has rendering data for the node and the benefits that are provided if the node is activated. (the actual rules for benefits provided are extremely complicated in theory, but with how Talent Grids are being used in Destiny 2 you don't have to worry about a lot of those old Destiny 1 rules.) This is an index into: DestinyTalentGridDefinition.nodes[nodeIndex].steps[stepIndex]</summary>
        [JsonPropertyName("stepIndex")]
        public int StepIndex { get; set; }

        /// <summary>If the node has material requirements to be activated, this is the list of those requirements.</summary>
        [JsonPropertyName("materialsToUpgrade")]
        public IEnumerable<Destiny.Definitions.DestinyMaterialRequirement> MaterialsToUpgrade { get; set; }

        /// <summary>The progression level required on the Talent Grid in order to be able to activate this talent node. Talent Grids have their own Progression - similar to Character Level, but in this case it is experience related to the item itself.</summary>
        [JsonPropertyName("activationGridLevel")]
        public int ActivationGridLevel { get; set; }

        /// <summary>If you want to show a progress bar or circle for how close this talent node is to being activate-able, this is the percentage to show. It follows the node's underlying rules about when the progress bar should first show up, and when it should be filled.</summary>
        [JsonPropertyName("progressPercent")]
        public float ProgressPercent { get; set; }

        /// <summary>Whether or not the talent node is actually visible in the game's UI. Whether you want to show it in your own UI is up to you! I'm not gonna tell you who to sock it to.</summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        /// <summary>This property has some history. A talent grid can provide stats on both the item it's related to and the character equipping the item. This returns data about those stat bonuses.</summary>
        [JsonPropertyName("nodeStatsBlock")]
        public Destiny.DestinyTalentNodeStatBlock NodeStatsBlock { get; set; }
    }

    public enum DestinyTalentNodeState : int
    {
        Invalid = 0,
        CanUpgrade = 1,
        NoPoints = 2,
        NoPrerequisites = 3,
        NoSteps = 4,
        NoUnlock = 5,
        NoMaterial = 6,
        NoGridLevel = 7,
        SwappingLocked = 8,
        MustSwap = 9,
        Complete = 10,
        Unknown = 11,
        CreationOnly = 12,
        Hidden = 13
    }

    /// <summary>
    /// This property has some history. A talent grid can provide stats on both the item it's related to and the character equipping the item. This returns data about those stat bonuses.
    /// </summary>
    public class DestinyTalentNodeStatBlock
    {
        /// <summary>The stat benefits conferred when this talent node is activated for the current Step that is active on the node.</summary>
        [JsonPropertyName("currentStepStats")]
        public IEnumerable<Destiny.DestinyStat> CurrentStepStats { get; set; }

        /// <summary>This is a holdover from the old days of Destiny 1, when a node could be activated multiple times, conferring multiple steps worth of benefits: you would use this property to show what activating the "next" step on the node would provide vs. what the current step is providing. While Nodes are currently not being used this way, the underlying system for this functionality still exists. I hesitate to remove this property while the ability for designers to make such a talent grid still exists. Whether you want to show it is up to you.</summary>
        [JsonPropertyName("nextStepStats")]
        public IEnumerable<Destiny.DestinyStat> NextStepStats { get; set; }
    }

    /// <summary>
    /// Indicates the type of filter to apply to Vendor results.
    /// </summary>
    public enum DestinyVendorFilter : int
    {
        None = 0,
        ApiPurchasable = 1
    }

    [Flags]
    public enum VendorItemStatus : int
    {
        Success = 0,
        NoInventorySpace = 1,
        NoFunds = 2,
        NoProgression = 4,
        NoUnlock = 8,
        NoQuantity = 16,
        OutsidePurchaseWindow = 32,
        NotAvailable = 64,
        UniquenessViolation = 128,
        UnknownError = 256,
        AlreadySelling = 512,
        Unsellable = 1024,
        SellingInhibited = 2048,
        AlreadyOwned = 4096,
        DisplayOnly = 8192
    }

    /// <summary>
    /// Indicates the status of an "Unlock Flag" on a Character or Profile.
    /// These are individual bits of state that can be either set or not set, and sometimes provide interesting human-readable information in their related DestinyUnlockDefinition.
    /// </summary>
    public class DestinyUnlockStatus
    {
        /// <summary>The hash identifier for the Unlock Flag. Use to lookup DestinyUnlockDefinition for static data. Not all unlocks have human readable data - in fact, most don't. But when they do, it can be very useful to show. Even if they don't have human readable data, you might be able to infer the meaning of an unlock flag with a bit of experimentation...</summary>
        [JsonPropertyName("unlockHash")]
        public uint UnlockHash { get; set; }

        /// <summary>Whether the unlock flag is set.</summary>
        [JsonPropertyName("isSet")]
        public bool IsSet { get; set; }
    }

    /// <summary>
    /// The possible states of Destiny Profile Records. IMPORTANT: Any given item can theoretically have many of these states simultaneously: as a result, this was altered to be a flags enumeration/bitmask for v3.2.0.
    /// </summary>
    [Flags]
    public enum DestinyVendorItemState : int
    {
        /// <summary>There are no augments on the item.</summary>
        None = 0,

        /// <summary>Deprecated forever (probably). There was a time when Records were going to be implemented through Vendors, and this field was relevant. Now they're implemented through Presentation Nodes, and this field doesn't matter anymore.</summary>
        Incomplete = 1,

        /// <summary>Deprecated forever (probably). See the description of the "Incomplete" value for the juicy scoop.</summary>
        RewardAvailable = 2,

        /// <summary>Deprecated forever (probably). See the description of the "Incomplete" value for the juicy scoop.</summary>
        Complete = 4,

        /// <summary>This item is considered to be "newly available", and should have some UI showing how shiny it is.</summary>
        New = 8,

        /// <summary>This item is being "featured", and should be shiny in a different way from items that are merely new.</summary>
        Featured = 16,

        /// <summary>This item is only available for a limited time, and that time is approaching.</summary>
        Ending = 32,

        /// <summary>This item is "on sale". Get it while it's hot.</summary>
        OnSale = 64,

        /// <summary>This item is already owned.</summary>
        Owned = 128,

        /// <summary>This item should be shown with a "wide view" instead of normal icon view.</summary>
        WideView = 256,

        /// <summary>This indicates that you should show some kind of attention-requesting indicator on the item, in a similar manner to items in the nexus that have such notifications.</summary>
        NexusAttention = 512,

        /// <summary>This indicates that the item has some sort of a 'set' discount.</summary>
        SetDiscount = 1024,

        /// <summary>This indicates that the item has a price drop.</summary>
        PriceDrop = 2048,

        /// <summary>This indicates that the item is a daily offer.</summary>
        DailyOffer = 4096,

        /// <summary>This indicates that the item is for charity.</summary>
        Charity = 8192,

        /// <summary>This indicates that the item has a seasonal reward expiration.</summary>
        SeasonalRewardExpiration = 16384,

        /// <summary>This indicates that the sale item is the best deal among different choices.</summary>
        BestDeal = 32768,

        /// <summary>This indicates that the sale item is popular.</summary>
        Popular = 65536,

        /// <summary>This indicates that the sale item is free.</summary>
        Free = 131072
    }

    /// <summary>
    /// The results of a bulk Equipping operation performed through the Destiny API.
    /// </summary>
    public class DestinyEquipItemResults
    {
        [JsonPropertyName("equipResults")]
        public IEnumerable<Destiny.DestinyEquipItemResult> EquipResults { get; set; }
    }

    /// <summary>
    /// The results of an Equipping operation performed through the Destiny API.
    /// </summary>
    public class DestinyEquipItemResult
    {
        /// <summary>The instance ID of the item in question (all items that can be equipped must, but definition, be Instanced and thus have an Instance ID that you can use to refer to them)</summary>
        [JsonPropertyName("itemInstanceId")]
        public long ItemInstanceId { get; set; }

        /// <summary>A PlatformErrorCodes enum indicating whether it succeeded, and if it failed why.</summary>
        [JsonPropertyName("equipStatus")]
        public Exceptions.PlatformErrorCodes EquipStatus { get; set; }
    }
}