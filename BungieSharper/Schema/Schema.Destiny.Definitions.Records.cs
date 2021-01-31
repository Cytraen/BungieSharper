using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Records
{
    public class DestinyRecordDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>Indicates whether this Record's state is determined on a per-character or on an account-wide basis.</summary>
        public Schema.Destiny.DestinyScope scope { get; set; }
        public Schema.Destiny.Definitions.Presentation.DestinyPresentationChildBlock presentationInfo { get; set; }
        public uint? loreHash { get; set; }
        public IEnumerable<uint> objectiveHashes { get; set; }
        public Schema.Destiny.DestinyRecordValueStyle recordValueStyle { get; set; }
        public Schema.Destiny.Definitions.Records.DestinyRecordTitleBlock titleInfo { get; set; }
        public Schema.Destiny.Definitions.Records.DestinyRecordCompletionBlock completionInfo { get; set; }
        public Schema.Destiny.Definitions.Records.SchemaRecordStateBlock stateInfo { get; set; }
        public Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock requirements { get; set; }
        public Schema.Destiny.Definitions.Records.DestinyRecordExpirationBlock expirationInfo { get; set; }
        /// <summary>Some records have multiple 'interval' objectives, and the record may be claimed at each completed interval</summary>
        public Schema.Destiny.Definitions.Records.DestinyRecordIntervalBlock intervalInfo { get; set; }
        /// <summary>
        /// If there is any publicly available information about rewards earned for achieving this record, this is the list of those items.
        ///  However, note that some records intentionally have "hidden" rewards. These will not be returned in this list.
        /// </summary>
        public IEnumerable<Schema.Destiny.DestinyItemQuantity> rewardItems { get; set; }
        public Schema.Destiny.DestinyPresentationNodeType presentationNodeType { get; set; }
        public IEnumerable<string> traitIds { get; set; }
        public IEnumerable<uint> traitHashes { get; set; }
        /// <summary>A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.</summary>
        public IEnumerable<uint> parentNodeHashes { get; set; }
    }

    public class DestinyRecordTitleBlock
    {
        public bool hasTitle { get; set; }
        public Dictionary<Schema.Destiny.DestinyGender, string> titlesByGender { get; set; }
        /// <summary>For those who prefer to use the definitions.</summary>
        public Dictionary<uint, string> titlesByGenderHash { get; set; }
    }

    public class DestinyRecordCompletionBlock
    {
        /// <summary>The number of objectives that must be completed before the objective is considered "complete"</summary>
        public int partialCompletionObjectiveCountThreshold { get; set; }
        public int ScoreValue { get; set; }
        public bool shouldFireToast { get; set; }
        public Schema.Destiny.DestinyRecordToastStyle toastStyle { get; set; }
    }

    public class SchemaRecordStateBlock
    {
        public int featuredPriority { get; set; }
        public string obscuredString { get; set; }
    }

    /// <summary>
    /// If this record has an expiration after which it cannot be earned, this is some information about that expiration.
    /// </summary>
    public class DestinyRecordExpirationBlock
    {
        public bool hasExpiration { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class DestinyRecordIntervalBlock
    {
        public IEnumerable<Schema.Destiny.Definitions.Records.DestinyRecordIntervalObjective> intervalObjectives { get; set; }
        public int originalObjectiveArrayInsertionIndex { get; set; }
    }

    public class DestinyRecordIntervalObjective
    {
        public uint intervalObjectiveHash { get; set; }
        public int intervalScoreValue { get; set; }
    }
}