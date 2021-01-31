using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Artifacts
{
    /// <summary>
    /// Represents known info about a Destiny Artifact.
    /// We cannot guarantee that artifact definitions will be immutable between seasons - in fact, we've been told that they will be replaced between seasons. But this definition is built both to minimize the amount of lookups for related data that have to occur, and is built in hope that, if this plan changes, we will be able to accommodate it more easily.
    /// </summary>
    public class DestinyArtifactDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>Any basic display info we know about the Artifact. Currently sourced from a related inventory item, but the source of this data is subject to change.</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>Any Geometry/3D info we know about the Artifact. Currently sourced from a related inventory item's gearset information, but the source of this data is subject to change.</summary>
        public Destiny.Definitions.DestinyItemTranslationBlockDefinition translationBlock { get; set; }

        /// <summary>Any Tier/Rank data related to this artifact, listed in display order.  Currently sourced from a Vendor, but this source is subject to change.</summary>
        public IEnumerable<Destiny.Definitions.Artifacts.DestinyArtifactTierDefinition> tiers { get; set; }
    }

    public class DestinyArtifactTierDefinition
    {
        /// <summary>An identifier, unique within the Artifact, for this specific tier.</summary>
        public uint tierHash { get; set; }

        /// <summary>The human readable title of this tier, if any.</summary>
        public string displayTitle { get; set; }

        /// <summary>A string representing the localized minimum requirement text for this Tier, if any.</summary>
        public string progressRequirementMessage { get; set; }

        /// <summary>The items that can be earned within this tier.</summary>
        public IEnumerable<Destiny.Definitions.Artifacts.DestinyArtifactTierItemDefinition> items { get; set; }

        /// <summary>The minimum number of "unlock points" that you must have used before you can unlock items from this tier.</summary>
        public int minimumUnlockPointsUsedRequirement { get; set; }
    }

    public class DestinyArtifactTierItemDefinition
    {
        /// <summary>The identifier of the Plug Item unlocked by activating this item in the Artifact.</summary>
        public uint itemHash { get; set; }
    }
}