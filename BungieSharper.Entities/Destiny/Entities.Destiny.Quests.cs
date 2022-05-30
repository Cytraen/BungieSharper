using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Quests
{
    /// <summary>
    /// Returns data about a character's status with a given Objective. Combine with DestinyObjectiveDefinition static data for display purposes.
    /// </summary>
    public class DestinyObjectiveProgress
    {
        /// <summary>The unique identifier of the Objective being referred to. Use to look up the DestinyObjectiveDefinition in static data.</summary>
        [JsonPropertyName("objectiveHash")]
        public uint ObjectiveHash { get; set; }

        /// <summary>If the Objective has a Destination associated with it, this is the unique identifier of the Destination being referred to. Use to look up the DestinyDestinationDefinition in static data. This will give localized data about *where* in the universe the objective should be achieved.</summary>
        [JsonPropertyName("destinationHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? DestinationHash { get; set; }

        /// <summary>If the Objective has an Activity associated with it, this is the unique identifier of the Activity being referred to. Use to look up the DestinyActivityDefinition in static data. This will give localized data about *what* you should be playing for the objective to be achieved.</summary>
        [JsonPropertyName("activityHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ActivityHash { get; set; }

        /// <summary>If progress has been made, and the progress can be measured numerically, this will be the value of that progress. You can compare it to the DestinyObjectiveDefinition.completionValue property for current vs. upper bounds, and use DestinyObjectiveDefinition.inProgressValueStyle or completedValueStyle to determine how this should be rendered. Note that progress, in Destiny 2, need not be a literal numeric progression. It could be one of a number of possible values, even a Timestamp. Always examine DestinyObjectiveDefinition.inProgressValueStyle or completedValueStyle before rendering progress.</summary>
        [JsonPropertyName("progress")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Progress { get; set; }

        /// <summary>
        /// As of Forsaken, objectives' completion value is determined dynamically at runtime.
        /// This value represents the threshold of progress you need to surpass in order for this objective to be considered "complete".
        /// If you were using objective data, switch from using the DestinyObjectiveDefinition's "completionValue" to this value.
        /// </summary>
        [JsonPropertyName("completionValue")]
        public int CompletionValue { get; set; }

        /// <summary>Whether or not the Objective is completed.</summary>
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }

        /// <summary>If this is true, the objective is visible in-game. Otherwise, it's not yet visible to the player. Up to you if you want to honor this property.</summary>
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyObjectiveProgress))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyObjectiveProgressJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// Data regarding the progress of a Quest for a specific character. Quests are composed of multiple steps, each with potentially multiple objectives: this QuestStatus will return Objective data for the *currently active* step in this quest.
    /// </summary>
    public class DestinyQuestStatus
    {
        /// <summary>The hash identifier for the Quest Item. (Note: Quests are defined as Items, and thus you would use this to look up the quest's DestinyInventoryItemDefinition). For information on all steps in the quest, you can then examine its DestinyInventoryItemDefinition.setData property for Quest Steps (which are *also* items). You can use the Item Definition to display human readable data about the overall quest.</summary>
        [JsonPropertyName("questHash")]
        public uint QuestHash { get; set; }

        /// <summary>The hash identifier of the current Quest Step, which is also a DestinyInventoryItemDefinition. You can use this to get human readable data about the current step and what to do in that step.</summary>
        [JsonPropertyName("stepHash")]
        public uint StepHash { get; set; }

        /// <summary>A step can have multiple objectives. This will give you the progress for each objective in the current step, in the order in which they are rendered in-game.</summary>
        [JsonPropertyName("stepObjectives")]
        public IEnumerable<Destiny.Quests.DestinyObjectiveProgress> StepObjectives { get; set; }

        /// <summary>Whether or not the quest is tracked</summary>
        [JsonPropertyName("tracked")]
        public bool Tracked { get; set; }

        /// <summary>The current Quest Step will be an instanced item in the player's inventory. If you care about that, this is the instance ID of that item.</summary>
        [JsonPropertyName("itemInstanceId")]
        public long ItemInstanceId { get; set; }

        /// <summary>Whether or not the whole quest has been completed, regardless of whether or not you have redeemed the rewards for the quest.</summary>
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        /// <summary>Whether or not you have redeemed rewards for this quest.</summary>
        [JsonPropertyName("redeemed")]
        public bool Redeemed { get; set; }

        /// <summary>Whether or not you have started this quest.</summary>
        [JsonPropertyName("started")]
        public bool Started { get; set; }

        /// <summary>If the quest has a related Vendor that you should talk to in order to initiate the quest/earn rewards/continue the quest, this will be the hash identifier of that Vendor. Look it up its DestinyVendorDefinition.</summary>
        [JsonPropertyName("vendorHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? VendorHash { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyQuestStatus))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyQuestStatusJsonContext : JsonSerializerContext { }
#endif
}