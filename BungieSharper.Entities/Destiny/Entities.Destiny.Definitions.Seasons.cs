using System;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Seasons
{
    /// <summary>
    /// Defines a canonical "Season" of Destiny: a range of a few months where the game highlights certain challenges, provides new loot, has new Clan-related rewards and celebrates various seasonal events.
    /// </summary>
    public class DestinySeasonDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        [JsonPropertyName("backgroundImagePath")]
        public string BackgroundImagePath { get; set; }

        [JsonPropertyName("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonPropertyName("startDate"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("endDate"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("seasonPassHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? SeasonPassHash { get; set; }

        [JsonPropertyName("seasonPassProgressionHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? SeasonPassProgressionHash { get; set; }

        [JsonPropertyName("artifactItemHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ArtifactItemHash { get; set; }

        [JsonPropertyName("sealPresentationNodeHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? SealPresentationNodeHash { get; set; }

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

    public class DestinySeasonPassDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>This is the progression definition related to the progression for the initial levels 1-100 that provide item rewards for the Season pass. Further experience after you reach the limit is provided in the "Prestige" progression referred to by prestigeProgressionHash.</summary>
        [JsonPropertyName("rewardProgressionHash")]
        public uint RewardProgressionHash { get; set; }

        /// <summary>
        /// I know what you're thinking, but I promise we're not going to duplicate and drown you. Instead, we're giving you sweet, sweet power bonuses.
        /// Prestige progression is further progression that you can make on the Season pass after you gain max ranks, that will ultimately increase your power/light level over the theoretical limit.
        /// </summary>
        [JsonPropertyName("prestigeProgressionHash")]
        public uint PrestigeProgressionHash { get; set; }

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