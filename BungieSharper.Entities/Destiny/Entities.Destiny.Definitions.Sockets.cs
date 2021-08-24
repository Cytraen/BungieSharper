using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Sockets
{
    /// <summary>
    /// All Sockets have a "Type": a set of common properties that determine when the socket allows Plugs to be inserted, what Categories of Plugs can be inserted, and whether the socket is even visible at all given the current game/character/account state.
    /// See DestinyInventoryItemDefinition for more information about Socketed items and Plugs.
    /// </summary>
    public class DestinySocketTypeDefinition
    {
        /// <summary>There are fields for this display data, but they appear to be unpopulated as of now. I am not sure where in the UI these would show if they even were populated, but I will continue to return this data in case it becomes useful.</summary>
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>Defines what happens when a plug is inserted into sockets of this type.</summary>
        [JsonPropertyName("insertAction")]
        public Destiny.Definitions.Sockets.DestinyInsertPlugActionDefinition InsertAction { get; set; }

        /// <summary>
        /// A list of Plug "Categories" that are allowed to be plugged into sockets of this type.
        /// These should be compared against a given plug item's DestinyInventoryItemDefinition.plug.plugCategoryHash, which indicates the plug item's category.
        /// If the plug's category matches any whitelisted plug, or if the whitelist is empty, it is allowed to be inserted.
        /// </summary>
        [JsonPropertyName("plugWhitelist")]
        public IEnumerable<Destiny.Definitions.Sockets.DestinyPlugWhitelistEntryDefinition> PlugWhitelist { get; set; }

        [JsonPropertyName("socketCategoryHash")]
        public uint SocketCategoryHash { get; set; }

        /// <summary>Sometimes a socket isn't visible. These are some of the conditions under which sockets of this type are not visible. Unfortunately, the truth of visibility is much, much more complex. Best to rely on the live data for whether the socket is visible and enabled.</summary>
        [JsonPropertyName("visibility")]
        public Destiny.DestinySocketVisibility Visibility { get; set; }

        [JsonPropertyName("alwaysRandomizeSockets")]
        public bool AlwaysRandomizeSockets { get; set; }

        [JsonPropertyName("isPreviewEnabled")]
        public bool IsPreviewEnabled { get; set; }

        [JsonPropertyName("hideDuplicateReusablePlugs")]
        public bool HideDuplicateReusablePlugs { get; set; }

        /// <summary>This property indicates if the socket type determines whether Emblem icons and nameplates should be overridden by the inserted plug item's icon and nameplate.</summary>
        [JsonPropertyName("overridesUiAppearance")]
        public bool OverridesUiAppearance { get; set; }

        [JsonPropertyName("avoidDuplicatesOnInitialization")]
        public bool AvoidDuplicatesOnInitialization { get; set; }

        [JsonPropertyName("currencyScalars")]
        public IEnumerable<Destiny.Definitions.Sockets.DestinySocketTypeScalarMaterialRequirementEntry> CurrencyScalars { get; set; }

        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        [JsonPropertyName("hash")]
        public uint Hash { get; set; }

        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        [JsonPropertyName("redacted")]
        public bool Redacted { get; set; }
    }

    /// <summary>
    /// Data related to what happens while a plug is being inserted, mostly for UI purposes.
    /// </summary>
    public class DestinyInsertPlugActionDefinition
    {
        /// <summary>How long it takes for the Plugging of the item to be completed once it is initiated, if you care.</summary>
        [JsonPropertyName("actionExecuteSeconds")]
        public int ActionExecuteSeconds { get; set; }

        /// <summary>The type of action being performed when you act on this Socket Type. The most common value is "insert plug", but there are others as well (for instance, a "Masterwork" socket may allow for Re-initialization, and an Infusion socket allows for items to be consumed to upgrade the item)</summary>
        [JsonPropertyName("actionType")]
        public Destiny.SocketTypeActionType ActionType { get; set; }
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
        [JsonPropertyName("categoryHash")]
        public uint CategoryHash { get; set; }

        /// <summary>The string identifier for the category, which is here mostly for debug purposes.</summary>
        [JsonPropertyName("categoryIdentifier")]
        public string CategoryIdentifier { get; set; }

        /// <summary>
        /// The list of all plug items (DestinyInventoryItemDefinition) that the socket may randomly be populated with when reinitialized.
        /// Which ones you should actually show are determined by the plug being inserted into the socket, and the socket’s type.
        /// When you inspect the plug that could go into a Masterwork Socket, look up the socket type of the socket being inspected and find the DestinySocketTypeDefinition.
        /// Then, look at the Plugs that can fit in that socket. Find the Whitelist in the DestinySocketTypeDefinition that matches the plug item’s categoryhash.
        /// That whitelist entry will potentially have a new “reinitializationPossiblePlugHashes” property.If it does, that means we know what it will roll if you try to insert this plug into this socket.
        /// </summary>
        [JsonPropertyName("reinitializationPossiblePlugHashes")]
        public IEnumerable<uint> ReinitializationPossiblePlugHashes { get; set; }
    }

    public class DestinySocketTypeScalarMaterialRequirementEntry
    {
        [JsonPropertyName("currencyItemHash")]
        public uint CurrencyItemHash { get; set; }

        [JsonPropertyName("scalarValue")]
        public int ScalarValue { get; set; }
    }

    /// <summary>
    /// Sockets on an item are organized into Categories visually.
    /// You can find references to the socket category defined on an item's DestinyInventoryItemDefinition.sockets.socketCategories property.
    /// This has the display information for rendering the categories' header, and a hint for how the UI should handle showing this category.
    /// The shitty thing about this, however, is that the socket categories' UI style can be overridden by the item's UI style. For instance, the Socket Category used by Emote Sockets says it's "consumable," but that's a lie: they're all reusable, and overridden by the detail UI pages in ways that we can't easily account for in the API.
    /// As a result, I will try to compile these rules into the individual sockets on items, and provide the best hint possible there through the plugSources property. In the future, I may attempt to use this information in conjunction with the item to provide a more usable UI hint on the socket layer, but for now improving the consistency of plugSources is the best I have time to provide. (See https://github.com/Bungie-net/api/issues/522 for more info)
    /// </summary>
    public class DestinySocketCategoryDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>
        /// A string hinting to the game's UI system about how the sockets in this category should be displayed.
        /// BNet doesn't use it: it's up to you to find valid values and make your own special UI if you want to honor this category style.
        /// </summary>
        [JsonPropertyName("uiCategoryStyle")]
        public uint UiCategoryStyle { get; set; }

        /// <summary>Same as uiCategoryStyle, but in a more usable enumeration form.</summary>
        [JsonPropertyName("categoryStyle")]
        public Destiny.DestinySocketCategoryStyle CategoryStyle { get; set; }

        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        [JsonPropertyName("hash")]
        public uint Hash { get; set; }

        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        [JsonPropertyName("redacted")]
        public bool Redacted { get; set; }
    }

    /// <summary>
    /// Sometimes, we have large sets of reusable plugs that are defined identically and thus can (and in some cases, are so large that they *must*) be shared across the places where they are used. These are the definitions for those reusable sets of plugs.
    /// See DestinyItemSocketEntryDefinition.plugSource and reusablePlugSetHash for the relationship between these reusable plug sets and the sockets that leverage them (for starters, Emotes).
    /// As of the release of Shadowkeep (Late 2019), these will begin to be sourced from game content directly - which means there will be many more of them, but it also means we may not get all data that we used to get for them.
    /// DisplayProperties, in particular, will no longer be guaranteed to contain valid information. We will make a best effort to guess what ought to be populated there where possible, but it will be invalid for many/most plug sets.
    /// </summary>
    public class DestinyPlugSetDefinition
    {
        /// <summary>If you want to show these plugs in isolation, these are the display properties for them.</summary>
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>
        /// This is a list of pre-determined plugs that can be plugged into this socket, without the character having the plug in their inventory.
        /// If this list is populated, you will not be allowed to plug an arbitrary item in the socket: you will only be able to choose from one of these reusable plugs.
        /// </summary>
        [JsonPropertyName("reusablePlugItems")]
        public IEnumerable<Destiny.Definitions.DestinyItemSocketEntryPlugItemRandomizedDefinition> ReusablePlugItems { get; set; }

        /// <summary>
        /// Mostly for our debugging or reporting bugs, BNet is making "fake" plug sets in a desperate effort to reduce socket sizes.
        /// If this is true, the plug set was generated by BNet: if it looks wrong, that's a good indicator that it's bungie.net that fucked this up.
        /// </summary>
        [JsonPropertyName("isFakePlugSet")]
        public bool IsFakePlugSet { get; set; }

        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        [JsonPropertyName("hash")]
        public uint Hash { get; set; }

        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        [JsonPropertyName("redacted")]
        public bool Redacted { get; set; }
    }
}