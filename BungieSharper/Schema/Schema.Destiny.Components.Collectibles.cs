using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Components.Collectibles
{
    public class DestinyCollectiblesComponent
    {
        public Dictionary<uint, Schema.Destiny.Components.Collectibles.DestinyCollectibleComponent> collectibles { get; set; }
        /// <summary>The hash for the root presentation node definition of Collection categories.</summary>
        public uint collectionCategoriesRootNodeHash { get; set; }
        /// <summary>The hash for the root presentation node definition of Collection Badges.</summary>
        public uint collectionBadgesRootNodeHash { get; set; }
    }

    public class DestinyCollectibleComponent
    {
        public Schema.Destiny.DestinyCollectibleState state { get; set; }
    }

    public class DestinyProfileCollectiblesComponent
    {
        /// <summary>The list of collectibles determined by the game as having been "recently" acquired.</summary>
        public IEnumerable<uint> recentCollectibleHashes { get; set; }
        /// <summary>
        /// The list of collectibles determined by the game as having been "recently" acquired.
        /// The game client itself actually controls this data, so I personally question whether anyone will get much use out of this: because we can't edit this value through the API. But in case anyone finds it useful, here it is.
        /// </summary>
        public IEnumerable<uint> newnessFlaggedCollectibleHashes { get; set; }
        public Dictionary<uint, Schema.Destiny.Components.Collectibles.DestinyCollectibleComponent> collectibles { get; set; }
        /// <summary>The hash for the root presentation node definition of Collection categories.</summary>
        public uint collectionCategoriesRootNodeHash { get; set; }
        /// <summary>The hash for the root presentation node definition of Collection Badges.</summary>
        public uint collectionBadgesRootNodeHash { get; set; }
    }
}