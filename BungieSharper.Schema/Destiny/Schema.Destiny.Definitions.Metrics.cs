namespace BungieSharper.Schema.Destiny.Definitions.Metrics
{
    public class DestinyMetricDefinition : Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        public uint trackingObjectiveHash { get; set; }

        public bool lowerValueIsBetter { get; set; }
    }
}