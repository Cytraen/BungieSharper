using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions
{
    /// <summary>
    /// Provides common properties for destiny definitions.
    /// </summary>
    public class DestinyDefinition
    {
        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        public uint hash { get; set; }

        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        public int index { get; set; }

        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        public bool redacted { get; set; }
    }

    /// <summary>
    /// A "Progression" in Destiny is best explained by an example.
    /// A Character's "Level" is a progression: it has Experience that can be earned, levels that can be gained, and is evaluated and displayed at various points in the game. A Character's "Faction Reputation" is also a progression for much the same reason.
    /// Progression is used by a variety of systems, and the definition of a Progression will generally only be useful if combining with live data (such as a character's DestinyCharacterProgressionComponent.progressions property, which holds that character's live Progression states).
    /// Fundamentally, a Progression measures your "Level" by evaluating the thresholds in its Steps (one step per level, except for the last step which can be repeated indefinitely for "Levels" that have no ceiling) against the total earned "progression points"/experience. (for simplicity purposes, we will henceforth refer to earned progression points as experience, though it need not be a mechanic that in any way resembles Experience in a traditional sense).
    /// Earned experience is calculated in a variety of ways, determined by the Progression's scope. These go from looking up a stored value to performing exceedingly obtuse calculations. This is why we provide live data in DestinyCharacterProgressionComponent.progressions, so you don't have to worry about those.
    /// </summary>
    public class DestinyProgressionDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.DestinyProgressionDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>
        /// The "Scope" of the progression indicates the source of the progression's live data.
        /// See the DestinyProgressionScope enum for more info: but essentially, a Progression can either be backed by a stored value, or it can be a calculated derivative of other values.
        /// </summary>
        public Destiny.DestinyProgressionScope scope { get; set; }

        /// <summary>If this is True, then the progression doesn't have a maximum level.</summary>
        public bool repeatLastStep { get; set; }

        /// <summary>If there's a description of how to earn this progression in the local config, this will be that localized description.</summary>
        public string source { get; set; }

        /// <summary>
        /// Progressions are divided into Steps, which roughly equate to "Levels" in the traditional sense of a Progression. Notably, the last step can be repeated indefinitely if repeatLastStep is true, meaning that the calculation for your level is not as simple as comparing your current progress to the max progress of the steps.
        /// These and more calculations are done for you if you grab live character progression data, such as in the DestinyCharacterProgressionComponent.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyProgressionStepDefinition> steps { get; set; }

        /// <summary>
        /// If true, the Progression is something worth showing to users.
        /// If false, BNet isn't going to show it. But that doesn't mean you can't. We're all friends here.
        /// </summary>
        public bool visible { get; set; }

        /// <summary>
        /// If the value exists, this is the hash identifier for the Faction that owns this Progression.
        /// This is purely for convenience, if you're looking at a progression and want to know if and who it's related to in terms of Faction Reputation.
        /// </summary>
        public uint? factionHash { get; set; }

        /// <summary>The #RGB string value for the color related to this progression, if there is one.</summary>
        public Destiny.Misc.DestinyColor color { get; set; }

        /// <summary>For progressions that have it, this is the rank icon we use in the Companion, displayed above the progressions' rank value.</summary>
        public string rankIcon { get; set; }

        public IEnumerable<Destiny.Definitions.DestinyProgressionRewardItemQuantity> rewardItems { get; set; }
    }

    public class DestinyProgressionDisplayPropertiesDefinition
    {
        /// <summary>When progressions show your "experience" gained, that bar has units (i.e. "Experience", "Bad Dudes Snuffed Out", whatever). This is the localized string for that unit of measurement.</summary>
        public string displayUnitsName { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        /// <summary>
        /// Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
        /// But usually, it will be a small square image that you can use as... well, an icon.
        /// They are currently represented as 96px x 96px images.
        /// </summary>
        public string icon { get; set; }

        public IEnumerable<Destiny.Definitions.Common.DestinyIconSequenceDefinition> iconSequences { get; set; }

        /// <summary>If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.</summary>
        public string highResIcon { get; set; }

        public bool hasIcon { get; set; }
    }

    /// <summary>
    /// This defines a single Step in a progression (which roughly equates to a level. See DestinyProgressionDefinition for caveats).
    /// </summary>
    public class DestinyProgressionStepDefinition
    {
        /// <summary>Very rarely, Progressions will have localized text describing the Level of the progression. This will be that localized text, if it exists. Otherwise, the standard appears to be to simply show the level numerically.</summary>
        public string stepName { get; set; }

        /// <summary>This appears to be, when you "level up", whether a visual effect will display and on what entity. See DestinyProgressionStepDisplayEffect for slightly more info.</summary>
        public Destiny.DestinyProgressionStepDisplayEffect displayEffectType { get; set; }

        /// <summary>The total amount of progression points/"experience" you will need to initially reach this step. If this is the last step and the progression is repeating indefinitely (DestinyProgressionDefinition.repeatLastStep), this will also be the progress needed to level it up further by repeating this step again.</summary>
        public int progressTotal { get; set; }

        /// <summary>A listing of items rewarded as a result of reaching this level.</summary>
        public IEnumerable<Destiny.DestinyItemQuantity> rewardItems { get; set; }

        /// <summary>If this progression step has a specific icon related to it, this is the icon to show.</summary>
        public string icon { get; set; }
    }

    /// <summary>
    /// So much of what you see in Destiny is actually an Item used in a new and creative way. This is the definition for Items in Destiny, which started off as just entities that could exist in your Inventory but ended up being the backing data for so much more: quests, reward previews, slots, and subclasses.
    /// In practice, you will want to associate this data with "live" item data from a Bungie.Net Platform call: these definitions describe the item in generic, non-instanced terms: but an actual instance of an item can vary widely from these generic definitions.
    /// </summary>
    public class DestinyInventoryItemDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>Tooltips that only come up conditionally for the item. Check the live data DestinyItemComponent.tooltipNotificationIndexes property for which of these should be shown at runtime.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemTooltipNotification> tooltipNotifications { get; set; }

        /// <summary>If this item has a collectible related to it, this is the hash identifier of that collectible entry.</summary>
        public uint? collectibleHash { get; set; }

        /// <summary>If available, this is the original 'active' release watermark overlay for the icon. If the item has different versions, this can be overridden by the 'display version watermark icon' from the 'quality' block. Alternatively, if there is no watermark for the version, and the item version has a power cap below the current season power cap, this can be overridden by the iconWatermarkShelved property.</summary>
        public string iconWatermark { get; set; }

        /// <summary>If available, this is the 'shelved' release watermark overlay for the icon. If the item version has a power cap below the current season power cap, it can be treated as 'shelved', and should be shown with this 'shelved' watermark overlay.</summary>
        public string iconWatermarkShelved { get; set; }

        /// <summary>A secondary icon associated with the item. Currently this is used in very context specific applications, such as Emblem Nameplates.</summary>
        public string secondaryIcon { get; set; }

        /// <summary>Pulled from the secondary icon, this is the "secondary background" of the secondary icon. Confusing? Sure, that's why I call it "overlay" here: because as far as it's been used thus far, it has been for an optional overlay image. We'll see if that holds up, but at least for now it explains what this image is a bit better.</summary>
        public string secondaryOverlay { get; set; }

        /// <summary>Pulled from the Secondary Icon, this is the "special" background for the item. For Emblems, this is the background image used on the Details view: but it need not be limited to that for other types of items.</summary>
        public string secondarySpecial { get; set; }

        /// <summary>Sometimes, an item will have a background color. Most notably this occurs with Emblems, who use the Background Color for small character nameplates such as the "friends" view you see in-game. There are almost certainly other items that have background color as well, though I have not bothered to investigate what items have it nor what purposes they serve: use it as you will.</summary>
        public Destiny.Misc.DestinyColor backgroundColor { get; set; }

        /// <summary>If we were able to acquire an in-game screenshot for the item, the path to that screenshot will be returned here. Note that not all items have screenshots: particularly not any non-equippable items.</summary>
        public string screenshot { get; set; }

        /// <summary>The localized title/name of the item's type. This can be whatever the designers want, and has no guarantee of consistency between items.</summary>
        public string itemTypeDisplayName { get; set; }

        /// <summary>A string identifier that the game's UI uses to determine how the item should be rendered in inventory screens and the like. This could really be anything - at the moment, we don't have the time to really breakdown and maintain all the possible strings this could be, partly because new ones could be added ad hoc. But if you want to use it to dictate your own UI, or look for items with a certain display style, go for it!</summary>
        public string uiItemDisplayStyle { get; set; }

        /// <summary>It became a common enough pattern in our UI to show Item Type and Tier combined into a single localized string that I'm just going to go ahead and start pre-creating these for items.</summary>
        public string itemTypeAndTierDisplayName { get; set; }

        /// <summary>In theory, it is a localized string telling you about how you can find the item. I really wish this was more consistent. Many times, it has nothing. Sometimes, it's instead a more narrative-forward description of the item. Which is cool, and I wish all properties had that data, but it should really be its own property.</summary>
        public string displaySource { get; set; }

        /// <summary>An identifier that the game UI uses to determine what type of tooltip to show for the item. These have no corresponding definitions that BNet can link to: so it'll be up to you to interpret and display your UI differently according to these styles (or ignore it).</summary>
        public string tooltipStyle { get; set; }

        /// <summary>If the item can be "used", this block will be non-null, and will have data related to the action performed when using the item. (Guess what? 99% of the time, this action is "dismantle". Shocker)</summary>
        public Destiny.Definitions.DestinyItemActionBlockDefinition action { get; set; }

        /// <summary>If this item can exist in an inventory, this block will be non-null. In practice, every item that currently exists has one of these blocks. But note that it is not necessarily guaranteed.</summary>
        public Destiny.Definitions.DestinyItemInventoryBlockDefinition inventory { get; set; }

        /// <summary>If this item is a quest, this block will be non-null. In practice, I wish I had called this the Quest block, but at the time it wasn't clear to me whether it would end up being used for purposes other than quests. It will contain data about the steps in the quest, and mechanics we can use for displaying and tracking the quest.</summary>
        public Destiny.Definitions.DestinyItemSetBlockDefinition setData { get; set; }

        /// <summary>If this item can have stats (such as a weapon, armor, or vehicle), this block will be non-null and populated with the stats found on the item.</summary>
        public Destiny.Definitions.DestinyItemStatBlockDefinition stats { get; set; }

        /// <summary>If the item is an emblem that has a special Objective attached to it - for instance, if the emblem tracks PVP Kills, or what-have-you. This is a bit different from, for example, the Vanguard Kill Tracker mod, which pipes data into the "art channel". When I get some time, I would like to standardize these so you can get at the values they expose without having to care about what they're being used for and how they are wired up, but for now here's the raw data.</summary>
        public uint? emblemObjectiveHash { get; set; }

        /// <summary>If this item can be equipped, this block will be non-null and will be populated with the conditions under which it can be equipped.</summary>
        public Destiny.Definitions.DestinyEquippingBlockDefinition equippingBlock { get; set; }

        /// <summary>If this item can be rendered, this block will be non-null and will be populated with rendering information.</summary>
        public Destiny.Definitions.DestinyItemTranslationBlockDefinition translationBlock { get; set; }

        /// <summary>If this item can be Used or Acquired to gain other items (for instance, how Eververse Boxes can be consumed to get items from the box), this block will be non-null and will give summary information for the items that can be acquired.</summary>
        public Destiny.Definitions.DestinyItemPreviewBlockDefinition preview { get; set; }

        /// <summary>If this item can have a level or stats, this block will be non-null and will be populated with default quality (item level, "quality", and infusion) data. See the block for more details, there's often less upfront information in D2 so you'll want to be aware of how you use quality and item level on the definition level now.</summary>
        public Destiny.Definitions.DestinyItemQualityBlockDefinition quality { get; set; }

        /// <summary>The conceptual "Value" of an item, if any was defined. See the DestinyItemValueBlockDefinition for more details.</summary>
        public Destiny.Definitions.DestinyItemValueBlockDefinition value { get; set; }

        /// <summary>If this item has a known source, this block will be non-null and populated with source information. Unfortunately, at this time we are not generating sources: that is some aggressively manual work which we didn't have time for, and I'm hoping to get back to at some point in the future.</summary>
        public Destiny.Definitions.DestinyItemSourceBlockDefinition sourceData { get; set; }

        /// <summary>If this item has Objectives (extra tasks that can be accomplished related to the item... most frequently when the item is a Quest Step and the Objectives need to be completed to move on to the next Quest Step), this block will be non-null and the objectives defined herein.</summary>
        public Destiny.Definitions.DestinyItemObjectiveBlockDefinition objectives { get; set; }

        /// <summary>If this item has available metrics to be shown, this block will be non-null have the appropriate hashes defined.</summary>
        public Destiny.Definitions.DestinyItemMetricBlockDefinition metrics { get; set; }

        /// <summary>If this item *is* a Plug, this will be non-null and the info defined herein. See DestinyItemPlugDefinition for more information.</summary>
        public Destiny.Definitions.Items.DestinyItemPlugDefinition plug { get; set; }

        /// <summary>If this item has related items in a "Gear Set", this will be non-null and the relationships defined herein.</summary>
        public Destiny.Definitions.DestinyItemGearsetBlockDefinition gearset { get; set; }

        /// <summary>If this item is a "reward sack" that can be opened to provide other items, this will be non-null and the properties of the sack contained herein.</summary>
        public Destiny.Definitions.DestinyItemSackBlockDefinition sack { get; set; }

        /// <summary>If this item has any Sockets, this will be non-null and the individual sockets on the item will be defined herein.</summary>
        public Destiny.Definitions.DestinyItemSocketBlockDefinition sockets { get; set; }

        /// <summary>Summary data about the item.</summary>
        public Destiny.Definitions.DestinyItemSummaryBlockDefinition summary { get; set; }

        /// <summary>If the item has a Talent Grid, this will be non-null and the properties of the grid defined herein. Note that, while many items still have talent grids, the only ones with meaningful Nodes still on them will be Subclass/"Build" items.</summary>
        public Destiny.Definitions.DestinyItemTalentGridBlockDefinition talentGrid { get; set; }

        /// <summary>If the item has stats, this block will be defined. It has the "raw" investment stats for the item. These investment stats don't take into account the ways that the items can spawn, nor do they take into account any Stat Group transformations. I have retained them for debugging purposes, but I do not know how useful people will find them.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemInvestmentStatDefinition> investmentStats { get; set; }

        /// <summary>If the item has any *intrinsic* Perks (Perks that it will provide regardless of Sockets, Talent Grid, and other transitory state), they will be defined here.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemPerkEntryDefinition> perks { get; set; }

        /// <summary>If the item has any related Lore (DestinyLoreDefinition), this will be the hash identifier you can use to look up the lore definition.</summary>
        public uint? loreHash { get; set; }

        /// <summary>
        /// There are times when the game will show you a "summary/vague" version of an item - such as a description of its type represented as a DestinyInventoryItemDefinition - rather than display the item itself.
        /// This happens sometimes when summarizing possible rewards in a tooltip. This is the item displayed instead, if it exists.
        /// </summary>
        public uint? summaryItemHash { get; set; }

        /// <summary>If any animations were extracted from game content for this item, these will be the definitions of those animations.</summary>
        public IEnumerable<Destiny.Definitions.Animations.DestinyAnimationReference> animations { get; set; }

        /// <summary>BNet may forbid the execution of actions on this item via the API. If that is occurring, allowActions will be set to false.</summary>
        public bool allowActions { get; set; }

        /// <summary>If we added any help or informational URLs about this item, these will be those links.</summary>
        public IEnumerable<Links.HyperlinkReference> links { get; set; }

        /// <summary>
        /// The boolean will indicate to us (and you!) whether something *could* happen when you transfer this item from the Postmaster that might be considered a "destructive" action.
        /// It is not feasible currently to tell you (or ourelves!) in a consistent way whether this *will* actually cause a destructive action, so we are playing it safe: if it has the potential to do so, we will not allow it to be transferred from the Postmaster by default. You will need to check for this flag before transferring an item from the Postmaster, or else you'll end up receiving an error.
        /// </summary>
        public bool doesPostmasterPullHaveSideEffects { get; set; }

        /// <summary>
        /// The intrinsic transferability of an item.
        /// I hate that this boolean is negative - but there's a reason.
        /// Just because an item is intrinsically transferrable doesn't mean that it can be transferred, and we don't want to imply that this is the only source of that transferability.
        /// </summary>
        public bool nonTransferrable { get; set; }

        /// <summary>
        /// BNet attempts to make a more formal definition of item "Categories", as defined by DestinyItemCategoryDefinition. This is a list of all Categories that we were able to algorithmically determine that this item is a member of. (for instance, that it's a "Weapon", that it's an "Auto Rifle", etc...)
        /// The algorithm for these is, unfortunately, volatile. If you believe you see a miscategorized item, please let us know on the Bungie API forums.
        /// </summary>
        public IEnumerable<uint> itemCategoryHashes { get; set; }

        /// <summary>In Destiny 1, we identified some items as having particular categories that we'd like to know about for various internal logic purposes. These are defined in SpecialItemType, and while these days the itemCategoryHashes are the preferred way of identifying types, we have retained this enum for its convenience.</summary>
        public Destiny.SpecialItemType specialItemType { get; set; }

        /// <summary>
        /// A value indicating the "base" the of the item. This enum is a useful but dramatic oversimplification of what it means for an item to have a "Type". Still, it's handy in many situations.
        /// itemCategoryHashes are the preferred way of identifying types, we have retained this enum for its convenience.
        /// </summary>
        public Destiny.DestinyItemType itemType { get; set; }

        /// <summary>
        /// A value indicating the "sub-type" of the item. For instance, where an item might have an itemType value "Weapon", this will be something more specific like "Auto Rifle".
        /// itemCategoryHashes are the preferred way of identifying types, we have retained this enum for its convenience.
        /// </summary>
        public Destiny.DestinyItemSubType itemSubType { get; set; }

        /// <summary>
        /// We run a similarly weak-sauce algorithm to try and determine whether an item is restricted to a specific class. If we find it to be restricted in such a way, we set this classType property to match the class' enumeration value so that users can easily identify class restricted items.
        /// If you see a mis-classed item, please inform the developers in the Bungie API forum.
        /// </summary>
        public Destiny.DestinyClass classType { get; set; }

        /// <summary>Some weapons and plugs can have a "Breaker Type": a special ability that works sort of like damage type vulnerabilities. This is (almost?) always set on items by plugs.</summary>
        public Destiny.DestinyBreakerType breakerType { get; set; }

        /// <summary>Since we also have a breaker type definition, this is the hash for that breaker type for your convenience. Whether you use the enum or hash and look up the definition depends on what's cleanest for your code.</summary>
        public uint? breakerTypeHash { get; set; }

        /// <summary>
        /// If true, then you will be allowed to equip the item if you pass its other requirements.
        /// This being false means that you cannot equip the item under any circumstances.
        /// </summary>
        public bool equippable { get; set; }

        /// <summary>Theoretically, an item can have many possible damage types. In *practice*, this is not true, but just in case weapons start being made that have multiple (for instance, an item where a socket has reusable plugs for every possible damage type that you can choose from freely), this field will return all of the possible damage types that are available to the weapon by default.</summary>
        public IEnumerable<uint> damageTypeHashes { get; set; }

        /// <summary>
        /// This is the list of all damage types that we know ahead of time the item can take on. Unfortunately, this does not preclude the possibility of something funky happening to give the item a damage type that cannot be predicted beforehand: for example, if some designer decides to create arbitrary non-reusable plugs that cause damage type to change.
        /// This damage type prediction will only use the following to determine potential damage types:
        /// - Intrinsic perks
        /// - Talent Node perks
        /// - Known, reusable plugs for sockets
        /// </summary>
        public IEnumerable<Destiny.DamageType> damageTypes { get; set; }

        /// <summary>
        /// If the item has a damage type that could be considered to be default, it will be populated here.
        /// For various upsetting reasons, it's surprisingly cumbersome to figure this out. I hope you're happy.
        /// </summary>
        public Destiny.DamageType defaultDamageType { get; set; }

        /// <summary>
        /// Similar to defaultDamageType, but represented as the hash identifier for a DestinyDamageTypeDefinition.
        /// I will likely regret leaving in the enumeration versions of these properties, but for now they're very convenient.
        /// </summary>
        public uint? defaultDamageTypeHash { get; set; }

        /// <summary>If this item is related directly to a Season of Destiny, this is the hash identifier for that season.</summary>
        public uint? seasonHash { get; set; }

        /// <summary>If true, this is a dummy vendor-wrapped item template. Items purchased from Eververse will be "wrapped" by one of these items so that we can safely provide refund capabilities before the item is "unwrapped".</summary>
        public bool isWrapper { get; set; }

        /// <summary>Traits are metadata tags applied to this item. For example: armor slot, weapon type, foundry, faction, etc. These IDs come from the game and don't map to any content, but should still be useful.</summary>
        public IEnumerable<string> traitIds { get; set; }
    }

    public class DestinyItemTooltipNotification
    {
        public string displayString { get; set; }

        public string displayStyle { get; set; }
    }

    /// <summary>
    /// If an item can have an action performed on it (like "Dismantle"), it will be defined here if you care.
    /// </summary>
    public class DestinyItemActionBlockDefinition
    {
        /// <summary>Localized text for the verb of the action being performed.</summary>
        public string verbName { get; set; }

        /// <summary>Localized text describing the action being performed.</summary>
        public string verbDescription { get; set; }

        /// <summary>The content has this property, however it's not entirely clear how it is used.</summary>
        public bool isPositive { get; set; }

        /// <summary>If the action has an overlay screen associated with it, this is the name of that screen. Unfortunately, we cannot return the screen's data itself.</summary>
        public string overlayScreenName { get; set; }

        /// <summary>The icon associated with the overlay screen for the action, if any.</summary>
        public string overlayIcon { get; set; }

        /// <summary>The number of seconds to delay before allowing this action to be performed again.</summary>
        public int requiredCooldownSeconds { get; set; }

        /// <summary>If the action requires other items to exist or be destroyed, this is the list of those items and requirements.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemActionRequiredItemDefinition> requiredItems { get; set; }

        /// <summary>If performing this action earns you Progression, this is the list of progressions and values granted for those progressions by performing this action.</summary>
        public IEnumerable<Destiny.Definitions.DestinyProgressionRewardDefinition> progressionRewards { get; set; }

        /// <summary>The internal identifier for the action.</summary>
        public string actionTypeLabel { get; set; }

        /// <summary>Theoretically, an item could have a localized string for a hint about the location in which the action should be performed. In practice, no items yet have this property.</summary>
        public string requiredLocation { get; set; }

        /// <summary>The identifier hash for the Cooldown associated with this action. We have not pulled this data yet for you to have more data to use for cooldowns.</summary>
        public uint requiredCooldownHash { get; set; }

        /// <summary>If true, the item is deleted when the action completes.</summary>
        public bool deleteOnAction { get; set; }

        /// <summary>If true, the entire stack is deleted when the action completes.</summary>
        public bool consumeEntireStack { get; set; }

        /// <summary>If true, this action will be performed as soon as you earn this item. Some rewards work this way, providing you a single item to pick up from a reward-granting vendor in-game and then immediately consuming itself to provide you multiple items.</summary>
        public bool useOnAcquire { get; set; }
    }

    /// <summary>
    /// The definition of an item and quantity required in a character's inventory in order to perform an action.
    /// </summary>
    public class DestinyItemActionRequiredItemDefinition
    {
        /// <summary>The minimum quantity of the item you have to have.</summary>
        public int count { get; set; }

        /// <summary>The hash identifier of the item you need to have. Use it to look up the DestinyInventoryItemDefinition for more info.</summary>
        public uint itemHash { get; set; }

        /// <summary>If true, the item/quantity will be deleted from your inventory when the action is performed. Otherwise, you'll retain these required items after the action is complete.</summary>
        public bool deleteOnAction { get; set; }
    }

    /// <summary>
    /// Inventory Items can reward progression when actions are performed on them. A common example of this in Destiny 1 was Bounties, which would reward Experience on your Character and the like when you completed the bounty.
    /// Note that this maps to a DestinyProgressionMappingDefinition, and *not* a DestinyProgressionDefinition directly. This is apparently so that multiple progressions can be granted progression points/experience at the same time.
    /// </summary>
    public class DestinyProgressionRewardDefinition
    {
        /// <summary>The hash identifier of the DestinyProgressionMappingDefinition that contains the progressions for which experience should be applied.</summary>
        public uint progressionMappingHash { get; set; }

        /// <summary>The amount of experience to give to each of the mapped progressions.</summary>
        public int amount { get; set; }

        /// <summary>If true, the game's internal mechanisms to throttle progression should be applied.</summary>
        public bool applyThrottles { get; set; }
    }

    /// <summary>
    /// Aggregations of multiple progressions.
    /// These are used to apply rewards to multiple progressions at once. They can sometimes have human readable data as well, but only extremely sporadically.
    /// </summary>
    public class DestinyProgressionMappingDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>Infrequently defined in practice. Defer to the individual progressions' display properties.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The localized unit of measurement for progression across the progressions defined in this mapping. Unfortunately, this is very infrequently defined. Defer to the individual progressions' display units.</summary>
        public string displayUnits { get; set; }
    }

    /// <summary>
    /// If the item can exist in an inventory - the overwhelming majority of them can and do - then this is the basic properties regarding the item's relationship with the inventory.
    /// </summary>
    public class DestinyItemInventoryBlockDefinition
    {
        /// <summary>If this string is populated, you can't have more than one stack with this label in a given inventory. Note that this is different from the equipping block's unique label, which is used for equipping uniqueness.</summary>
        public string stackUniqueLabel { get; set; }

        /// <summary>The maximum quantity of this item that can exist in a stack.</summary>
        public int maxStackSize { get; set; }

        /// <summary>The hash identifier for the DestinyInventoryBucketDefinition to which this item belongs. I should have named this "bucketHash", but too many things refer to it now. Sigh.</summary>
        public uint bucketTypeHash { get; set; }

        /// <summary>If the item is picked up by the lost loot queue, this is the hash identifier for the DestinyInventoryBucketDefinition into which it will be placed. Again, I should have named this recoveryBucketHash instead.</summary>
        public uint recoveryBucketTypeHash { get; set; }

        /// <summary>The hash identifier for the Tier Type of the item, use to look up its DestinyItemTierTypeDefinition if you need to show localized data for the item's tier.</summary>
        public uint tierTypeHash { get; set; }

        /// <summary>If TRUE, this item is instanced. Otherwise, it is a generic item that merely has a quantity in a stack (like Glimmer).</summary>
        public bool isInstanceItem { get; set; }

        /// <summary>The localized name of the tier type, which is a useful shortcut so you don't have to look up the definition every time. However, it's mostly a holdover from days before we had a DestinyItemTierTypeDefinition to refer to.</summary>
        public string tierTypeName { get; set; }

        /// <summary>The enumeration matching the tier type of the item to known values, again for convenience sake.</summary>
        public Destiny.TierType tierType { get; set; }

        /// <summary>The tooltip message to show, if any, when the item expires.</summary>
        public string expirationTooltip { get; set; }

        /// <summary>If the item expires while playing in an activity, we show a different message.</summary>
        public string expiredInActivityMessage { get; set; }

        /// <summary>If the item expires in orbit, we show a... more different message. ("Consummate V's, consummate!")</summary>
        public string expiredInOrbitMessage { get; set; }

        public bool suppressExpirationWhenObjectivesComplete { get; set; }
    }

    /// <summary>
    /// An Inventory (be it Character or Profile level) is comprised of many Buckets. An example of a bucket is "Primary Weapons", where all of the primary weapons on a character are gathered together into a single visual element in the UI: a subset of the inventory that has a limited number of slots, and in this case also has an associated Equipment Slot for equipping an item in the bucket.
    /// Item definitions declare what their "default" bucket is (DestinyInventoryItemDefinition.inventory.bucketTypeHash), and Item instances will tell you which bucket they are currently residing in (DestinyItemComponent.bucketHash). You can use this information along with the DestinyInventoryBucketDefinition to show these items grouped by bucket.
    /// You cannot transfer an item to a bucket that is not its Default without going through a Vendor's "accepted items" (DestinyVendorDefinition.acceptedItems). This is how transfer functionality like the Vault is implemented, as a feature of a Vendor. See the vendor's acceptedItems property for more details.
    /// </summary>
    public class DestinyInventoryBucketDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>Where the bucket is found. 0 = Character, 1 = Account</summary>
        public Destiny.BucketScope scope { get; set; }

        /// <summary>An enum value for what items can be found in the bucket. See the BucketCategory enum for more details.</summary>
        public Destiny.BucketCategory category { get; set; }

        /// <summary>Use this property to provide a quick-and-dirty recommended ordering for buckets in the UI. Most UIs will likely want to forsake this for something more custom and manual.</summary>
        public int bucketOrder { get; set; }

        /// <summary>
        /// The maximum # of item "slots" in a bucket. A slot is a given combination of item + quantity.
        /// For instance, a Weapon will always take up a single slot, and always have a quantity of 1. But a material could take up only a single slot with hundreds of quantity.
        /// </summary>
        public int itemCount { get; set; }

        /// <summary>
        /// Sometimes, inventory buckets represent conceptual "locations" in the game that might not be expected. This value indicates the conceptual location of the bucket, regardless of where it is actually contained on the character/account.
        /// See ItemLocation for details.
        /// Note that location includes the Vault and the Postmaster (both of whom being just inventory buckets with additional actions that can be performed on them through a Vendor)
        /// </summary>
        public Destiny.ItemLocation location { get; set; }

        /// <summary>If TRUE, there is at least one Vendor that can transfer items to/from this bucket. See the DestinyVendorDefinition's acceptedItems property for more information on how transferring works.</summary>
        public bool hasTransferDestination { get; set; }

        /// <summary>If True, this bucket is enabled. Disabled buckets may include buckets that were included for test purposes, or that were going to be used but then were abandoned but never removed from content *cough*.</summary>
        public bool enabled { get; set; }

        /// <summary>if a FIFO bucket fills up, it will delete the oldest item from said bucket when a new item tries to be added to it. If this is FALSE, the bucket will not allow new items to be placed in it until room is made by the user manually deleting items from it. You can see an example of this with the Postmaster's bucket.</summary>
        public bool fifo { get; set; }
    }

    /// <summary>
    /// Primarily for Quests, this is the definition of properties related to the item if it is a quest and its various quest steps.
    /// </summary>
    public class DestinyItemSetBlockDefinition
    {
        /// <summary>A collection of hashes of set items, for items such as Quest Metadata items that possess this data.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemSetBlockEntryDefinition> itemList { get; set; }

        /// <summary>If true, items in the set can only be added in increasing order, and adding an item will remove any previous item. For Quests, this is by necessity true. Only one quest step is present at a time, and previous steps are removed as you advance in the quest.</summary>
        public bool requireOrderedSetItemAdd { get; set; }

        /// <summary>If true, the UI should treat this quest as "featured"</summary>
        public bool setIsFeatured { get; set; }

        /// <summary>A string identifier we can use to attempt to identify the category of the Quest.</summary>
        public string setType { get; set; }

        /// <summary>The name of the quest line that this quest step is a part of.</summary>
        public string questLineName { get; set; }

        /// <summary>The description of the quest line that this quest step is a part of.</summary>
        public string questLineDescription { get; set; }

        /// <summary>An additional summary of this step in the quest line.</summary>
        public string questStepSummary { get; set; }
    }

    /// <summary>
    /// Defines a particular entry in an ItemSet (AKA a particular Quest Step in a Quest)
    /// </summary>
    public class DestinyItemSetBlockEntryDefinition
    {
        /// <summary>Used for tracking which step a user reached. These values will be populated in the user's internal state, which we expose externally as a more usable DestinyQuestStatus object. If this item has been obtained, this value will be set in trackingUnlockValueHash.</summary>
        public int trackingValue { get; set; }

        /// <summary>This is the hash identifier for a DestinyInventoryItemDefinition representing this quest step.</summary>
        public uint itemHash { get; set; }
    }

    /// <summary>
    /// Information about the item's calculated stats, with as much data as we can find for the stats without having an actual instance of the item.
    /// Note that this means the entire concept of providing these stats is fundamentally insufficient: we cannot predict with 100% accuracy the conditions under which an item can spawn, so we use various heuristics to attempt to simulate the conditions as accurately as possible. Actual stats for items in-game can and will vary, but these should at least be useful base points for comparison and display.
    /// It is also worth noting that some stats, like Magazine size, have further calculations performed on them by scripts in-game and on the game servers that BNet does not have access to. We cannot know how those stats are further transformed, and thus some stats will be inaccurate even on instances of items in BNet vs. how they appear in-game. This is a known limitation of our item statistics, without any planned fix.
    /// </summary>
    public class DestinyItemStatBlockDefinition
    {
        /// <summary>
        /// If true, the game won't show the "primary" stat on this item when you inspect it.
        /// NOTE: This is being manually mapped, because I happen to want it in a block that isn't going to directly create this derivative block.
        /// </summary>
        public bool disablePrimaryStatDisplay { get; set; }

        /// <summary>
        /// If the item's stats are meant to be modified by a DestinyStatGroupDefinition, this will be the identifier for that definition.
        /// If you are using live data or precomputed stats data on the DestinyInventoryItemDefinition.stats.stats property, you don't have to worry about statGroupHash and how it alters stats: the already altered stats are provided to you. But if you want to see how the sausage gets made, or perform computations yourself, this is valuable information.
        /// </summary>
        public uint? statGroupHash { get; set; }

        /// <summary>
        /// If you are looking for precomputed values for the stats on a weapon, this is where they are stored. Technically these are the "Display" stat values. Please see DestinyStatsDefinition for what Display Stat Values means, it's a very long story... but essentially these are the closest values BNet can get to the item stats that you see in-game.
        /// These stats are keyed by the DestinyStatDefinition's hash identifier for the stat that's found on the item.
        /// </summary>
        public Dictionary<uint, Destiny.Definitions.DestinyInventoryItemStatDefinition> stats { get; set; }

        /// <summary>A quick and lazy way to determine whether any stat other than the "primary" stat is actually visible on the item. Items often have stats that we return in case people find them useful, but they're not part of the "Stat Group" and thus we wouldn't display them in our UI. If this is False, then we're not going to display any of these stats other than the primary one.</summary>
        public bool hasDisplayableStats { get; set; }

        /// <summary>
        /// This stat is determined to be the "primary" stat, and can be looked up in the stats or any other stat collection related to the item.
        /// Use this hash to look up the stat's value using DestinyInventoryItemDefinition.stats.stats, and the renderable data for the primary stat in the related DestinyStatDefinition.
        /// </summary>
        public uint primaryBaseStatHash { get; set; }
    }

    /// <summary>
    /// Defines a specific stat value on an item, and the minimum/maximum range that we could compute for the item based on our heuristics for how the item might be generated.
    /// Not guaranteed to match real-world instances of the item, but should hopefully at least be close. If it's not close, let us know on the Bungie API forums.
    /// </summary>
    public class DestinyInventoryItemStatDefinition
    {
        /// <summary>The hash for the DestinyStatDefinition representing this stat.</summary>
        public uint statHash { get; set; }

        /// <summary>
        /// This value represents the stat value assuming the minimum possible roll but accounting for any mandatory bonuses that should be applied to the stat on item creation.
        /// In Destiny 1, this was different from the "minimum" value because there were certain conditions where an item could be theoretically lower level/value than the initial roll.
        /// In Destiny 2, this is not possible unless Talent Grids begin to be used again for these purposes or some other system change occurs... thus in practice, value and minimum should be the same in Destiny 2. Good riddance.
        /// </summary>
        public int value { get; set; }

        /// <summary>The minimum possible value for this stat that we think the item can roll.</summary>
        public int minimum { get; set; }

        /// <summary>
        /// The maximum possible value for this stat that we think the item can roll.
        /// WARNING: In Destiny 1, this field was calculated using the potential stat rolls on the item's talent grid. In Destiny 2, items no longer have meaningful talent grids and instead have sockets: but the calculation of this field was never altered to adapt to this change. As such, this field should be considered deprecated until we can address this oversight.
        /// </summary>
        public int maximum { get; set; }

        /// <summary>
        /// The maximum possible value for the stat as shown in the UI, if it is being shown somewhere that reveals maximum in the UI (such as a bar chart-style view).
        /// This is pulled directly from the item's DestinyStatGroupDefinition, and placed here for convenience.
        /// If not returned, there is no maximum to use (and thus the stat should not be shown in a way that assumes there is a limit to the stat)
        /// </summary>
        public int? displayMaximum { get; set; }
    }

    /// <summary>
    /// This represents a stat that's applied to a character or an item (such as a weapon, piece of armor, or a vehicle).
    /// An example of a stat might be Attack Power on a weapon.
    /// Stats go through a complex set of transformations before they end up being shown to the user as a number or a progress bar, and those transformations are fundamentally intertwined with the concept of a "Stat Group" (DestinyStatGroupDefinition). Items have both Stats and a reference to a Stat Group, and it is the Stat Group that takes the raw stat information and gives it both rendering metadata (such as whether to show it as a number or a progress bar) and the final transformation data (interpolation tables to turn the raw investment stat into a display stat). Please see DestinyStatGroupDefinition for more information on that transformational process.
    /// Stats are segregated from Stat Groups because different items and types of items can refer to the same stat, but have different "scales" for the stat while still having the same underlying value. For example, both a Shotgun and an Auto Rifle may have a "raw" impact stat of 50, but the Auto Rifle's Stat Group will scale that 50 down so that, when it is displayed, it is a smaller value relative to the shotgun. (this is a totally made up example, don't assume shotguns have naturally higher impact than auto rifles because of this)
    /// A final caveat is that some stats, even after this "final" transformation, go through yet another set of transformations directly in the game as a result of dynamic, stateful scripts that get run. BNet has no access to these scripts, nor any way to know which scripts get executed. As a result, the stats for an item that you see in-game - particularly for stats that are often impacted by Perks, like Magazine Size - can change dramatically from what we return on Bungie.Net. This is a known issue with no fix coming down the pipeline. Take these stats with a grain of salt.
    /// Stats actually go through four transformations, for those interested:
    /// 1) "Sandbox" stat, the "most raw" form. These are pretty much useless without transformations applied, and thus are not currently returned in the API. If you really want these, we can provide them. Maybe someone could do something cool with it?
    /// 2) "Investment" stat (the stat's value after DestinyStatDefinition's interpolation tables and aggregation logic is applied to the "Sandbox" stat value)
    /// 3) "Display" stat (the stat's base UI-visible value after DestinyStatGroupDefinition's interpolation tables are applied to the Investment Stat value. For most stats, this is what is displayed.)
    /// 4) Underlying in-game stat (the stat's actual value according to the game, after the game runs dynamic scripts based on the game and character's state. This is the final transformation that BNet does not have access to. For most stats, this is not actually displayed to the user, with the exception of Magazine Size which is then piped back to the UI for display in-game, but not to BNet.)
    /// </summary>
    public class DestinyStatDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>Stats can exist on a character or an item, and they may potentially be aggregated in different ways. The DestinyStatAggregationType enum value indicates the way that this stat is being aggregated.</summary>
        public Destiny.DestinyStatAggregationType aggregationType { get; set; }

        /// <summary>
        /// True if the stat is computed rather than being delivered as a raw value on items.
        /// For instance, the Light stat in Destiny 1 was a computed stat.
        /// </summary>
        public bool hasComputedBlock { get; set; }

        /// <summary>The category of the stat, according to the game.</summary>
        public Destiny.DestinyStatCategory statCategory { get; set; }
    }

    /// <summary>
    /// When an inventory item (DestinyInventoryItemDefinition) has Stats (such as Attack Power), the item will refer to a Stat Group. This definition enumerates the properties used to transform the item's "Investment" stats into "Display" stats.
    /// See DestinyStatDefinition's documentation for information about the transformation of Stats, and the meaning of an Investment vs. a Display stat.
    /// If you don't want to do these calculations on your own, fear not: pulling live data from the BNet endpoints will return display stat values pre-computed and ready for you to use. I highly recommend this approach, saves a lot of time and also accounts for certain stat modifiers that can't easily be accounted for without live data (such as stat modifiers on Talent Grids and Socket Plugs)
    /// </summary>
    public class DestinyStatGroupDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>
        /// The maximum possible value that any stat in this group can be transformed into.
        /// This is used by stats that *don't* have scaledStats entries below, but that still need to be displayed as a progress bar, in which case this is used as the upper bound for said progress bar. (the lower bound is always 0)
        /// </summary>
        public int maximumValue { get; set; }

        /// <summary>This apparently indicates the position of the stats in the UI? I've returned it in case anyone can use it, but it's not of any use to us on BNet. Something's being lost in translation with this value.</summary>
        public int uiPosition { get; set; }

        /// <summary>
        /// Any stat that requires scaling to be transformed from an "Investment" stat to a "Display" stat will have an entry in this list. For more information on what those types of stats mean and the transformation process, see DestinyStatDefinition.
        /// In retrospect, I wouldn't mind if this was a dictionary keyed by the stat hash instead. But I'm going to leave it be because [[After Apple Picking]].
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyStatDisplayDefinition> scaledStats { get; set; }

        /// <summary>
        /// The game has the ability to override, based on the stat group, what the localized text is that is displayed for Stats being shown on the item.
        /// Mercifully, no Stat Groups use this feature currently. If they start using them, we'll all need to start using them (and those of you who are more prudent than I am can go ahead and start pre-checking for this.)
        /// </summary>
        public Dictionary<uint, Destiny.Definitions.DestinyStatOverrideDefinition> overrides { get; set; }
    }

    /// <summary>
    /// Describes the way that an Item Stat (see DestinyStatDefinition) is transformed using the DestinyStatGroupDefinition related to that item. See both of the aforementioned definitions for more information about the stages of stat transformation.
    /// This represents the transformation of a stat into a "Display" stat (the closest value that BNet can get to the in-game display value of the stat)
    /// </summary>
    public class DestinyStatDisplayDefinition
    {
        /// <summary>
        /// The hash identifier for the stat being transformed into a Display stat.
        /// Use it to look up the DestinyStatDefinition, or key into a DestinyInventoryItemDefinition's stats property.
        /// </summary>
        public uint statHash { get; set; }

        /// <summary>Regardless of the output of interpolation, this is the maximum possible value that the stat can be. It should also be used as the upper bound for displaying the stat as a progress bar (the minimum always being 0)</summary>
        public int maximumValue { get; set; }

        /// <summary>If this is true, the stat should be displayed as a number. Otherwise, display it as a progress bar. Or, you know, do whatever you want. There's no displayAsNumeric police.</summary>
        public bool displayAsNumeric { get; set; }

        /// <summary>
        /// The interpolation table representing how the Investment Stat is transformed into a Display Stat.
        /// See DestinyStatDefinition for a description of the stages of stat transformation.
        /// </summary>
        public IEnumerable<Interpolation.InterpolationPoint> displayInterpolation { get; set; }
    }

    /// <summary>
    /// Stat Groups (DestinyStatGroupDefinition) has the ability to override the localized text associated with stats that are to be shown on the items with which they are associated.
    /// This defines a specific overridden stat. You could theoretically check these before rendering your stat UI, and for each stat that has an override show these displayProperties instead of those on the DestinyStatDefinition.
    /// Or you could be like us, and skip that for now because the game has yet to actually use this feature. But know that it's here, waiting for a resilliant young designer to take up the mantle and make us all look foolish by showing the wrong name for stats.
    /// Note that, if this gets used, the override will apply only to items using the overriding Stat Group. Other items will still show the default stat's name/description.
    /// </summary>
    public class DestinyStatOverrideDefinition
    {
        /// <summary>The hash identifier of the stat whose display properties are being overridden.</summary>
        public uint statHash { get; set; }

        /// <summary>The display properties to show instead of the base DestinyStatDefinition display properties.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    /// <summary>
    /// Items that can be equipped define this block. It contains information we need to understand how and when the item can be equipped.
    /// </summary>
    public class DestinyEquippingBlockDefinition
    {
        /// <summary>If the item is part of a gearset, this is a reference to that gearset item.</summary>
        public uint? gearsetItemHash { get; set; }

        /// <summary>
        /// If defined, this is the label used to check if the item has other items of matching types already equipped.
        /// For instance, when you aren't allowed to equip more than one Exotic Weapon, that's because all exotic weapons have identical uniqueLabels and the game checks the to-be-equipped item's uniqueLabel vs. all other already equipped items (other than the item in the slot that's about to be occupied).
        /// </summary>
        public string uniqueLabel { get; set; }

        /// <summary>The hash of that unique label. Does not point to a specific definition.</summary>
        public uint uniqueLabelHash { get; set; }

        /// <summary>An equipped item *must* be equipped in an Equipment Slot. This is the hash identifier of the DestinyEquipmentSlotDefinition into which it must be equipped.</summary>
        public uint equipmentSlotTypeHash { get; set; }

        /// <summary>
        /// These are custom attributes on the equippability of the item.
        /// For now, this can only be "equip on acquire", which would mean that the item will be automatically equipped as soon as you pick it up.
        /// </summary>
        public Destiny.EquippingItemBlockAttributes attributes { get; set; }

        /// <summary>Ammo type used by a weapon is no longer determined by the bucket in which it is contained. If the item has an ammo type - i.e. if it is a weapon - this will be the type of ammunition expected.</summary>
        public Destiny.DestinyAmmunitionType ammoType { get; set; }

        /// <summary>These are strings that represent the possible Game/Account/Character state failure conditions that can occur when trying to equip the item. They match up one-to-one with requiredUnlockExpressions.</summary>
        public IEnumerable<string> displayStrings { get; set; }
    }

    /// <summary>
    /// Characters can not only have Inventory buckets (containers of items that are generally matched by their type or functionality), they can also have Equipment Slots.
    /// The Equipment Slot is an indicator that the related bucket can have instanced items equipped on the character. For instance, the Primary Weapon bucket has an Equipment Slot that determines whether you can equip primary weapons, and holds the association between its slot and the inventory bucket from which it can have items equipped.
    /// An Equipment Slot must have a related Inventory Bucket, but not all inventory buckets must have Equipment Slots.
    /// </summary>
    public class DestinyEquipmentSlotDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>These technically point to "Equipment Category Definitions". But don't get excited. There's nothing of significant value in those definitions, so I didn't bother to expose them. You can use the hash here to group equipment slots by common functionality, which serves the same purpose as if we had the Equipment Category definitions exposed.</summary>
        public uint equipmentCategoryHash { get; set; }

        /// <summary>The inventory bucket that owns this equipment slot.</summary>
        public uint bucketTypeHash { get; set; }

        /// <summary>If True, equipped items should have their custom art dyes applied when rendering the item. Otherwise, custom art dyes on an item should be ignored if the item is equipped in this slot.</summary>
        public bool applyCustomArtDyes { get; set; }

        /// <summary>The Art Dye Channels that apply to this equipment slot.</summary>
        public IEnumerable<Destiny.Definitions.DestinyArtDyeReference> artDyeChannels { get; set; }
    }

    public class DestinyArtDyeReference
    {
        public uint artDyeChannelHash { get; set; }
    }

    /// <summary>
    /// This Block defines the rendering data associated with the item, if any.
    /// </summary>
    public class DestinyItemTranslationBlockDefinition
    {
        public string weaponPatternIdentifier { get; set; }

        public uint weaponPatternHash { get; set; }

        public IEnumerable<Destiny.DyeReference> defaultDyes { get; set; }

        public IEnumerable<Destiny.DyeReference> lockedDyes { get; set; }

        public IEnumerable<Destiny.DyeReference> customDyes { get; set; }

        public IEnumerable<Destiny.Definitions.DestinyGearArtArrangementReference> arrangements { get; set; }

        public bool hasGeometry { get; set; }
    }

    public class DestinyGearArtArrangementReference
    {
        public uint classHash { get; set; }

        public uint artArrangementHash { get; set; }
    }

    /// <summary>
    /// Items like Sacks or Boxes can have items that it shows in-game when you view details that represent the items you can obtain if you use or acquire the item.
    /// This defines those categories, and gives some insights into that data's source.
    /// </summary>
    public class DestinyItemPreviewBlockDefinition
    {
        /// <summary>A string that the game UI uses as a hint for which detail screen to show for the item. You, too, can leverage this for your own custom screen detail views. Note, however, that these are arbitrarily defined by designers: there's no guarantees of a fixed, known number of these - so fall back to something reasonable if you don't recognize it.</summary>
        public string screenStyle { get; set; }

        /// <summary>If the preview data is derived from a fake "Preview" Vendor, this will be the hash identifier for the DestinyVendorDefinition of that fake vendor.</summary>
        public uint previewVendorHash { get; set; }

        /// <summary>If this item should show you Artifact information when you preview it, this is the hash identifier of the DestinyArtifactDefinition for the artifact whose data should be shown.</summary>
        public uint? artifactHash { get; set; }

        /// <summary>If the preview has an associated action (like "Open"), this will be the localized string for that action.</summary>
        public string previewActionString { get; set; }

        /// <summary>This is a list of the items being previewed, categorized in the same way as they are in the preview UI.</summary>
        public IEnumerable<Destiny.Definitions.Items.DestinyDerivedItemCategoryDefinition> derivedItemCategories { get; set; }
    }

    /// <summary>
    /// These are the definitions for Vendors.
    /// In Destiny, a Vendor can be a lot of things - some things that you wouldn't expect, and some things that you don't even see directly in the game. Vendors are the Dolly Levi of the Destiny universe.
    /// - Traditional Vendors as you see in game: people who you come up to and who give you quests, rewards, or who you can buy things from.
    /// - Kiosks/Collections, which are really just Vendors that don't charge currency (or charge some pittance of a currency) and whose gating for purchases revolves more around your character's state.
    /// - Previews for rewards or the contents of sacks. These are implemented as Vendors, where you can't actually purchase from them but the items that they have for sale and the categories of sale items reflect the rewards or contents of the sack. This is so that the game could reuse the existing Vendor display UI for rewards and save a bunch of wheel reinvention.
    /// - Item Transfer capabilities, like the Vault and Postmaster. Vendors can have "acceptedItem" buckets that determine the source and destination buckets for transfers. When you interact with such a vendor, these buckets are what gets shown in the UI instead of any items that the Vendor would have for sale. Yep, the Vault is a vendor.
    /// It is pretty much guaranteed that they'll be used for even more features in the future. They have come to be seen more as generic categorized containers for items than "vendors" in a traditional sense, for better or worse.
    /// Where possible and time allows, we'll attempt to split those out into their own more digestible derived "Definitions": but often time does not allow that, as you can see from the above ways that vendors are used which we never split off from Vendor Definitions externally.
    /// Since Vendors are so many things to so many parts of the game, the definition is understandably complex. You will want to combine this data with live Vendor information from the API when it is available.
    /// </summary>
    public class DestinyVendorDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.DestinyVendorDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>If the vendor has a custom localized string describing the "buy" action, that is returned here.</summary>
        public string buyString { get; set; }

        /// <summary>Ditto for selling. Not that you can sell items to a vendor anymore. Will it come back? Who knows. The string's still there.</summary>
        public string sellString { get; set; }

        /// <summary>
        /// If the vendor has an item that should be displayed as the "featured" item, this is the hash identifier for that DestinyVendorItemDefinition.
        /// Apparently this is usually a related currency, like a reputation token. But it need not be restricted to that.
        /// </summary>
        public uint displayItemHash { get; set; }

        /// <summary>If this is true, you aren't allowed to buy whatever the vendor is selling.</summary>
        public bool inhibitBuying { get; set; }

        /// <summary>If this is true, you're not allowed to sell whatever the vendor is buying.</summary>
        public bool inhibitSelling { get; set; }

        /// <summary>
        /// If the Vendor has a faction, this hash will be valid and point to a DestinyFactionDefinition.
        /// The game UI and BNet often mine the faction definition for additional elements and details to place on the screen, such as the faction's Progression status (aka "Reputation").
        /// </summary>
        public uint factionHash { get; set; }

        /// <summary>
        /// A number used for calculating the frequency of a vendor's inventory resetting/refreshing.
        /// Don't worry about calculating this - we do it on the server side and send you the next refresh date with the live data.
        /// </summary>
        public int resetIntervalMinutes { get; set; }

        /// <summary>Again, used for reset/refreshing of inventory. Don't worry too much about it. Unless you want to.</summary>
        public int resetOffsetMinutes { get; set; }

        /// <summary>
        /// If an item can't be purchased from the vendor, there may be many "custom"/game state specific reasons why not.
        /// This is a list of localized strings with messages for those custom failures. The live BNet data will return a failureIndexes property for items that can't be purchased: using those values to index into this array, you can show the user the appropriate failure message for the item that can't be bought.
        /// </summary>
        public IEnumerable<string> failureStrings { get; set; }

        /// <summary>If we were able to predict the dates when this Vendor will be visible/available, this will be the list of those date ranges. Sadly, we're not able to predict this very frequently, so this will often be useless data.</summary>
        public IEnumerable<Dates.DateRange> unlockRanges { get; set; }

        /// <summary>The internal identifier for the Vendor. A holdover from the old days of Vendors, but we don't have time to refactor it away.</summary>
        public string vendorIdentifier { get; set; }

        /// <summary>A portrait of the Vendor's smiling mug. Or frothing tentacles.</summary>
        public string vendorPortrait { get; set; }

        /// <summary>If the vendor has a custom banner image, that can be found here.</summary>
        public string vendorBanner { get; set; }

        /// <summary>If a vendor is not enabled, we won't even save the vendor's definition, and we won't return any items or info about them. It's as if they don't exist.</summary>
        public bool enabled { get; set; }

        /// <summary>If a vendor is not visible, we still have and will give vendor definition info, but we won't use them for things like Advisors or UI.</summary>
        public bool visible { get; set; }

        /// <summary>The identifier of the VendorCategoryDefinition for this vendor's subcategory.</summary>
        public string vendorSubcategoryIdentifier { get; set; }

        /// <summary>If TRUE, consolidate categories that only differ by trivial properties (such as having minor differences in name)</summary>
        public bool consolidateCategories { get; set; }

        /// <summary>Describes "actions" that can be performed on a vendor. Currently, none of these exist. But theoretically a Vendor could let you interact with it by performing actions. We'll see what these end up looking like if they ever get used.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorActionDefinition> actions { get; set; }

        /// <summary>
        /// These are the headers for sections of items that the vendor is selling. When you see items organized by category in the header, it is these categories that it is showing.
        /// Well, technically not *exactly* these. On BNet, it doesn't make sense to have categories be "paged" as we do in Destiny, so we run some heuristics to attempt to aggregate pages of categories together.
        /// These are the categories post-concatenation, if the vendor had concatenation applied. If you want the pre-aggregated category data, use originalCategories.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorCategoryEntryDefinition> categories { get; set; }

        /// <summary>See the categories property for a description of categories and why originalCategories exists.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorCategoryEntryDefinition> originalCategories { get; set; }

        /// <summary>
        /// Display Categories are different from "categories" in that these are specifically for visual grouping and display of categories in Vendor UI.
        /// The "categories" structure is for validation of the contained items, and can be categorized entirely separately from "Display Categories", there need be and often will be no meaningful relationship between the two.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyDisplayCategoryDefinition> displayCategories { get; set; }

        /// <summary>In addition to selling items, vendors can have "interactions": UI where you "talk" with the vendor and they offer you a reward, some item, or merely acknowledge via dialog that you did something cool.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorInteractionDefinition> interactions { get; set; }

        /// <summary>If the vendor shows you items from your own inventory - such as the Vault vendor does - this data describes the UI around showing those inventory buckets and which ones get shown.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorInventoryFlyoutDefinition> inventoryFlyouts { get; set; }

        /// <summary>
        /// If the vendor sells items (or merely has a list of items to show like the "Sack" vendors do), this is the list of those items that the vendor can sell. From this list, only a subset will be available from the vendor at any given time, selected randomly and reset on the vendor's refresh interval.
        /// Note that a vendor can sell the same item multiple ways: for instance, nothing stops a vendor from selling you some specific weapon but using two different currencies, or the same weapon at multiple "item levels".
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorItemDefinition> itemList { get; set; }

        /// <summary>BNet doesn't use this data yet, but it appears to be an optional list of flavor text about services that the Vendor can provide.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorServiceDefinition> services { get; set; }

        /// <summary>If the Vendor is actually a vehicle for the transferring of items (like the Vault and Postmaster vendors), this defines the list of source->destination buckets for transferring.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorAcceptedItemDefinition> acceptedItems { get; set; }

        /// <summary>As many of you know, Vendor data has historically been pretty brutal on the BNet servers. In an effort to reduce this workload, only Vendors with this flag set will be returned on Vendor requests. This allows us to filter out Vendors that don't dynamic data that's particularly useful: things like "Preview/Sack" vendors, for example, that you can usually suss out the details for using just the definitions themselves.</summary>
        public bool returnWithVendorRequest { get; set; }

        /// <summary>A vendor can be at different places in the world depending on the game/character/account state. This is the list of possible locations for the vendor, along with conditions we use to determine which one is currently active.</summary>
        public IEnumerable<Destiny.Definitions.Vendors.DestinyVendorLocationDefinition> locations { get; set; }

        /// <summary>A vendor can be a part of 0 or 1 "groups" at a time: a group being a collection of Vendors related by either location or function/purpose. It's used for our our Companion Vendor UI. Only one of these can be active for a Vendor at a time.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorGroupReference> groups { get; set; }

        /// <summary>Some items don't make sense to return in the API, for example because they represent an action to be performed rather than an item being sold. I'd rather we not do this, but at least in the short term this is a workable workaround.</summary>
        public IEnumerable<uint> ignoreSaleItemHashes { get; set; }
    }

    public class DestinyVendorDisplayPropertiesDefinition
    {
        /// <summary>I regret calling this a "large icon". It's more like a medium-sized image with a picture of the vendor's mug on it, trying their best to look cool. Not what one would call an icon.</summary>
        public string largeIcon { get; set; }

        public string subtitle { get; set; }

        /// <summary>If we replaced the icon with something more glitzy, this is the original icon that the vendor had according to the game's content. It may be more lame and/or have less razzle-dazzle. But who am I to tell you which icon to use.</summary>
        public string originalIcon { get; set; }

        /// <summary>Vendors, in addition to expected display property data, may also show some "common requirements" as statically defined definition data. This might be when a vendor accepts a single type of currency, or when the currency is unique to the vendor and the designers wanted to show that currency when you interact with the vendor.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorRequirementDisplayEntryDefinition> requirementsDisplay { get; set; }

        /// <summary>This is the icon used in parts of the game UI such as the vendor's waypoint.</summary>
        public string smallTransparentIcon { get; set; }

        /// <summary>This is the icon used in the map overview, when the vendor is located on the map.</summary>
        public string mapIcon { get; set; }

        /// <summary>This is apparently the "Watermark". I am not certain offhand where this is actually used in the Game UI, but some people may find it useful.</summary>
        public string largeTransparentIcon { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        /// <summary>
        /// Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
        /// But usually, it will be a small square image that you can use as... well, an icon.
        /// They are currently represented as 96px x 96px images.
        /// </summary>
        public string icon { get; set; }

        public IEnumerable<Destiny.Definitions.Common.DestinyIconSequenceDefinition> iconSequences { get; set; }

        /// <summary>If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.</summary>
        public string highResIcon { get; set; }

        public bool hasIcon { get; set; }
    }

    /// <summary>
    /// The localized properties of the requirementsDisplay, allowing information about the requirement or item being featured to be seen.
    /// </summary>
    public class DestinyVendorRequirementDisplayEntryDefinition
    {
        public string icon { get; set; }

        public string name { get; set; }

        public string source { get; set; }

        public string type { get; set; }
    }

    /// <summary>
    /// If a vendor can ever end up performing actions, these are the properties that will be related to those actions. I'm not going to bother documenting this yet, as it is unused and unclear if it will ever be used... but in case it is ever populated and someone finds it useful, it is defined here.
    /// </summary>
    public class DestinyVendorActionDefinition
    {
        public string description { get; set; }

        public int executeSeconds { get; set; }

        public string icon { get; set; }

        public string name { get; set; }

        public string verb { get; set; }

        public bool isPositive { get; set; }

        public string actionId { get; set; }

        public uint actionHash { get; set; }

        public bool autoPerformAction { get; set; }
    }

    /// <summary>
    /// This is the definition for a single Vendor Category, into which Sale Items are grouped.
    /// </summary>
    public class DestinyVendorCategoryEntryDefinition
    {
        /// <summary>The index of the category in the original category definitions for the vendor.</summary>
        public int categoryIndex { get; set; }

        /// <summary>Used in sorting items in vendors... but there's a lot more to it. Just go with the order provided in the itemIndexes property on the DestinyVendorCategoryComponent instead, it should be more reliable than trying to recalculate it yourself.</summary>
        public int sortValue { get; set; }

        /// <summary>The hashed identifier for the category.</summary>
        public uint categoryHash { get; set; }

        /// <summary>The amount of items that will be available when this category is shown.</summary>
        public int quantityAvailable { get; set; }

        /// <summary>If items aren't up for sale in this category, should we still show them (greyed out)?</summary>
        public bool showUnavailableItems { get; set; }

        /// <summary>If you don't have the currency required to buy items from this category, should the items be hidden?</summary>
        public bool hideIfNoCurrency { get; set; }

        /// <summary>True if this category doesn't allow purchases.</summary>
        public bool hideFromRegularPurchase { get; set; }

        /// <summary>The localized string for making purchases from this category, if it is different from the vendor's string for purchasing.</summary>
        public string buyStringOverride { get; set; }

        /// <summary>If the category is disabled, this is the localized description to show.</summary>
        public string disabledDescription { get; set; }

        /// <summary>The localized title of the category.</summary>
        public string displayTitle { get; set; }

        /// <summary>If this category has an overlay prompt that should appear, this contains the details of that prompt.</summary>
        public Destiny.Definitions.DestinyVendorCategoryOverlayDefinition overlay { get; set; }

        /// <summary>A shortcut for the vendor item indexes sold under this category. Saves us from some expensive reorganization at runtime.</summary>
        public IEnumerable<int> vendorItemIndexes { get; set; }

        /// <summary>Sometimes a category isn't actually used to sell items, but rather to preview them. This implies different UI (and manual placement of the category in the UI) in the game, and special treatment.</summary>
        public bool isPreview { get; set; }

        /// <summary>If true, this category only displays items: you can't purchase anything in them.</summary>
        public bool isDisplayOnly { get; set; }

        public int resetIntervalMinutesOverride { get; set; }

        public int resetOffsetMinutesOverride { get; set; }
    }

    /// <summary>
    /// The details of an overlay prompt to show to a user. They are all fairly self-explanatory localized strings that can be shown.
    /// </summary>
    public class DestinyVendorCategoryOverlayDefinition
    {
        public string choiceDescription { get; set; }

        public string description { get; set; }

        public string icon { get; set; }

        public string title { get; set; }

        /// <summary>If this overlay has a currency item that it features, this is said featured item.</summary>
        public uint? currencyItemHash { get; set; }
    }

    /// <summary>
    /// Display Categories are different from "categories" in that these are specifically for visual grouping and display of categories in Vendor UI. The "categories" structure is for validation of the contained items, and can be categorized entirely separately from "Display Categories", there need be and often will be no meaningful relationship between the two.
    /// </summary>
    public class DestinyDisplayCategoryDefinition
    {
        public int index { get; set; }

        /// <summary>A string identifier for the display category.</summary>
        public string identifier { get; set; }

        public uint displayCategoryHash { get; set; }

        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>If true, this category should be displayed in the "Banner" section of the vendor's UI.</summary>
        public bool displayInBanner { get; set; }

        /// <summary>
        /// If it exists, this is the hash identifier of a DestinyProgressionDefinition that represents the progression to show on this display category.
        /// Specific categories can now have thier own distinct progression, apparently. So that's cool.
        /// </summary>
        public uint? progressionHash { get; set; }

        /// <summary>If this category sorts items in a nonstandard way, this will be the way we sort.</summary>
        public Destiny.VendorDisplayCategorySortOrder sortOrder { get; set; }

        /// <summary>An indicator of how the category will be displayed in the UI. It's up to you to do something cool or interesting in response to this, or just to treat it as a normal category.</summary>
        public uint? displayStyleHash { get; set; }

        /// <summary>An indicator of how the category will be displayed in the UI. It's up to you to do something cool or interesting in response to this, or just to treat it as a normal category.</summary>
        public string displayStyleIdentifier { get; set; }
    }

    /// <summary>
    /// A Vendor Interaction is a dialog shown by the vendor other than sale items or transfer screens. The vendor is showing you something, and asking you to reply to it by choosing an option or reward.
    /// </summary>
    public class DestinyVendorInteractionDefinition
    {
        /// <summary>The position of this interaction in its parent array. Note that this is NOT content agnostic, and should not be used as such.</summary>
        public int interactionIndex { get; set; }

        /// <summary>The potential replies that the user can make to the interaction.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorInteractionReplyDefinition> replies { get; set; }

        /// <summary>If >= 0, this is the category of sale items to show along with this interaction dialog.</summary>
        public int vendorCategoryIndex { get; set; }

        /// <summary>If this interaction dialog is about a quest, this is the questline related to the interaction. You can use this to show the quest overview, or even the character's status with the quest if you use it to find the character's current Quest Step by checking their inventory against this questlineItemHash's DestinyInventoryItemDefinition.setData.</summary>
        public uint questlineItemHash { get; set; }

        /// <summary>If this interaction is meant to show you sacks, this is the list of types of sacks to be shown. If empty, the interaction is not meant to show sacks.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorInteractionSackEntryDefinition> sackInteractionList { get; set; }

        /// <summary>A UI hint for the behavior of the interaction screen. This is useful to determine what type of interaction is occurring, such as a prompt to receive a rank up reward or a prompt to choose a reward for completing a quest. The hash isn't as useful as the Enum in retrospect, well what can you do. Try using interactionType instead.</summary>
        public uint uiInteractionType { get; set; }

        /// <summary>The enumerated version of the possible UI hints for vendor interactions, which is a little easier to grok than the hash found in uiInteractionType.</summary>
        public Destiny.VendorInteractionType interactionType { get; set; }

        /// <summary>If this interaction is displaying rewards, this is the text to use for the header of the reward-displaying section of the interaction.</summary>
        public string rewardBlockLabel { get; set; }

        /// <summary>If the vendor's reward list is sourced from one of his categories, this is the index into the category array of items to show.</summary>
        public int rewardVendorCategoryIndex { get; set; }

        /// <summary>If the vendor interaction has flavor text, this is some of it.</summary>
        public string flavorLineOne { get; set; }

        /// <summary>If the vendor interaction has flavor text, this is the rest of it.</summary>
        public string flavorLineTwo { get; set; }

        /// <summary>The header for the interaction dialog.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition headerDisplayProperties { get; set; }

        /// <summary>The localized text telling the player what to do when they see this dialog.</summary>
        public string instructions { get; set; }
    }

    /// <summary>
    /// When the interaction is replied to, Reward sites will fire and items potentially selected based on whether the given unlock expression is TRUE.
    /// You can potentially choose one from multiple replies when replying to an interaction: this is how you get either/or rewards from vendors.
    /// </summary>
    public class DestinyVendorInteractionReplyDefinition
    {
        /// <summary>The rewards granted upon responding to the vendor.</summary>
        public Destiny.DestinyVendorInteractionRewardSelection itemRewardsSelection { get; set; }

        /// <summary>The localized text for the reply.</summary>
        public string reply { get; set; }

        /// <summary>An enum indicating the type of reply being made.</summary>
        public Destiny.DestinyVendorReplyType replyType { get; set; }
    }

    /// <summary>
    /// Compare this sackType to the sack identifier in the DestinyInventoryItemDefinition.vendorSackType property of items. If they match, show this sack with this interaction.
    /// </summary>
    public class DestinyVendorInteractionSackEntryDefinition
    {
        public uint sackType { get; set; }
    }

    /// <summary>
    /// The definition for an "inventory flyout": a UI screen where we show you part of an otherwise hidden vendor inventory: like the Vault inventory buckets.
    /// </summary>
    public class DestinyVendorInventoryFlyoutDefinition
    {
        /// <summary>If the flyout is locked, this is the reason why.</summary>
        public string lockedDescription { get; set; }

        /// <summary>The title and other common properties of the flyout.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>A list of inventory buckets and other metadata to show on the screen.</summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorInventoryFlyoutBucketDefinition> buckets { get; set; }

        /// <summary>An identifier for the flyout, in case anything else needs to refer to them.</summary>
        public uint flyoutId { get; set; }

        /// <summary>If this is true, don't show any of the glistening "this is a new item" UI elements, like we show on the inventory items themselves in in-game UI.</summary>
        public bool suppressNewness { get; set; }

        /// <summary>If this flyout is meant to show you the contents of the player's equipment slot, this is the slot to show.</summary>
        public uint? equipmentSlotHash { get; set; }
    }

    /// <summary>
    /// Information about a single inventory bucket in a vendor flyout UI and how it is shown.
    /// </summary>
    public class DestinyVendorInventoryFlyoutBucketDefinition
    {
        /// <summary>If true, the inventory bucket should be able to be collapsed visually.</summary>
        public bool collapsible { get; set; }

        /// <summary>The inventory bucket whose contents should be shown.</summary>
        public uint inventoryBucketHash { get; set; }

        /// <summary>The methodology to use for sorting items from the flyout.</summary>
        public Destiny.DestinyItemSortType sortItemsBy { get; set; }
    }

    /// <summary>
    /// This represents an item being sold by the vendor.
    /// </summary>
    public class DestinyVendorItemDefinition
    {
        /// <summary>The index into the DestinyVendorDefinition.saleList. This is what we use to refer to items being sold throughout live and definition data.</summary>
        public int vendorItemIndex { get; set; }

        /// <summary>
        /// The hash identifier of the item being sold (DestinyInventoryItemDefinition).
        /// Note that a vendor can sell the same item in multiple ways, so don't assume that itemHash is a unique identifier for this entity.
        /// </summary>
        public uint itemHash { get; set; }

        /// <summary>The amount you will recieve of the item described in itemHash if you make the purchase.</summary>
        public int quantity { get; set; }

        /// <summary>An list of indexes into the DestinyVendorDefinition.failureStrings array, indicating the possible failure strings that can be relevant for this item.</summary>
        public IEnumerable<int> failureIndexes { get; set; }

        /// <summary>
        /// This is a pre-compiled aggregation of item value and priceOverrideList, so that we have one place to check for what the purchaser must pay for the item. Use this instead of trying to piece together the price separately.
        /// The somewhat crappy part about this is that, now that item quantity overrides have dynamic modifiers, this will not necessarily be statically true. If you were using this instead of live data, switch to using live data.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyVendorItemQuantity> currencies { get; set; }

        /// <summary>If this item can be refunded, this is the policy for what will be refundd, how, and in what time period.</summary>
        public Destiny.DestinyVendorItemRefundPolicy refundPolicy { get; set; }

        /// <summary>The amount of time before refundability of the newly purchased item will expire.</summary>
        public int refundTimeLimit { get; set; }

        /// <summary>The Default level at which the item will spawn. Almost always driven by an adjusto these days. Ideally should be singular. It's a long story how this ended up as a list, but there is always either going to be 0:1 of these entities.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemCreationEntryLevelDefinition> creationLevels { get; set; }

        /// <summary>This is an index specifically into the display category, as opposed to the server-side Categories (which do not need to match or pair with each other in any way: server side categories are really just structures for common validation. Display Category will let us more easily categorize items visually)</summary>
        public int displayCategoryIndex { get; set; }

        /// <summary>The index into the DestinyVendorDefinition.categories array, so you can find the category associated with this item.</summary>
        public int categoryIndex { get; set; }

        /// <summary>Same as above, but for the original category indexes.</summary>
        public int originalCategoryIndex { get; set; }

        /// <summary>The minimum character level at which this item is available for sale.</summary>
        public int minimumLevel { get; set; }

        /// <summary>The maximum character level at which this item is available for sale.</summary>
        public int maximumLevel { get; set; }

        /// <summary>The action to be performed when purchasing the item, if it's not just "buy".</summary>
        public Destiny.Definitions.DestinyVendorSaleItemActionBlockDefinition action { get; set; }

        /// <summary>The string identifier for the category selling this item.</summary>
        public string displayCategory { get; set; }

        /// <summary>The inventory bucket into which this item will be placed upon purchase.</summary>
        public uint inventoryBucketHash { get; set; }

        /// <summary>
        /// The most restrictive scope that determines whether the item is available in the Vendor's inventory. See DestinyGatingScope's documentation for more information.
        /// This can be determined by Unlock gating, or by whether or not the item has purchase level requirements (minimumLevel and maximumLevel properties).
        /// </summary>
        public Destiny.DestinyGatingScope visibilityScope { get; set; }

        /// <summary>
        /// Similar to visibilityScope, it represents the most restrictive scope that determines whether the item can be purchased. It will at least be as restrictive as visibilityScope, but could be more restrictive if the item has additional purchase requirements beyond whether it is merely visible or not.
        /// See DestinyGatingScope's documentation for more information.
        /// </summary>
        public Destiny.DestinyGatingScope purchasableScope { get; set; }

        /// <summary>If this item can only be purchased by a given platform, this indicates the platform to which it is restricted.</summary>
        public BungieMembershipType exclusivity { get; set; }

        /// <summary>If this sale can only be performed as the result of an offer check, this is true.</summary>
        public bool? isOffer { get; set; }

        /// <summary>If this sale can only be performed as the result of receiving a CRM offer, this is true.</summary>
        public bool? isCrm { get; set; }

        /// <summary>*if* the category this item is in supports non-default sorting, this value should represent the sorting value to use, pre-processed and ready to go.</summary>
        public int sortValue { get; set; }

        /// <summary>If this item can expire, this is the tooltip message to show with its expiration info.</summary>
        public string expirationTooltip { get; set; }

        /// <summary>If this is populated, the purchase of this item should redirect to purchasing these other items instead.</summary>
        public IEnumerable<int> redirectToSaleIndexes { get; set; }

        public IEnumerable<Destiny.Definitions.DestinyVendorItemSocketOverride> socketOverrides { get; set; }

        /// <summary>
        /// If true, this item is some sort of dummy sale item that cannot actually be purchased. It may be a display only item, or some fluff left by a content designer for testing purposes, or something that got disabled because it was a terrible idea. You get the picture. We won't know *why* it can't be purchased, only that it can't be. Sorry.
        /// This is also only whether it's unpurchasable as a static property according to game content. There are other reasons why an item may or may not be purchasable at runtime, so even if this isn't set to True you should trust the runtime value for this sale item over the static definition if this is unset.
        /// </summary>
        public bool? unpurchasable { get; set; }
    }

    /// <summary>
    /// In addition to item quantity information for vendor prices, this also has any optional information that may exist about how the item's quantity can be modified. (unfortunately not information that is able to be read outside of the BNet servers, but it's there)
    /// </summary>
    public class DestinyVendorItemQuantity : Destiny.DestinyItemQuantity { }

    /// <summary>
    /// An overly complicated wrapper for the item level at which the item should spawn.
    /// </summary>
    public class DestinyItemCreationEntryLevelDefinition
    {
        public int level { get; set; }
    }

    /// <summary>
    /// Not terribly useful, some basic cooldown interaction info.
    /// </summary>
    public class DestinyVendorSaleItemActionBlockDefinition
    {
        public float executeSeconds { get; set; }

        public bool isPositive { get; set; }
    }

    /// <summary>
    /// The information for how the vendor purchase should override a given socket with custom plug data.
    /// </summary>
    public class DestinyVendorItemSocketOverride
    {
        /// <summary>
        /// If this is populated, the socket will be overridden with a specific plug.
        /// If this isn't populated, it's being overridden by something more complicated that is only known by the Game Server and God, which means we can't tell you in advance what it'll be.
        /// </summary>
        public uint? singleItemHash { get; set; }

        /// <summary>If this is greater than -1, the number of randomized plugs on this socket will be set to this quantity instead of whatever it's set to by default.</summary>
        public int randomizedOptionsCount { get; set; }

        /// <summary>This appears to be used to select which socket ultimately gets the override defined here.</summary>
        public uint socketTypeHash { get; set; }
    }

    /// <summary>
    /// When a vendor provides services, this is the localized name of those services.
    /// </summary>
    public class DestinyVendorServiceDefinition
    {
        /// <summary>The localized name of a service provided.</summary>
        public string name { get; set; }
    }

    /// <summary>
    /// If you ever wondered how the Vault works, here it is.
    /// The Vault is merely a set of inventory buckets that exist on your Profile/Account level. When you transfer items in the Vault, the game is using the Vault Vendor's DestinyVendorAcceptedItemDefinitions to see where the appropriate destination bucket is for the source bucket from whence your item is moving. If it finds such an entry, it transfers the item to the other bucket.
    /// The mechanics for Postmaster works similarly, which is also a vendor. All driven by Accepted Items.
    /// </summary>
    public class DestinyVendorAcceptedItemDefinition
    {
        /// <summary>The "source" bucket for a transfer. When a user wants to transfer an item, the appropriate DestinyVendorDefinition's acceptedItems property is evaluated, looking for an entry where acceptedInventoryBucketHash matches the bucket that the item being transferred is currently located. If it exists, the item will be transferred into whatever bucket is defined by destinationInventoryBucketHash.</summary>
        public uint acceptedInventoryBucketHash { get; set; }

        /// <summary>This is the bucket where the item being transferred will be put, given that it was being transferred *from* the bucket defined in acceptedInventoryBucketHash.</summary>
        public uint destinationInventoryBucketHash { get; set; }
    }

    /// <summary>
    /// On to one of the more confusing subjects of the API. What is a Destination, and what is the relationship between it, Activities, Locations, and Places?
    /// A "Destination" is a specific region/city/area of a larger "Place". For instance, a Place might be Earth where a Destination might be Bellevue, Washington. (Please, pick a more interesting destination if you come to visit Earth).
    /// </summary>
    public class DestinyDestinationDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The place that "owns" this Destination. Use this hash to look up the DestinyPlaceDefinition.</summary>
        public uint placeHash { get; set; }

        /// <summary>If this Destination has a default Free-Roam activity, this is the hash for that Activity. Use it to look up the DestinyActivityDefintion.</summary>
        public uint defaultFreeroamActivityHash { get; set; }

        /// <summary>If the Destination has default Activity Graphs (i.e. "Map") that should be shown in the director, this is the list of those Graphs. At most, only one should be active at any given time for a Destination: these would represent, for example, different variants on a Map if the Destination is changing on a macro level based on game state.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityGraphListEntryDefinition> activityGraphEntries { get; set; }

        /// <summary>
        /// A Destination may have many "Bubbles" zones with human readable properties.
        /// We don't get as much info as I'd like about them - I'd love to return info like where on the map they are located - but at least this gives you the name of those bubbles. bubbleSettings and bubbles both have the identical number of entries, and you should match up their indexes to provide matching bubble and bubbleSettings data.
        /// DEPRECATED - Just use bubbles, it now has this data.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyDestinationBubbleSettingDefinition> bubbleSettings { get; set; }

        /// <summary>
        /// This provides the unique identifiers for every bubble in the destination (only guaranteed unique within the destination), and any intrinsic properties of the bubble.
        /// bubbleSettings and bubbles both have the identical number of entries, and you should match up their indexes to provide matching bubble and bubbleSettings data.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyBubbleDefinition> bubbles { get; set; }
    }

    /// <summary>
    /// Destinations and Activities may have default Activity Graphs that should be shown when you bring up the Director and are playing in either.
    /// This contract defines the graph referred to and the gating for when it is relevant.
    /// </summary>
    public class DestinyActivityGraphListEntryDefinition
    {
        /// <summary>The hash identifier of the DestinyActivityGraphDefinition that should be shown when opening the director.</summary>
        public uint activityGraphHash { get; set; }
    }

    /// <summary>
    /// The static data about Activities in Destiny 2.
    /// Note that an Activity must be combined with an ActivityMode to know - from a Gameplay perspective - what the user is "Playing".
    /// In most PvE activities, this is fairly straightforward. A Story Activity can only be played in the Story Activity Mode.
    /// However, in PvP activities, the Activity alone only tells you the map being played, or the Playlist that the user chose to enter. You'll need to know the Activity Mode they're playing to know that they're playing Mode X on Map Y.
    /// Activity Definitions tell a great deal of information about what *could* be relevant to a user: what rewards they can earn, what challenges could be performed, what modifiers could be applied. To figure out which of these properties is actually live, you'll need to combine the definition with "Live" data from one of the Destiny endpoints.
    /// Activities also have Activity Types, but unfortunately in Destiny 2 these are even less reliable of a source of information than they were in Destiny 1. I will be looking into ways to provide more reliable sources for type information as time goes on, but for now we're going to have to deal with the limitations. See DestinyActivityTypeDefinition for more information.
    /// </summary>
    public class DestinyActivityDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>The title, subtitle, and icon for the activity. We do a little post-processing on this to try and account for Activities where the designers have left this data too minimal to determine what activity is actually being played.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The unadulterated form of the display properties, as they ought to be shown in the Director (if the activity appears in the director).</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition originalDisplayProperties { get; set; }

        /// <summary>The title, subtitle, and icon for the activity as determined by Selection Screen data, if there is any for this activity. There won't be data in this field if the activity is never shown in a selection/options screen.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition selectionScreenDisplayProperties { get; set; }

        /// <summary>If the activity has an icon associated with a specific release (such as a DLC), this is the path to that release's icon.</summary>
        public string releaseIcon { get; set; }

        /// <summary>If the activity will not be visible until a specific and known time, this will be the seconds since the Epoch when it will become visible.</summary>
        public int releaseTime { get; set; }

        /// <summary>The difficulty level of the activity.</summary>
        public int activityLevel { get; set; }

        /// <summary>The recommended light level for this activity.</summary>
        public int activityLightLevel { get; set; }

        /// <summary>The hash identifier for the Destination on which this Activity is played. Use it to look up the DestinyDestinationDefinition for human readable info about the destination. A Destination can be thought of as a more specific location than a "Place". For instance, if the "Place" is Earth, the "Destination" would be a specific city or region on Earth.</summary>
        public uint destinationHash { get; set; }

        /// <summary>The hash identifier for the "Place" on which this Activity is played. Use it to look up the DestinyPlaceDefinition for human readable info about the Place. A Place is the largest-scoped concept for location information. For instance, if the "Place" is Earth, the "Destination" would be a specific city or region on Earth.</summary>
        public uint placeHash { get; set; }

        /// <summary>The hash identifier for the Activity Type of this Activity. You may use it to look up the DestinyActivityTypeDefinition for human readable info, but be forewarned: Playlists and many PVP Map Activities will map to generic Activity Types. You'll have to use your knowledge of the Activity Mode being played to get more specific information about what the user is playing.</summary>
        public uint activityTypeHash { get; set; }

        /// <summary>The difficulty tier of the activity.</summary>
        public int tier { get; set; }

        /// <summary>When Activities are completed, we generate a "Post-Game Carnage Report", or PGCR, with details about what happened in that activity (how many kills someone got, which team won, etc...) We use this image as the background when displaying PGCR information, and often use it when we refer to the Activity in general.</summary>
        public string pgcrImage { get; set; }

        /// <summary>The expected possible rewards for the activity. These rewards may or may not be accessible for an individual player based on their character state, the account state, and even the game's state overall. But it is a useful reference for possible rewards you can earn in the activity. These match up to rewards displayed when you hover over the Activity in the in-game Director, and often refer to Placeholder or "Dummy" items: items that tell you what you can earn in vague terms rather than what you'll specifically be earning (partly because the game doesn't even know what you'll earn specifically until you roll for it at the end)</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityRewardDefinition> rewards { get; set; }

        /// <summary>Activities can have Modifiers, as defined in DestinyActivityModifierDefinition. These are references to the modifiers that *can* be applied to that activity, along with data that we use to determine if that modifier is actually active at any given point in time.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityModifierReferenceDefinition> modifiers { get; set; }

        /// <summary>If True, this Activity is actually a Playlist that refers to multiple possible specific Activities and Activity Modes. For instance, a Crucible Playlist may have references to multiple Activities (Maps) with multiple Activity Modes (specific PvP gameplay modes). If this is true, refer to the playlistItems property for the specific entries in the playlist.</summary>
        public bool isPlaylist { get; set; }

        /// <summary>An activity can have many Challenges, of which any subset of them may be active for play at any given period of time. This gives the information about the challenges and data that we use to understand when they're active and what rewards they provide. Sadly, at the moment there's no central definition for challenges: much like "Skulls" were in Destiny 1, these are defined on individual activities and there can be many duplicates/near duplicates across the Destiny 2 ecosystem. I have it in mind to centralize these in a future revision of the API, but we are out of time.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityChallengeDefinition> challenges { get; set; }

        /// <summary>If there are status strings related to the activity and based on internal state of the game, account, or character, then this will be the definition of those strings and the states needed in order for the strings to be shown.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityUnlockStringDefinition> optionalUnlockStrings { get; set; }

        /// <summary>Represents all of the possible activities that could be played in the Playlist, along with information that we can use to determine if they are active at the present time.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityPlaylistItemDefinition> playlistItems { get; set; }

        /// <summary>Unfortunately, in practice this is almost never populated. In theory, this is supposed to tell which Activity Graph to show if you bring up the director while in this activity.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityGraphListEntryDefinition> activityGraphList { get; set; }

        /// <summary>This block of data provides information about the Activity's matchmaking attributes: how many people can join and such.</summary>
        public Destiny.Definitions.DestinyActivityMatchmakingBlockDefinition matchmaking { get; set; }

        /// <summary>This block of data, if it exists, provides information about the guided game experience and restrictions for this activity. If it doesn't exist, the game is not able to be played as a guided game.</summary>
        public Destiny.Definitions.DestinyActivityGuidedBlockDefinition guidedGame { get; set; }

        /// <summary>If this activity had an activity mode directly defined on it, this will be the hash of that mode.</summary>
        public uint? directActivityModeHash { get; set; }

        /// <summary>If the activity had an activity mode directly defined on it, this will be the enum value of that mode.</summary>
        public int? directActivityModeType { get; set; }

        /// <summary>The set of all possible loadout requirements that could be active for this activity. Only one will be active at any given time, and you can discover which one through activity-associated data such as Milestones that have activity info on them.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityLoadoutRequirementSet> loadouts { get; set; }

        /// <summary>The hash identifiers for Activity Modes relevant to this activity.  Note that if this is a playlist, the specific playlist entry chosen will determine the actual activity modes that end up being relevant.</summary>
        public IEnumerable<uint> activityModeHashes { get; set; }

        /// <summary>The activity modes - if any - in enum form. Because we can't seem to escape the enums.</summary>
        public IEnumerable<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> activityModeTypes { get; set; }

        /// <summary>If true, this activity is a PVP activity or playlist.</summary>
        public bool isPvP { get; set; }

        /// <summary>The list of phases or points of entry into an activity, along with information we can use to determine their gating and availability.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityInsertionPointDefinition> insertionPoints { get; set; }

        /// <summary>A list of location mappings that are affected by this activity. Pulled out of DestinyLocationDefinitions for our/your lookup convenience.</summary>
        public IEnumerable<Destiny.Constants.DestinyEnvironmentLocationMapping> activityLocationMappings { get; set; }
    }

    /// <summary>
    /// Activities can refer to one or more sets of tooltip-friendly reward data. These are the definitions for those tooltip friendly rewards.
    /// </summary>
    public class DestinyActivityRewardDefinition
    {
        /// <summary>The header for the reward set, if any.</summary>
        public string rewardText { get; set; }

        /// <summary>
        /// The "Items provided" in the reward. This is almost always a pointer to a DestinyInventoryItemDefintion for an item that you can't actually earn in-game, but that has name/description/icon information for the vague concept of the rewards you will receive. This is because the actual reward generation is non-deterministic and extremely complicated, so the best the game can do is tell you what you'll get in vague terms. And so too shall we.
        /// Interesting trivia: you actually *do* earn these items when you complete the activity. They go into a single-slot bucket on your profile, which is how you see the pop-ups of these rewards when you complete an activity that match these "dummy" items. You can even see them if you look at the last one you earned in your profile-level inventory through the BNet API! Who said reading documentation is a waste of time?
        /// </summary>
        public IEnumerable<Destiny.DestinyItemQuantity> rewardItems { get; set; }
    }

    /// <summary>
    /// A reference to an Activity Modifier from another entity, such as an Activity (for now, just Activities).
    /// This defines some
    /// </summary>
    public class DestinyActivityModifierReferenceDefinition
    {
        /// <summary>The hash identifier for the DestinyActivityModifierDefinition referenced by this activity.</summary>
        public uint activityModifierHash { get; set; }
    }

    /// <summary>
    /// Represents a reference to a Challenge, which for now is just an Objective.
    /// </summary>
    public class DestinyActivityChallengeDefinition
    {
        /// <summary>The hash for the Objective that matches this challenge. Use it to look up the DestinyObjectiveDefinition.</summary>
        public uint objectiveHash { get; set; }

        /// <summary>
        /// The rewards as they're represented in the UI. Note that they generally link to "dummy" items that give a summary of rewards rather than direct, real items themselves.
        /// If the quantity is 0, don't show the quantity.
        /// </summary>
        public IEnumerable<Destiny.DestinyItemQuantity> dummyRewards { get; set; }
    }

    /// <summary>
    /// Defines an "Objective".
    /// An objective is a specific task you should accomplish in the game. These are referred to by:
    /// - Quest Steps (which are DestinyInventoryItemDefinition entities with Objectives)
    /// - Challenges (which are Objectives defined on an DestinyActivityDefintion)
    /// - Milestones (which refer to Objectives that are defined on both Quest Steps and Activities)
    /// - Anything else that the designers decide to do later.
    /// Objectives have progress, a notion of having been Completed, human readable data describing the task to be accomplished, and a lot of optional tack-on data that can enhance the information provided about the task.
    /// </summary>
    public class DestinyObjectiveDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>Ideally, this should tell you what your task is. I'm not going to lie to you though. Sometimes this doesn't have useful information at all. Which sucks, but there's nothing either of us can do about it.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The value that the unlock value defined in unlockValueHash must reach in order for the objective to be considered Completed. Used in calculating progress and completion status.</summary>
        public int completionValue { get; set; }

        /// <summary>A shortcut for determining the most restrictive gating that this Objective is set to use. This includes both the dynamic determination of progress and of completion values. See the DestinyGatingScope enum's documentation for more details.</summary>
        public Destiny.DestinyGatingScope scope { get; set; }

        /// <summary>OPTIONAL: a hash identifier for the location at which this objective must be accomplished, if there is a location defined. Look up the DestinyLocationDefinition for this hash for that additional location info.</summary>
        public uint locationHash { get; set; }

        /// <summary>If true, the value is allowed to go negative.</summary>
        public bool allowNegativeValue { get; set; }

        /// <summary>
        /// If true, you can effectively "un-complete" this objective if you lose progress after crossing the completion threshold.
        /// If False, once you complete the task it will remain completed forever by locking the value.
        /// </summary>
        public bool allowValueChangeWhenCompleted { get; set; }

        /// <summary>
        /// If true, completion means having an unlock value less than or equal to the completionValue.
        /// If False, completion means having an unlock value greater than or equal to the completionValue.
        /// </summary>
        public bool isCountingDownward { get; set; }

        /// <summary>The UI style applied to the objective. It's an enum, take a look at DestinyUnlockValueUIStyle for details of the possible styles. Use this info as you wish to customize your UI.</summary>
        public Destiny.DestinyUnlockValueUIStyle valueStyle { get; set; }

        /// <summary>Text to describe the progress bar.</summary>
        public string progressDescription { get; set; }

        /// <summary>If this objective enables Perks intrinsically, the conditions for that enabling are defined here.</summary>
        public Destiny.Definitions.DestinyObjectivePerkEntryDefinition perks { get; set; }

        /// <summary>If this objective enables modifications on a player's stats intrinsically, the conditions are defined here.</summary>
        public Destiny.Definitions.DestinyObjectiveStatEntryDefinition stats { get; set; }

        /// <summary>If nonzero, this is the minimum value at which the objective's progression should be shown. Otherwise, don't show it yet.</summary>
        public int minimumVisibilityThreshold { get; set; }

        /// <summary>If True, the progress will continue even beyond the point where the objective met its minimum completion requirements. Your UI will have to accommodate it.</summary>
        public bool allowOvercompletion { get; set; }

        /// <summary>If True, you should continue showing the progression value in the UI after it's complete. I mean, we already do that in BNet anyways, but if you want to be better behaved than us you could honor this flag.</summary>
        public bool showValueOnComplete { get; set; }

        /// <summary>The style to use when the objective is completed.</summary>
        public Destiny.DestinyUnlockValueUIStyle completedValueStyle { get; set; }

        /// <summary>The style to use when the objective is still in progress.</summary>
        public Destiny.DestinyUnlockValueUIStyle inProgressValueStyle { get; set; }
    }

    /// <summary>
    /// Defines the conditions under which an intrinsic perk is applied while participating in an Objective.
    /// These perks will generally not be benefit-granting perks, but rather a perk that modifies gameplay in some interesting way.
    /// </summary>
    public class DestinyObjectivePerkEntryDefinition
    {
        /// <summary>The hash identifier of the DestinySandboxPerkDefinition that will be applied to the character.</summary>
        public uint perkHash { get; set; }

        /// <summary>An enumeration indicating whether it will be applied as long as the Objective is active, when it's completed, or until it's completed.</summary>
        public Destiny.DestinyObjectiveGrantStyle style { get; set; }
    }

    /// <summary>
    /// Perks are modifiers to a character or item that can be applied situationally.
    /// - Perks determine a weapons' damage type.
    /// - Perks put the Mods in Modifiers (they are literally the entity that bestows the Sandbox benefit for whatever fluff text about the modifier in the Socket, Plug or Talent Node)
    /// - Perks are applied for unique alterations of state in Objectives
    /// Anyways, I'm sure you can see why perks are so interesting.
    /// What Perks often don't have is human readable information, so we attempt to reverse engineer that by pulling that data from places that uniquely refer to these perks: namely, Talent Nodes and Plugs. That only gives us a subset of perks that are human readable, but those perks are the ones people generally care about anyways. The others are left as a mystery, their true purpose mostly unknown and undocumented.
    /// </summary>
    public class DestinySandboxPerkDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>These display properties are by no means guaranteed to be populated. Usually when it is, it's only because we back-filled them with the displayProperties of some Talent Node or Plug item that happened to be uniquely providing that perk.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The string identifier for the perk.</summary>
        public string perkIdentifier { get; set; }

        /// <summary>If true, you can actually show the perk in the UI. Otherwise, it doesn't have useful player-facing information.</summary>
        public bool isDisplayable { get; set; }

        /// <summary>
        /// If this perk grants a damage type to a weapon, the damage type will be defined here.
        /// Unless you have a compelling reason to use this enum value, use the damageTypeHash instead to look up the actual DestinyDamageTypeDefinition.
        /// </summary>
        public Destiny.DamageType damageType { get; set; }

        /// <summary>
        /// The hash identifier for looking up the DestinyDamageTypeDefinition, if this perk has a damage type.
        /// This is preferred over using the damageType enumeration value, which has been left purely because it is occasionally convenient.
        /// </summary>
        public uint? damageTypeHash { get; set; }

        /// <summary>
        /// An old holdover from the original Armory, this was an attempt to group perks by functionality.
        /// It is as yet unpopulated, and there will be quite a bit of work needed to restore it to its former working order.
        /// </summary>
        public Destiny.Definitions.DestinyTalentNodeStepGroups perkGroups { get; set; }
    }

    /// <summary>
    /// These properties are an attempt to categorize talent node steps by certain common properties. See the related enumerations for the type of properties being categorized.
    /// </summary>
    public class DestinyTalentNodeStepGroups
    {
        public Destiny.Definitions.DestinyTalentNodeStepWeaponPerformances weaponPerformance { get; set; }

        public Destiny.Definitions.DestinyTalentNodeStepImpactEffects impactEffects { get; set; }

        public Destiny.Definitions.DestinyTalentNodeStepGuardianAttributes guardianAttributes { get; set; }

        public Destiny.Definitions.DestinyTalentNodeStepLightAbilities lightAbilities { get; set; }

        public Destiny.Definitions.DestinyTalentNodeStepDamageTypes damageTypes { get; set; }
    }

    [Flags]
    public enum DestinyTalentNodeStepWeaponPerformances
    {
        None = 0,

        RateOfFire = 1,

        Damage = 2,

        Accuracy = 4,

        Range = 8,

        Zoom = 16,

        Recoil = 32,

        Ready = 64,

        Reload = 128,

        HairTrigger = 256,

        AmmoAndMagazine = 512,

        TrackingAndDetonation = 1024,

        ShotgunSpread = 2048,

        ChargeTime = 4096,

        All = 8191
    }

    [Flags]
    public enum DestinyTalentNodeStepImpactEffects
    {
        None = 0,

        ArmorPiercing = 1,

        Ricochet = 2,

        Flinch = 4,

        CollateralDamage = 8,

        Disorient = 16,

        HighlightTarget = 32,

        All = 63
    }

    [Flags]
    public enum DestinyTalentNodeStepGuardianAttributes
    {
        None = 0,

        Stats = 1,

        Shields = 2,

        Health = 4,

        Revive = 8,

        AimUnderFire = 16,

        Radar = 32,

        Invisibility = 64,

        Reputations = 128,

        All = 255
    }

    [Flags]
    public enum DestinyTalentNodeStepLightAbilities
    {
        None = 0,

        Grenades = 1,

        Melee = 2,

        MovementModes = 4,

        Orbs = 8,

        SuperEnergy = 16,

        SuperMods = 32,

        All = 63
    }

    [Flags]
    public enum DestinyTalentNodeStepDamageTypes
    {
        None = 0,

        Kinetic = 1,

        Arc = 2,

        Solar = 4,

        Void = 8,

        All = 15
    }

    /// <summary>
    /// Defines the conditions under which stat modifications will be applied to a Character while participating in an objective.
    /// </summary>
    public class DestinyObjectiveStatEntryDefinition
    {
        /// <summary>The stat being modified, and the value used.</summary>
        public Destiny.Definitions.DestinyItemInvestmentStatDefinition stat { get; set; }

        /// <summary>Whether it will be applied as long as the objective is active, when it's completed, or until it's completed.</summary>
        public Destiny.DestinyObjectiveGrantStyle style { get; set; }
    }

    /// <summary>
    /// Represents a "raw" investment stat, before calculated stats are calculated and before any DestinyStatGroupDefinition is applied to transform the stat into something closer to what you see in-game.
    /// Because these won't match what you see in-game, consider carefully whether you really want to use these stats. I have left them in case someone can do something useful or interesting with the pre-processed statistics.
    /// </summary>
    public class DestinyItemInvestmentStatDefinition
    {
        /// <summary>The hash identifier for the DestinyStatDefinition defining this stat.</summary>
        public uint statTypeHash { get; set; }

        /// <summary>The raw "Investment" value for the stat, before transformations are performed to turn this raw stat into stats that are displayed in the game UI.</summary>
        public int value { get; set; }

        /// <summary>If this is true, the stat will only be applied on the item in certain game state conditions, and we can't know statically whether or not this stat will be applied. Check the "live" API data instead for whether this value is being applied on a specific instance of the item in question, and you can use this to decide whether you want to show the stat on the generic view of the item, or whether you want to show some kind of caveat or warning about the stat value being conditional on game state.</summary>
        public bool isConditionallyActive { get; set; }
    }

    /// <summary>
    /// A "Location" is a sort of shortcut for referring to a specific combination of Activity, Destination, Place, and even Bubble or NavPoint within a space.
    /// Most of this data isn't intrinsically useful to us, but Objectives refer to locations, and through that we can at least infer the Activity, Destination, and Place being referred to by the Objective.
    /// </summary>
    public class DestinyLocationDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>If the location has a Vendor on it, this is the hash identifier for that Vendor. Look them up with DestinyVendorDefinition.</summary>
        public uint vendorHash { get; set; }

        /// <summary>A Location may refer to different specific spots in the world based on the world's current state. This is a list of those potential spots, and the data we can use at runtime to determine which one of the spots is the currently valid one.</summary>
        public IEnumerable<Destiny.Definitions.DestinyLocationReleaseDefinition> locationReleases { get; set; }
    }

    /// <summary>
    /// A specific "spot" referred to by a location. Only one of these can be active at a time for a given Location.
    /// </summary>
    public class DestinyLocationReleaseDefinition
    {
        /// <summary>Sadly, these don't appear to be populated anymore (ever?)</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        public string smallTransparentIcon { get; set; }

        public string mapIcon { get; set; }

        public string largeTransparentIcon { get; set; }

        /// <summary>If we had map information, this spawnPoint would be interesting. But sadly, we don't have that info.</summary>
        public uint spawnPoint { get; set; }

        /// <summary>The Destination being pointed to by this location.</summary>
        public uint destinationHash { get; set; }

        /// <summary>The Activity being pointed to by this location.</summary>
        public uint activityHash { get; set; }

        /// <summary>The Activity Graph being pointed to by this location.</summary>
        public uint activityGraphHash { get; set; }

        /// <summary>The Activity Graph Node being pointed to by this location. (Remember that Activity Graph Node hashes are only unique within an Activity Graph: so use the combination to find the node being spoken of)</summary>
        public uint activityGraphNodeHash { get; set; }

        /// <summary>The Activity Bubble within the Destination. Look this up in the DestinyDestinationDefinition's bubbles and bubbleSettings properties.</summary>
        public uint activityBubbleName { get; set; }

        /// <summary>If we had map information, this would tell us something cool about the path this location wants you to take. I wish we had map information.</summary>
        public uint activityPathBundle { get; set; }

        /// <summary>If we had map information, this would tell us about path information related to destination on the map. Sad. Maybe you can do something cool with it. Go to town man.</summary>
        public uint activityPathDestination { get; set; }

        /// <summary>The type of Nav Point that this represents. See the enumeration for more info.</summary>
        public Destiny.DestinyActivityNavPointType navPointType { get; set; }

        /// <summary>Looks like it should be the position on the map, but sadly it does not look populated... yet?</summary>
        public IEnumerable<int> worldPosition { get; set; }
    }

    /// <summary>
    /// Represents a status string that could be conditionally displayed about an activity. Note that externally, you can only see the strings themselves. Internally we combine this information with server state to determine which strings should be shown.
    /// </summary>
    public class DestinyActivityUnlockStringDefinition
    {
        /// <summary>The string to be displayed if the conditions are met.</summary>
        public string displayString { get; set; }
    }

    /// <summary>
    /// If the activity is a playlist, this is the definition for a specific entry in the playlist: a single possible combination of Activity and Activity Mode that can be chosen.
    /// </summary>
    public class DestinyActivityPlaylistItemDefinition
    {
        /// <summary>The hash identifier of the Activity that can be played. Use it to look up the DestinyActivityDefinition.</summary>
        public uint activityHash { get; set; }

        /// <summary>If this playlist entry had an activity mode directly defined on it, this will be the hash of that mode.</summary>
        public uint? directActivityModeHash { get; set; }

        /// <summary>If the playlist entry had an activity mode directly defined on it, this will be the enum value of that mode.</summary>
        public int? directActivityModeType { get; set; }

        /// <summary>The hash identifiers for Activity Modes relevant to this entry.</summary>
        public IEnumerable<uint> activityModeHashes { get; set; }

        /// <summary>The activity modes - if any - in enum form. Because we can't seem to escape the enums.</summary>
        public IEnumerable<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> activityModeTypes { get; set; }
    }

    /// <summary>
    /// This definition represents an "Activity Mode" as it exists in the Historical Stats endpoints. An individual Activity Mode represents a collection of activities that are played in a certain way. For example, Nightfall Strikes are part of a "Nightfall" activity mode, and any activities played as the PVP mode "Clash" are part of the "Clash activity mode.
    /// Activity modes are nested under each other in a hierarchy, so that if you ask for - for example - "AllPvP", you will get any PVP activities that the user has played, regardless of what specific PVP mode was being played.
    /// </summary>
    public class DestinyActivityModeDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>If this activity mode has a related PGCR image, this will be the path to said image.</summary>
        public string pgcrImage { get; set; }

        /// <summary>The Enumeration value for this Activity Mode. Pass this identifier into Stats endpoints to get aggregate stats for this mode.</summary>
        public Destiny.HistoricalStats.Definitions.DestinyActivityModeType modeType { get; set; }

        /// <summary>The type of play being performed in broad terms (PVP, PVE)</summary>
        public Destiny.DestinyActivityModeCategory activityModeCategory { get; set; }

        /// <summary>
        /// If True, this mode has oppositional teams fighting against each other rather than "Free-For-All" or Co-operative modes of play.
        /// Note that Aggregate modes are never marked as team based, even if they happen to be team based at the moment. At any time, an aggregate whose subordinates are only team based could be changed so that one or more aren't team based, and then this boolean won't make much sense (the aggregation would become "sometimes team based"). Let's not deal with that right now.
        /// </summary>
        public bool isTeamBased { get; set; }

        /// <summary>If true, this mode is an aggregation of other, more specific modes rather than being a mode in itself. This includes modes that group Features/Events rather than Gameplay, such as Trials of The Nine: Trials of the Nine being an Event that is interesting to see aggregate data for, but when you play the activities within Trials of the Nine they are more specific activity modes such as Clash.</summary>
        public bool isAggregateMode { get; set; }

        /// <summary>The hash identifiers of the DestinyActivityModeDefinitions that represent all of the "parent" modes for this mode. For instance, the Nightfall Mode is also a member of AllStrikes and AllPvE.</summary>
        public IEnumerable<uint> parentHashes { get; set; }

        /// <summary>A Friendly identifier you can use for referring to this Activity Mode. We really only used this in our URLs, so... you know, take that for whatever it's worth.</summary>
        public string friendlyName { get; set; }

        /// <summary>If this exists, the mode has specific Activities (referred to by the Key) that should instead map to other Activity Modes when they are played. This was useful in D1 for Private Matches, where we wanted to have Private Matches as an activity mode while still referring to the specific mode being played.</summary>
        public Dictionary<uint, Destiny.HistoricalStats.Definitions.DestinyActivityModeType> activityModeMappings { get; set; }

        /// <summary>If FALSE, we want to ignore this type when we're showing activity modes in BNet UI. It will still be returned in case 3rd parties want to use it for any purpose.</summary>
        public bool display { get; set; }

        /// <summary>The relative ordering of activity modes.</summary>
        public int order { get; set; }
    }

    /// <summary>
    /// Information about matchmaking and party size for the activity.
    /// </summary>
    public class DestinyActivityMatchmakingBlockDefinition
    {
        /// <summary>If TRUE, the activity is matchmade. Otherwise, it requires explicit forming of a party.</summary>
        public bool isMatchmade { get; set; }

        /// <summary>The minimum # of people in the fireteam for the activity to launch.</summary>
        public int minParty { get; set; }

        /// <summary>The maximum # of people allowed in a Fireteam.</summary>
        public int maxParty { get; set; }

        /// <summary>The maximum # of people allowed across all teams in the activity.</summary>
        public int maxPlayers { get; set; }

        /// <summary>If true, you have to Solemnly Swear to be up to Nothing But Good(tm) to play.</summary>
        public bool requiresGuardianOath { get; set; }
    }

    /// <summary>
    /// Guided Game information for this activity.
    /// </summary>
    public class DestinyActivityGuidedBlockDefinition
    {
        /// <summary>The maximum amount of people that can be in the waiting lobby.</summary>
        public int guidedMaxLobbySize { get; set; }

        /// <summary>The minimum amount of people that can be in the waiting lobby.</summary>
        public int guidedMinLobbySize { get; set; }

        /// <summary>If -1, the guided group cannot be disbanded. Otherwise, take the total # of players in the activity and subtract this number: that is the total # of votes needed for the guided group to disband.</summary>
        public int guidedDisbandCount { get; set; }
    }

    public class DestinyActivityLoadoutRequirementSet
    {
        /// <summary>The set of requirements that will be applied on the activity if this requirement set is active.</summary>
        public IEnumerable<Destiny.Definitions.DestinyActivityLoadoutRequirement> requirements { get; set; }
    }

    public class DestinyActivityLoadoutRequirement
    {
        public uint equipmentSlotHash { get; set; }

        public IEnumerable<uint> allowedEquippedItemHashes { get; set; }

        public IEnumerable<Destiny.DestinyItemSubType> allowedWeaponSubTypes { get; set; }
    }

    /// <summary>
    /// A point of entry into an activity, gated by an unlock flag and with some more-or-less useless (for our purposes) phase information. I'm including it in case we end up being able to bolt more useful information onto it in the future.
    /// UPDATE: Turns out this information isn't actually useless, and is in fact actually useful for people. Who would have thought? We still don't have localized info for it, but at least this will help people when they're looking at phase indexes in stats data, or when they want to know what phases have been completed on a weekly achievement.
    /// </summary>
    public class DestinyActivityInsertionPointDefinition
    {
        /// <summary>A unique hash value representing the phase. This can be useful for, for example, comparing how different instances of Raids have phases in different orders!</summary>
        public uint phaseHash { get; set; }
    }

    /// <summary>
    /// Okay, so Activities (DestinyActivityDefinition) take place in Destinations (DestinyDestinationDefinition). Destinations are part of larger locations known as Places (you're reading its documentation right now).
    /// Places are more on the planetary scale, like "Earth" and "Your Mom."
    /// </summary>
    public class DestinyPlaceDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    /// <summary>
    /// The definition for an Activity Type.
    /// In Destiny 2, an Activity Type represents a conceptual categorization of Activities.
    /// These are most commonly used in the game for the subtitle under Activities, but BNet uses them extensively to identify and group activities by their common properties.
    /// Unfortunately, there has been a movement away from providing the richer data in Destiny 2 that we used to get in Destiny 1 for Activity Types. For instance, Nightfalls are grouped under the same Activity Type as regular Strikes.
    /// For this reason, BNet will eventually migrate toward Activity Modes as a better indicator of activity category. But for the time being, it is still referred to in many places across our codebase.
    /// </summary>
    public class DestinyActivityTypeDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    /// <summary>
    /// Where the sausage gets made. Unlock Expressions are the foundation of the game's gating mechanics and investment-related restrictions. They can test Unlock Flags and Unlock Values for certain states, using a sufficient amount of logical operators such that unlock expressions are effectively Turing complete.
    /// Use UnlockExpressionParser to evaluate expressions using an IUnlockContext parsed from Babel.
    /// </summary>
    public class DestinyUnlockExpressionDefinition
    {
        /// <summary>A shortcut for determining the most restrictive gating that this expression performs. See the DestinyGatingScope enum's documentation for more details.</summary>
        public Destiny.DestinyGatingScope scope { get; set; }
    }

    /// <summary>
    /// Human readable data about the bubble. Combine with DestinyBubbleDefinition - see DestinyDestinationDefinition.bubbleSettings for more information.
    /// DEPRECATED - Just use bubbles.
    /// </summary>
    public class DestinyDestinationBubbleSettingDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    /// <summary>
    /// Basic identifying data about the bubble. Combine with DestinyDestinationBubbleSettingDefinition - see DestinyDestinationDefinition.bubbleSettings for more information.
    /// </summary>
    public class DestinyBubbleDefinition
    {
        /// <summary>The identifier for the bubble: only guaranteed to be unique within the Destination.</summary>
        public uint hash { get; set; }

        /// <summary>The display properties of this bubble, so you don't have to look them up in a separate list anymore.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    public class DestinyVendorGroupReference
    {
        /// <summary>The DestinyVendorGroupDefinition to which this Vendor can belong.</summary>
        public uint vendorGroupHash { get; set; }
    }

    /// <summary>
    /// BNet attempts to group vendors into similar collections. These groups aren't technically game canonical, but they are helpful for filtering vendors or showing them organized into a clean view on a webpage or app.
    /// These definitions represent the groups we've built. Unlike in Destiny 1, a Vendors' group may change dynamically as the game state changes: thus, you will want to check DestinyVendorComponent responses to find a vendor's currently active Group (if you care).
    /// Using this will let you group your vendors in your UI in a similar manner to how we will do grouping in the Companion.
    /// </summary>
    public class DestinyVendorGroupDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>The recommended order in which to render the groups, Ascending order.</summary>
        public int order { get; set; }

        /// <summary>For now, a group just has a name.</summary>
        public string categoryName { get; set; }
    }

    /// <summary>
    /// These definitions represent Factions in the game. Factions have ended up unilaterally being related to Vendors that represent them, but that need not necessarily be the case.
    /// A Faction is really just an entity that has a related progression for which a character can gain experience. In Destiny 1, Dead Orbit was an example of a Faction: there happens to be a Vendor that represents Dead Orbit (and indeed, DestinyVendorDefinition.factionHash defines to this relationship), but Dead Orbit could theoretically exist without the Vendor that provides rewards.
    /// </summary>
    public class DestinyFactionDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The hash identifier for the DestinyProgressionDefinition that indicates the character's relationship with this faction in terms of experience and levels.</summary>
        public uint progressionHash { get; set; }

        /// <summary>The faction token item hashes, and their respective progression values.</summary>
        public Dictionary<uint, uint> tokenValues { get; set; }

        /// <summary>The faction reward item hash, usually an engram.</summary>
        public uint rewardItemHash { get; set; }

        /// <summary>The faction reward vendor hash, used for faction engram previews.</summary>
        public uint rewardVendorHash { get; set; }

        /// <summary>List of vendors that are associated with this faction. The last vendor that passes the unlock flag checks is the one that should be shown.</summary>
        public IEnumerable<Destiny.Definitions.DestinyFactionVendorDefinition> vendors { get; set; }
    }

    /// <summary>
    /// These definitions represent faction vendors at different points in the game.
    /// A single faction may contain multiple vendors, or the same vendor available at two different locations.
    /// </summary>
    public class DestinyFactionVendorDefinition
    {
        /// <summary>The faction vendor hash.</summary>
        public uint vendorHash { get; set; }

        /// <summary>The hash identifier for a Destination at which this vendor may be located. Each destination where a Vendor may exist will only ever have a single entry.</summary>
        public uint destinationHash { get; set; }

        /// <summary>The relative path to the background image representing this Vendor at this location, for use in a banner.</summary>
        public string backgroundImagePath { get; set; }
    }

    /// <summary>
    /// An item's "Quality" determines its calculated stats. The Level at which the item spawns is combined with its "qualityLevel" along with some additional calculations to determine the value of those stats.
    /// In Destiny 2, most items don't have default item levels and quality, making this property less useful: these apparently are almost always determined by the complex mechanisms of the Reward system rather than statically. They are still provided here in case they are still useful for people. This also contains some information about Infusion.
    /// </summary>
    public class DestinyItemQualityBlockDefinition
    {
        /// <summary>
        /// The "base" defined level of an item. This is a list because, in theory, each Expansion could define its own base level for an item.
        /// In practice, not only was that never done in Destiny 1, but now this isn't even populated at all. When it's not populated, the level at which it spawns has to be inferred by Reward information, of which BNet receives an imperfect view and will only be reliable on instanced data as a result.
        /// </summary>
        public IEnumerable<int> itemLevels { get; set; }

        /// <summary>qualityLevel is used in combination with the item's level to calculate stats like Attack and Defense. It plays a role in that calculation, but not nearly as large as itemLevel does.</summary>
        public int qualityLevel { get; set; }

        /// <summary>
        /// The string identifier for this item's "infusability", if any.
        /// Items that match the same infusionCategoryName are allowed to infuse with each other.
        /// DEPRECATED: Items can now have multiple infusion categories. Please use infusionCategoryHashes instead.
        /// </summary>
        public string infusionCategoryName { get; set; }

        /// <summary>
        /// The hash identifier for the infusion. It does not map to a Definition entity.
        /// DEPRECATED: Items can now have multiple infusion categories. Please use infusionCategoryHashes instead.
        /// </summary>
        public uint infusionCategoryHash { get; set; }

        /// <summary>If any one of these hashes matches any value in another item's infusionCategoryHashes, the two can infuse with each other.</summary>
        public IEnumerable<uint> infusionCategoryHashes { get; set; }

        /// <summary>An item can refer to pre-set level requirements. They are defined in DestinyProgressionLevelRequirementDefinition, and you can use this hash to find the appropriate definition.</summary>
        public uint progressionLevelRequirementHash { get; set; }

        /// <summary>The latest version available for this item.</summary>
        public uint currentVersion { get; set; }

        /// <summary>The list of versions available for this item.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemVersionDefinition> versions { get; set; }

        /// <summary>Icon overlays to denote the item version and power cap status.</summary>
        public IEnumerable<string> displayVersionWatermarkIcons { get; set; }
    }

    /// <summary>
    /// The version definition currently just holds a reference to the power cap.
    /// </summary>
    public class DestinyItemVersionDefinition
    {
        /// <summary>A reference to the power cap for this item version.</summary>
        public uint powerCapHash { get; set; }
    }

    /// <summary>
    /// This defines an item's "Value". Unfortunately, this appears to be used in different ways depending on the way that the item itself is used.
    /// For items being sold at a Vendor, this is the default "sale price" of the item. These days, the vendor itself almost always sets the price, but it still possible for the price to fall back to this value. For quests, it is a preview of rewards you can gain by completing the quest. For dummy items, if the itemValue refers to an Emblem, it is the emblem that should be shown as the reward. (jeez louise)
    /// It will likely be used in a number of other ways in the future, it appears to be a bucket where they put arbitrary items and quantities into the item.
    /// </summary>
    public class DestinyItemValueBlockDefinition
    {
        /// <summary>References to the items that make up this item's "value", and the quantity.</summary>
        public IEnumerable<Destiny.DestinyItemQuantity> itemValue { get; set; }

        /// <summary>If there's a localized text description of the value provided, this will be said description.</summary>
        public string valueDescription { get; set; }
    }

    /// <summary>
    /// Data about an item's "sources": ways that the item can be obtained.
    /// </summary>
    public class DestinyItemSourceBlockDefinition
    {
        /// <summary>The list of hash identifiers for Reward Sources that hint where the item can be found (DestinyRewardSourceDefinition).</summary>
        public IEnumerable<uint> sourceHashes { get; set; }

        /// <summary>A collection of details about the stats that were computed for the ways we found that the item could be spawned.</summary>
        public IEnumerable<Destiny.Definitions.Sources.DestinyItemSourceDefinition> sources { get; set; }

        /// <summary>If we found that this item is exclusive to a specific platform, this will be set to the BungieMembershipType enumeration that matches that platform.</summary>
        public BungieMembershipType exclusive { get; set; }

        /// <summary>A denormalized reference back to vendors that potentially sell this item.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemVendorSourceReference> vendorSources { get; set; }
    }

    /// <summary>
    /// Represents a heuristically-determined "item source" according to Bungie.net. These item sources are non-canonical: we apply a combination of special configuration and often-fragile heuristics to attempt to discern whether an item should be part of a given "source," but we have known cases of false positives and negatives due to our imperfect heuristics.
    /// Still, they provide a decent approximation for people trying to figure out how an item can be obtained. DestinyInventoryItemDefinition refers to sources in the sourceDatas.sourceHashes property for all sources we determined the item could spawn from.
    /// An example in Destiny 1 of a Source would be "Nightfall". If an item has the "Nightfall" source associated with it, it's extremely likely that you can earn that item while playing Nightfall, either during play or as an after-completion reward.
    /// </summary>
    public class DestinyRewardSourceDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>Sources are grouped into categories: common ways that items are provided. I hope to see this expand in Destiny 2 once we have time to generate accurate reward source data.</summary>
        public Destiny.Definitions.DestinyRewardSourceCategory category { get; set; }
    }

    /// <summary>
    /// BNet's custom categorization of reward sources. We took a look at the existing ways that items could be spawned, and tried to make high-level categorizations of them. This needs to be re-evaluated for Destiny 2.
    /// </summary>
    public enum DestinyRewardSourceCategory
    {
        /// <summary>The source doesn't fit well into any of the other types.</summary>
        None = 0,

        /// <summary>The source is directly related to the rewards gained by playing an activity or set of activities. This currently includes Quests and other action in-game.</summary>
        Activity = 1,

        /// <summary>This source is directly related to items that Vendors sell.</summary>
        Vendor = 2,

        /// <summary>This source is a custom aggregation of items that can be earned in many ways, but that share some other property in common that is useful to share. For instance, in Destiny 1 we would make "Reward Sources" for every game expansion: that way, you could search reward sources to see what items became available with any given Expansion.</summary>
        Aggregate = 3
    }

    /// <summary>
    /// Represents that a vendor could sell this item, and provides a quick link to that vendor and sale item.
    ///  Note that we do not and cannot make a guarantee that the vendor will ever *actually* sell this item, only that the Vendor has a definition that indicates it *could* be sold.
    ///  Note also that a vendor may sell the same item in multiple "ways", which means there may be multiple vendorItemIndexes for a single Vendor hash.
    /// </summary>
    public class DestinyItemVendorSourceReference
    {
        /// <summary>The identifier for the vendor that may sell this item.</summary>
        public uint vendorHash { get; set; }

        /// <summary>The Vendor sale item indexes that represent the sale information for this item. The same vendor may sell an item in multiple "ways", hence why this is a list. (for instance, a weapon may be "sold" as a reward in a quest, for Glimmer, and for Masterwork Cores: each of those ways would be represented by a different vendor sale item with a different index)</summary>
        public IEnumerable<int> vendorItemIndexes { get; set; }
    }

    /// <summary>
    /// An item can have objectives on it. In practice, these are the exclusive purview of "Quest Step" items: DestinyInventoryItemDefinitions that represent a specific step in a Quest.
    /// Quest steps have 1:M objectives that we end up processing and returning in live data as DestinyQuestStatus data, and other useful information.
    /// </summary>
    public class DestinyItemObjectiveBlockDefinition
    {
        /// <summary>The hashes to Objectives (DestinyObjectiveDefinition) that are part of this Quest Step, in the order that they should be rendered.</summary>
        public IEnumerable<uint> objectiveHashes { get; set; }

        /// <summary>
        /// For every entry in objectiveHashes, there is a corresponding entry in this array at the same index. If the objective is meant to be associated with a specific DestinyActivityDefinition, there will be a valid hash at that index. Otherwise, it will be invalid (0).
        /// Rendered somewhat obsolete by perObjectiveDisplayProperties, which currently has much the same information but may end up with more info in the future.
        /// </summary>
        public IEnumerable<uint> displayActivityHashes { get; set; }

        /// <summary>If True, all objectives must be completed for the step to be completed. If False, any one objective can be completed for the step to be completed.</summary>
        public bool requireFullObjectiveCompletion { get; set; }

        /// <summary>The hash for the DestinyInventoryItemDefinition representing the Quest to which this Quest Step belongs.</summary>
        public uint questlineItemHash { get; set; }

        /// <summary>The localized string for narrative text related to this quest step, if any.</summary>
        public string narrative { get; set; }

        /// <summary>The localized string describing an action to be performed associated with the objectives, if any.</summary>
        public string objectiveVerbName { get; set; }

        /// <summary>The identifier for the type of quest being performed, if any. Not associated with any fixed definition, yet.</summary>
        public string questTypeIdentifier { get; set; }

        /// <summary>A hashed value for the questTypeIdentifier, because apparently I like to be redundant.</summary>
        public uint questTypeHash { get; set; }

        /// <summary>One entry per Objective on the item, it will have related display information.</summary>
        public IEnumerable<Destiny.Definitions.DestinyObjectiveDisplayProperties> perObjectiveDisplayProperties { get; set; }

        public bool displayAsStatTracker { get; set; }
    }

    public class DestinyObjectiveDisplayProperties
    {
        /// <summary>The activity associated with this objective in the context of this item, if any.</summary>
        public uint? activityHash { get; set; }

        /// <summary>If true, the game shows this objective on item preview screens.</summary>
        public bool displayOnItemPreviewScreen { get; set; }
    }

    /// <summary>
    /// The metrics available for display and selection on an item.
    /// </summary>
    public class DestinyItemMetricBlockDefinition
    {
        /// <summary>Hash identifiers for any DestinyPresentationNodeDefinition entry that can be used to list available metrics. Any metric listed directly below these nodes, or in any of these nodes' children will be made available for selection.</summary>
        public IEnumerable<uint> availableMetricCategoryNodeHashes { get; set; }
    }

    /// <summary>
    /// Represent a set of material requirements: Items that either need to be owned or need to be consumed in order to perform an action.
    /// A variety of other entities refer to these as gatekeepers and payments for actions that can be performed in game.
    /// </summary>
    public class DestinyMaterialRequirementSetDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>The list of all materials that are required.</summary>
        public IEnumerable<Destiny.Definitions.DestinyMaterialRequirement> materials { get; set; }
    }

    /// <summary>
    /// Many actions relating to items require you to expend materials: - Activating a talent node - Inserting a plug into a socket The items will refer to material requirements by a materialRequirementsHash in these cases, and this is the definition for those requirements in terms of the item required, how much of it is required and other interesting info. This is one of the rare/strange times where a single contract class is used both in definitions *and* in live data response contracts. I'm not sure yet whether I regret that.
    /// </summary>
    public class DestinyMaterialRequirement
    {
        /// <summary>The hash identifier of the material required. Use it to look up the material's DestinyInventoryItemDefinition.</summary>
        public uint itemHash { get; set; }

        /// <summary>If True, the material will be removed from the character's inventory when the action is performed.</summary>
        public bool deleteOnAction { get; set; }

        /// <summary>The amount of the material required.</summary>
        public int count { get; set; }

        /// <summary>If True, this requirement is "silent": don't bother showing it in a material requirements display. I mean, I'm not your mom: I'm not going to tell you you *can't* show it. But we won't show it in our UI.</summary>
        public bool omitFromRequirements { get; set; }
    }

    /// <summary>
    /// An Unlock Value is an internal integer value, stored on the server and used in a variety of ways, most frequently for the gating/requirement checks that the game performs across all of its main features. They can also be used as the storage data for mapped Progressions, Objectives, and other features that require storage of variable numeric values.
    /// </summary>
    public class DestinyUnlockValueDefinition : Destiny.Definitions.DestinyDefinition { }

    /// <summary>
    /// Gender is a social construct, and as such we have definitions for Genders. Right now there happens to only be two, but we'll see what the future holds.
    /// </summary>
    public class DestinyGenderDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>This is a quick reference enumeration for all of the currently defined Genders. We use the enumeration for quicker lookups in related data, like DestinyClassDefinition.genderedClassNames.</summary>
        public Destiny.DestinyGender genderType { get; set; }

        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    /// <summary>
    /// If an item has a related gearset, this is the list of items in that set, and an unlock expression that evaluates to a number representing the progress toward gearset completion (a very rare use for unlock expressions!)
    /// </summary>
    public class DestinyItemGearsetBlockDefinition
    {
        /// <summary>The maximum possible number of items that can be collected.</summary>
        public int trackingValueMax { get; set; }

        /// <summary>The list of hashes for items in the gearset. Use them to look up DestinyInventoryItemDefinition entries for the items in the set.</summary>
        public IEnumerable<uint> itemList { get; set; }
    }

    /// <summary>
    /// Some items are "sacks" - they can be "opened" to produce other items. This is information related to its sack status, mostly UI strings. Engrams are an example of items that are considered to be "Sacks".
    /// </summary>
    public class DestinyItemSackBlockDefinition
    {
        /// <summary>A description of what will happen when you open the sack. As far as I can tell, this is blank currently. Unknown whether it will eventually be populated with useful info.</summary>
        public string detailAction { get; set; }

        /// <summary>The localized name of the action being performed when you open the sack.</summary>
        public string openAction { get; set; }

        public int selectItemCount { get; set; }

        public string vendorSackType { get; set; }

        public bool openOnAcquire { get; set; }
    }

    /// <summary>
    /// If defined, the item has at least one socket.
    /// </summary>
    public class DestinyItemSocketBlockDefinition
    {
        /// <summary>This was supposed to be a string that would give per-item details about sockets. In practice, it turns out that all this ever has is the localized word "details". ... that's lame, but perhaps it will become something cool in the future.</summary>
        public string detail { get; set; }

        /// <summary>Each non-intrinsic (or mutable) socket on an item is defined here. Check inside for more info.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemSocketEntryDefinition> socketEntries { get; set; }

        /// <summary>Each intrinsic (or immutable/permanent) socket on an item is defined here, along with the plug that is permanently affixed to the socket.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemIntrinsicSocketEntryDefinition> intrinsicSockets { get; set; }

        /// <summary>A convenience property, that refers to the sockets in the "sockets" property, pre-grouped by category and ordered in the manner that they should be grouped in the UI. You could form this yourself with the existing data, but why would you want to? Enjoy life man.</summary>
        public IEnumerable<Destiny.Definitions.DestinyItemSocketCategoryDefinition> socketCategories { get; set; }
    }

    /// <summary>
    /// The definition information for a specific socket on an item. This will determine how the socket behaves in-game.
    /// </summary>
    public class DestinyItemSocketEntryDefinition
    {
        /// <summary>All sockets have a type, and this is the hash identifier for this particular type. Use it to look up the DestinySocketTypeDefinition: read there for more information on how socket types affect the behavior of the socket.</summary>
        public uint socketTypeHash { get; set; }

        /// <summary>If a valid hash, this is the hash identifier for the DestinyInventoryItemDefinition representing the Plug that will be initially inserted into the item on item creation. Otherwise, this Socket will either start without a plug inserted, or will have one randomly inserted.</summary>
        public uint singleInitialItemHash { get; set; }

        /// <summary>
        /// This is a list of pre-determined plugs that can *always* be plugged into this socket, without the character having the plug in their inventory.
        /// If this list is populated, you will not be allowed to plug an arbitrary item in the socket: you will only be able to choose from one of these reusable plugs.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyItemSocketEntryPlugItemDefinition> reusablePlugItems { get; set; }

        /// <summary>
        /// If this is true, then the socket will not be initialized with a plug if the item is purchased from a Vendor.
        /// Remember that Vendors are much more than conceptual vendors: they include "Collection Kiosks" and other entities. See DestinyVendorDefinition for more information.
        /// </summary>
        public bool preventInitializationOnVendorPurchase { get; set; }

        /// <summary>If this is true, the perks provided by this socket shouldn't be shown in the item's tooltip. This might be useful if it's providing a hidden bonus, or if the bonus is less important than other benefits on the item.</summary>
        public bool hidePerksInItemTooltip { get; set; }

        /// <summary>Indicates where you should go to get plugs for this socket. This will affect how you populate your UI, as well as what plugs are valid for this socket. It's an alternative to having to check for the existence of certain properties (reusablePlugItems for example) to infer where plugs should come from.</summary>
        public Destiny.SocketPlugSources plugSources { get; set; }

        /// <summary>
        /// If this socket's plugs come from a reusable DestinyPlugSetDefinition, this is the identifier for that set. We added this concept to reduce some major duplication that's going to come from sockets as replacements for what was once implemented as large sets of items and kiosks (like Emotes).
        ///  As of Shadowkeep, these will come up much more frequently and be driven by game content rather than custom curation.
        /// </summary>
        public uint? reusablePlugSetHash { get; set; }

        /// <summary>
        /// This field replaces "randomizedPlugItems" as of Shadowkeep launch. If a socket has randomized plugs, this is a pointer to the set of plugs that could be used, as defined in DestinyPlugSetDefinition.
        ///  If null, the item has no randomized plugs.
        /// </summary>
        public uint? randomizedPlugSetHash { get; set; }

        /// <summary>If true, then this socket is visible in the item's "default" state. If you have an instance, you should always check the runtime state, as that can override this visibility setting: but if you're looking at the item on a conceptual level, this property can be useful for hiding data such as legacy sockets - which remain defined on items for infrastructure purposes, but can be confusing for users to see.</summary>
        public bool defaultVisible { get; set; }
    }

    /// <summary>
    /// The definition of a known, reusable plug that can be applied to a socket.
    /// </summary>
    public class DestinyItemSocketEntryPlugItemDefinition
    {
        /// <summary>The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.</summary>
        public uint plugItemHash { get; set; }
    }

    public class DestinyItemSocketEntryPlugItemRandomizedDefinition
    {
        /// <summary>Indicates if the plug can be rolled on the current version of the item. For example, older versions of weapons may have plug rolls that are no longer possible on the current versions.</summary>
        public bool currentlyCanRoll { get; set; }

        /// <summary>The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.</summary>
        public uint plugItemHash { get; set; }
    }

    /// <summary>
    /// Represents a socket that has a plug associated with it intrinsically. This is useful for situations where the weapon needs to have a visual plug/Mod on it, but that plug/Mod should never change.
    /// </summary>
    public class DestinyItemIntrinsicSocketEntryDefinition
    {
        /// <summary>Indicates the plug that is intrinsically inserted into this socket.</summary>
        public uint plugItemHash { get; set; }

        /// <summary>Indicates the type of this intrinsic socket.</summary>
        public uint socketTypeHash { get; set; }

        /// <summary>If true, then this socket is visible in the item's "default" state. If you have an instance, you should always check the runtime state, as that can override this visibility setting: but if you're looking at the item on a conceptual level, this property can be useful for hiding data such as legacy sockets - which remain defined on items for infrastructure purposes, but can be confusing for users to see.</summary>
        public bool defaultVisible { get; set; }
    }

    /// <summary>
    /// Sockets are grouped into categories in the UI. These define which category and which sockets are under that category.
    /// </summary>
    public class DestinyItemSocketCategoryDefinition
    {
        /// <summary>The hash for the Socket Category: a quick way to go get the header display information for the category. Use it to look up DestinySocketCategoryDefinition info.</summary>
        public uint socketCategoryHash { get; set; }

        /// <summary>Use these indexes to look up the sockets in the "sockets.socketEntries" property on the item definition. These are the indexes under the category, in game-rendered order.</summary>
        public IEnumerable<int> socketIndexes { get; set; }
    }

    /// <summary>
    /// This appears to be information used when rendering rewards. We don't currently use it on BNet.
    /// </summary>
    public class DestinyItemSummaryBlockDefinition
    {
        /// <summary>Apparently when rendering an item in a reward, this should be used as a sort priority. We're not doing it presently.</summary>
        public int sortPriority { get; set; }
    }

    /// <summary>
    /// This defines information that can only come from a talent grid on an item. Items mostly have negligible talent grid data these days, but instanced items still retain grids as a source for some of this common information.
    /// Builds/Subclasses are the only items left that still have talent grids with meaningful Nodes.
    /// </summary>
    public class DestinyItemTalentGridBlockDefinition
    {
        /// <summary>The hash identifier of the DestinyTalentGridDefinition attached to this item.</summary>
        public uint talentGridHash { get; set; }

        /// <summary>This is meant to be a subtitle for looking at the talent grid. In practice, somewhat frustratingly, this always merely says the localized word for "Details". Great. Maybe it'll have more if talent grids ever get used for more than builds and subclasses again.</summary>
        public string itemDetailString { get; set; }

        /// <summary>A shortcut string identifier for the "build" in question, if this talent grid has an associated build. Doesn't map to anything we can expose at the moment.</summary>
        public string buildName { get; set; }

        /// <summary>If the talent grid implies a damage type, this is the enum value for that damage type.</summary>
        public Destiny.DamageType hudDamageType { get; set; }

        /// <summary>If the talent grid has a special icon that's shown in the game UI (like builds, funny that), this is the identifier for that icon. Sadly, we don't actually get that icon right now. I'll be looking to replace this with a path to the actual icon itself.</summary>
        public string hudIcon { get; set; }
    }

    /// <summary>
    /// The time has unfortunately come to talk about Talent Grids.
    /// Talent Grids are the most complex and unintuitive part of the Destiny Definition data. Grab a cup of coffee before we begin, I can wait.
    /// Talent Grids were the primary way that items could be customized in Destiny 1. In Destiny 2, for now, talent grids have become exclusively used by Subclass/Build items: but the system is still in place for it to be used by items should the direction change back toward talent grids.
    /// Talent Grids have Nodes: the visual circles on the talent grid detail screen that have icons and can be activated if you meet certain requirements and pay costs. The actual visual data and effects, however, are driven by the "Steps" on Talent Nodes. Any given node will have 1:M of these steps, and the specific step that will be considered the "current" step (and thus the dictator of all benefits, visual state, and activation requirements on the Node) will almost always not be determined until an instance of the item is created. This is how, in Destiny 1, items were able to have such a wide variety of what users saw as "Perks": they were actually Talent Grids with nodes that had a wide variety of Steps, randomly chosen at the time of item creation.
    /// Now that Talent Grids are used exclusively by subclasses and builds, all of the properties within still apply: but there are additional visual elements on the Subclass/Build screens that are superimposed on top of the talent nodes. Unfortunately, BNet doesn't have this data: if you want to build a subclass screen, you will have to provide your own "decorative" assets, such as the visual connectors between nodes and the fancy colored-fire-bathed character standing behind the nodes.
    /// DestinyInventoryItem.talentGrid.talentGridHash defines an item's linked Talent Grid, which brings you to this definition that contains enough satic data about talent grids to make your head spin. These *must* be combined with instanced data - found when live data returns DestinyItemTalentGridComponent - in order to derive meaning. The instanced data will reference nodes and steps within these definitions, which you will then have to look up in the definition and combine with the instanced data to give the user the visual representation of their item's talent grid.
    /// </summary>
    public class DestinyTalentGridDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>The maximum possible level of the Talent Grid: at this level, any nodes are allowed to be activated.</summary>
        public int maxGridLevel { get; set; }

        /// <summary>The meaning of this has been lost in the sands of time: it still exists as a property, but appears to be unused in the modern UI of talent grids. It used to imply that each visual "column" of talent nodes required identical progression levels in order to be activated. Returning this value in case it is still useful to someone? Perhaps it's just a bit of interesting history.</summary>
        public int gridLevelPerColumn { get; set; }

        /// <summary>The hash identifier of the Progression (DestinyProgressionDefinition) that drives whether and when Talent Nodes can be activated on the Grid. Items will have instances of this Progression, and will gain experience that will eventually cause the grid to increase in level. As the grid's level increases, it will cross the threshold where nodes can be activated. See DestinyTalentGridStepDefinition's activation requirements for more information.</summary>
        public uint progressionHash { get; set; }

        /// <summary>The list of Talent Nodes on the Grid (recall that Nodes themselves are really just locations in the UI to show whatever their current Step is. You will only know the current step for a node by retrieving instanced data through platform calls to the API that return DestinyItemTalentGridComponent).</summary>
        public IEnumerable<Destiny.Definitions.DestinyTalentNodeDefinition> nodes { get; set; }

        /// <summary>
        /// Talent Nodes can exist in "exclusive sets": these are sets of nodes in which only a single node in the set can be activated at any given time. Activating a node in this set will automatically deactivate the other nodes in the set (referred to as a "Swap").
        /// If a node in the exclusive set has already been activated, the game will not charge you materials to activate another node in the set, even if you have never activated it before, because you already paid the cost to activate one node in the set.
        /// Not to be confused with Exclusive Groups. (how the heck do we NOT get confused by that? Jeez) See the groups property for information about that only-tangentially-related concept.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyTalentNodeExclusiveSetDefinition> exclusiveSets { get; set; }

        /// <summary>This is a quick reference to the indexes of nodes that are not part of exclusive sets. Handy for knowing which talent nodes can only be activated directly, rather than via swapping.</summary>
        public IEnumerable<int> independentNodeIndexes { get; set; }

        /// <summary>
        /// Talent Nodes can have "Exclusive Groups". These are not to be confused with Exclusive Sets (see exclusiveSets property).
        /// Look at the definition of DestinyTalentExclusiveGroup for more information and how they work. These groups are keyed by the "groupHash" from DestinyTalentExclusiveGroup.
        /// </summary>
        public Dictionary<uint, Destiny.Definitions.DestinyTalentExclusiveGroup> groups { get; set; }

        /// <summary>
        /// BNet wants to show talent nodes grouped by similar purpose with localized titles. This is the ordered list of those categories: if you want to show nodes by category, you can iterate over this list, render the displayProperties for the category as the title, and then iterate over the talent nodes referenced by the category to show the related nodes.
        /// Note that this is different from Exclusive Groups or Sets, because these categories also incorporate "Independent" nodes that belong to neither sets nor groups. These are purely for visual grouping of nodes rather than functional grouping.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyTalentNodeCategory> nodeCategories { get; set; }
    }

    /// <summary>
    /// Talent Grids on items have Nodes. These nodes have positions in the talent grid's UI, and contain "Steps" (DestinyTalentNodeStepDefinition), one of whom will be the "Current" step.
    /// The Current Step determines the visual properties of the node, as well as what the node grants when it is activated.
    /// See DestinyTalentGridDefinition for a more complete overview of how Talent Grids work, and how they are used in Destiny 2 (and how they were used in Destiny 1).
    /// </summary>
    public class DestinyTalentNodeDefinition
    {
        /// <summary>The index into the DestinyTalentGridDefinition's "nodes" property where this node is located. Used to uniquely identify the node within the Talent Grid. Note that this is content version dependent: make sure you have the latest version of content before trying to use these properties.</summary>
        public int nodeIndex { get; set; }

        /// <summary>
        /// The hash identifier for the node, which unfortunately is also content version dependent but can be (and ideally, should be) used instead of the nodeIndex to uniquely identify the node.
        /// The two exist side-by-side for backcompat reasons due to the Great Talent Node Restructuring of Destiny 1, and I ran out of time to remove one of them and standardize on the other. Sorry!
        /// </summary>
        public uint nodeHash { get; set; }

        /// <summary>The visual "row" where the node should be shown in the UI. If negative, then the node is hidden.</summary>
        public int row { get; set; }

        /// <summary>The visual "column" where the node should be shown in the UI. If negative, the node is hidden.</summary>
        public int column { get; set; }

        /// <summary>
        /// Indexes into the DestinyTalentGridDefinition.nodes property for any nodes that must be activated before this one is allowed to be activated.
        /// I would have liked to change this to hashes for Destiny 2, but we have run out of time.
        /// </summary>
        public IEnumerable<int> prerequisiteNodeIndexes { get; set; }

        /// <summary>
        /// At one point, Talent Nodes supported the idea of "Binary Pairs": nodes that overlapped each other visually, and where activating one deactivated the other. They ended up not being used, mostly because Exclusive Sets are *almost* a superset of this concept, but the potential for it to be used still exists in theory.
        /// If this is ever used, this will be the index into the DestinyTalentGridDefinition.nodes property for the node that is the binary pair match to this node. Activating one deactivates the other.
        /// </summary>
        public int binaryPairNodeIndex { get; set; }

        /// <summary>If true, this node will automatically unlock when the Talent Grid's level reaches the required level of the current step of this node.</summary>
        public bool autoUnlocks { get; set; }

        /// <summary>
        /// At one point, Nodes were going to be able to be activated multiple times, changing the current step and potentially piling on multiple effects from the previously activated steps. This property would indicate if the last step could be activated multiple times.
        /// This is not currently used, but it isn't out of the question that this could end up being used again in a theoretical future.
        /// </summary>
        public bool lastStepRepeats { get; set; }

        /// <summary>If this is true, the node's step is determined randomly rather than the first step being chosen.</summary>
        public bool isRandom { get; set; }

        /// <summary>
        /// At one point, you were going to be able to repurchase talent nodes that had random steps, to "re-roll" the current step of the node (and thus change the properties of your item). This was to be the activation requirement for performing that re-roll.
        /// The system still exists to do this, as far as I know, so it may yet come back around!
        /// </summary>
        public Destiny.Definitions.DestinyNodeActivationRequirement randomActivationRequirement { get; set; }

        /// <summary>If this is true, the node can be "re-rolled" to acquire a different random current step. This is not used, but still exists for a theoretical future of talent grids.</summary>
        public bool isRandomRepurchasable { get; set; }

        /// <summary>
        /// At this point, "steps" have been obfuscated into conceptual entities, aggregating the underlying notions of "properties" and "true steps".
        /// If you need to know a step as it truly exists - such as when recreating Node logic when processing Vendor data - you'll have to use the "realSteps" property below.
        /// </summary>
        public IEnumerable<Destiny.Definitions.DestinyNodeStepDefinition> steps { get; set; }

        /// <summary>
        /// The nodeHash values for nodes that are in an Exclusive Set with this node.
        /// See DestinyTalentGridDefinition.exclusiveSets for more info about exclusive sets.
        /// Again, note that these are nodeHashes and *not* nodeIndexes.
        /// </summary>
        public IEnumerable<uint> exclusiveWithNodeHashes { get; set; }

        /// <summary>If the node's step is randomly selected, this is the amount of the Talent Grid's progression experience at which the progression bar for the node should be shown.</summary>
        public int randomStartProgressionBarAtProgression { get; set; }

        /// <summary>A string identifier for a custom visual layout to apply to this talent node. Unfortunately, we do not have any data for rendering these custom layouts. It will be up to you to interpret these strings and change your UI if you want to have custom UI matching these layouts.</summary>
        public string layoutIdentifier { get; set; }

        /// <summary>
        /// As of Destiny 2, nodes can exist as part of "Exclusive Groups". These differ from exclusive sets in that, within the group, many nodes can be activated. But the act of activating any node in the group will cause "opposing" nodes (nodes in groups that are not allowed to be activated at the same time as this group) to deactivate.
        /// See DestinyTalentExclusiveGroup for more information on the details. This is an identifier for this node's group, if it is part of one.
        /// </summary>
        public uint? groupHash { get; set; }

        /// <summary>Talent nodes can be associated with a piece of Lore, generally rendered in a tooltip. This is the hash identifier of the lore element to show, if there is one to be show.</summary>
        public uint? loreHash { get; set; }

        /// <summary>Comes from the talent grid node style: this identifier should be used to determine how to render the node in the UI.</summary>
        public string nodeStyleIdentifier { get; set; }

        /// <summary>Comes from the talent grid node style: if true, then this node should be ignored for determining whether the grid is complete.</summary>
        public bool ignoreForCompletion { get; set; }
    }

    /// <summary>
    /// Talent nodes have requirements that must be met before they can be activated.
    /// This describes the material costs, the Level of the Talent Grid's progression required, and other conditional information that limits whether a talent node can be activated.
    /// </summary>
    public class DestinyNodeActivationRequirement
    {
        /// <summary>
        /// The Progression level on the Talent Grid required to activate this node.
        /// See DestinyTalentGridDefinition.progressionHash for the related Progression, and read DestinyProgressionDefinition's documentation to learn more about Progressions.
        /// </summary>
        public int gridLevel { get; set; }

        /// <summary>
        /// The list of hash identifiers for material requirement sets: materials that are required for the node to be activated. See DestinyMaterialRequirementSetDefinition for more information about material requirements.
        /// In this case, only a single DestinyMaterialRequirementSetDefinition will be chosen from this list, and we won't know which one will be chosen until an instance of the item is created.
        /// </summary>
        public IEnumerable<uint> materialRequirementHashes { get; set; }
    }

    /// <summary>
    /// This defines the properties of a "Talent Node Step". When you see a talent node in game, the actual visible properties that you see (its icon, description, the perks and stats it provides) are not provided by the Node itself, but rather by the currently active Step on the node.
    /// When a Talent Node is activated, the currently active step's benefits are conferred upon the item and character.
    /// The currently active step on talent nodes are determined when an item is first instantiated. Sometimes it is random, sometimes it is more deterministic (particularly when a node has only a single step).
    /// Note that, when dealing with Talent Node Steps, you must ensure that you have the latest version of content. stepIndex and nodeStepHash - two ways of identifying the step within a node - are both content version dependent, and thus are subject to change between content updates.
    /// </summary>
    public class DestinyNodeStepDefinition
    {
        /// <summary>These are the display properties actually used to render the Talent Node. The currently active step's displayProperties are shown.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>
        /// The index of this step in the list of Steps on the Talent Node.
        /// Unfortunately, this is the closest thing we have to an identifier for the Step: steps are not provided a content version agnostic identifier. This means that, when you are dealing with talent nodes, you will need to first ensure that you have the latest version of content.
        /// </summary>
        public int stepIndex { get; set; }

        /// <summary>The hash of this node step. Unfortunately, while it can be used to uniquely identify the step within a node, it is also content version dependent and should not be relied on without ensuring you have the latest vesion of content.</summary>
        public uint nodeStepHash { get; set; }

        /// <summary>If you can interact with this node in some way, this is the localized description of that interaction.</summary>
        public string interactionDescription { get; set; }

        /// <summary>An enum representing a damage type granted by activating this step, if any.</summary>
        public Destiny.DamageType damageType { get; set; }

        /// <summary>If the step provides a damage type, this will be the hash identifier used to look up the damage type's DestinyDamageTypeDefinition.</summary>
        public uint? damageTypeHash { get; set; }

        /// <summary>If the step has requirements for activation (they almost always do, if nothing else than for the Talent Grid's Progression to have reached a certain level), they will be defined here.</summary>
        public Destiny.Definitions.DestinyNodeActivationRequirement activationRequirement { get; set; }

        /// <summary>
        /// There was a time when talent nodes could be activated multiple times, and the effects of subsequent Steps would be compounded on each other, essentially "upgrading" the node. We have moved away from this, but theoretically the capability still exists.
        /// I continue to return this in case it is used in the future: if true and this step is the current step in the node, you are allowed to activate the node a second time to receive the benefits of the next step in the node, which will then become the active step.
        /// </summary>
        public bool canActivateNextStep { get; set; }

        /// <summary>
        /// The stepIndex of the next step in the talent node, or -1 if this is the last step or if the next step to be chosen is random.
        /// This doesn't really matter anymore unless canActivateNextStep begins to be used again.
        /// </summary>
        public int nextStepIndex { get; set; }

        /// <summary>If true, the next step to be chosen is random, and if you're allowed to activate the next step. (if canActivateNextStep = true)</summary>
        public bool isNextStepRandom { get; set; }

        /// <summary>The list of hash identifiers for Perks (DestinySandboxPerkDefinition) that are applied when this step is active. Perks provide a variety of benefits and modifications - examine DestinySandboxPerkDefinition to learn more.</summary>
        public IEnumerable<uint> perkHashes { get; set; }

        /// <summary>
        /// When the Talent Grid's progression reaches this value, the circular "progress bar" that surrounds the talent node should be shown.
        /// This also indicates the lower bound of said progress bar, with the upper bound being the progress required to reach activationRequirement.gridLevel. (at some point I should precalculate the upper bound and put it in the definition to save people time)
        /// </summary>
        public int startProgressionBarAtProgress { get; set; }

        /// <summary>When the step provides stat benefits on the item or character, this is the list of hash identifiers for stats (DestinyStatDefinition) that are provided.</summary>
        public IEnumerable<uint> statHashes { get; set; }

        /// <summary>If this is true, the step affects the item's Quality in some way. See DestinyInventoryItemDefinition for more information about the meaning of Quality. I already made a joke about Zen and the Art of Motorcycle Maintenance elsewhere in the documentation, so I will avoid doing it again. Oops too late</summary>
        public bool affectsQuality { get; set; }

        /// <summary>In Destiny 1, the Armory's Perk Filtering was driven by a concept of TalentNodeStepGroups: categorizations of talent nodes based on their functionality. While the Armory isn't a BNet-facing thing for now, and the new Armory will need to account for Sockets rather than Talent Nodes, this categorization capability feels useful enough to still keep around.</summary>
        public Destiny.Definitions.DestinyTalentNodeStepGroups stepGroups { get; set; }

        /// <summary>If true, this step can affect the level of the item. See DestinyInventoryItemDefintion for more information about item levels and their effect on stats.</summary>
        public bool affectsLevel { get; set; }

        /// <summary>If this step is activated, this will be a list of information used to replace socket items with new Plugs. See DestinyInventoryItemDefinition for more information about sockets and plugs.</summary>
        public IEnumerable<Destiny.Definitions.DestinyNodeSocketReplaceResponse> socketReplacements { get; set; }
    }

    /// <summary>
    /// This is a bit of an odd duck. Apparently, if talent nodes steps have this data, the game will go through on step activation and alter the first Socket it finds on the item that has a type matching the given socket type, inserting the indicated plug item.
    /// </summary>
    public class DestinyNodeSocketReplaceResponse
    {
        /// <summary>The hash identifier of the socket type to find amidst the item's sockets (the item to which this talent grid is attached). See DestinyInventoryItemDefinition.sockets.socketEntries to find the socket type of sockets on the item in question.</summary>
        public uint socketTypeHash { get; set; }

        /// <summary>The hash identifier of the plug item that will be inserted into the socket found.</summary>
        public uint plugItemHash { get; set; }
    }

    /// <summary>
    /// All damage types that are possible in the game are defined here, along with localized info and icons as needed.
    /// </summary>
    public class DestinyDamageTypeDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>The description of the damage type, icon etc...</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>A variant of the icon that is transparent and colorless.</summary>
        public string transparentIconPath { get; set; }

        /// <summary>If TRUE, the game shows this damage type's icon. Otherwise, it doesn't. Whether you show it or not is up to you.</summary>
        public bool showIcon { get; set; }

        /// <summary>We have an enumeration for damage types for quick reference. This is the current definition's damage type enum value.</summary>
        public Destiny.DamageType enumValue { get; set; }
    }

    /// <summary>
    /// The list of indexes into the Talent Grid's "nodes" property for nodes in this exclusive set. (See DestinyTalentNodeDefinition.nodeIndex)
    /// </summary>
    public class DestinyTalentNodeExclusiveSetDefinition
    {
        /// <summary>The list of node indexes for the exclusive set. Historically, these were indexes. I would have liked to replace this with nodeHashes for consistency, but it's way too late for that. (9:09 PM, he's right!)</summary>
        public IEnumerable<int> nodeIndexes { get; set; }
    }

    /// <summary>
    /// As of Destiny 2, nodes can exist as part of "Exclusive Groups". These differ from exclusive sets in that, within the group, many nodes can be activated. But the act of activating any node in the group will cause "opposing" nodes (nodes in groups that are not allowed to be activated at the same time as this group) to deactivate.
    /// </summary>
    public class DestinyTalentExclusiveGroup
    {
        /// <summary>The identifier for this exclusive group. Only guaranteed unique within the talent grid, not globally.</summary>
        public uint groupHash { get; set; }

        /// <summary>If this group has an associated piece of lore to show next to it, this will be the identifier for that DestinyLoreDefinition.</summary>
        public uint? loreHash { get; set; }

        /// <summary>A quick reference of the talent nodes that are part of this group, by their Talent Node hashes. (See DestinyTalentNodeDefinition.nodeHash)</summary>
        public IEnumerable<uint> nodeHashes { get; set; }

        /// <summary>A quick reference of Groups whose nodes will be deactivated if any node in this group is activated.</summary>
        public IEnumerable<uint> opposingGroupHashes { get; set; }

        /// <summary>A quick reference of Nodes that will be deactivated if any node in this group is activated, by their Talent Node hashes. (See DestinyTalentNodeDefinition.nodeHash)</summary>
        public IEnumerable<uint> opposingNodeHashes { get; set; }
    }

    /// <summary>
    /// An artificial construct provided by Bungie.Net, where we attempt to group talent nodes by functionality.
    /// This is a single set of references to Talent Nodes that share a common trait or purpose.
    /// </summary>
    public class DestinyTalentNodeCategory
    {
        /// <summary>Mostly just for debug purposes, but if you find it useful you can have it. This is BNet's manually created identifier for this category.</summary>
        public string identifier { get; set; }

        /// <summary>If true, we found the localized content in a related DestinyLoreDefinition instead of local BNet localization files. This is mostly for ease of my own future investigations.</summary>
        public bool isLoreDriven { get; set; }

        /// <summary>Will contain at least the "name", which will be the title of the category. We will likely not have description and an icon yet, but I'm going to keep my options open.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The set of all hash identifiers for Talent Nodes (DestinyTalentNodeDefinition) in this Talent Grid that are part of this Category.</summary>
        public IEnumerable<uint> nodeHashes { get; set; }
    }

    /// <summary>
    /// An intrinsic perk on an item, and the requirements for it to be activated.
    /// </summary>
    public class DestinyItemPerkEntryDefinition
    {
        /// <summary>If this perk is not active, this is the string to show for why it's not providing its benefits.</summary>
        public string requirementDisplayString { get; set; }

        /// <summary>A hash identifier for the DestinySandboxPerkDefinition being provided on the item.</summary>
        public uint perkHash { get; set; }

        /// <summary>Indicates whether this perk should be shown, or if it should be shown disabled.</summary>
        public Destiny.ItemPerkVisibility perkVisibility { get; set; }
    }

    /// <summary>
    /// In an attempt to categorize items by type, usage, and other interesting properties, we created DestinyItemCategoryDefinition: information about types that is assembled using a set of heuristics that examine the properties of an item such as what inventory bucket it's in, its item type name, and whether it has or is missing certain blocks of data.
    /// This heuristic is imperfect, however. If you find an item miscategorized, let us know on the Bungie API forums!
    /// We then populate all of the categories that we think an item belongs to in its DestinyInventoryItemDefinition.itemCategoryHashes property. You can use that to provide your own custom item filtering, sorting, aggregating... go nuts on it! And let us know if you see more categories that you wish would be added!
    /// </summary>
    public class DestinyItemCategoryDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>If True, this category should be visible in UI. Sometimes we make categories that we don't think are interesting externally. It's up to you if you want to skip on showing them.</summary>
        public bool visible { get; set; }

        /// <summary>If True, this category has been deprecated: it may have no items left, or there may be only legacy items that remain in it which are no longer relevant to the game.</summary>
        public bool deprecated { get; set; }

        /// <summary>A shortened version of the title. The reason why we have this is because the Armory in German had titles that were too long to display in our UI, so these were localized abbreviated versions of those categories. The property still exists today, even though the Armory doesn't exist for D2... yet.</summary>
        public string shortTitle { get; set; }

        /// <summary>The janky regular expression we used against the item type to try and discern whether the item belongs to this category.</summary>
        public string itemTypeRegex { get; set; }

        /// <summary>If the item in question has this category, it also should have this breaker type.</summary>
        public Destiny.DestinyBreakerType grantDestinyBreakerType { get; set; }

        /// <summary>If the item is a plug, this is the identifier we expect to find associated with it if it is in this category.</summary>
        public string plugCategoryIdentifier { get; set; }

        /// <summary>If the item type matches this janky regex, it does *not* belong to this category.</summary>
        public string itemTypeRegexNot { get; set; }

        /// <summary>If the item belongs to this bucket, it does belong to this category.</summary>
        public string originBucketIdentifier { get; set; }

        /// <summary>If an item belongs to this category, it will also receive this item type. This is now how DestinyItemType is populated for items: it used to be an even jankier process, but that's a story that requires more alcohol.</summary>
        public Destiny.DestinyItemType grantDestinyItemType { get; set; }

        /// <summary>
        /// If an item belongs to this category, it will also receive this subtype enum value.
        /// I know what you're thinking - what if it belongs to multiple categories that provide sub-types?
        /// The last one processed wins, as is the case with all of these "grant" enums. Now you can see one reason why we moved away from these enums... but they're so convenient when they work, aren't they?
        /// </summary>
        public Destiny.DestinyItemSubType grantDestinySubType { get; set; }

        /// <summary>
        /// If an item belongs to this category, it will also get this class restriction enum value.
        /// See the other "grant"-prefixed properties on this definition for my color commentary.
        /// </summary>
        public Destiny.DestinyClass grantDestinyClass { get; set; }

        /// <summary>The traitId that can be found on items that belong to this category.</summary>
        public string traitId { get; set; }

        /// <summary>
        /// If this category is a "parent" category of other categories, those children will have their hashes listed in rendering order here, and can be looked up using these hashes against DestinyItemCategoryDefinition.
        /// In this way, you can build up a visual hierarchy of item categories. That's what we did, and you can do it too. I believe in you. Yes, you, Carl.
        /// (I hope someone named Carl reads this someday)
        /// </summary>
        public IEnumerable<uint> groupedCategoryHashes { get; set; }

        /// <summary>All item category hashes of "parent" categories: categories that contain this as a child through the hierarchy of groupedCategoryHashes. It's a bit redundant, but having this child-centric list speeds up some calculations.</summary>
        public IEnumerable<uint> parentCategoryHashes { get; set; }

        /// <summary>If true, this category is only used for grouping, and should not be evaluated with its own checks. Rather, the item only has this category if it has one of its child categories.</summary>
        public bool groupCategoryOnly { get; set; }
    }

    public class DestinyProgressionRewardItemQuantity : Destiny.DestinyItemQuantity
    {
        public int rewardedAtProgressionLevel { get; set; }

        public Destiny.DestinyProgressionRewardItemAcquisitionBehavior acquisitionBehavior { get; set; }

        public string uiDisplayStyle { get; set; }

        public IEnumerable<string> claimUnlockDisplayStrings { get; set; }
    }

    /// <summary>
    /// In Destiny, "Races" are really more like "Species". Sort of. I mean, are the Awoken a separate species from humans? I'm not sure. But either way, they're defined here. You'll see Exo, Awoken, and Human as examples of these Species. Players will choose one for their character.
    /// </summary>
    public class DestinyRaceDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>An enumeration defining the existing, known Races/Species for player characters. This value will be the enum value matching this definition.</summary>
        public Destiny.DestinyRace raceType { get; set; }

        /// <summary>A localized string referring to the singular form of the Race's name when referred to in gendered form. Keyed by the DestinyGender.</summary>
        public Dictionary<Destiny.DestinyGender, string> genderedRaceNames { get; set; }

        public Dictionary<uint, string> genderedRaceNamesByGenderHash { get; set; }
    }

    /// <summary>
    /// Defines a Character Class in Destiny 2. These are types of characters you can play, like Titan, Warlock, and Hunter.
    /// </summary>
    public class DestinyClassDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>In Destiny 1, we added a convenience Enumeration for referring to classes. We've kept it, though mostly for posterity. This is the enum value for this definition's class.</summary>
        public Destiny.DestinyClass classType { get; set; }

        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>A localized string referring to the singular form of the Class's name when referred to in gendered form. Keyed by the DestinyGender.</summary>
        public Dictionary<Destiny.DestinyGender, string> genderedClassNames { get; set; }

        public Dictionary<uint, string> genderedClassNamesByGenderHash { get; set; }

        /// <summary>Mentors don't really mean anything anymore. Don't expect this to be populated.</summary>
        public uint? mentorVendorHash { get; set; }
    }

    /// <summary>
    /// Unlock Flags are small bits (literally, a bit, as in a boolean value) that the game server uses for an extremely wide range of state checks, progress storage, and other interesting tidbits of information.
    /// </summary>
    public class DestinyUnlockDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>Sometimes, but not frequently, these unlock flags also have human readable information: usually when they are being directly tested for some requirement, in which case the string is a localized description of why the requirement check failed.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    /// <summary>
    /// The results of a search for Destiny content. This will be improved on over time, I've been doing some experimenting to see what might be useful.
    /// </summary>
    public class DestinyEntitySearchResult
    {
        /// <summary>A list of suggested words that might make for better search results, based on the text searched for.</summary>
        public IEnumerable<string> suggestedWords { get; set; }

        /// <summary>The items found that are matches/near matches for the searched-for term, sorted by something vaguely resembling "relevance". Hopefully this will get better in the future.</summary>
        public SearchResultOfDestinyEntitySearchResultItem results { get; set; }
    }

    /// <summary>
    /// An individual Destiny Entity returned from the entity search.
    /// </summary>
    public class DestinyEntitySearchResultItem
    {
        /// <summary>The hash identifier of the entity. You will use this to look up the DestinyDefinition relevant for the entity found.</summary>
        public uint hash { get; set; }

        /// <summary>The type of entity, returned as a string matching the DestinyDefinition's contract class name. You'll have to have your own mapping from class names to actually looking up those definitions in the manifest databases.</summary>
        public string entityType { get; set; }

        /// <summary>Basic display properties on the entity, so you don't have to look up the definition to show basic results for the item.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>The ranking value for sorting that we calculated using our relevance formula. This will hopefully get better with time and iteration.</summary>
        public double weight { get; set; }
    }
}