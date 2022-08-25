using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Artifacts;

/// <summary>
/// Represents known info about a Destiny Artifact.
/// We cannot guarantee that artifact definitions will be immutable between seasons - in fact, we've been told that they will be replaced between seasons. But this definition is built both to minimize the amount of lookups for related data that have to occur, and is built in hope that, if this plan changes, we will be able to accommodate it more easily.
/// </summary>
public class DestinyArtifactDefinition
{
    /// <summary>Any basic display info we know about the Artifact. Currently sourced from a related inventory item, but the source of this data is subject to change.</summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>Any Geometry/3D info we know about the Artifact. Currently sourced from a related inventory item's gearset information, but the source of this data is subject to change.</summary>
    [JsonPropertyName("translationBlock")]
    public Destiny.Definitions.DestinyItemTranslationBlockDefinition TranslationBlock { get; set; }

    /// <summary>Any Tier/Rank data related to this artifact, listed in display order.  Currently sourced from a Vendor, but this source is subject to change.</summary>
    [JsonPropertyName("tiers")]
    public IEnumerable<Destiny.Definitions.Artifacts.DestinyArtifactTierDefinition> Tiers { get; set; }

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

public class DestinyArtifactTierDefinition
{
    /// <summary>An identifier, unique within the Artifact, for this specific tier.</summary>
    [JsonPropertyName("tierHash")]
    public uint TierHash { get; set; }

    /// <summary>The human readable title of this tier, if any.</summary>
    [JsonPropertyName("displayTitle")]
    public string DisplayTitle { get; set; }

    /// <summary>A string representing the localized minimum requirement text for this Tier, if any.</summary>
    [JsonPropertyName("progressRequirementMessage")]
    public string ProgressRequirementMessage { get; set; }

    /// <summary>The items that can be earned within this tier.</summary>
    [JsonPropertyName("items")]
    public IEnumerable<Destiny.Definitions.Artifacts.DestinyArtifactTierItemDefinition> Items { get; set; }

    /// <summary>The minimum number of "unlock points" that you must have used before you can unlock items from this tier.</summary>
    [JsonPropertyName("minimumUnlockPointsUsedRequirement")]
    public int MinimumUnlockPointsUsedRequirement { get; set; }
}

public class DestinyArtifactTierItemDefinition
{
    /// <summary>The identifier of the Plug Item unlocked by activating this item in the Artifact.</summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }
}