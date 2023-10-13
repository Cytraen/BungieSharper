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
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities;

public class AggregateDestinyDefinitions
{
    // [JsonPropertyName("DestinyEnemyRaceDefinition")]
    // public Dictionary<uint, DestinyEnemyRaceDefinition>? EnemyRaces { get; set; }

    // [JsonPropertyName("DestinyNodeStepSummaryDefinition")]
    // public Dictionary<uint, DestinyNodeStepSummaryDefinition>? NodeStepSummaries { get; set; }

    // [JsonPropertyName("DestinyArtDyeChannelDefinition")]
    // public Dictionary<uint, DestinyArtDyeChannelDefinition>? ArtDyeChannels { get; set; }

    // [JsonPropertyName("DestinyArtDyeReferenceDefinition")]
    // public Dictionary<uint, DestinyArtDyeReferenceDefinition>? ArtDyeReferences { get; set; }

    [JsonPropertyName("DestinyPlaceDefinition")]
    public Dictionary<uint, DestinyPlaceDefinition>? Places { get; set; }

    [JsonPropertyName("DestinyActivityDefinition")]
    public Dictionary<uint, DestinyActivityDefinition>? Activities { get; set; }

    [JsonPropertyName("DestinyActivityTypeDefinition")]
    public Dictionary<uint, DestinyActivityTypeDefinition>? ActivityTypes { get; set; }

    [JsonPropertyName("DestinyClassDefinition")]
    public Dictionary<uint, DestinyClassDefinition>? Classes { get; set; }

    [JsonPropertyName("DestinyGenderDefinition")]
    public Dictionary<uint, DestinyGenderDefinition>? Genders { get; set; }

    [JsonPropertyName("DestinyInventoryBucketDefinition")]
    public Dictionary<uint, DestinyInventoryBucketDefinition>? InventoryBuckets { get; set; }

    [JsonPropertyName("DestinyRaceDefinition")]
    public Dictionary<uint, DestinyRaceDefinition>? Races { get; set; }

    [JsonPropertyName("DestinyTalentGridDefinition")]
    public Dictionary<uint, DestinyTalentGridDefinition>? TalentGrids { get; set; }

    [JsonPropertyName("DestinyUnlockDefinition")]
    public Dictionary<uint, DestinyUnlockDefinition>? Unlocks { get; set; }

    [JsonPropertyName("DestinyMaterialRequirementSetDefinition")]
    public Dictionary<uint, DestinyMaterialRequirementSetDefinition>? MaterialRequirementSets { get; set; }

    [JsonPropertyName("DestinySandboxPerkDefinition")]
    public Dictionary<uint, DestinySandboxPerkDefinition>? SandboxPerks { get; set; }

    [JsonPropertyName("DestinyStatGroupDefinition")]
    public Dictionary<uint, DestinyStatGroupDefinition>? StatGroups { get; set; }

    [JsonPropertyName("DestinyProgressionMappingDefinition")]
    public Dictionary<uint, DestinyProgressionMappingDefinition>? ProgressionMappings { get; set; }

    [JsonPropertyName("DestinyFactionDefinition")]
    public Dictionary<uint, DestinyFactionDefinition>? Factions { get; set; }

    [JsonPropertyName("DestinyVendorGroupDefinition")]
    public Dictionary<uint, DestinyVendorGroupDefinition>? VendorGroups { get; set; }

    [JsonPropertyName("DestinyRewardSourceDefinition")]
    public Dictionary<uint, DestinyRewardSourceDefinition>? RewardSources { get; set; }

    [JsonPropertyName("DestinyUnlockValueDefinition")]
    public Dictionary<uint, DestinyUnlockValueDefinition>? UnlockValues { get; set; }

    // [JsonPropertyName("DestinyRewardMappingDefinition")]
    // public Dictionary<uint, DestinyRewardMappingDefinition>? RewardMappings { get; set; }

    // [JsonPropertyName("DestinyRewardSheetDefinition")]
    // public Dictionary<uint, DestinyRewardSheetDefinition>? RewardSheets { get; set; }

    [JsonPropertyName("DestinyItemCategoryDefinition")]
    public Dictionary<uint, DestinyItemCategoryDefinition>? ItemCategories { get; set; }

    [JsonPropertyName("DestinyDamageTypeDefinition")]
    public Dictionary<uint, DestinyDamageTypeDefinition>? DamageTypes { get; set; }

