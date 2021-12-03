using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Requests.Actions
{
    public class DestinyActionRequest
    {
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    public class DestinyCharacterActionRequest
    {
        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    public class DestinyItemActionRequest
    {
        /// <summary>The instance ID of the item for this action request.</summary>
        [JsonPropertyName("itemId")]
        public long ItemId { get; set; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    public class DestinyPostmasterTransferRequest
    {
        [JsonPropertyName("itemReferenceHash")]
        public uint ItemReferenceHash { get; set; }

        [JsonPropertyName("stackSize")]
        public int StackSize { get; set; }

        /// <summary>The instance ID of the item for this action request.</summary>
        [JsonPropertyName("itemId")]
        public long ItemId { get; set; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    public class DestinyItemSetActionRequest
    {
        [JsonPropertyName("itemIds")]
        public IEnumerable<long> ItemIds { get; set; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    public class DestinyItemStateRequest
    {
        [JsonPropertyName("state")]
        public bool State { get; set; }

        /// <summary>The instance ID of the item for this action request.</summary>
        [JsonPropertyName("itemId")]
        public long ItemId { get; set; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    public class DestinyInsertPlugsActionRequest
    {
        /// <summary>Action token provided by the AwaGetActionToken API call.</summary>
        [JsonPropertyName("actionToken")]
        public string ActionToken { get; set; }

        /// <summary>The instance ID of the item having a plug inserted. Only instanced items can have sockets.</summary>
        [JsonPropertyName("itemInstanceId")]
        public long ItemInstanceId { get; set; }

        /// <summary>The plugs being inserted.</summary>
        [JsonPropertyName("plug")]
        public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry Plug { get; set; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    /// <summary>
    /// Represents all of the data related to a single plug to be inserted.
    /// Note that, while you *can* point to a socket that represents infusion, you will receive an error if you attempt to do so. Come on guys, let's play nice.
    /// </summary>
    public class DestinyInsertPlugsRequestEntry
    {
        /// <summary>
        /// The index into the socket array, which identifies the specific socket being operated on. We also need to know the socketArrayType in order to uniquely identify the socket.
        /// Don't point to or try to insert a plug into an infusion socket. It won't work.
        /// </summary>
        [JsonPropertyName("socketIndex")]
        public int SocketIndex { get; set; }

        /// <summary>This property, combined with the socketIndex, tells us which socket we are referring to (since operations can be performed on both Intrinsic and "default" sockets, and they occupy different arrays in the Inventory Item Definition). I know, I know. Don't give me that look.</summary>
        [JsonPropertyName("socketArrayType")]
        public Destiny.Requests.Actions.DestinySocketArrayType SocketArrayType { get; set; }

        /// <summary>Plugs are never instanced (except in infusion). So with the hash alone, we should be able to: 1) Infer whether the player actually needs to have the item, or if it's a reusable plug 2) Perform any operation needed to use the Plug, including removing the plug item and running reward sheets.</summary>
        [JsonPropertyName("plugItemHash")]
        public uint PlugItemHash { get; set; }
    }

    /// <summary>
    /// If you look in the DestinyInventoryItemDefinition's "sockets" property, you'll see that there are two types of sockets: intrinsic, and "socketEntry."
    /// Unfortunately, because Intrinsic sockets are a whole separate array, it is no longer sufficient to know the index into that array to know which socket we're talking about. You have to know whether it's in the default "socketEntries" or if it's in the "intrinsic" list.
    /// </summary>
    public enum DestinySocketArrayType : int
    {
        Default = 0,
        Intrinsic = 1
    }

    public class DestinyInsertPlugsFreeActionRequest
    {
        /// <summary>The plugs being inserted.</summary>
        [JsonPropertyName("plug")]
        public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry Plug { get; set; }

        /// <summary>The instance ID of the item for this action request.</summary>
        [JsonPropertyName("itemId")]
        public long ItemId { get; set; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }
}