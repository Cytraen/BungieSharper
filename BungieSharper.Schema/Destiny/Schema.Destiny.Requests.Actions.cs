using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Requests.Actions
{
    public class DestinyActionRequest
    {
        public BungieMembershipType membershipType { get; set; }
    }

    public class DestinyCharacterActionRequest : Destiny.Requests.Actions.DestinyActionRequest
    {
        public long characterId { get; set; }
    }

    public class DestinyItemActionRequest : Destiny.Requests.Actions.DestinyActionRequest
    {
        public long itemId { get; set; }

        public long characterId { get; set; }
    }

    public class DestinyPostmasterTransferRequest : Destiny.Requests.Actions.DestinyActionRequest
    {
        public uint itemReferenceHash { get; set; }

        public int stackSize { get; set; }

        public long itemId { get; set; }

        public long characterId { get; set; }
    }

    public class DestinyItemSetActionRequest : Destiny.Requests.Actions.DestinyActionRequest
    {
        public IEnumerable<long> itemIds { get; set; }

        public long characterId { get; set; }
    }

    public class DestinyItemStateRequest
    {
        public bool state { get; set; }

        public long itemId { get; set; }

        public long characterId { get; set; }

        public BungieMembershipType membershipType { get; set; }
    }

    public class DestinyInsertPlugsActionRequest : Destiny.Requests.Actions.DestinyActionRequest
    {
        /// <summary>Action token provided by the AwaGetActionToken API call.</summary>
        public string actionToken { get; set; }

        /// <summary>The instance ID of the item having a plug inserted. Only instanced items can have sockets.</summary>
        public long itemInstanceId { get; set; }

        /// <summary>The plugs being inserted.</summary>
        public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry plug { get; set; }

        public long characterId { get; set; }
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
        public int socketIndex { get; set; }

        /// <summary>This property, combined with the socketIndex, tells us which socket we are referring to (since operations can be performed on both Intrinsic and "default" sockets, and they occupy different arrays in the Inventory Item Definition). I know, I know. Don't give me that look.</summary>
        public Destiny.Requests.Actions.DestinySocketArrayType socketArrayType { get; set; }

        /// <summary>Plugs are never instanced (except in infusion). So with the hash alone, we should be able to: 1) Infer whether the player actually needs to have the item, or if it's a reusable plug 2) Perform any operation needed to use the Plug, including removing the plug item and running reward sheets.</summary>
        public uint plugItemHash { get; set; }
    }

    /// <summary>
    /// If you look in the DestinyInventoryItemDefinition's "sockets" property, you'll see that there are two types of sockets: intrinsic, and "socketEntry."
    /// Unfortunately, because Intrinsic sockets are a whole separate array, it is no longer sufficient to know the index into that array to know which socket we're talking about. You have to know whether it's in the default "socketEntries" or if it's in the "intrinsic" list.
    /// </summary>
    public enum DestinySocketArrayType
    {
        Default = 0,

        Intrinsic = 1
    }
}