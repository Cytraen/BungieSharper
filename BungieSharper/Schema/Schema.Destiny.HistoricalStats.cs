using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.HistoricalStats
{
    public class DestinyPostGameCarnageReportData
    {
        /// <summary>Date and time for the activity.</summary>
        public DateTime period { get; set; }
        /// <summary>If this activity has "phases", this is the phase at which the activity was started.</summary>
        public int? startingPhaseIndex { get; set; }
        /// <summary>Details about the activity.</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsActivity activityDetails { get; set; }
        /// <summary>Collection of players and their data for this activity.</summary>
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry> entries { get; set; }
        /// <summary>Collection of stats for the player in this activity.</summary>
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry> teams { get; set; }
    }

    /// <summary>
    /// Summary information about the activity that was played.
    /// </summary>
    public class DestinyHistoricalStatsActivity
    {
        /// <summary>The unique hash identifier of the DestinyActivityDefinition that was played. If I had this to do over, it'd be named activityHash. Too late now.</summary>
        public uint referenceId { get; set; }
        /// <summary>The unique hash identifier of the DestinyActivityDefinition that was played.</summary>
        public uint directorActivityHash { get; set; }
        /// <summary>
        /// The unique identifier for this *specific* match that was played.
        /// This value can be used to get additional data about this activity such as who else was playing via the GetPostGameCarnageReport endpoint.
        /// </summary>
        public long instanceId { get; set; }
        /// <summary>Indicates the most specific game mode of the activity that we could find.</summary>
        public Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode { get; set; }
        /// <summary>The list of all Activity Modes to which this activity applies, including aggregates. This will let you see, for example, whether the activity was both Clash and part of the Trials of the Nine event.</summary>
        public IEnumerable<Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType> modes { get; set; }
        /// <summary>Whether or not the match was a private match.</summary>
        public bool isPrivate { get; set; }
        /// <summary>The Membership Type indicating the platform on which this match was played.</summary>
        public Schema.BungieMembershipType membershipType { get; set; }
    }

    public class DestinyPostGameCarnageReportEntry
    {
        /// <summary>Standing of the player</summary>
        public int standing { get; set; }
        /// <summary>Score of the player if available</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue score { get; set; }
        /// <summary>Identity details of the player</summary>
        public Schema.Destiny.HistoricalStats.DestinyPlayer player { get; set; }
        /// <summary>ID of the player's character used in the activity.</summary>
        public long characterId { get; set; }
        /// <summary>Collection of stats for the player in this activity.</summary>
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> values { get; set; }
        /// <summary>Extended data extracted from the activity blob.</summary>
        public Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportExtendedData extended { get; set; }
    }

    public class DestinyHistoricalStatsValue
    {
        /// <summary>Unique ID for this stat</summary>
        public string statId { get; set; }
        /// <summary>Basic stat value.</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValuePair basic { get; set; }
        /// <summary>Per game average for the statistic, if applicable</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValuePair pga { get; set; }
        /// <summary>Weighted value of the stat if a weight greater than 1 has been assigned.</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValuePair weighted { get; set; }
        /// <summary>When a stat represents the best, most, longest, fastest or some other personal best, the actual activity ID where that personal best was established is available on this property.</summary>
        public long? activityId { get; set; }
    }

    public class DestinyHistoricalStatsValuePair
    {
        /// <summary>Raw value of the statistic</summary>
        public double value { get; set; }
        /// <summary>Localized formated version of the value.</summary>
        public string displayValue { get; set; }
    }

    public class DestinyPlayer
    {
        /// <summary>Details about the player as they are known in game (platform display name, Destiny emblem)</summary>
        public Schema.User.UserInfoCard destinyUserInfo { get; set; }
        /// <summary>Class of the character if applicable and available.</summary>
        public string characterClass { get; set; }
        public uint classHash { get; set; }
        public uint raceHash { get; set; }
        public uint genderHash { get; set; }
        /// <summary>Level of the character if available. Zero if it is not available.</summary>
        public int characterLevel { get; set; }
        /// <summary>Light Level of the character if available. Zero if it is not available.</summary>
        public int lightLevel { get; set; }
        /// <summary>Details about the player as they are known on BungieNet. This will be undefined if the player has marked their credential private, or does not have a BungieNet account.</summary>
        public Schema.User.UserInfoCard bungieNetUserInfo { get; set; }
        /// <summary>Current clan name for the player. This value may be null or an empty string if the user does not have a clan.</summary>
        public string clanName { get; set; }
        /// <summary>Current clan tag for the player. This value may be null or an empty string if the user does not have a clan.</summary>
        public string clanTag { get; set; }
        /// <summary>If we know the emblem's hash, this can be used to look up the player's emblem at the time of a match when receiving PGCR data, or otherwise their currently equipped emblem (if we are able to obtain it).</summary>
        public uint emblemHash { get; set; }
    }

    public class DestinyPostGameCarnageReportExtendedData
    {
        /// <summary>List of weapons and their perspective values.</summary>
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyHistoricalWeaponStats> weapons { get; set; }
        /// <summary>Collection of stats for the player in this activity.</summary>
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> values { get; set; }
    }

    public class DestinyHistoricalWeaponStats
    {
        /// <summary>The hash ID of the item definition that describes the weapon.</summary>
        public uint referenceId { get; set; }
        /// <summary>Collection of stats for the period.</summary>
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> values { get; set; }
    }

    public class DestinyPostGameCarnageReportTeamEntry
    {
        /// <summary>Integer ID for the team.</summary>
        public int teamId { get; set; }
        /// <summary>Team's standing relative to other teams.</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue standing { get; set; }
        /// <summary>Score earned by the team</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue score { get; set; }
        /// <summary>Alpha or Bravo</summary>
        public string teamName { get; set; }
    }

    public class DestinyLeaderboard
    {
        public string statId { get; set; }
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyLeaderboardEntry> entries { get; set; }
    }

    public class DestinyLeaderboardEntry
    {
        /// <summary>Where this player ranks on the leaderboard. A value of 1 is the top rank.</summary>
        public int rank { get; set; }
        /// <summary>Identity details of the player</summary>
        public Schema.Destiny.HistoricalStats.DestinyPlayer player { get; set; }
        /// <summary>ID of the player's best character for the reported stat.</summary>
        public long characterId { get; set; }
        /// <summary>Value of the stat for this player</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue value { get; set; }
    }

    public class DestinyLeaderboardResults
    {
        /// <summary>Indicate the membership ID of the account that is the focal point of the provided leaderboards.</summary>
        public long? focusMembershipId { get; set; }
        /// <summary>Indicate the character ID of the character that is the focal point of the provided leaderboards. May be null, in which case any character from the focus membership can appear in the provided leaderboards.</summary>
        public long? focusCharacterId { get; set; }
    }

    public class DestinyClanAggregateStat
    {
        /// <summary>The id of the mode of stats (allPvp, allPvE, etc)</summary>
        public Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode { get; set; }
        /// <summary>The id of the stat</summary>
        public string statId { get; set; }
        /// <summary>Value of the stat for this player</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue value { get; set; }
    }

    public class DestinyHistoricalStatsByPeriod
    {
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> allTime { get; set; }
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> allTimeTier1 { get; set; }
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> allTimeTier2 { get; set; }
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> allTimeTier3 { get; set; }
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> daily { get; set; }
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> monthly { get; set; }
    }

    public class DestinyHistoricalStatsPeriodGroup
    {
        /// <summary>Period for the group. If the stat periodType is day, then this will have a specific day. If the type is monthly, then this value will be the first day of the applicable month. This value is not set when the periodType is 'all time'.</summary>
        public DateTime period { get; set; }
        /// <summary>If the period group is for a specific activity, this property will be set.</summary>
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsActivity activityDetails { get; set; }
        /// <summary>Collection of stats for the period.</summary>
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> values { get; set; }
    }



    public class DestinyHistoricalStatsAccountResult
    {
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged mergedDeletedCharacters { get; set; }
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged mergedAllCharacters { get; set; }
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsPerCharacter> characters { get; set; }
    }

    public class DestinyHistoricalStatsWithMerged
    {
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> results { get; set; }
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod merged { get; set; }
    }

    public class DestinyHistoricalStatsPerCharacter
    {
        public long characterId { get; set; }
        public bool deleted { get; set; }
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> results { get; set; }
        public Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod merged { get; set; }
    }

    public class DestinyActivityHistoryResults
    {
        /// <summary>List of activities, the most recent activity first.</summary>
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> activities { get; set; }
    }

    public class DestinyHistoricalWeaponStatsData
    {
        /// <summary>List of weapons and their perspective values.</summary>
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyHistoricalWeaponStats> weapons { get; set; }
    }

    public class DestinyAggregateActivityResults
    {
        /// <summary>List of all activities the player has participated in.</summary>
        public IEnumerable<Schema.Destiny.HistoricalStats.DestinyAggregateActivityStats> activities { get; set; }
    }

    public class DestinyAggregateActivityStats
    {
        /// <summary>Hash ID that can be looked up in the DestinyActivityTable.</summary>
        public uint activityHash { get; set; }
        /// <summary>Collection of stats for the player in this activity.</summary>
        public Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsValue> values { get; set; }
    }
}