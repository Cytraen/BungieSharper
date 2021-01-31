using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Records
{
    public class DestinyRecordDefinition : Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>Indicates whether this Record's state is determined on a per-character or on an account-wide basis.</summary>
        public Destiny.DestinyScope scope { get; set; }

        public Destiny.Definitions.Presentation.DestinyPresentationChildBlock presentationInfo { get; set; }

        public uint? loreHash { get; set; }

        public IEnumerable<uint> objectiveHashes { get; set; }

        public Destiny.DestinyRecordValueStyle recordValueStyle { get; set; }

        public Destiny.Definitions.Records.DestinyRecordTitleBlock titleInfo { get; set; }

        public Destiny.Definitions.Records.DestinyRecordCompletionBlock completionInfo { get; set; }

        public Destiny.Definitions.Records.SchemaRecordStateBlock stateInfo { get; set; }

        public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock requirements { get; set; }

        public Destiny.Definitions.Records.DestinyRecordExpirationBlock expirationInfo { get; set; }

        /// <summary>Some records have multiple 'interval' objectives, and the record may be claimed at each completed interval</summary>
        public Destiny.Definitions.Records.DestinyRecordIntervalBlock intervalInfo { get; set; }

        /// <summary>
        /// If there is any publicly available information about rewards earned for achieving this record, this is the list of those items.
        ///  However, note that some records intentionally have "hidden" rewards. These will not be returned in this list.
        /// </summary>
        public IEnumerable<Destiny.DestinyItemQuantity> rewardItems { get; set; }
    }

    public class DestinyRecordTitleBlock
    {
        public bool hasTitle { get; set; }

        public Dictionary<Destiny.DestinyGender, string> titlesByGender { get; set; }

        /// <summary>For those who prefer to use the definitions.</summary>
        public Dictionary<uint, string> titlesByGenderHash { get; set; }
    }

    public class DestinyRecordCompletionBlock
    {
        /// <summary>The number of objectives that must be completed before the objective is considered "complete"</summary>
        public int partialCompletionObjectiveCountThreshold { get; set; }

        public int ScoreValue { get; set; }

        public bool shouldFireToast { get; set; }

        public Destiny.DestinyRecordToastStyle toastStyle { get; set; }
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
        public IEnumerable<Destiny.Definitions.Records.DestinyRecordIntervalObjective> intervalObjectives { get; set; }

        public int originalObjectiveArrayInsertionIndex { get; set; }
    }

    public class DestinyRecordIntervalObjective
    {
        public uint intervalObjectiveHash { get; set; }

        public int intervalScoreValue { get; set; }
    }
}