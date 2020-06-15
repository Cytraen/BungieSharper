using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Items
{
    /// <summary>
    /// Defines the tier type of an item. Mostly this provides human readable properties for types like Common, Rare, etc...
    /// It also provides some base data for infusion that could be useful.
    /// </summary>
    public class DestinyItemTierTypeDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>If this tier defines infusion properties, they will be contained here.</summary>
        public Schema.Destiny.Definitions.Items.DestinyItemTierTypeInfusionBlock infusionProcess { get; set; }
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

    public class DestinyItemTierTypeInfusionBlock
    {
        /// <summary>The default portion of quality that will transfer from the infuser to the infusee item. (InfuserQuality - InfuseeQuality) * baseQualityTransferRatio = base quality transferred.</summary>
        public float baseQualityTransferRatio { get; set; }
        /// <summary>As long as InfuserQuality > InfuseeQuality, the amount of quality bestowed is guaranteed to be at least this value, even if the transferRatio would dictate that it should be less. The total amount of quality that ends up in the Infusee cannot exceed the Infuser's quality however (for instance, if you infuse a 300 item with a 301 item and the minimum quality increment is 10, the infused item will not end up with 310 quality)</summary>
        public int minimumQualityIncrement { get; set; }
    }

    /// <summary>
    /// A shortcut for the fact that some items have a "Preview Vendor" - See DestinyInventoryItemDefinition.preview.previewVendorHash - that is intended to be used to show what items you can get as a result of acquiring or using this item.
    /// A common example of this in Destiny 1 was Eververse "Boxes," which could have many possible items. This "Preview Vendor" is not a vendor you can actually see in the game, but it defines categories and sale items for all of the possible items you could get from the Box so that the game can show them to you. We summarize that info here so that you don't have to do that Vendor lookup and aggregation manually.
    /// </summary>
    public class DestinyDerivedItemCategoryDefinition
    {
        /// <summary>The localized string for the category title. This will be something describing the items you can get as a group, or your likelihood/the quantity you'll get.</summary>
        public string categoryDescription { get; set; }
        /// <summary>This is the list of all of the items for this category and the basic properties we'll know about them.</summary>
        public IEnumerable<Schema.Destiny.Definitions.Items.DestinyDerivedItemDefinition> items { get; set; }
    }

    /// <summary>
    /// This is a reference to, and summary data for, a specific item that you can get as a result of Using or Acquiring some other Item (For example, this could be summary information for an Emote that you can get by opening an an Eververse Box) See DestinyDerivedItemCategoryDefinition for more information.
    /// </summary>
    public class DestinyDerivedItemDefinition
    {
        /// <summary>The hash for the DestinyInventoryItemDefinition of this derived item, if there is one. Sometimes we are given this information as a manual override, in which case there won't be an actual DestinyInventoryItemDefinition for what we display, but you can still show the strings from this object itself.</summary>
        public uint itemHash { get; set; }
        /// <summary>The name of the derived item.</summary>
        public string itemName { get; set; }
        /// <summary>Additional details about the derived item, in addition to the description.</summary>
        public string itemDetail { get; set; }
        /// <summary>A brief description of the item.</summary>
        public string itemDescription { get; set; }
        /// <summary>An icon for the item.</summary>
        public string iconPath { get; set; }
        /// <summary>If the item was derived from a "Preview Vendor", this will be an index into the DestinyVendorDefinition's itemList property. Otherwise, -1.</summary>
        public int vendorItemIndex { get; set; }
    }

    /// <summary>
    /// If an item is a Plug, its DestinyInventoryItemDefinition.plug property will be populated with an instance of one of these bad boys.
    /// This gives information about when it can be inserted, what the plug's category is (and thus whether it is compatible with a socket... see DestinySocketTypeDefinition for information about Plug Categories and socket compatibility), whether it is enabled and other Plug info.
    /// </summary>
    public class DestinyItemPlugDefinition
    {
        /// <summary>
        /// The rules around when this plug can be inserted into a socket, aside from the socket's individual restrictions.
        /// The live data DestinyItemPlugComponent.insertFailIndexes will be an index into this array, so you can pull out the failure strings appropriate for the user.
        /// </summary>
        public IEnumerable<Schema.Destiny.Definitions.Items.DestinyPlugRuleDefinition> insertionRules { get; set; }
        /// <summary>The string identifier for the plug's category. Use the socket's DestinySocketTypeDefinition.plugWhitelist to determine whether this plug can be inserted into the socket.</summary>
        public string plugCategoryIdentifier { get; set; }
        /// <summary>The hash for the plugCategoryIdentifier. You can use this instead if you wish: I put both in the definition for debugging purposes.</summary>
        public uint plugCategoryHash { get; set; }
        /// <summary>If you successfully socket the item, this will determine whether or not you get "refunded" on the plug.</summary>
        public bool onActionRecreateSelf { get; set; }
        /// <summary>If inserting this plug requires materials, this is the hash identifier for looking up the DestinyMaterialRequirementSetDefinition for those requirements.</summary>
        public uint insertionMaterialRequirementHash { get; set; }
        /// <summary>In the game, if you're inspecting a plug item directly, this will be the item shown with the plug attached. Look up the DestinyInventoryItemDefinition for this hash for the item.</summary>
        public uint previewItemOverrideHash { get; set; }
        /// <summary>It's not enough for the plug to be inserted. It has to be enabled as well. For it to be enabled, it may require materials. This is the hash identifier for the DestinyMaterialRequirementSetDefinition for those requirements, if there is one.</summary>
        public uint enabledMaterialRequirementHash { get; set; }
        /// <summary>
        /// The rules around whether the plug, once inserted, is enabled and providing its benefits.
        /// The live data DestinyItemPlugComponent.enableFailIndexes will be an index into this array, so you can pull out the failure strings appropriate for the user.
        /// </summary>
        public IEnumerable<Schema.Destiny.Definitions.Items.DestinyPlugRuleDefinition> enabledRules { get; set; }
        /// <summary>Plugs can have arbitrary, UI-defined identifiers that the UI designers use to determine the style applied to plugs. Unfortunately, we have neither a definitive list of these labels nor advance warning of when new labels might be applied or how that relates to how they get rendered. If you want to, you can refer to known labels to change your own styles: but know that new ones can be created arbitrarily, and we have no way of associating the labels with any specific UI style guidance... you'll have to piece that together on your end. Or do what we do, and just show plugs more generically, without specialized styles.</summary>
        public string uiPlugLabel { get; set; }
        public Schema.Destiny.PlugUiStyles plugStyle { get; set; }
        /// <summary>Indicates the rules about when this plug can be used. See the PlugAvailabilityMode enumeration for more information!</summary>
        public Schema.Destiny.PlugAvailabilityMode plugAvailability { get; set; }
        /// <summary>If the plug meets certain state requirements, it may have an alternative label applied to it. This is the alternative label that will be applied in such a situation.</summary>
        public string alternateUiPlugLabel { get; set; }
        /// <summary>The alternate plug of the plug: only applies when the item is in states that only the server can know about and control, unfortunately. See AlternateUiPlugLabel for the related label info.</summary>
        public Schema.Destiny.PlugUiStyles alternatePlugStyle { get; set; }
        /// <summary>If TRUE, this plug is used for UI display purposes only, and doesn't have any interesting effects of its own.</summary>
        public bool isDummyPlug { get; set; }
        /// <summary>
        /// Do you ever get the feeling that a system has become so overburdened by edge cases that it probably should have become some other system entirely? So do I!
        /// In totally unrelated news, Plugs can now override properties of their parent items. This is some of the relevant definition data for those overrides.
        /// If this is populated, it will have the override data to be applied when this plug is applied to an item.
        /// </summary>
        public Schema.Destiny.Definitions.Items.DestinyParentItemOverride parentItemOverride { get; set; }
        /// <summary>IF not null, this plug provides Energy capacity to the item in which it is socketed. In Armor 2.0 for example, is implemented in a similar way to Masterworks, where visually it's a single area of the UI being clicked on to "Upgrade" to higher energy levels, but it's actually socketing new plugs.</summary>
        public Schema.Destiny.Definitions.Items.DestinyEnergyCapacityEntry energyCapacity { get; set; }
        /// <summary>IF not null, this plug has an energy cost. This contains the details of that cost.</summary>
        public Schema.Destiny.Definitions.Items.DestinyEnergyCostEntry energyCost { get; set; }
    }

    /// <summary>
    /// Dictates a rule around whether the plug is enabled or insertable.
    /// In practice, the live Destiny data will refer to these entries by index. You can then look up that index in the appropriate property (enabledRules or insertionRules) to get the localized string for the failure message if it failed.
    /// </summary>
    public class DestinyPlugRuleDefinition
    {
        /// <summary>The localized string to show if this rule fails.</summary>
        public string failureMessage { get; set; }
    }

    public class DestinyParentItemOverride
    {
        public IEnumerable<string> additionalEquipRequirementsDisplayStrings { get; set; }
        public string pipIcon { get; set; }
    }

    /// <summary>
    /// Items can have Energy Capacity, and plugs can provide that capacity such as on a piece of Armor in Armor 2.0. This is how much "Energy" can be spent on activating plugs for this item.
    /// </summary>
    public class DestinyEnergyCapacityEntry
    {
        /// <summary>How much energy capacity this plug provides.</summary>
        public int capacityValue { get; set; }
        /// <summary>Energy provided by a plug is always of a specific type - this is the hash identifier for the energy type for which it provides Capacity.</summary>
        public uint energyTypeHash { get; set; }
        /// <summary>The Energy Type for this energy capacity, in enum form for easy use.</summary>
        public Schema.Destiny.DestinyEnergyType energyType { get; set; }
    }

    /// <summary>
    /// Some plugs cost Energy, which is a stat on the item that can be increased by other plugs (that, at least in Armor 2.0, have a "masterworks-like" mechanic for upgrading). If a plug has costs, the details of that cost are defined here.
    /// </summary>
    public class DestinyEnergyCostEntry
    {
        /// <summary>The Energy cost for inserting this plug.</summary>
        public int energyCost { get; set; }
        /// <summary>The type of energy that this plug costs, as a reference to the DestinyEnergyTypeDefinition of the energy type.</summary>
        public uint energyTypeHash { get; set; }
        /// <summary>The type of energy that this plug costs, in enum form.</summary>
        public Schema.Destiny.DestinyEnergyType energyType { get; set; }
    }
}