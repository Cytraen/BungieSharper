using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Common.Models
{
    public class CoreSettingsConfiguration
    {
        [JsonPropertyName("environment")]
        public string Environment { get; set; }

        [JsonPropertyName("systems")]
        public Dictionary<string, CoreSystem> Systems { get; set; }

        [JsonPropertyName("ignoreReasons")]
        public IEnumerable<CoreSetting> IgnoreReasons { get; set; }

        [JsonPropertyName("forumCategories")]
        public IEnumerable<CoreSetting> ForumCategories { get; set; }

        [JsonPropertyName("groupAvatars")]
        public IEnumerable<CoreSetting> GroupAvatars { get; set; }

        [JsonPropertyName("destinyMembershipTypes")]
        public IEnumerable<CoreSetting> DestinyMembershipTypes { get; set; }

        [JsonPropertyName("recruitmentPlatformTags")]
        public IEnumerable<CoreSetting> RecruitmentPlatformTags { get; set; }

        [JsonPropertyName("recruitmentMiscTags")]
        public IEnumerable<CoreSetting> RecruitmentMiscTags { get; set; }

        [JsonPropertyName("recruitmentActivities")]
        public IEnumerable<CoreSetting> RecruitmentActivities { get; set; }

        [JsonPropertyName("userContentLocales")]
        public IEnumerable<CoreSetting> UserContentLocales { get; set; }

        [JsonPropertyName("systemContentLocales")]
        public IEnumerable<CoreSetting> SystemContentLocales { get; set; }

        [JsonPropertyName("clanBannerDecals")]
        public IEnumerable<CoreSetting> ClanBannerDecals { get; set; }

        [JsonPropertyName("clanBannerDecalColors")]
        public IEnumerable<CoreSetting> ClanBannerDecalColors { get; set; }

        [JsonPropertyName("clanBannerGonfalons")]
        public IEnumerable<CoreSetting> ClanBannerGonfalons { get; set; }

        [JsonPropertyName("clanBannerGonfalonColors")]
        public IEnumerable<CoreSetting> ClanBannerGonfalonColors { get; set; }

        [JsonPropertyName("clanBannerGonfalonDetails")]
        public IEnumerable<CoreSetting> ClanBannerGonfalonDetails { get; set; }

        [JsonPropertyName("clanBannerGonfalonDetailColors")]
        public IEnumerable<CoreSetting> ClanBannerGonfalonDetailColors { get; set; }

        [JsonPropertyName("clanBannerStandards")]
        public IEnumerable<CoreSetting> ClanBannerStandards { get; set; }

        [JsonPropertyName("destiny2CoreSettings")]
        public Destiny2CoreSettings Destiny2CoreSettings { get; set; }

        [JsonPropertyName("emailSettings")]
        public User.EmailSettings EmailSettings { get; set; }

        [JsonPropertyName("fireteamActivities")]
        public IEnumerable<CoreSetting> FireteamActivities { get; set; }
    }

    public class CoreSystem
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("parameters")]
        public Dictionary<string, string> Parameters { get; set; }
    }

    public class CoreSetting
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("isDefault")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; }

        [JsonPropertyName("childSettings")]
        public IEnumerable<CoreSetting> ChildSettings { get; set; }
    }

    public class Destiny2CoreSettings
    {
        [JsonPropertyName("collectionRootNode")]
        public uint CollectionRootNode { get; set; }

        [JsonPropertyName("badgesRootNode")]
        public uint BadgesRootNode { get; set; }

        [JsonPropertyName("recordsRootNode")]
        public uint RecordsRootNode { get; set; }

        [JsonPropertyName("medalsRootNode")]
        public uint MedalsRootNode { get; set; }

        [JsonPropertyName("metricsRootNode")]
        public uint MetricsRootNode { get; set; }

        [JsonPropertyName("activeTriumphsRootNodeHash")]
        public uint ActiveTriumphsRootNodeHash { get; set; }

        [JsonPropertyName("activeSealsRootNodeHash")]
        public uint ActiveSealsRootNodeHash { get; set; }

        [JsonPropertyName("legacyTriumphsRootNodeHash")]
        public uint LegacyTriumphsRootNodeHash { get; set; }

        [JsonPropertyName("legacySealsRootNodeHash")]
        public uint LegacySealsRootNodeHash { get; set; }

        [JsonPropertyName("medalsRootNodeHash")]
        public uint MedalsRootNodeHash { get; set; }

        [JsonPropertyName("exoticCatalystsRootNodeHash")]
        public uint ExoticCatalystsRootNodeHash { get; set; }

        [JsonPropertyName("loreRootNodeHash")]
        public uint LoreRootNodeHash { get; set; }

        [JsonPropertyName("currentRankProgressionHashes")]
        public IEnumerable<uint> CurrentRankProgressionHashes { get; set; }

        [JsonPropertyName("undiscoveredCollectibleImage")]
        public string UndiscoveredCollectibleImage { get; set; }

        [JsonPropertyName("ammoTypeHeavyIcon")]
        public string AmmoTypeHeavyIcon { get; set; }

        [JsonPropertyName("ammoTypeSpecialIcon")]
        public string AmmoTypeSpecialIcon { get; set; }

        [JsonPropertyName("ammoTypePrimaryIcon")]
        public string AmmoTypePrimaryIcon { get; set; }

        [JsonPropertyName("currentSeasonalArtifactHash")]
        public uint CurrentSeasonalArtifactHash { get; set; }

        [JsonPropertyName("currentSeasonHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? CurrentSeasonHash { get; set; }

        [JsonPropertyName("seasonalChallengesPresentationNodeHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? SeasonalChallengesPresentationNodeHash { get; set; }

        [JsonPropertyName("futureSeasonHashes")]
        public IEnumerable<uint> FutureSeasonHashes { get; set; }

        [JsonPropertyName("pastSeasonHashes")]
        public IEnumerable<uint> PastSeasonHashes { get; set; }
    }
}