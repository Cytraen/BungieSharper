using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Records
{
    public class DestinyRecordDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>Indicates whether this Record's state is determined on a per-character or on an account-wide basis.</summary>
        [JsonPropertyName("scope")]
        public Destiny.DestinyScope Scope { get; set; }

        [JsonPropertyName("presentationInfo")]
        public Destiny.Definitions.Presentation.DestinyPresentationChildBlock PresentationInfo { get; set; }

        [JsonPropertyName("loreHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? LoreHash { get; set; }

        [JsonPropertyName("objectiveHashes")]
        public IEnumerable<uint> ObjectiveHashes { get; set; }

        [JsonPropertyName("recordValueStyle")]
        public Destiny.DestinyRecordValueStyle RecordValueStyle { get; set; }

        [JsonPropertyName("forTitleGilding")]
        public bool ForTitleGilding { get; set; }

        /// <summary>A hint to show a large icon for a reward</summary>
        [JsonPropertyName("shouldShowLargeIcons")]
        public bool ShouldShowLargeIcons { get; set; }

        [JsonPropertyName("titleInfo")]
        public Destiny.Definitions.Records.DestinyRecordTitleBlock TitleInfo { get; set; }

        [JsonPropertyName("completionInfo")]
        public Destiny.Definitions.Records.DestinyRecordCompletionBlock CompletionInfo { get; set; }

        [JsonPropertyName("stateInfo")]
        public Destiny.Definitions.Records.SchemaRecordStateBlock StateInfo { get; set; }

        [JsonPropertyName("requirements")]
        public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; set; }

        [JsonPropertyName("expirationInfo")]
        public Destiny.Definitions.Records.DestinyRecordExpirationBlock ExpirationInfo { get; set; }

        /// <summary>Some records have multiple 'interval' objectives, and the record may be claimed at each completed interval</summary>
        [JsonPropertyName("intervalInfo")]
        public Destiny.Definitions.Records.DestinyRecordIntervalBlock IntervalInfo { get; set; }

        /// <summary>
        /// If there is any publicly available information about rewards earned for achieving this record, this is the list of those items.
        /// However, note that some records intentionally have "hidden" rewards. These will not be returned in this list.
        /// </summary>
        [JsonPropertyName("rewardItems")]
        public IEnumerable<Destiny.DestinyItemQuantity> RewardItems { get; set; }

        [JsonPropertyName("presentationNodeType")]
        public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

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

    [JsonSerializable(typeof(DestinyRecordDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordDefinitionJsonContext : JsonSerializerContext { }

    public class DestinyRecordTitleBlock
    {
        [JsonPropertyName("hasTitle")]
        public bool HasTitle { get; set; }

        [JsonPropertyName("titlesByGender")]
        public Dictionary<Destiny.DestinyGender, string> TitlesByGender { get; set; }

        /// <summary>For those who prefer to use the definitions.</summary>
        [JsonPropertyName("titlesByGenderHash")]
        public Dictionary<uint, string> TitlesByGenderHash { get; set; }

        [JsonPropertyName("gildingTrackingRecordHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? GildingTrackingRecordHash { get; set; }
    }

    [JsonSerializable(typeof(DestinyRecordTitleBlock))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordTitleBlockJsonContext : JsonSerializerContext { }

    public class DestinyRecordCompletionBlock
    {
        /// <summary>The number of objectives that must be completed before the objective is considered "complete"</summary>
        [JsonPropertyName("partialCompletionObjectiveCountThreshold")]
        public int PartialCompletionObjectiveCountThreshold { get; set; }

        [JsonPropertyName("ScoreValue")]
        public int ScoreValue { get; set; }

        [JsonPropertyName("shouldFireToast")]
        public bool ShouldFireToast { get; set; }

        [JsonPropertyName("toastStyle")]
        public Destiny.DestinyRecordToastStyle ToastStyle { get; set; }
    }

    [JsonSerializable(typeof(DestinyRecordCompletionBlock))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordCompletionBlockJsonContext : JsonSerializerContext { }

    public class SchemaRecordStateBlock
    {
        [JsonPropertyName("featuredPriority")]
        public int FeaturedPriority { get; set; }

        [JsonPropertyName("obscuredString")]
        public string ObscuredString { get; set; }
    }

    [JsonSerializable(typeof(SchemaRecordStateBlock))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SchemaRecordStateBlockJsonContext : JsonSerializerContext { }

    /// <summary>
    /// If this record has an expiration after which it cannot be earned, this is some information about that expiration.
    /// </summary>
    public class DestinyRecordExpirationBlock
    {
        [JsonPropertyName("hasExpiration")]
        public bool HasExpiration { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    [JsonSerializable(typeof(DestinyRecordExpirationBlock))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordExpirationBlockJsonContext : JsonSerializerContext { }

    public class DestinyRecordIntervalBlock
    {
        [JsonPropertyName("intervalObjectives")]
        public IEnumerable<Destiny.Definitions.Records.DestinyRecordIntervalObjective> IntervalObjectives { get; set; }

        [JsonPropertyName("intervalRewards")]
        public IEnumerable<Destiny.Definitions.Records.DestinyRecordIntervalRewards> IntervalRewards { get; set; }

        [JsonPropertyName("originalObjectiveArrayInsertionIndex")]
        public int OriginalObjectiveArrayInsertionIndex { get; set; }
    }

    [JsonSerializable(typeof(DestinyRecordIntervalBlock))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordIntervalBlockJsonContext : JsonSerializerContext { }

    public class DestinyRecordIntervalObjective
    {
        [JsonPropertyName("intervalObjectiveHash")]
        public uint IntervalObjectiveHash { get; set; }

        [JsonPropertyName("intervalScoreValue")]
        public int IntervalScoreValue { get; set; }
    }

    [JsonSerializable(typeof(DestinyRecordIntervalObjective))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordIntervalObjectiveJsonContext : JsonSerializerContext { }

    public class DestinyRecordIntervalRewards
    {
        [JsonPropertyName("intervalRewardItems")]
        public IEnumerable<Destiny.DestinyItemQuantity> IntervalRewardItems { get; set; }
    }

    [JsonSerializable(typeof(DestinyRecordIntervalRewards))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyRecordIntervalRewardsJsonContext : JsonSerializerContext { }
}