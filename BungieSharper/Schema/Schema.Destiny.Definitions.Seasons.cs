using System;

namespace BungieSharper.Schema.Destiny.Definitions.Seasons
{

    /// <summary>
    /// Defines a canonical "Season" of Destiny: a range of a few months where the game highlights certain challenges, provides new loot, has new Clan-related rewards and celebrates various seasonal events.
    /// </summary>
    public class DestinySeasonDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        public string backgroundImagePath { get; set; }
        public int seasonNumber { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public uint? seasonPassHash { get; set; }
        public uint? seasonPassProgressionHash { get; set; }
        public uint? artifactItemHash { get; set; }
        public uint? sealPresentationNodeHash { get; set; }
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

    public class DestinySeasonPassDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>This is the progression definition related to the progression for the initial levels 1-100 that provide item rewards for the Season pass. Further experience after you reach the limit is provided in the "Prestige" progression referred to by prestigeProgressionHash.</summary>
        public uint rewardProgressionHash { get; set; }
        /// <summary>
        /// I know what you're thinking, but I promise we're not going to duplicate and drown you. Instead, we're giving you sweet, sweet power bonuses.
        ///  Prestige progression is further progression that you can make on the Season pass after you gain max ranks, that will ultimately increase your power/light level over the theoretical limit.
        /// </summary>
        public uint prestigeProgressionHash { get; set; }
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
}