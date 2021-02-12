using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Common.Models
{
    public class CoreSettingsConfiguration
    {
        [JsonPropertyName("environment")]
        public string Environment { get; set; }

        [JsonPropertyName("systems")]
        public Dictionary<string, Common.Models.CoreSystem> Systems { get; set; }

        [JsonPropertyName("ignoreReasons")]
        public IEnumerable<Common.Models.CoreSetting> IgnoreReasons { get; set; }

        [JsonPropertyName("forumCategories")]
        public IEnumerable<Common.Models.CoreSetting> ForumCategories { get; set; }

        [JsonPropertyName("groupAvatars")]
        public IEnumerable<Common.Models.CoreSetting> GroupAvatars { get; set; }

        [JsonPropertyName("destinyMembershipTypes")]
        public IEnumerable<Common.Models.CoreSetting> DestinyMembershipTypes { get; set; }

        [JsonPropertyName("recruitmentPlatformTags")]
        public IEnumerable<Common.Models.CoreSetting> RecruitmentPlatformTags { get; set; }

        [JsonPropertyName("recruitmentMiscTags")]
        public IEnumerable<Common.Models.CoreSetting> RecruitmentMiscTags { get; set; }

        [JsonPropertyName("recruitmentActivities")]
        public IEnumerable<Common.Models.CoreSetting> RecruitmentActivities { get; set; }

        [JsonPropertyName("userContentLocales")]
        public IEnumerable<Common.Models.CoreSetting> UserContentLocales { get; set; }

        [JsonPropertyName("systemContentLocales")]
        public IEnumerable<Common.Models.CoreSetting> SystemContentLocales { get; set; }

        [JsonPropertyName("clanBannerDecals")]
        public IEnumerable<Common.Models.CoreSetting> ClanBannerDecals { get; set; }

        [JsonPropertyName("clanBannerDecalColors")]
        public IEnumerable<Common.Models.CoreSetting> ClanBannerDecalColors { get; set; }

        [JsonPropertyName("clanBannerGonfalons")]
        public IEnumerable<Common.Models.CoreSetting> ClanBannerGonfalons { get; set; }

        [JsonPropertyName("clanBannerGonfalonColors")]
        public IEnumerable<Common.Models.CoreSetting> ClanBannerGonfalonColors { get; set; }

        [JsonPropertyName("clanBannerGonfalonDetails")]
        public IEnumerable<Common.Models.CoreSetting> ClanBannerGonfalonDetails { get; set; }

        [JsonPropertyName("clanBannerGonfalonDetailColors")]
        public IEnumerable<Common.Models.CoreSetting> ClanBannerGonfalonDetailColors { get; set; }

        [JsonPropertyName("clanBannerStandards")]
        public IEnumerable<Common.Models.CoreSetting> ClanBannerStandards { get; set; }

        [JsonPropertyName("destiny2CoreSettings")]
        public Common.Models.Destiny2CoreSettings Destiny2CoreSettings { get; set; }

        [JsonPropertyName("emailSettings")]
        public User.EmailSettings EmailSettings { get; set; }

        [JsonPropertyName("fireteamActivities")]
        public IEnumerable<Common.Models.CoreSetting> FireteamActivities { get; set; }
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
        public IEnumerable<Common.Models.CoreSetting> ChildSettings { get; set; }
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

        [JsonPropertyName("futureSeasonHashes")]
        public IEnumerable<uint> FutureSeasonHashes { get; set; }

        [JsonPropertyName("pastSeasonHashes")]
        public IEnumerable<uint> PastSeasonHashes { get; set; }
    }
}