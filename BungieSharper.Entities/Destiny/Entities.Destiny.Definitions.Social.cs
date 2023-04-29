using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Social;

public class DestinySocialCommendationNodeDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>The color associated with this group of commendations.</summary>
    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor Color { get; set; }

    [JsonPropertyName("parentCommendationNodeHash")]
    public uint ParentCommendationNodeHash { get; set; }

    /// <summary>A list of hashes that map to child commendation nodes. Only the root commendations node is expected to have child nodes.</summary>
    [JsonPropertyName("childCommendationNodeHashes")]
    public IEnumerable<uint> ChildCommendationNodeHashes { get; set; }

    /// <summary>A list of hashes that map to child commendations.</summary>
    [JsonPropertyName("childCommendationHashes")]
    public IEnumerable<uint> ChildCommendationHashes { get; set; }

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

public class DestinySocialCommendationDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("cardImagePath")]
    public string CardImagePath { get; set; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor Color { get; set; }

    [JsonPropertyName("displayPriority")]
    public int DisplayPriority { get; set; }

    [JsonPropertyName("activityGivingLimit")]
    public int ActivityGivingLimit { get; set; }

    [JsonPropertyName("parentCommendationNodeHash")]
    public uint ParentCommendationNodeHash { get; set; }

    /// <summary>The display properties for the the activities that this commendation is available in.</summary>
    [JsonPropertyName("displayActivities")]
    public IEnumerable<Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition> DisplayActivities { get; set; }

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