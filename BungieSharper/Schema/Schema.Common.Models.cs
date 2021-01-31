using System.Collections.Generic;

namespace BungieSharper.Schema.Common.Models
{
    public class CoreSettingsConfiguration
    {
        public string environment { get; set; }
        public Dictionary<string, Schema.Common.Models.CoreSystem> systems { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> ignoreReasons { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> forumCategories { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> groupAvatars { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> destinyMembershipTypes { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> recruitmentPlatformTags { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> recruitmentMiscTags { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> recruitmentActivities { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> userContentLocales { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> systemContentLocales { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> clanBannerDecals { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> clanBannerDecalColors { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> clanBannerGonfalons { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> clanBannerGonfalonColors { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> clanBannerGonfalonDetails { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> clanBannerGonfalonDetailColors { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> clanBannerStandards { get; set; }
        public Schema.Common.Models.Destiny2CoreSettings destiny2CoreSettings { get; set; }
        public Schema.User.EmailSettings emailSettings { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> fireteamActivities { get; set; }
    }

    public class CoreSystem
    {
        public bool enabled { get; set; }
        public Dictionary<string, string> parameters { get; set; }
    }

    public class CoreSetting
    {
        public string identifier { get; set; }
        public bool isDefault { get; set; }
        public string displayName { get; set; }
        public string summary { get; set; }
        public string imagePath { get; set; }
        public IEnumerable<Schema.Common.Models.CoreSetting> childSettings { get; set; }
    }

    public class Destiny2CoreSettings
    {
        public uint collectionRootNode { get; set; }
        public uint badgesRootNode { get; set; }
        public uint recordsRootNode { get; set; }
        public uint medalsRootNode { get; set; }
        public uint metricsRootNode { get; set; }
        public uint activeTriumphsRootNodeHash { get; set; }
        public uint activeSealsRootNodeHash { get; set; }
        public uint legacyTriumphsRootNodeHash { get; set; }
        public uint legacySealsRootNodeHash { get; set; }
        public uint medalsRootNodeHash { get; set; }
        public uint exoticCatalystsRootNodeHash { get; set; }
        public uint loreRootNodeHash { get; set; }
        public IEnumerable<uint> currentRankProgressionHashes { get; set; }
        public string undiscoveredCollectibleImage { get; set; }
        public string ammoTypeHeavyIcon { get; set; }
        public string ammoTypeSpecialIcon { get; set; }
        public string ammoTypePrimaryIcon { get; set; }
        public uint currentSeasonalArtifactHash { get; set; }
        public uint? currentSeasonHash { get; set; }
        public IEnumerable<uint> futureSeasonHashes { get; set; }
        public IEnumerable<uint> pastSeasonHashes { get; set; }
    }
}