    [JsonPropertyName("DestinyActivityModeDefinition")]
    public Dictionary<uint, DestinyActivityModeDefinition>? ActivityModes { get; set; }

    // [JsonPropertyName("DestinyMedalTierDefinition")]
    // public Dictionary<uint, DestinyMedalTierDefinition>? MedalTiers { get; set; }

    // [JsonPropertyName("DestinyAchievementDefinition")]
    // public Dictionary<uint, DestinyAchievementDefinition>? Achievements { get; set; }

    [JsonPropertyName("DestinyActivityGraphDefinition")]
    public Dictionary<uint, DestinyActivityGraphDefinition>? ActivityGraphs { get; set; }

    // [JsonPropertyName("DestinyActivityInteractableDefinition")]
    // public Dictionary<uint, DestinyActivityInteractableDefinition>? ActivityInteractables { get; set; }

    // [JsonPropertyName("DestinyBondDefinition")]
    // public Dictionary<uint, DestinyBondDefinition>? Bonds { get; set; }

    // [JsonPropertyName("DestinyCharacterCustomizationCategoryDefinition")]
    // public Dictionary<uint, DestinyCharacterCustomizationCategoryDefinition>? CharacterCustomizationCategories { get; set; }

    // [JsonPropertyName("DestinyCharacterCustomizationOptionDefinition")]
    // public Dictionary<uint, DestinyCharacterCustomizationOptionDefinition>? CharacterCustomizationOptions { get; set; }

    [JsonPropertyName("DestinyCollectibleDefinition")]
    public Dictionary<uint, DestinyCollectibleDefinition>? Collectibles { get; set; }

    [JsonPropertyName("DestinyDestinationDefinition")]
    public Dictionary<uint, DestinyDestinationDefinition>? Destinations { get; set; }

    // [JsonPropertyName("DestinyEntitlementOfferDefinition")]
    // public Dictionary<uint, DestinyEntitlementOfferDefinition>? EntitlementOffers { get; set; }

    [JsonPropertyName("DestinyEquipmentSlotDefinition")]
    public Dictionary<uint, DestinyEquipmentSlotDefinition>? EquipmentSlots { get; set; }

    [JsonPropertyName("DestinyStatDefinition")]
    public Dictionary<uint, DestinyStatDefinition>? Stats { get; set; }

    [JsonPropertyName("DestinyInventoryItemDefinition")]
    public Dictionary<uint, DestinyInventoryItemDefinition>? InventoryItems { get; set; }

    // [JsonPropertyName("DestinyInventoryItemLiteDefinition")]
    // public Dictionary<uint, DestinyInventoryItemLiteDefinition>? InventoryItemsLite { get; set; }

    [JsonPropertyName("DestinyItemTierTypeDefinition")]
    public Dictionary<uint, DestinyItemTierTypeDefinition>? ItemTierTypes { get; set; }

    [JsonPropertyName("DestinyLocationDefinition")]
    public Dictionary<uint, DestinyLocationDefinition>? Locations { get; set; }

    [JsonPropertyName("DestinyLoreDefinition")]
    public Dictionary<uint, DestinyLoreDefinition>? Lore { get; set; }

    [JsonPropertyName("DestinyMetricDefinition")]
    public Dictionary<uint, DestinyMetricDefinition>? Metrics { get; set; }

    [JsonPropertyName("DestinyObjectiveDefinition")]
    public Dictionary<uint, DestinyObjectiveDefinition>? Objectives { get; set; }

    // [JsonPropertyName("DestinyPlatformBucketMappingDefinition")]
    // public Dictionary<uint, DestinyPlatformBucketMappingDefinition>? PlatformBucketMappings { get; set; }

    [JsonPropertyName("DestinyPlugSetDefinition")]
    public Dictionary<uint, DestinyPlugSetDefinition>? PlugSets { get; set; }

    [JsonPropertyName("DestinyPowerCapDefinition")]
    public Dictionary<uint, DestinyPowerCapDefinition>? PowerCaps { get; set; }

    [JsonPropertyName("DestinyPresentationNodeDefinition")]
    public Dictionary<uint, DestinyPresentationNodeDefinition>? PresentationNodes { get; set; }

    [JsonPropertyName("DestinyPresentationNodeBaseDefinition")]
    public Dictionary<uint, DestinyPresentationNodeBaseDefinition>? PresentationNodeBases { get; set; }

