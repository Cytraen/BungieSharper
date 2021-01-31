using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Collectibles
{

    /// <summary>
    /// Defines a
    /// </summary>
    public class DestinyCollectibleDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>Indicates whether the state of this Collectible is determined on a per-character or on an account-wide basis.</summary>
        public Schema.Destiny.DestinyScope scope { get; set; }
        /// <summary>A human readable string for a hint about how to acquire the item.</summary>
        public string sourceString { get; set; }
        /// <summary>
        /// This is a hash identifier we are building on the BNet side in an attempt to let people group collectibles by similar sources.
        /// I can't promise that it's going to be 100% accurate, but if the designers were consistent in assigning the same source strings to items with the same sources, it *ought to* be. No promises though.
        /// This hash also doesn't relate to an actual definition, just to note: we've got nothing useful other than the source string for this data.
        /// </summary>
        public uint? sourceHash { get; set; }
        public uint itemHash { get; set; }
        public Schema.Destiny.Definitions.Collectibles.DestinyCollectibleAcquisitionBlock acquisitionInfo { get; set; }
        public Schema.Destiny.Definitions.Collectibles.DestinyCollectibleStateBlock stateInfo { get; set; }
        public Schema.Destiny.Definitions.Presentation.DestinyPresentationChildBlock presentationInfo { get; set; }
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

    public class DestinyCollectibleAcquisitionBlock
    {
        public uint? acquireMaterialRequirementHash { get; set; }
        public uint? acquireTimestampUnlockValueHash { get; set; }
    }

    public class DestinyCollectibleStateBlock
    {
        public uint? obscuredOverrideItemHash { get; set; }
        public Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock requirements { get; set; }
    }
}