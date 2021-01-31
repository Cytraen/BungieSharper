using System;

namespace BungieSharper.Schema.Destiny.Definitions.Seasons
{

    /// <summary>
    /// Defines a canonical "Season" of Destiny: a range of a few months where the game highlights certain challenges, provides new loot, has new Clan-related rewards and celebrates various seasonal events.
    /// </summary>
    public class DestinySeasonDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
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
    }

    public class DestinySeasonPassDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>This is the progression definition related to the progression for the initial levels 1-100 that provide item rewards for the Season pass. Further experience after you reach the limit is provided in the "Prestige" progression referred to by prestigeProgressionHash.</summary>
        public uint rewardProgressionHash { get; set; }
        /// <summary>
        /// I know what you're thinking, but I promise we're not going to duplicate and drown you. Instead, we're giving you sweet, sweet power bonuses.
        ///  Prestige progression is further progression that you can make on the Season pass after you gain max ranks, that will ultimately increase your power/light level over the theoretical limit.
        /// </summary>
        public uint prestigeProgressionHash { get; set; }
    }
}