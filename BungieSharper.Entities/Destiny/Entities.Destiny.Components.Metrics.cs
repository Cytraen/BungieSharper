using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.Metrics;

public class DestinyMetricsComponent
{
    [JsonPropertyName("metrics")]
    public Dictionary<uint, Destiny.Components.Metrics.DestinyMetricComponent> Metrics { get; set; }

    [JsonPropertyName("metricsRootNodeHash")]
    public uint MetricsRootNodeHash { get; set; }
}

public class DestinyMetricComponent
{
    [JsonPropertyName("invisible")]
    public bool Invisible { get; set; }

    [JsonPropertyName("objectiveProgress")]
    public Destiny.Quests.DestinyObjectiveProgress ObjectiveProgress { get; set; }
}