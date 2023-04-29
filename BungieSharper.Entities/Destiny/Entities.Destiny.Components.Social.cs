using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.Social;

public class DestinySocialCommendationsComponent
{
    [JsonPropertyName("totalScore")]
    public int TotalScore { get; set; }

    [JsonPropertyName("scoreDetailValues")]
    public IEnumerable<int> ScoreDetailValues { get; set; }

    [JsonPropertyName("commendationNodeScoresByHash")]
    public Dictionary<uint, int> CommendationNodeScoresByHash { get; set; }

    [JsonPropertyName("commendationScoresByHash")]
    public Dictionary<uint, int> CommendationScoresByHash { get; set; }
}