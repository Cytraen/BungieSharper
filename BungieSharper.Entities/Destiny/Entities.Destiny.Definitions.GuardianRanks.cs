using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.GuardianRanks;

public class DestinyGuardianRankDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("rankNumber")]
    public int RankNumber { get; set; }

    [JsonPropertyName("presentationNodeHash")]
    public uint PresentationNodeHash { get; set; }

    [JsonPropertyName("foregroundImagePath")]
    public string ForegroundImagePath { get; set; }

    [JsonPropertyName("overlayImagePath")]
    public string OverlayImagePath { get; set; }

    [JsonPropertyName("overlayMaskImagePath")]
    public string OverlayMaskImagePath { get; set; }

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

public class DestinyGuardianRankConstantsDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("rankCount")]
    public int RankCount { get; set; }

    [JsonPropertyName("guardianRankHashes")]
    public IEnumerable<uint> GuardianRankHashes { get; set; }

    [JsonPropertyName("rootNodeHash")]
    public uint RootNodeHash { get; set; }

    [JsonPropertyName("iconBackgrounds")]
    public Destiny.Definitions.GuardianRanks.DestinyGuardianRankIconBackgroundsDefinition IconBackgrounds { get; set; }

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

public class DestinyGuardianRankIconBackgroundsDefinition
{
    [JsonPropertyName("backgroundEmptyBorderedImagePath")]
    public string BackgroundEmptyBorderedImagePath { get; set; }

    [JsonPropertyName("backgroundEmptyBlueGradientBorderedImagePath")]
    public string BackgroundEmptyBlueGradientBorderedImagePath { get; set; }

    [JsonPropertyName("backgroundFilledBlueBorderedImagePath")]
    public string BackgroundFilledBlueBorderedImagePath { get; set; }

    [JsonPropertyName("backgroundFilledBlueGradientBorderedImagePath")]
    public string BackgroundFilledBlueGradientBorderedImagePath { get; set; }

    [JsonPropertyName("backgroundFilledBlueLowAlphaImagePath")]
    public string BackgroundFilledBlueLowAlphaImagePath { get; set; }

    [JsonPropertyName("backgroundFilledBlueMediumAlphaImagePath")]
    public string BackgroundFilledBlueMediumAlphaImagePath { get; set; }

    [JsonPropertyName("backgroundFilledGrayMediumAlphaBorderedImagePath")]
    public string BackgroundFilledGrayMediumAlphaBorderedImagePath { get; set; }

    [JsonPropertyName("backgroundFilledGrayHeavyAlphaBorderedImagePath")]
    public string BackgroundFilledGrayHeavyAlphaBorderedImagePath { get; set; }

    [JsonPropertyName("backgroundFilledWhiteMediumAlphaImagePath")]
    public string BackgroundFilledWhiteMediumAlphaImagePath { get; set; }

    [JsonPropertyName("backgroundFilledWhiteImagePath")]
    public string BackgroundFilledWhiteImagePath { get; set; }

    [JsonPropertyName("backgroundPlateWhiteImagePath")]
    public string BackgroundPlateWhiteImagePath { get; set; }

    [JsonPropertyName("backgroundPlateBlackImagePath")]
    public string BackgroundPlateBlackImagePath { get; set; }

    [JsonPropertyName("backgroundPlateBlackAlphaImagePath")]
    public string BackgroundPlateBlackAlphaImagePath { get; set; }
}