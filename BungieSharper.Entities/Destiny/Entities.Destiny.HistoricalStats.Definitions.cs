using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.HistoricalStats.Definitions
{
    /// <summary>
    /// For historical reasons, this list will have both D1 and D2-relevant Activity Modes in it. Please don't take this to mean that some D1-only feature is coming back!
    /// </summary>
    public enum DestinyActivityModeType : int
    {
        None = 0,
        Story = 2,
        Strike = 3,
        Raid = 4,
        AllPvP = 5,
        Patrol = 6,
        AllPvE = 7,
        Reserved9 = 9,
        Control = 10,
        Reserved11 = 11,

        /// <summary>Clash -> Destiny's name for Team Deathmatch. 4v4 combat, the team with the highest kills at the end of time wins.</summary>
        Clash = 12,
        Reserved13 = 13,
        CrimsonDoubles = 15,
        Nightfall = 16,
        HeroicNightfall = 17,
        AllStrikes = 18,
        IronBanner = 19,
        Reserved20 = 20,
        Reserved21 = 21,
        Reserved22 = 22,
        Reserved24 = 24,
        AllMayhem = 25,
        Reserved26 = 26,
        Reserved27 = 27,
        Reserved28 = 28,
        Reserved29 = 29,
        Reserved30 = 30,
        Supremacy = 31,
        PrivateMatchesAll = 32,
        Survival = 37,
        Countdown = 38,
        TrialsOfTheNine = 39,
        Social = 40,
        TrialsCountdown = 41,
        TrialsSurvival = 42,
        IronBannerControl = 43,
        IronBannerClash = 44,
        IronBannerSupremacy = 45,
        ScoredNightfall = 46,
        ScoredHeroicNightfall = 47,
        Rumble = 48,
        AllDoubles = 49,
        Doubles = 50,
        PrivateMatchesClash = 51,
        PrivateMatchesControl = 52,
        PrivateMatchesSupremacy = 53,
        PrivateMatchesCountdown = 54,
        PrivateMatchesSurvival = 55,
        PrivateMatchesMayhem = 56,
        PrivateMatchesRumble = 57,
        HeroicAdventure = 58,
        Showdown = 59,
        Lockdown = 60,
        Scorched = 61,
        ScorchedTeam = 62,
        Gambit = 63,
        AllPvECompetitive = 64,
        Breakthrough = 65,
        BlackArmoryRun = 66,
        Salvage = 67,
        IronBannerSalvage = 68,
        PvPCompetitive = 69,
        PvPQuickplay = 70,
        ClashQuickplay = 71,
        ClashCompetitive = 72,
        ControlQuickplay = 73,
        ControlCompetitive = 74,
        GambitPrime = 75,
        Reckoning = 76,
        Menagerie = 77,
        VexOffensive = 78,
        NightmareHunt = 79,
        Elimination = 80,
        Momentum = 81,
        Dungeon = 82,
        Sundial = 83,
        TrialsOfOsiris = 84
    }

    public class DestinyHistoricalStatsDefinition
    {
        /// <summary>Unique programmer friendly ID for this stat</summary>
        [JsonPropertyName("statId")]
        public string StatId { get; set; }

        /// <summary>Statistic group</summary>
        [JsonPropertyName("group")]
        public Destiny.HistoricalStats.Definitions.DestinyStatsGroupType Group { get; set; }

        /// <summary>Time periods the statistic covers</summary>
        [JsonPropertyName("periodTypes")]
        public IEnumerable<Destiny.HistoricalStats.Definitions.PeriodType> PeriodTypes { get; set; }

        /// <summary>Game modes where this statistic can be reported.</summary>
        [JsonPropertyName("modes")]
        public IEnumerable<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> Modes { get; set; }

        /// <summary>Category for the stat.</summary>
        [JsonPropertyName("category")]
        public Destiny.HistoricalStats.Definitions.DestinyStatsCategoryType Category { get; set; }

        /// <summary>Display name</summary>
        [JsonPropertyName("statName")]
        public string StatName { get; set; }

        /// <summary>Display name abbreviated</summary>
        [JsonPropertyName("statNameAbbr")]
        public string StatNameAbbr { get; set; }

        /// <summary>Description of a stat if applicable.</summary>
        [JsonPropertyName("statDescription")]
        public string StatDescription { get; set; }

        /// <summary>Unit, if any, for the statistic</summary>
        [JsonPropertyName("unitType")]
        public Destiny.HistoricalStats.Definitions.UnitType UnitType { get; set; }

        /// <summary>Optional URI to an icon for the statistic</summary>
        [JsonPropertyName("iconImage")]
        public string IconImage { get; set; }

        /// <summary>Optional icon for the statistic</summary>
        [JsonPropertyName("mergeMethod")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MergeMethod { get; set; }

        /// <summary>Localized Unit Name for the stat.</summary>
        [JsonPropertyName("unitLabel")]
        public string UnitLabel { get; set; }

        /// <summary>Weight assigned to this stat indicating its relative impressiveness.</summary>
        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        /// <summary>The tier associated with this medal - be it implicitly or explicitly.</summary>
        [JsonPropertyName("medalTierHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? MedalTierHash { get; set; }
    }

    /// <summary>
    /// If the enum value is > 100, it is a "special" group that cannot be queried for directly (special cases apply to when they are returned, and are not relevant in general cases)
    /// </summary>
    public enum DestinyStatsGroupType : int
    {
        None = 0,
        General = 1,
        Weapons = 2,
        Medals = 3,

        /// <summary>This is purely to serve as the dividing line between filterable and un-filterable groups. Below this number is a group you can pass as a filter. Above it are groups used in very specific circumstances and not relevant for filtering.</summary>
        ReservedGroups = 100,

        /// <summary>Only applicable while generating leaderboards.</summary>
        Leaderboard = 101,

        /// <summary>These will *only* be consumed by GetAggregateStatsByActivity</summary>
        Activity = 102,

        /// <summary>These are only consumed and returned by GetUniqueWeaponHistory</summary>
        UniqueWeapon = 103,
        Internal = 104
    }

    public enum DestinyStatsCategoryType : int
    {
        None = 0,
        Kills = 1,
        Assists = 2,
        Deaths = 3,
        Criticals = 4,
        KDa = 5,
        KD = 6,
        Score = 7,
        Entered = 8,
        TimePlayed = 9,
        MedalWins = 10,
        MedalGame = 11,
        MedalSpecialKills = 12,
        MedalSprees = 13,
        MedalMultiKills = 14,
        MedalAbilities = 15
    }

    public enum UnitType : int
    {
        None = 0,

        /// <summary>Indicates the statistic is a simple count of something.</summary>
        Count = 1,

        /// <summary>Indicates the statistic is a per game average.</summary>
        PerGame = 2,

        /// <summary>Indicates the number of seconds</summary>
        Seconds = 3,

        /// <summary>Indicates the number of points earned</summary>
        Points = 4,

        /// <summary>Values represents a team ID</summary>
        Team = 5,

        /// <summary>Values represents a distance (units to-be-determined)</summary>
        Distance = 6,

        /// <summary>Ratio represented as a whole value from 0 to 100.</summary>
        Percent = 7,

        /// <summary>Ratio of something, shown with decimal places</summary>
        Ratio = 8,

        /// <summary>True or false</summary>
        Boolean = 9,

        /// <summary>The stat is actually a weapon type.</summary>
        WeaponType = 10,

        /// <summary>Indicates victory, defeat, or something in between.</summary>
        Standing = 11,

        /// <summary>Number of milliseconds some event spanned. For example, race time, or lap time.</summary>
        Milliseconds = 12,

        /// <summary>The value is a enumeration of the Completion Reason type.</summary>
        CompletionReason = 13
    }

    public enum DestinyStatsMergeMethod : int
    {
        /// <summary>When collapsing multiple instances of the stat together, add the values.</summary>
        Add = 0,

        /// <summary>When collapsing multiple instances of the stat together, take the lower value.</summary>
        Min = 1,

        /// <summary>When collapsing multiple instances of the stat together, take the higher value.</summary>
        Max = 2
    }

    public enum PeriodType : int
    {
        None = 0,
        Daily = 1,
        AllTime = 2,
        Activity = 3
    }
}