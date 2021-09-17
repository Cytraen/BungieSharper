using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.Records
{
    public class DestinyRecordsComponent
    {
        [JsonPropertyName("records")]
        public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; set; }

        /// <summary>The hash for the root presentation node definition of Triumph categories.</summary>
        [JsonPropertyName("recordCategoriesRootNodeHash")]
        public uint RecordCategoriesRootNodeHash { get; set; }

        /// <summary>The hash for the root presentation node definition of Triumph Seals.</summary>
        [JsonPropertyName("recordSealsRootNodeHash")]
        public uint RecordSealsRootNodeHash { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyRecordsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyRecordComponent
    {
        [JsonPropertyName("state")]
        public Destiny.DestinyRecordState State { get; set; }

        [JsonPropertyName("objectives")]
        public IEnumerable<Destiny.Quests.DestinyObjectiveProgress> Objectives { get; set; }

        [JsonPropertyName("intervalObjectives")]
        public IEnumerable<Destiny.Quests.DestinyObjectiveProgress> IntervalObjectives { get; set; }

        [JsonPropertyName("intervalsRedeemedCount")]
        public int IntervalsRedeemedCount { get; set; }

        /// <summary>If available, this is the number of times this record has been completed. For example, the number of times a seal title has been gilded.</summary>
        [JsonPropertyName("completedCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CompletedCount { get; set; }

        /// <summary>If available, a list that describes which reward rewards should be shown (true) or hidden (false). This property is for regular record rewards, and not for interval objective rewards.</summary>
        [JsonPropertyName("rewardVisibilty")]
        public IEnumerable<bool> RewardVisibilty { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyRecordComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyProfileRecordsComponent
    {
        /// <summary>Your 'active' Triumphs score, maintained for backwards compatibility.</summary>
        [JsonPropertyName("score")]
        public int Score { get; set; }

        /// <summary>Your 'active' Triumphs score.</summary>
        [JsonPropertyName("activeScore")]
        public int ActiveScore { get; set; }

        /// <summary>Your 'legacy' Triumphs score.</summary>
        [JsonPropertyName("legacyScore")]
        public int LegacyScore { get; set; }

        /// <summary>Your 'lifetime' Triumphs score.</summary>
        [JsonPropertyName("lifetimeScore")]
        public int LifetimeScore { get; set; }

        /// <summary>If this profile is tracking a record, this is the hash identifier of the record it is tracking.</summary>
        [JsonPropertyName("trackedRecordHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? TrackedRecordHash { get; set; }

        [JsonPropertyName("records")]
        public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; set; }

        /// <summary>The hash for the root presentation node definition of Triumph categories.</summary>
        [JsonPropertyName("recordCategoriesRootNodeHash")]
        public uint RecordCategoriesRootNodeHash { get; set; }

        /// <summary>The hash for the root presentation node definition of Triumph Seals.</summary>
        [JsonPropertyName("recordSealsRootNodeHash")]
        public uint RecordSealsRootNodeHash { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyProfileRecordsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyProfileRecordsComponentJsonContext : JsonSerializerContext { }
#endif

    public class DestinyCharacterRecordsComponent
    {
        [JsonPropertyName("featuredRecordHashes")]
        public IEnumerable<uint> FeaturedRecordHashes { get; set; }

        [JsonPropertyName("records")]
        public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; set; }

        /// <summary>The hash for the root presentation node definition of Triumph categories.</summary>
        [JsonPropertyName("recordCategoriesRootNodeHash")]
        public uint RecordCategoriesRootNodeHash { get; set; }

        /// <summary>The hash for the root presentation node definition of Triumph Seals.</summary>
        [JsonPropertyName("recordSealsRootNodeHash")]
        public uint RecordSealsRootNodeHash { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyCharacterRecordsComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyCharacterRecordsComponentJsonContext : JsonSerializerContext { }
#endif
}