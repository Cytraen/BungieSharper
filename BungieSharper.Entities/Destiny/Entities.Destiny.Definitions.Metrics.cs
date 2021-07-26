using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Metrics
{
    public class DestinyMetricDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        [JsonPropertyName("trackingObjectiveHash")]
        public uint TrackingObjectiveHash { get; set; }

        [JsonPropertyName("lowerValueIsBetter")]
        public bool LowerValueIsBetter { get; set; }

        [JsonPropertyName("presentationNodeType")]
        public DestinyPresentationNodeType PresentationNodeType { get; set; }

        [JsonPropertyName("traitIds")]
        public IEnumerable<string> TraitIds { get; set; }

        [JsonPropertyName("traitHashes")]
        public IEnumerable<uint> TraitHashes { get; set; }

        /// <summary>A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.</summary>
        [JsonPropertyName("parentNodeHashes")]
        public IEnumerable<uint> ParentNodeHashes { get; set; }

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
}