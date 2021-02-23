using BungieSharper.Entities.Destiny.Definitions;
using BungieSharper.Entities.Destiny.Definitions.ActivityModifiers;
using BungieSharper.Entities.Destiny.Definitions.Artifacts;
using BungieSharper.Entities.Destiny.Definitions.BreakerTypes;
using BungieSharper.Entities.Destiny.Definitions.Checklists;
using BungieSharper.Entities.Destiny.Definitions.Collectibles;
using BungieSharper.Entities.Destiny.Definitions.Director;
using BungieSharper.Entities.Destiny.Definitions.EnergyTypes;
using BungieSharper.Entities.Destiny.Definitions.Items;
using BungieSharper.Entities.Destiny.Definitions.Lore;
using BungieSharper.Entities.Destiny.Definitions.Metrics;
using BungieSharper.Entities.Destiny.Definitions.Milestones;
using BungieSharper.Entities.Destiny.Definitions.PowerCaps;
using BungieSharper.Entities.Destiny.Definitions.Presentation;
using BungieSharper.Entities.Destiny.Definitions.Progression;
using BungieSharper.Entities.Destiny.Definitions.Records;
using BungieSharper.Entities.Destiny.Definitions.Reporting;
using BungieSharper.Entities.Destiny.Definitions.Seasons;
using BungieSharper.Entities.Destiny.Definitions.Sockets;
using BungieSharper.Entities.Destiny.Definitions.Traits;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities
{
    internal class AggregateDestinyDefinitions
    {
        // [JsonPropertyName("DestinyEnemyRaceDefinition")]
        // public DestinyEnemyRaceDefinition? EnemyRaces { get; set; }

        // [JsonPropertyName("DestinyNodeStepSummaryDefinition")]
        // public DestinyNodeStepSummaryDefinition? NodeStepSummaries { get; set; }

        // [JsonPropertyName("DestinyArtDyeChannelDefinition")]
        // public DestinyArtDyeChannelDefinition? ArtDyeChannels { get; set; }

        // [JsonPropertyName("DestinyArtDyeReferenceDefinition")]
        // public DestinyArtDyeReferenceDefinition? ArtDyeReferences { get; set; }

        [JsonPropertyName("DestinyPlaceDefinition")]
        public DestinyPlaceDefinition? Places { get; set; }

        [JsonPropertyName("DestinyActivityDefinition")]
        public DestinyActivityDefinition? Activities { get; set; }

        [JsonPropertyName("DestinyActivityTypeDefinition")]
        public DestinyActivityTypeDefinition? ActivityTypes { get; set; }

        [JsonPropertyName("DestinyClassDefinition")]
        public DestinyClassDefinition? Classes { get; set; }

        [JsonPropertyName("DestinyGenderDefinition")]
        public DestinyGenderDefinition? Genders { get; set; }

        [JsonPropertyName("DestinyInventoryBucketDefinition")]
        public DestinyInventoryBucketDefinition? InventoryBuckets { get; set; }

        [JsonPropertyName("DestinyRaceDefinition")]
        public DestinyRaceDefinition? Races { get; set; }

        [JsonPropertyName("DestinyTalentGridDefinition")]
        public DestinyTalentGridDefinition? TalentGrids { get; set; }

        [JsonPropertyName("DestinyUnlockDefinition")]
        public DestinyUnlockDefinition? Unlocks { get; set; }

        [JsonPropertyName("DestinyMaterialRequirementSetDefinition")]
        public DestinyMaterialRequirementSetDefinition? MaterialRequirementSets { get; set; }

        [JsonPropertyName("DestinySandboxPerkDefinition")]
        public DestinySandboxPerkDefinition? SandboxPerks { get; set; }

        [JsonPropertyName("DestinyStatGroupDefinition")]
        public DestinyStatGroupDefinition? StatGroups { get; set; }

        [JsonPropertyName("DestinyProgressionMappingDefinition")]
        public DestinyProgressionMappingDefinition? ProgressionMappings { get; set; }

        [JsonPropertyName("DestinyFactionDefinition")]
        public DestinyFactionDefinition? Factions { get; set; }

        [JsonPropertyName("DestinyVendorGroupDefinition")]
        public DestinyVendorGroupDefinition? VendorGroups { get; set; }

        [JsonPropertyName("DestinyRewardSourceDefinition")]
        public DestinyRewardSourceDefinition? RewardSources { get; set; }

        [JsonPropertyName("DestinyUnlockValueDefinition")]
        public DestinyUnlockValueDefinition? UnlockValues { get; set; }

        // [JsonPropertyName("DestinyRewardMappingDefinition")]
        // public DestinyRewardMappingDefinition? RewardMappings { get; set; }

        // [JsonPropertyName("DestinyRewardSheetDefinition")]
        // public DestinyRewardSheetDefinition? RewardSheets { get; set; }

        [JsonPropertyName("DestinyItemCategoryDefinition")]
        public DestinyItemCategoryDefinition? ItemCategories { get; set; }

        [JsonPropertyName("DestinyDamageTypeDefinition")]
        public DestinyDamageTypeDefinition? DamageTypes { get; set; }

        [JsonPropertyName("DestinyActivityModeDefinition")]
        public DestinyActivityModeDefinition? ActivityModes { get; set; }

        // [JsonPropertyName("DestinyMedalTierDefinition")]
        // public DestinyMedalTierDefinition? MedalTiers { get; set; }

        // [JsonPropertyName("DestinyAchievementDefinition")]
        // public DestinyAchievementDefinition? Achievements { get; set; }

        [JsonPropertyName("DestinyActivityGraphDefinition")]
        public DestinyActivityGraphDefinition? ActivityGraphs { get; set; }

        // [JsonPropertyName("DestinyActivityInteractableDefinition")]
        // public DestinyActivityInteractableDefinition? ActivityInteractables { get; set; }

        // [JsonPropertyName("DestinyBondDefinition")]
        // public DestinyBondDefinition? Bonds { get; set; }

        // [JsonPropertyName("DestinyCharacterCustomizationCategoryDefinition")]
        // public DestinyCharacterCustomizationCategoryDefinition? CharacterCustomizationCategories { get; set; }

        // [JsonPropertyName("DestinyCharacterCustomizationOptionDefinition")]
        // public DestinyCharacterCustomizationOptionDefinition? CharacterCustomizationOptions { get; set; }

        [JsonPropertyName("DestinyCollectibleDefinition")]
        public DestinyCollectibleDefinition? Collectibles { get; set; }

        [JsonPropertyName("DestinyDestinationDefinition")]
        public DestinyDestinationDefinition? Destinations { get; set; }

        // [JsonPropertyName("DestinyEntitlementOfferDefinition")]
        // public DestinyEntitlementOfferDefinition? EntitlementOffers { get; set; }

        [JsonPropertyName("DestinyEquipmentSlotDefinition")]
        public DestinyEquipmentSlotDefinition? EquipmentSlots { get; set; }

        [JsonPropertyName("DestinyStatDefinition")]
        public DestinyStatDefinition? Stats { get; set; }

        [JsonPropertyName("DestinyInventoryItemDefinition")]
        public DestinyInventoryItemDefinition? InventoryItems { get; set; }

        // [JsonPropertyName("DestinyInventoryItemLiteDefinition")]
        // public DestinyInventoryItemLiteDefinition? InventoryItemsLite { get; set; }

        [JsonPropertyName("DestinyItemTierTypeDefinition")]
        public DestinyItemTierTypeDefinition? ItemTierTypes { get; set; }

        [JsonPropertyName("DestinyLocationDefinition")]
        public DestinyLocationDefinition? Locations { get; set; }

        [JsonPropertyName("DestinyLoreDefinition")]
        public DestinyLoreDefinition? Lore { get; set; }

        [JsonPropertyName("DestinyMetricDefinition")]
        public DestinyMetricDefinition? Metrics { get; set; }

        [JsonPropertyName("DestinyObjectiveDefinition")]
        public DestinyObjectiveDefinition? Objectives { get; set; }

        // [JsonPropertyName("DestinyPlatformBucketMappingDefinition")]
        // public DestinyPlatformBucketMappingDefinition? PlatformBucketMappings { get; set; }

        [JsonPropertyName("DestinyPlugSetDefinition")]
        public DestinyPlugSetDefinition? PlugSets { get; set; }

        [JsonPropertyName("DestinyPowerCapDefinition")]
        public DestinyPowerCapDefinition? PowerCaps { get; set; }

        [JsonPropertyName("DestinyPresentationNodeDefinition")]
        public DestinyPresentationNodeDefinition? PresentationNodes { get; set; }

        [JsonPropertyName("DestinyPresentationNodeBaseDefinition")]
        public DestinyPresentationNodeBaseDefinition? PresentationNodeBases { get; set; }

        [JsonPropertyName("DestinyProgressionDefinition")]
        public DestinyProgressionDefinition? Progressions { get; set; }

        [JsonPropertyName("DestinyProgressionLevelRequirementDefinition")]
        public DestinyProgressionLevelRequirementDefinition? ProgressionLevelRequirements { get; set; }

        [JsonPropertyName("DestinyRecordDefinition")]
        public DestinyRecordDefinition? Records { get; set; }

        // [JsonPropertyName("DestinyRewardAdjusterPointerDefinition")]
        // public DestinyRewardAdjusterPointerDefinition? RewardAdjusterPointers { get; set; }

        // [JsonPropertyName("DestinyRewardAdjusterProgressionMapDefinition")]
        // public DestinyRewardAdjusterProgressionMapDefinition? RewardAdjusterProgressionMaps { get; set; }

        // [JsonPropertyName("DestinyRewardItemListDefinition")]
        // public DestinyRewardItemListDefinition? RewardItemLists { get; set; }

        // [JsonPropertyName("DestinySackRewardItemListDefinition")]
        // public DestinySackRewardItemListDefinition? SackRewardItemLists { get; set; }

        // [JsonPropertyName("DestinySandboxPatternDefinition")]
        // public DestinySandboxPatternDefinition? SandboxPatterns { get; set; }

        [JsonPropertyName("DestinySeasonDefinition")]
        public DestinySeasonDefinition? Seasons { get; set; }

        [JsonPropertyName("DestinySeasonPassDefinition")]
        public DestinySeasonPassDefinition? SeasonPasses { get; set; }

        [JsonPropertyName("DestinySocketCategoryDefinition")]
        public DestinySocketCategoryDefinition? SocketCategories { get; set; }

        [JsonPropertyName("DestinySocketTypeDefinition")]
        public DestinySocketTypeDefinition? SocketTypes { get; set; }

        [JsonPropertyName("DestinyTraitDefinition")]
        public DestinyTraitDefinition? Traits { get; set; }

        [JsonPropertyName("DestinyTraitCategoryDefinition")]
        public DestinyTraitCategoryDefinition? TraitCategories { get; set; }

        // [JsonPropertyName("DestinyUnlockCountMappingDefinition")]
        // public DestinyUnlockCountMappingDefinition? UnlockCountMappings { get; set; }

        // [JsonPropertyName("DestinyUnlockEventDefinition")]
        // public DestinyUnlockEventDefinition? UnlockEvents { get; set; }

        // [JsonPropertyName("DestinyUnlockExpressionMappingDefinition")]
        // public DestinyUnlockExpressionMappingDefinition? UnlockExpressionMappings { get; set; }

        [JsonPropertyName("DestinyVendorDefinition")]
        public DestinyVendorDefinition? Vendors { get; set; }

        [JsonPropertyName("DestinyMilestoneDefinition")]
        public DestinyMilestoneDefinition? Milestones { get; set; }

        [JsonPropertyName("DestinyActivityModifierDefinition")]
        public DestinyActivityModifierDefinition? ActivityModifiers { get; set; }

        [JsonPropertyName("DestinyReportReasonCategoryDefinition")]
        public DestinyReportReasonCategoryDefinition? ReportReasonCategories { get; set; }

        [JsonPropertyName("DestinyArtifactDefinition")]
        public DestinyArtifactDefinition? Artifacts { get; set; }

        [JsonPropertyName("DestinyBreakerTypeDefinition")]
        public DestinyBreakerTypeDefinition? BreakerTypes { get; set; }

        [JsonPropertyName("DestinyChecklistDefinition")]
        public DestinyChecklistDefinition? Checklists { get; set; }

        [JsonPropertyName("DestinyEnergyTypeDefinition")]
        public DestinyEnergyTypeDefinition? EnergyTypes { get; set; }
    }
}