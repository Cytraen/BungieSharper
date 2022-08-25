using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportData
{
    /// <summary>Date and time for the activity.</summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; set; }

    /// <summary>If this activity has "phases", this is the phase at which the activity was started. This value is only valid for activities before the Beyond Light expansion shipped. Subsequent activities will not have a valid value here.</summary>
    [JsonPropertyName("startingPhaseIndex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? StartingPhaseIndex { get; set; }

    /// <summary>True if the activity was started from the beginning, if that information is available and the activity was played post Witch Queen release.</summary>
    [JsonPropertyName("activityWasStartedFromBeginning")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ActivityWasStartedFromBeginning { get; set; }

    /// <summary>Details about the activity.</summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; set; }

    /// <summary>Collection of players and their data for this activity.</summary>
    [JsonPropertyName("entries")]
    public IEnumerable<Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry> Entries { get; set; }

    /// <summary>Collection of stats for the player in this activity.</summary>
    [JsonPropertyName("teams")]
    public IEnumerable<Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry> Teams { get; set; }
}

/// <summary>
/// Summary information about the activity that was played.
/// </summary>
public class DestinyHistoricalStatsActivity
{
    /// <summary>The unique hash identifier of the DestinyActivityDefinition that was played. If I had this to do over, it'd be named activityHash. Too late now.</summary>
    [JsonPropertyName("referenceId")]
    public uint ReferenceId { get; set; }

    /// <summary>The unique hash identifier of the DestinyActivityDefinition that was played.</summary>
    [JsonPropertyName("directorActivityHash")]
    public uint DirectorActivityHash { get; set; }

    /// <summary>
    /// The unique identifier for this *specific* match that was played.
    /// This value can be used to get additional data about this activity such as who else was playing via the GetPostGameCarnageReport endpoint.
    /// </summary>
    [JsonPropertyName("instanceId")]
    public long InstanceId { get; set; }

    /// <summary>Indicates the most specific game mode of the activity that we could find.</summary>
    [JsonPropertyName("mode")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType Mode { get; set; }

    /// <summary>The list of all Activity Modes to which this activity applies, including aggregates. This will let you see, for example, whether the activity was both Clash and part of the Trials of the Nine event.</summary>
    [JsonPropertyName("modes")]
    public IEnumerable<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> Modes { get; set; }

    /// <summary>Whether or not the match was a private match.</summary>
    [JsonPropertyName("isPrivate")]
    public bool IsPrivate { get; set; }

    /// <summary>The Membership Type indicating the platform on which this match was played.</summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }
}

public class DestinyPostGameCarnageReportEntry
{
    /// <summary>Standing of the player</summary>
    [JsonPropertyName("standing")]
    public int Standing { get; set; }

    /// <summary>Score of the player if available</summary>
    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Score { get; set; }

    /// <summary>Identity details of the player</summary>
    [JsonPropertyName("player")]
    public Destiny.HistoricalStats.DestinyPlayer Player { get; set; }

    /// <summary>ID of the player's character used in the activity.</summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    /// <summary>Collection of stats for the player in this activity.</summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    /// <summary>Extended data extracted from the activity blob.</summary>
    [JsonPropertyName("extended")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportExtendedData Extended { get; set; }
}

public class DestinyHistoricalStatsValue
{
    /// <summary>Unique ID for this stat</summary>
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    /// <summary>Basic stat value.</summary>
    [JsonPropertyName("basic")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Basic { get; set; }

    /// <summary>Per game average for the statistic, if applicable</summary>
    [JsonPropertyName("pga")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Pga { get; set; }

    /// <summary>Weighted value of the stat if a weight greater than 1 has been assigned.</summary>
    [JsonPropertyName("weighted")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Weighted { get; set; }

    /// <summary>When a stat represents the best, most, longest, fastest or some other personal best, the actual activity ID where that personal best was established is available on this property.</summary>
    [JsonPropertyName("activityId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? ActivityId { get; set; }
}

public class DestinyHistoricalStatsValuePair
{
    /// <summary>Raw value of the statistic</summary>
    [JsonPropertyName("value")]
    public double Value { get; set; }

    /// <summary>Localized formated version of the value.</summary>
    [JsonPropertyName("displayValue")]
    public string DisplayValue { get; set; }
}

public class DestinyPlayer
{
    /// <summary>Details about the player as they are known in game (platform display name, Destiny emblem)</summary>
    [JsonPropertyName("destinyUserInfo")]
    public User.UserInfoCard DestinyUserInfo { get; set; }

    /// <summary>Class of the character if applicable and available.</summary>
    [JsonPropertyName("characterClass")]
    public string CharacterClass { get; set; }

    [JsonPropertyName("classHash")]
    public uint ClassHash { get; set; }

    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; set; }

    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; set; }

    /// <summary>Level of the character if available. Zero if it is not available.</summary>
    [JsonPropertyName("characterLevel")]
    public int CharacterLevel { get; set; }

    /// <summary>Light Level of the character if available. Zero if it is not available.</summary>
    [JsonPropertyName("lightLevel")]
    public int LightLevel { get; set; }

    /// <summary>Details about the player as they are known on BungieNet. This will be undefined if the player has marked their credential private, or does not have a BungieNet account.</summary>
    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    /// <summary>Current clan name for the player. This value may be null or an empty string if the user does not have a clan.</summary>
    [JsonPropertyName("clanName")]
    public string ClanName { get; set; }

    /// <summary>Current clan tag for the player. This value may be null or an empty string if the user does not have a clan.</summary>
    [JsonPropertyName("clanTag")]
    public string ClanTag { get; set; }

    /// <summary>If we know the emblem's hash, this can be used to look up the player's emblem at the time of a match when receiving PGCR data, or otherwise their currently equipped emblem (if we are able to obtain it).</summary>
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; set; }
}

public class DestinyPostGameCarnageReportExtendedData
{
    /// <summary>List of weapons and their perspective values.</summary>
    [JsonPropertyName("weapons")]
    public IEnumerable<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; set; }

    /// <summary>Collection of stats for the player in this activity.</summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }
}

public class DestinyHistoricalWeaponStats
{
    /// <summary>The hash ID of the item definition that describes the weapon.</summary>
    [JsonPropertyName("referenceId")]
    public uint ReferenceId { get; set; }

    /// <summary>Collection of stats for the period.</summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }
}

public class DestinyPostGameCarnageReportTeamEntry
{
    /// <summary>Integer ID for the team.</summary>
    [JsonPropertyName("teamId")]
    public int TeamId { get; set; }

    /// <summary>Team's standing relative to other teams.</summary>
    [JsonPropertyName("standing")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Standing { get; set; }

    /// <summary>Score earned by the team</summary>
    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Score { get; set; }

    /// <summary>Alpha or Bravo</summary>
    [JsonPropertyName("teamName")]
    public string TeamName { get; set; }
}

public class DestinyLeaderboard
{
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    [JsonPropertyName("entries")]
    public IEnumerable<Destiny.HistoricalStats.DestinyLeaderboardEntry> Entries { get; set; }
}

public class DestinyLeaderboardEntry
{
    /// <summary>Where this player ranks on the leaderboard. A value of 1 is the top rank.</summary>
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    /// <summary>Identity details of the player</summary>
    [JsonPropertyName("player")]
    public Destiny.HistoricalStats.DestinyPlayer Player { get; set; }

    /// <summary>ID of the player's best character for the reported stat.</summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    /// <summary>Value of the stat for this player</summary>
    [JsonPropertyName("value")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Value { get; set; }
}

public class DestinyLeaderboardResults
{
    /// <summary>Indicate the membership ID of the account that is the focal point of the provided leaderboards.</summary>
    [JsonPropertyName("focusMembershipId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? FocusMembershipId { get; set; }

    /// <summary>Indicate the character ID of the character that is the focal point of the provided leaderboards. May be null, in which case any character from the focus membership can appear in the provided leaderboards.</summary>
    [JsonPropertyName("focusCharacterId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? FocusCharacterId { get; set; }
}

public class DestinyClanAggregateStat
{
    /// <summary>The id of the mode of stats (allPvp, allPvE, etc)</summary>
    [JsonPropertyName("mode")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType Mode { get; set; }

    /// <summary>The id of the stat</summary>
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    /// <summary>Value of the stat for this player</summary>
    [JsonPropertyName("value")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Value { get; set; }
}

public class DestinyHistoricalStatsByPeriod
{
    [JsonPropertyName("allTime")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTime { get; set; }

    [JsonPropertyName("allTimeTier1")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTimeTier1 { get; set; }

    [JsonPropertyName("allTimeTier2")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTimeTier2 { get; set; }

    [JsonPropertyName("allTimeTier3")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTimeTier3 { get; set; }

    [JsonPropertyName("daily")]
    public IEnumerable<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Daily { get; set; }

    [JsonPropertyName("monthly")]
    public IEnumerable<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Monthly { get; set; }
}

public class DestinyHistoricalStatsPeriodGroup
{
    /// <summary>Period for the group. If the stat periodType is day, then this will have a specific day. If the type is monthly, then this value will be the first day of the applicable month. This value is not set when the periodType is 'all time'.</summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; set; }

    /// <summary>If the period group is for a specific activity, this property will be set.</summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; set; }

    /// <summary>Collection of stats for the period.</summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }
}

public class DestinyHistoricalStatsResults { }

public class DestinyHistoricalStatsAccountResult
{
    [JsonPropertyName("mergedDeletedCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; set; }

    [JsonPropertyName("mergedAllCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedAllCharacters { get; set; }

    [JsonPropertyName("characters")]
    public IEnumerable<Destiny.HistoricalStats.DestinyHistoricalStatsPerCharacter> Characters { get; set; }
}

public class DestinyHistoricalStatsWithMerged
{
    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> Results { get; set; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod Merged { get; set; }
}

public class DestinyHistoricalStatsPerCharacter
{
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> Results { get; set; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod Merged { get; set; }
}

public class DestinyActivityHistoryResults
{
    /// <summary>List of activities, the most recent activity first.</summary>
    [JsonPropertyName("activities")]
    public IEnumerable<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Activities { get; set; }
}

public class DestinyHistoricalWeaponStatsData
{
    /// <summary>List of weapons and their perspective values.</summary>
    [JsonPropertyName("weapons")]
    public IEnumerable<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; set; }
}

public class DestinyAggregateActivityResults
{
    /// <summary>List of all activities the player has participated in.</summary>
    [JsonPropertyName("activities")]
    public IEnumerable<Destiny.HistoricalStats.DestinyAggregateActivityStats> Activities { get; set; }
}

public class DestinyAggregateActivityStats
{
    /// <summary>Hash ID that can be looked up in the DestinyActivityTable.</summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>Collection of stats for the player in this activity.</summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }
}