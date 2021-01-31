using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Artifacts
{
    /// <summary>
    /// Represents a Seasonal Artifact and all data related to it for the requested Account.
    /// It can be combined with Character-scoped data for a full picture of what a character has available/has chosen, or just these settings can be used for overview information.
    /// </summary>
    public class DestinyArtifactProfileScoped
    {
        public uint artifactHash { get; set; }

        public Destiny.DestinyProgression pointProgression { get; set; }

        public int pointsAcquired { get; set; }

        public Destiny.DestinyProgression powerBonusProgression { get; set; }

        public int powerBonus { get; set; }
    }

    public class DestinyArtifactCharacterScoped
    {
        public uint artifactHash { get; set; }

        public int pointsUsed { get; set; }

        public int resetCount { get; set; }

        public IEnumerable<Destiny.Artifacts.DestinyArtifactTier> tiers { get; set; }
    }

    public class DestinyArtifactTier
    {
        public uint tierHash { get; set; }

        public bool isUnlocked { get; set; }

        public int pointsToUnlock { get; set; }

        public IEnumerable<Destiny.Artifacts.DestinyArtifactTierItem> items { get; set; }
    }

    public class DestinyArtifactTierItem
    {
        public uint itemHash { get; set; }

        public bool isActive { get; set; }
    }
}