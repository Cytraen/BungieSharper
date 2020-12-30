using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Presentation
{

    /// <summary>
    /// This is the base class for all presentation system children. Presentation Nodes, Records, Collectibles, and Metrics.
    /// </summary>
    public class DestinyPresentationNodeBaseDefinition
    {
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

    public class DestinyScoredPresentationNodeBaseDefinition
    {
        public int maxCategoryRecordScore { get; set; }
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

    /// <summary>
    /// A PresentationNode is an entity that represents a logical grouping of other entities visually/organizationally.
    /// For now, Presentation Nodes may contain the following... but it may be used for more in the future:
    /// - Collectibles - Records (Or, as the public will call them, "Triumphs." Don't ask me why we're overloading the term "Triumph", it still hurts me to think about it) - Metrics (aka Stat Trackers) - Other Presentation Nodes, allowing a tree of Presentation Nodes to be created
    /// Part of me wants to break these into conceptual definitions per entity being collected, but the possibility of these different types being mixed in the same UI and the possibility that it could actually be more useful to return the "bare metal" presentation node concept has resulted in me deciding against that for the time being.
    /// We'll see if I come to regret this as well.
    /// </summary>
    public class DestinyPresentationNodeDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>The original icon for this presentation node, before we futzed with it.</summary>
        public string originalIcon { get; set; }
        /// <summary>Some presentation nodes are meant to be explicitly shown on the "root" or "entry" screens for the feature to which they are related. You should use this icon when showing them on such a view, if you have a similar "entry point" view in your UI. If you don't have a UI, then I guess it doesn't matter either way does it?</summary>
        public string rootViewIcon { get; set; }
        public Schema.Destiny.DestinyPresentationNodeType nodeType { get; set; }
        /// <summary>Indicates whether this presentation node's state is determined on a per-character or on an account-wide basis.</summary>
        public Schema.Destiny.DestinyScope scope { get; set; }
        /// <summary>If this presentation node shows a related objective (for instance, if it tracks the progress of its children), the objective being tracked is indicated here.</summary>
        public uint objectiveHash { get; set; }
        /// <summary>If this presentation node has an associated "Record" that you can accomplish for completing its children, this is the identifier of that Record.</summary>
        public uint completionRecordHash { get; set; }
        /// <summary>The child entities contained by this presentation node.</summary>
        public Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeChildrenBlock children { get; set; }
        /// <summary>A hint for how to display this presentation node when it's shown in a list.</summary>
        public Schema.Destiny.DestinyPresentationDisplayStyle displayStyle { get; set; }
        /// <summary>A hint for how to display this presentation node when it's shown in its own detail screen.</summary>
        public Schema.Destiny.DestinyPresentationScreenStyle screenStyle { get; set; }
        /// <summary>The requirements for being able to interact with this presentation node and its children.</summary>
        public Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock requirements { get; set; }
        /// <summary>If this presentation node has children, but the game doesn't let you inspect the details of those children, that is indicated here.</summary>
        public bool disableChildSubscreenNavigation { get; set; }
        public int maxCategoryRecordScore { get; set; }
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

    /// <summary>
    /// As/if presentation nodes begin to host more entities as children, these lists will be added to. One list property exists per type of entity that can be treated as a child of this presentation node, and each holds the identifier of the entity and any associated information needed to display the UI for that entity (if anything)
    /// </summary>
    public class DestinyPresentationNodeChildrenBlock
    {
        public IEnumerable<Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeChildEntry> presentationNodes { get; set; }
        public IEnumerable<Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeCollectibleChildEntry> collectibles { get; set; }
        public IEnumerable<Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeRecordChildEntry> records { get; set; }
        public IEnumerable<Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeMetricChildEntry> metrics { get; set; }
    }

    public class DestinyPresentationNodeChildEntry
    {
        public uint presentationNodeHash { get; set; }
    }

    public class DestinyPresentationNodeCollectibleChildEntry
    {
        public uint collectibleHash { get; set; }
    }

    /// <summary>
    /// Presentation nodes can be restricted by various requirements. This defines the rules of those requirements, and the message(s) to be shown if these requirements aren't met.
    /// </summary>
    public class DestinyPresentationNodeRequirementsBlock
    {
        /// <summary>If this node is not accessible due to Entitlements (for instance, you don't own the required game expansion), this is the message to show.</summary>
        public string entitlementUnavailableMessage { get; set; }
    }

    public class DestinyPresentationChildBlock
    {
        public Schema.Destiny.DestinyPresentationNodeType presentationNodeType { get; set; }
        public IEnumerable<uint> parentPresentationNodeHashes { get; set; }
        public Schema.Destiny.DestinyPresentationDisplayStyle displayStyle { get; set; }
    }

    public class DestinyPresentationNodeRecordChildEntry
    {
        public uint recordHash { get; set; }
    }

    public class DestinyPresentationNodeMetricChildEntry
    {
        public uint metricHash { get; set; }
    }
}