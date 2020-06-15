using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Components.Metrics
{
    public class DestinyMetricsComponent
    {
        public Dictionary<uint, Schema.Destiny.Components.Metrics.DestinyMetricComponent> metrics { get; set; }
        public uint metricsRootNodeHash { get; set; }
    }

    public class DestinyMetricComponent
    {
        public bool invisible { get; set; }
        public Schema.Destiny.Quests.DestinyObjectiveProgress objectiveProgress { get; set; }
    }
}