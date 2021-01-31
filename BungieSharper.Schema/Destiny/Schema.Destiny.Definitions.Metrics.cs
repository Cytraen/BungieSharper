using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Metrics
{
    public class DestinyMetricDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        public uint trackingObjectiveHash { get; set; }

        public bool lowerValueIsBetter { get; set; }

        public Schema.Destiny.DestinyPresentationNodeType presentationNodeType { get; set; }

        public IEnumerable<string> traitIds { get; set; }

        public IEnumerable<uint> traitHashes { get; set; }

        /// <summary>A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.</summary>
        public IEnumerable<uint> parentNodeHashes { get; set; }
    }
}