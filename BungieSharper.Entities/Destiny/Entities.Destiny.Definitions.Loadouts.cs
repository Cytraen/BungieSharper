using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Loadouts;

public class DestinyLoadoutColorDefinition
{
    [JsonPropertyName("colorImagePath")]
    public string ColorImagePath { get; set; }

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

public class DestinyLoadoutIconDefinition
{
    [JsonPropertyName("iconImagePath")]
    public string IconImagePath { get; set; }

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

public class DestinyLoadoutNameDefinition
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

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

public class DestinyLoadoutConstantsDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>This is the same icon as the one in the display properties, offered here as well with a more descriptive name.</summary>
    [JsonPropertyName("whiteIconImagePath")]
    public string WhiteIconImagePath { get; set; }

    /// <summary>This is a color-inverted version of the whiteIconImagePath.</summary>
    [JsonPropertyName("blackIconImagePath")]
    public string BlackIconImagePath { get; set; }

    /// <summary>The maximum number of loadouts available to each character. The loadouts component API response can return fewer loadouts than this, as more loadouts are unlocked by reaching higher Guardian Ranks.</summary>
    [JsonPropertyName("loadoutCountPerCharacter")]
    public int LoadoutCountPerCharacter { get; set; }

    /// <summary>A list of the socket category hashes to be filtered out of loadout item preview displays.</summary>
    [JsonPropertyName("loadoutPreviewFilterOutSocketCategoryHashes")]
    public IEnumerable<uint> LoadoutPreviewFilterOutSocketCategoryHashes { get; set; }

    /// <summary>A list of the socket type hashes to be filtered out of loadout item preview displays.</summary>
    [JsonPropertyName("loadoutPreviewFilterOutSocketTypeHashes")]
    public IEnumerable<uint> LoadoutPreviewFilterOutSocketTypeHashes { get; set; }

    /// <summary>A list of the loadout name hashes in index order, for convenience.</summary>
    [JsonPropertyName("loadoutNameHashes")]
    public IEnumerable<uint> LoadoutNameHashes { get; set; }

    /// <summary>A list of the loadout icon hashes in index order, for convenience.</summary>
    [JsonPropertyName("loadoutIconHashes")]
    public IEnumerable<uint> LoadoutIconHashes { get; set; }

    /// <summary>A list of the loadout color hashes in index order, for convenience.</summary>
    [JsonPropertyName("loadoutColorHashes")]
    public IEnumerable<uint> LoadoutColorHashes { get; set; }

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