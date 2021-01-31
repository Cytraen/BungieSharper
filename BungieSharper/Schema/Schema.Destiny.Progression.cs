using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Progression
{

    /// <summary>
    /// Mostly for historical purposes, we segregate Faction progressions from other progressions. This is just a DestinyProgression with a shortcut for finding the DestinyFactionDefinition of the faction related to the progression.
    /// </summary>
    public class DestinyFactionProgression
    {
        /// <summary>The hash identifier of the Faction related to this progression. Use it to look up the DestinyFactionDefinition for more rendering info.</summary>
        public uint factionHash { get; set; }
        /// <summary>The index of the Faction vendor that is currently available. Will be set to -1 if no vendors are available.</summary>
        public int factionVendorIndex { get; set; }
        /// <summary>The hash identifier of the Progression in question. Use it to look up the DestinyProgressionDefinition in static data.</summary>
        public uint progressionHash { get; set; }
        /// <summary>The amount of progress earned today for this progression.</summary>
        public int dailyProgress { get; set; }
        /// <summary>If this progression has a daily limit, this is that limit.</summary>
        public int dailyLimit { get; set; }
        /// <summary>The amount of progress earned toward this progression in the current week.</summary>
        public int weeklyProgress { get; set; }
        /// <summary>If this progression has a weekly limit, this is that limit.</summary>
        public int weeklyLimit { get; set; }
        /// <summary>This is the total amount of progress obtained overall for this progression (for instance, the total amount of Character Level experience earned)</summary>
        public int currentProgress { get; set; }
        /// <summary>This is the level of the progression (for instance, the Character Level).</summary>
        public int level { get; set; }
        /// <summary>This is the maximum possible level you can achieve for this progression (for example, the maximum character level obtainable)</summary>
        public int levelCap { get; set; }
        /// <summary>Progressions define their levels in "steps". Since the last step may be repeatable, the user may be at a higher level than the actual Step achieved in the progression. Not necessarily useful, but potentially interesting for those cruising the API. Relate this to the "steps" property of the DestinyProgression to see which step the user is on, if you care about that. (Note that this is Content Version dependent since it refers to indexes.)</summary>
        public int stepIndex { get; set; }
        /// <summary>The amount of progression (i.e. "Experience") needed to reach the next level of this Progression. Jeez, progression is such an overloaded word.</summary>
        public int progressToNextLevel { get; set; }
        /// <summary>The total amount of progression (i.e. "Experience") needed in order to reach the next level.</summary>
        public int nextLevelAt { get; set; }
        /// <summary>The number of resets of this progression you've executed this season, if applicable to this progression.</summary>
        public int? currentResetCount { get; set; }
        /// <summary>Information about historical resets of this progression, if there is any data for it.</summary>
        public IEnumerable<Schema.Destiny.DestinyProgressionResetEntry> seasonResets { get; set; }
        /// <summary>Information about historical rewards for this progression, if there is any data for it.</summary>
        public IEnumerable<Schema.Destiny.DestinyProgressionRewardItemState> rewardItemStates { get; set; }
    }
}