using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Components.Presentation
{
    public class DestinyPresentationNodesComponent
    {
        public Dictionary<uint, Schema.Destiny.Components.Presentation.DestinyPresentationNodeComponent> nodes { get; set; }
    }

    public class DestinyPresentationNodeComponent
    {
        public Schema.Destiny.DestinyPresentationNodeState state { get; set; }
        /// <summary>An optional property: presentation nodes MAY have objectives, which can be used to infer more human readable data about the progress. However, progressValue and completionValue ought to be considered the canonical values for progress on Progression Nodes.</summary>
        public Schema.Destiny.Quests.DestinyObjectiveProgress objective { get; set; }
        /// <summary>How much of the presentation node is considered to be completed so far by the given character/profile.</summary>
        public int progressValue { get; set; }
        /// <summary>The value at which the presentation node is considered to be completed.</summary>
        public int completionValue { get; set; }
        /// <summary>If available, this is the current score for the record category that this node represents.</summary>
        public int recordCategoryScore { get; set; }
    }
}