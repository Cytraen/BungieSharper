using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.Collectibles
{
    public class DestinyCollectiblesComponent
    {
        [JsonPropertyName("collectibles")]
        public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent> Collectibles { get; set; }

        /// <summary>The hash for the root presentation node definition of Collection categories.</summary>
        [JsonPropertyName("collectionCategoriesRootNodeHash")]
        public uint CollectionCategoriesRootNodeHash { get; set; }

        /// <summary>The hash for the root presentation node definition of Collection Badges.</summary>
        [JsonPropertyName("collectionBadgesRootNodeHash")]
        public uint CollectionBadgesRootNodeHash { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyCollectiblesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyCollectiblesComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyCollectibleComponent
    {
        [JsonPropertyName("state")]
        public Destiny.DestinyCollectibleState State { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyCollectibleComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyCollectibleComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyProfileCollectiblesComponent
    {
        /// <summary>The list of collectibles determined by the game as having been "recently" acquired.</summary>
        [JsonPropertyName("recentCollectibleHashes")]
        public IEnumerable<uint> RecentCollectibleHashes { get; set; }

        /// <summary>
        /// The list of collectibles determined by the game as having been "recently" acquired.
        /// The game client itself actually controls this data, so I personally question whether anyone will get much use out of this: because we can't edit this value through the API. But in case anyone finds it useful, here it is.
        /// </summary>
        [JsonPropertyName("newnessFlaggedCollectibleHashes")]
        public IEnumerable<uint> NewnessFlaggedCollectibleHashes { get; set; }

        [JsonPropertyName("collectibles")]
        public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent> Collectibles { get; set; }

        /// <summary>The hash for the root presentation node definition of Collection categories.</summary>
        [JsonPropertyName("collectionCategoriesRootNodeHash")]
        public uint CollectionCategoriesRootNodeHash { get; set; }

        /// <summary>The hash for the root presentation node definition of Collection Badges.</summary>
        [JsonPropertyName("collectionBadgesRootNodeHash")]
        public uint CollectionBadgesRootNodeHash { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyProfileCollectiblesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyProfileCollectiblesComponentJsonContext : JsonSerializerContext { }
#endif
}