using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Character;

/// <summary>
/// Raw data about the customization options chosen for a character's face and appearance.
/// You can look up the relevant class/race/gender combo in DestinyCharacterCustomizationOptionDefinition for the character, and then look up these values within the CustomizationOptions found to pull some data about their choices. Warning: not all of that data is meaningful. Some data has useful icons. Others have nothing, and are only meant for 3D rendering purposes (which we sadly do not expose yet)
/// </summary>
public class DestinyCharacterCustomization
{
    [JsonPropertyName("personality")]
    public uint Personality { get; set; }

    [JsonPropertyName("face")]
    public uint Face { get; set; }

    [JsonPropertyName("skinColor")]
    public uint SkinColor { get; set; }

    [JsonPropertyName("lipColor")]
    public uint LipColor { get; set; }

    [JsonPropertyName("eyeColor")]
    public uint EyeColor { get; set; }

    [JsonPropertyName("hairColors")]
    public IEnumerable<uint> HairColors { get; set; }

    [JsonPropertyName("featureColors")]
    public IEnumerable<uint> FeatureColors { get; set; }

    [JsonPropertyName("decalColor")]
    public uint DecalColor { get; set; }

    [JsonPropertyName("wearHelmet")]
    public bool WearHelmet { get; set; }

    [JsonPropertyName("hairIndex")]
    public int HairIndex { get; set; }

    [JsonPropertyName("featureIndex")]
    public int FeatureIndex { get; set; }

    [JsonPropertyName("decalIndex")]
    public int DecalIndex { get; set; }
}

/// <summary>
/// A minimal view of a character's equipped items, for the purpose of rendering a summary screen or showing the character in 3D.
/// </summary>
public class DestinyCharacterPeerView
{
    [JsonPropertyName("equipment")]
    public IEnumerable<Destiny.Character.DestinyItemPeerView> Equipment { get; set; }
}

/// <summary>
/// Bare minimum summary information for an item, for the sake of 3D rendering the item.
/// </summary>
public class DestinyItemPeerView
{
    /// <summary>The hash identifier of the item in question. Use it to look up the DestinyInventoryItemDefinition of the item for static rendering data.</summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    /// <summary>The list of dyes that have been applied to this item.</summary>
    [JsonPropertyName("dyes")]
    public IEnumerable<Destiny.DyeReference> Dyes { get; set; }
}