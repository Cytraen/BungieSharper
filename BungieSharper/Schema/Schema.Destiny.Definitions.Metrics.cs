using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Metrics
{
    public class DestinyMetricDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        public uint trackingObjectiveHash { get; set; }
        public bool lowerValueIsBetter { get; set; }
        public Schema.Destiny.DestinyPresentationNodeType presentationNodeType { get; set; }
        public IEnumerable<string> traitIds { get; set; }
        public IEnumerable<uint> traitHashes { get; set; }
        /// <summary>A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.</summary>
        public IEnumerable<uint> parentNodeHashes { get; set; }
        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        public uint hash { get; set; }
        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        public int index { get; set; }
        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        public bool redacted { get; set; }
    }
}