    [JsonPropertyName("DestinyProgressionDefinition")]
    public Dictionary<uint, DestinyProgressionDefinition>? Progressions { get; set; }

    [JsonPropertyName("DestinyProgressionLevelRequirementDefinition")]
    public Dictionary<uint, DestinyProgressionLevelRequirementDefinition>? ProgressionLevelRequirements { get; set; }

    [JsonPropertyName("DestinyRecordDefinition")]
    public Dictionary<uint, DestinyRecordDefinition>? Records { get; set; }

    // [JsonPropertyName("DestinyRewardAdjusterPointerDefinition")]
    // public Dictionary<uint, DestinyRewardAdjusterPointerDefinition>? RewardAdjusterPointers { get; set; }

    // [JsonPropertyName("DestinyRewardAdjusterProgressionMapDefinition")]
    // public Dictionary<uint, DestinyRewardAdjusterProgressionMapDefinition>? RewardAdjusterProgressionMaps { get; set; }

    // [JsonPropertyName("DestinyRewardItemListDefinition")]
    // public Dictionary<uint, DestinyRewardItemListDefinition>? RewardItemLists { get; set; }

    // [JsonPropertyName("DestinySackRewardItemListDefinition")]
    // public Dictionary<uint, DestinySackRewardItemListDefinition>? SackRewardItemLists { get; set; }

    // [JsonPropertyName("DestinySandboxPatternDefinition")]
    // public Dictionary<uint, DestinySandboxPatternDefinition>? SandboxPatterns { get; set; }

    [JsonPropertyName("DestinySeasonDefinition")]
    public Dictionary<uint, DestinySeasonDefinition>? Seasons { get; set; }

    [JsonPropertyName("DestinySeasonPassDefinition")]
    public Dictionary<uint, DestinySeasonPassDefinition>? SeasonPasses { get; set; }

    [JsonPropertyName("DestinySocketCategoryDefinition")]
    public Dictionary<uint, DestinySocketCategoryDefinition>? SocketCategories { get; set; }

    [JsonPropertyName("DestinySocketTypeDefinition")]
    public Dictionary<uint, DestinySocketTypeDefinition>? SocketTypes { get; set; }

    [JsonPropertyName("DestinyTraitDefinition")]
    public Dictionary<uint, DestinyTraitDefinition>? Traits { get; set; }

    // [JsonPropertyName("DestinyTraitCategoryDefinition")]
    // public Dictionary<uint, DestinyTraitCategoryDefinition>? TraitCategories { get; set; }

    // [JsonPropertyName("DestinyUnlockCountMappingDefinition")]
    // public Dictionary<uint, DestinyUnlockCountMappingDefinition>? UnlockCountMappings { get; set; }

    // [JsonPropertyName("DestinyUnlockEventDefinition")]
    // public Dictionary<uint, DestinyUnlockEventDefinition>? UnlockEvents { get; set; }

    // [JsonPropertyName("DestinyUnlockExpressionMappingDefinition")]
    // public Dictionary<uint, DestinyUnlockExpressionMappingDefinition>? UnlockExpressionMappings { get; set; }

    [JsonPropertyName("DestinyVendorDefinition")]
    public Dictionary<uint, DestinyVendorDefinition>? Vendors { get; set; }

    [JsonPropertyName("DestinyMilestoneDefinition")]
    public Dictionary<uint, DestinyMilestoneDefinition>? Milestones { get; set; }

    [JsonPropertyName("DestinyActivityModifierDefinition")]
    public Dictionary<uint, DestinyActivityModifierDefinition>? ActivityModifiers { get; set; }

    [JsonPropertyName("DestinyReportReasonCategoryDefinition")]
    public Dictionary<uint, DestinyReportReasonCategoryDefinition>? ReportReasonCategories { get; set; }

    [JsonPropertyName("DestinyArtifactDefinition")]
    public Dictionary<uint, DestinyArtifactDefinition>? Artifacts { get; set; }

    [JsonPropertyName("DestinyBreakerTypeDefinition")]
    public Dictionary<uint, DestinyBreakerTypeDefinition>? BreakerTypes { get; set; }

    [JsonPropertyName("DestinyChecklistDefinition")]
    public Dictionary<uint, DestinyChecklistDefinition>? Checklists { get; set; }

    [JsonPropertyName("DestinyEnergyTypeDefinition")]
    public Dictionary<uint, DestinyEnergyTypeDefinition>? EnergyTypes { get; set; }
}