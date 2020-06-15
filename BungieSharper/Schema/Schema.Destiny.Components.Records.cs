using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Components.Records
{
    public class DestinyRecordsComponent
    {
        public Dictionary<uint, Schema.Destiny.Components.Records.DestinyRecordComponent> records { get; set; }
        /// <summary>The hash for the root presentation node definition of Triumph categories.</summary>
        public uint recordCategoriesRootNodeHash { get; set; }
        /// <summary>The hash for the root presentation node definition of Triumph Seals.</summary>
        public uint recordSealsRootNodeHash { get; set; }
    }

    public class DestinyRecordComponent
    {
        public Schema.Destiny.DestinyRecordState state { get; set; }
        public IEnumerable<Schema.Destiny.Quests.DestinyObjectiveProgress> objectives { get; set; }
        public IEnumerable<Schema.Destiny.Quests.DestinyObjectiveProgress> intervalObjectives { get; set; }
        public int intervalsRedeemedCount { get; set; }
    }

    public class DestinyProfileRecordsComponent
    {
        /// <summary>Your "Triumphs" score.</summary>
        public int score { get; set; }
        /// <summary>If this profile is tracking a record, this is the hash identifier of the record it is tracking.</summary>
        public uint trackedRecordHash { get; set; }
        public Dictionary<uint, Schema.Destiny.Components.Records.DestinyRecordComponent> records { get; set; }
        /// <summary>The hash for the root presentation node definition of Triumph categories.</summary>
        public uint recordCategoriesRootNodeHash { get; set; }
        /// <summary>The hash for the root presentation node definition of Triumph Seals.</summary>
        public uint recordSealsRootNodeHash { get; set; }
    }

    public class DestinyCharacterRecordsComponent
    {
        public IEnumerable<uint> featuredRecordHashes { get; set; }
        public Dictionary<uint, Schema.Destiny.Components.Records.DestinyRecordComponent> records { get; set; }
        /// <summary>The hash for the root presentation node definition of Triumph categories.</summary>
        public uint recordCategoriesRootNodeHash { get; set; }
        /// <summary>The hash for the root presentation node definition of Triumph Seals.</summary>
        public uint recordSealsRootNodeHash { get; set; }
    }
}