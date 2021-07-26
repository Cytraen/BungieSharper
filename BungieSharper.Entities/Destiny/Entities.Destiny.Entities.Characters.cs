using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Entities.Characters
{
    /// <summary>
    /// This component contains base properties of the character. You'll probably want to always request this component, but hey you do you.
    /// </summary>
    public class DestinyCharacterComponent
    {
        /// <summary>Every Destiny Profile has a membershipId. This is provided on the character as well for convenience.</summary>
        [JsonPropertyName("membershipId")]
        public long MembershipId { get; set; }

        /// <summary>membershipType tells you the platform on which the character plays. Examine the BungieMembershipType enumeration for possible values.</summary>
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }

        /// <summary>The unique identifier for the character.</summary>
        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        /// <summary>The last date that the user played Destiny.</summary>
        [JsonPropertyName("dateLastPlayed")]
        public DateTime DateLastPlayed { get; set; }

        /// <summary>If the user is currently playing, this is how long they've been playing.</summary>
        [JsonPropertyName("minutesPlayedThisSession")]
        public long MinutesPlayedThisSession { get; set; }

        /// <summary>If this value is 525,600, then they played Destiny for a year. Or they're a very dedicated Rent fan. Note that this includes idle time, not just time spent actually in activities shooting things.</summary>
        [JsonPropertyName("minutesPlayedTotal")]
        public long MinutesPlayedTotal { get; set; }

        /// <summary>The user's calculated "Light Level". Light level is an indicator of your power that mostly matters in the end game, once you've reached the maximum character level: it's a level that's dependent on the average Attack/Defense power of your items.</summary>
        [JsonPropertyName("light")]
        public int Light { get; set; }

        /// <summary>
        /// Your character's stats, such as Agility, Resilience, etc... *not* historical stats.
        /// You'll have to call a different endpoint for those.
        /// </summary>
        [JsonPropertyName("stats")]
        public Dictionary<uint, int> Stats { get; set; }

        /// <summary>Use this hash to look up the character's DestinyRaceDefinition.</summary>
        [JsonPropertyName("raceHash")]
        public uint RaceHash { get; set; }

        /// <summary>Use this hash to look up the character's DestinyGenderDefinition.</summary>
        [JsonPropertyName("genderHash")]
        public uint GenderHash { get; set; }

        /// <summary>Use this hash to look up the character's DestinyClassDefinition.</summary>
        [JsonPropertyName("classHash")]
        public uint ClassHash { get; set; }

        /// <summary>
        /// Mostly for historical purposes at this point, this is an enumeration for the character's race.
        /// It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
        /// </summary>
        [JsonPropertyName("raceType")]
        public DestinyRace RaceType { get; set; }

        /// <summary>
        /// Mostly for historical purposes at this point, this is an enumeration for the character's class.
        /// It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
        /// </summary>
        [JsonPropertyName("classType")]
        public DestinyClass ClassType { get; set; }

        /// <summary>
        /// Mostly for historical purposes at this point, this is an enumeration for the character's Gender.
        /// It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove. And yeah, it's an enumeration and not a boolean. Fight me.
        /// </summary>
        [JsonPropertyName("genderType")]
        public DestinyGender GenderType { get; set; }

        /// <summary>A shortcut path to the user's currently equipped emblem image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.</summary>
        [JsonPropertyName("emblemPath")]
        public string EmblemPath { get; set; }

        /// <summary>A shortcut path to the user's currently equipped emblem background image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.</summary>
        [JsonPropertyName("emblemBackgroundPath")]
        public string EmblemBackgroundPath { get; set; }

        /// <summary>The hash of the currently equipped emblem for the user. Can be used to look up the DestinyInventoryItemDefinition.</summary>
        [JsonPropertyName("emblemHash")]
        public uint EmblemHash { get; set; }

        /// <summary>A shortcut for getting the background color of the user's currently equipped emblem without having to do a DestinyInventoryItemDefinition lookup.</summary>
        [JsonPropertyName("emblemColor")]
        public Misc.DestinyColor EmblemColor { get; set; }

        /// <summary>The progression that indicates your character's level. Not their light level, but their character level: you know, the thing you max out a couple hours in and then ignore for the sake of light level.</summary>
        [JsonPropertyName("levelProgression")]
        public DestinyProgression LevelProgression { get; set; }

        /// <summary>The "base" level of your character, not accounting for any light level.</summary>
        [JsonPropertyName("baseCharacterLevel")]
        public int BaseCharacterLevel { get; set; }

        /// <summary>A number between 0 and 100, indicating the whole and fractional % remaining to get to the next character level.</summary>
        [JsonPropertyName("percentToNextLevel")]
        public float PercentToNextLevel { get; set; }

        /// <summary>If this Character has a title assigned to it, this is the identifier of the DestinyRecordDefinition that has that title information.</summary>
        [JsonPropertyName("titleRecordHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? TitleRecordHash { get; set; }
    }

    /// <summary>
    /// This component returns anything that could be considered "Progression" on a user: data where the user is gaining levels, reputation, completions, rewards, etc...
    /// </summary>
    public class DestinyCharacterProgressionComponent
    {
        /// <summary>
        /// A Dictionary of all known progressions for the Character, keyed by the Progression's hash.
        /// Not all progressions have user-facing data, but those who do will have that data contained in the DestinyProgressionDefinition.
        /// </summary>
        [JsonPropertyName("progressions")]
        public Dictionary<uint, DestinyProgression> Progressions { get; set; }

        /// <summary>A dictionary of all known Factions, keyed by the Faction's hash. It contains data about this character's status with the faction.</summary>
        [JsonPropertyName("factions")]
        public Dictionary<uint, Progression.DestinyFactionProgression> Factions { get; set; }

        /// <summary>Milestones are related to the simple progressions shown in the game, but return additional and hopefully helpful information for users about the specifics of the Milestone's status.</summary>
        [JsonPropertyName("milestones")]
        public Dictionary<uint, Milestones.DestinyMilestone> Milestones { get; set; }

        /// <summary>
        /// If the user has any active quests, the quests' statuses will be returned here.
        /// Note that quests have been largely supplanted by Milestones, but that doesn't mean that they won't make a comeback independent of milestones at some point.
        /// (Fun fact: quests came back as I feared they would, but we never looped back to populate this... I'm going to put that in the backlog.)
        /// </summary>
        [JsonPropertyName("quests")]
        public IEnumerable<Quests.DestinyQuestStatus> Quests { get; set; }

        /// <summary>
        /// Sometimes, you have items in your inventory that don't have instances, but still have Objective information. This provides you that objective information for uninstanced items.
        /// This dictionary is keyed by the item's hash: which you can use to look up the name and description for the overall task(s) implied by the objective. The value is the list of objectives for this item, and their statuses.
        /// </summary>
        [JsonPropertyName("uninstancedItemObjectives")]
        public Dictionary<uint, IEnumerable<Quests.DestinyObjectiveProgress>> UninstancedItemObjectives { get; set; }

        /// <summary>
        /// The set of checklists that can be examined for this specific character, keyed by the hash identifier of the Checklist (DestinyChecklistDefinition)
        /// For each checklist returned, its value is itself a Dictionary keyed by the checklist's hash identifier with the value being a boolean indicating if it's been discovered yet.
        /// </summary>
        [JsonPropertyName("checklists")]
        public Dictionary<uint, Dictionary<uint, bool>> Checklists { get; set; }

        /// <summary>Data related to your progress on the current season's artifact that can vary per character.</summary>
        [JsonPropertyName("seasonalArtifact")]
        public Artifacts.DestinyArtifactCharacterScoped SeasonalArtifact { get; set; }
    }

    /// <summary>
    /// Only really useful if you're attempting to render the character's current appearance in 3D, this returns a bare minimum of information, pre-aggregated, that you'll need to perform that rendering. Note that you need to combine this with other 3D assets and data from our servers.
    /// Examine the Javascript returned by https://bungie.net/sharedbundle/spasm to see how we use this data, but be warned: the rabbit hole goes pretty deep.
    /// </summary>
    public class DestinyCharacterRenderComponent
    {
        /// <summary>Custom dyes, calculated by iterating over the character's equipped items. Useful for pre-fetching all of the dye data needed from our server.</summary>
        [JsonPropertyName("customDyes")]
        public IEnumerable<DyeReference> CustomDyes { get; set; }

        /// <summary>This is actually something that Spasm.js *doesn't* do right now, and that we don't return assets for yet. This is the data about what character customization options you picked. You can combine this with DestinyCharacterCustomizationOptionDefinition to show some cool info, and hopefully someday to actually render a user's face in 3D. We'll see if we ever end up with time for that.</summary>
        [JsonPropertyName("customization")]
        public Character.DestinyCharacterCustomization Customization { get; set; }

        /// <summary>
        /// A minimal view of:
        /// - Equipped items
        /// - The rendering-related custom options on those equipped items
        /// Combined, that should be enough to render all of the items on the equipped character.
        /// </summary>
        [JsonPropertyName("peerView")]
        public Character.DestinyCharacterPeerView PeerView { get; set; }
    }

    /// <summary>
    /// This component holds activity data for a character. It will tell you about the character's current activity status, as well as activities that are available to the user.
    /// </summary>
    public class DestinyCharacterActivitiesComponent
    {
        /// <summary>The last date that the user started playing an activity.</summary>
        [JsonPropertyName("dateActivityStarted")]
        public DateTime DateActivityStarted { get; set; }

        /// <summary>The list of activities that the user can play.</summary>
        [JsonPropertyName("availableActivities")]
        public IEnumerable<DestinyActivity> AvailableActivities { get; set; }

        /// <summary>If the user is in an activity, this will be the hash of the Activity being played. Note that you must combine this info with currentActivityModeHash to get a real picture of what the user is doing right now. For instance, PVP "Activities" are just maps: it's the ActivityMode that determines what type of PVP game they're playing.</summary>
        [JsonPropertyName("currentActivityHash")]
        public uint CurrentActivityHash { get; set; }

        /// <summary>If the user is in an activity, this will be the hash of the activity mode being played. Combine with currentActivityHash to give a person a full picture of what they're doing right now.</summary>
        [JsonPropertyName("currentActivityModeHash")]
        public uint CurrentActivityModeHash { get; set; }

        /// <summary>And the current activity's most specific mode type, if it can be found.</summary>
        [JsonPropertyName("currentActivityModeType"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CurrentActivityModeType { get; set; }

        /// <summary>If the user is in an activity, this will be the hashes of the DestinyActivityModeDefinition being played. Combine with currentActivityHash to give a person a full picture of what they're doing right now.</summary>
        [JsonPropertyName("currentActivityModeHashes")]
        public IEnumerable<uint> CurrentActivityModeHashes { get; set; }

        /// <summary>All Activity Modes that apply to the current activity being played, in enum form.</summary>
        [JsonPropertyName("currentActivityModeTypes")]
        public IEnumerable<HistoricalStats.Definitions.DestinyActivityModeType> CurrentActivityModeTypes { get; set; }

        /// <summary>If the user is in a playlist, this is the hash identifier for the playlist that they chose.</summary>
        [JsonPropertyName("currentPlaylistActivityHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? CurrentPlaylistActivityHash { get; set; }

        /// <summary>This will have the activity hash of the last completed story/campaign mission, in case you care about that.</summary>
        [JsonPropertyName("lastCompletedStoryHash")]
        public uint LastCompletedStoryHash { get; set; }
    }
}