using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Sockets
{

    /// <summary>
    /// All Sockets have a "Type": a set of common properties that determine when the socket allows Plugs to be inserted, what Categories of Plugs can be inserted, and whether the socket is even visible at all given the current game/character/account state.
    /// See DestinyInventoryItemDefinition for more information about Socketed items and Plugs.
    /// </summary>
    public class DestinySocketTypeDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        /// <summary>There are fields for this display data, but they appear to be unpopulated as of now. I am not sure where in the UI these would show if they even were populated, but I will continue to return this data in case it becomes useful.</summary>
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>Defines what happens when a plug is inserted into sockets of this type.</summary>
        public Schema.Destiny.Definitions.Sockets.DestinyInsertPlugActionDefinition insertAction { get; set; }
        /// <summary>
        /// A list of Plug "Categories" that are allowed to be plugged into sockets of this type.
        /// These should be compared against a given plug item's DestinyInventoryItemDefinition.plug.plugCategoryHash, which indicates the plug item's category.
        /// If the plug's category matches any whitelisted plug, or if the whitelist is empty, it is allowed to be inserted.
        /// </summary>
        public IEnumerable<Schema.Destiny.Definitions.Sockets.DestinyPlugWhitelistEntryDefinition> plugWhitelist { get; set; }
        public uint socketCategoryHash { get; set; }
        /// <summary>Sometimes a socket isn't visible. These are some of the conditions under which sockets of this type are not visible. Unfortunately, the truth of visibility is much, much more complex. Best to rely on the live data for whether the socket is visible and enabled.</summary>
        public Schema.Destiny.DestinySocketVisibility visibility { get; set; }
        public bool alwaysRandomizeSockets { get; set; }
        public bool isPreviewEnabled { get; set; }
        public bool hideDuplicateReusablePlugs { get; set; }
        /// <summary>This property indicates if the socket type determines whether Emblem icons and nameplates should be overridden by the inserted plug item's icon and nameplate.</summary>
        public bool overridesUiAppearance { get; set; }
        public bool avoidDuplicatesOnInitialization { get; set; }
        public IEnumerable<Schema.Destiny.Definitions.Sockets.DestinySocketTypeScalarMaterialRequirementEntry> currencyScalars { get; set; }
    }

    /// <summary>
    /// Data related to what happens while a plug is being inserted, mostly for UI purposes.
    /// </summary>
    public class DestinyInsertPlugActionDefinition
    {
        /// <summary>How long it takes for the Plugging of the item to be completed once it is initiated, if you care.</summary>
        public int actionExecuteSeconds { get; set; }
        /// <summary>The type of action being performed when you act on this Socket Type. The most common value is "insert plug", but there are others as well (for instance, a "Masterwork" socket may allow for Re-initialization, and an Infusion socket allows for items to be consumed to upgrade the item)</summary>
        public Schema.Destiny.SocketTypeActionType actionType { get; set; }
    }

    /// <summary>
    /// Defines a plug "Category" that is allowed to be plugged into a socket of this type.
    /// This should be compared against a given plug item's DestinyInventoryItemDefinition.plug.plugCategoryHash, which indicates the plug item's category.
    /// </summary>
    public class DestinyPlugWhitelistEntryDefinition
    {
        /// <summary>
        /// The hash identifier of the Plug Category to compare against the plug item's plug.plugCategoryHash.
        /// Note that this does NOT relate to any Definition in itself, it is only used for comparison purposes.
        /// </summary>
        public uint categoryHash { get; set; }
        /// <summary>The string identifier for the category, which is here mostly for debug purposes.</summary>
        public string categoryIdentifier { get; set; }
        /// <summary>
        /// The list of all plug items (DestinyInventoryItemDefinition) that the socket may randomly be populated with when reinitialized.
        /// Which ones you should actually show are determined by the plug being inserted into the socket, and the socket’s type.
        /// When you inspect the plug that could go into a Masterwork Socket, look up the socket type of the socket being inspected and find the DestinySocketTypeDefinition.
        /// Then, look at the Plugs that can fit in that socket. Find the Whitelist in the DestinySocketTypeDefinition that matches the plug item’s categoryhash.
        /// That whitelist entry will potentially have a new “reinitializationPossiblePlugHashes” property.If it does, that means we know what it will roll if you try to insert this plug into this socket.
        /// </summary>
        public IEnumerable<uint> reinitializationPossiblePlugHashes { get; set; }
    }

    public class DestinySocketTypeScalarMaterialRequirementEntry
    {
        public uint currencyItemHash { get; set; }
        public int scalarValue { get; set; }
    }

    /// <summary>
    /// Sockets on an item are organized into Categories visually.
    /// You can find references to the socket category defined on an item's DestinyInventoryItemDefinition.sockets.socketCategories property.
    /// This has the display information for rendering the categories' header, and a hint for how the UI should handle showing this category.
    /// The shitty thing about this, however, is that the socket categories' UI style can be overridden by the item's UI style. For instance, the Socket Category used by Emote Sockets says it's "consumable," but that's a lie: they're all reusable, and overridden by the detail UI pages in ways that we can't easily account for in the API.
    /// As a result, I will try to compile these rules into the individual sockets on items, and provide the best hint possible there through the plugSources property. In the future, I may attempt to use this information in conjunction with the item to provide a more usable UI hint on the socket layer, but for now improving the consistency of plugSources is the best I have time to provide. (See https://github.com/Bungie-net/api/issues/522 for more info)
    /// </summary>
    public class DestinySocketCategoryDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>
        /// A string hinting to the game's UI system about how the sockets in this category should be displayed.
        /// BNet doesn't use it: it's up to you to find valid values and make your own special UI if you want to honor this category style.
        /// </summary>
        public uint uiCategoryStyle { get; set; }
        /// <summary>Same as uiCategoryStyle, but in a more usable enumeration form.</summary>
        public Schema.Destiny.DestinySocketCategoryStyle categoryStyle { get; set; }
    }

    /// <summary>
    /// Sometimes, we have large sets of reusable plugs that are defined identically and thus can (and in some cases, are so large that they *must*) be shared across the places where they are used. These are the definitions for those reusable sets of plugs. 
    ///  See DestinyItemSocketEntryDefinition.plugSource and reusablePlugSetHash for the relationship between these reusable plug sets and the sockets that leverage them (for starters, Emotes).
    ///  As of the release of Shadowkeep (Late 2019), these will begin to be sourced from game content directly - which means there will be many more of them, but it also means we may not get all data that we used to get for them.
    ///  DisplayProperties, in particular, will no longer be guaranteed to contain valid information. We will make a best effort to guess what ought to be populated there where possible, but it will be invalid for many/most plug sets.
    /// </summary>
    public class DestinyPlugSetDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        /// <summary>If you want to show these plugs in isolation, these are the display properties for them.</summary>
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>
        /// This is a list of pre-determined plugs that can be plugged into this socket, without the character having the plug in their inventory.
        /// If this list is populated, you will not be allowed to plug an arbitrary item in the socket: you will only be able to choose from one of these reusable plugs.
        /// </summary>
        public IEnumerable<Schema.Destiny.Definitions.DestinyItemSocketEntryPlugItemRandomizedDefinition> reusablePlugItems { get; set; }
        /// <summary>
        /// Mostly for our debugging or reporting bugs, BNet is making "fake" plug sets in a desperate effort to reduce socket sizes.
        ///  If this is true, the plug set was generated by BNet: if it looks wrong, that's a good indicator that it's bungie.net that fucked this up.
        /// </summary>
        public bool isFakePlugSet { get; set; }
    }
}