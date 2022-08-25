﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Collectibles;

/// <summary>
/// Defines a
/// </summary>
public class DestinyCollectibleDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>Indicates whether the state of this Collectible is determined on a per-character or on an account-wide basis.</summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; set; }

    /// <summary>A human readable string for a hint about how to acquire the item.</summary>
    [JsonPropertyName("sourceString")]
    public string SourceString { get; set; }

    /// <summary>
    /// This is a hash identifier we are building on the BNet side in an attempt to let people group collectibles by similar sources.
    /// I can't promise that it's going to be 100% accurate, but if the designers were consistent in assigning the same source strings to items with the same sources, it *ought to* be. No promises though.
    /// This hash also doesn't relate to an actual definition, just to note: we've got nothing useful other than the source string for this data.
    /// </summary>
    [JsonPropertyName("sourceHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? SourceHash { get; set; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    [JsonPropertyName("acquisitionInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleAcquisitionBlock AcquisitionInfo { get; set; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleStateBlock StateInfo { get; set; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock PresentationInfo { get; set; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("traitIds")]
    public IEnumerable<string> TraitIds { get; set; }

    [JsonPropertyName("traitHashes")]
    public IEnumerable<uint> TraitHashes { get; set; }

    /// <summary>A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.</summary>
    [JsonPropertyName("parentNodeHashes")]
    public IEnumerable<uint> ParentNodeHashes { get; set; }

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

public class DestinyCollectibleAcquisitionBlock
{
    [JsonPropertyName("acquireMaterialRequirementHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? AcquireMaterialRequirementHash { get; set; }

    [JsonPropertyName("acquireTimestampUnlockValueHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? AcquireTimestampUnlockValueHash { get; set; }
}

public class DestinyCollectibleStateBlock
{
    [JsonPropertyName("obscuredOverrideItemHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ObscuredOverrideItemHash { get; set; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; set; }
}