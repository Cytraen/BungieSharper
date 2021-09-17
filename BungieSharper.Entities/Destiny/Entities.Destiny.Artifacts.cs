using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Artifacts
{
    /// <summary>
    /// Represents a Seasonal Artifact and all data related to it for the requested Account.
    /// It can be combined with Character-scoped data for a full picture of what a character has available/has chosen, or just these settings can be used for overview information.
    /// </summary>
    public class DestinyArtifactProfileScoped
    {
        [JsonPropertyName("artifactHash")]
        public uint ArtifactHash { get; set; }

        [JsonPropertyName("pointProgression")]
        public Destiny.DestinyProgression PointProgression { get; set; }

        [JsonPropertyName("pointsAcquired")]
        public int PointsAcquired { get; set; }

        [JsonPropertyName("powerBonusProgression")]
        public Destiny.DestinyProgression PowerBonusProgression { get; set; }

        [JsonPropertyName("powerBonus")]
        public int PowerBonus { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyArtifactProfileScoped))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyArtifactProfileScopedJsonContext : JsonSerializerContext { }
#endif

    public class DestinyArtifactCharacterScoped
    {
        [JsonPropertyName("artifactHash")]
        public uint ArtifactHash { get; set; }

        [JsonPropertyName("pointsUsed")]
        public int PointsUsed { get; set; }

        [JsonPropertyName("resetCount")]
        public int ResetCount { get; set; }

        [JsonPropertyName("tiers")]
        public IEnumerable<Destiny.Artifacts.DestinyArtifactTier> Tiers { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyArtifactCharacterScoped))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyArtifactCharacterScopedJsonContext : JsonSerializerContext { }
#endif

    public class DestinyArtifactTier
    {
        [JsonPropertyName("tierHash")]
        public uint TierHash { get; set; }

        [JsonPropertyName("isUnlocked")]
        public bool IsUnlocked { get; set; }

        [JsonPropertyName("pointsToUnlock")]
        public int PointsToUnlock { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<Destiny.Artifacts.DestinyArtifactTierItem> Items { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyArtifactTier))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyArtifactTierJsonContext : JsonSerializerContext { }
#endif

    public class DestinyArtifactTierItem
    {
        [JsonPropertyName("itemHash")]
        public uint ItemHash { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyArtifactTierItem))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyArtifactTierItemJsonContext : JsonSerializerContext { }
#endif
}