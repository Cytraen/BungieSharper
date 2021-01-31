using BungieSharper.Schema.Destiny.Definitions;
using BungieSharper.Schema.Destiny.Definitions.ActivityModifiers;
using BungieSharper.Schema.Destiny.Definitions.Artifacts;
using BungieSharper.Schema.Destiny.Definitions.BreakerTypes;
using BungieSharper.Schema.Destiny.Definitions.Checklists;
using BungieSharper.Schema.Destiny.Definitions.Collectibles;
using BungieSharper.Schema.Destiny.Definitions.Director;
using BungieSharper.Schema.Destiny.Definitions.EnergyTypes;
using BungieSharper.Schema.Destiny.Definitions.Items;
using BungieSharper.Schema.Destiny.Definitions.Lore;
using BungieSharper.Schema.Destiny.Definitions.Metrics;
using BungieSharper.Schema.Destiny.Definitions.Milestones;
using BungieSharper.Schema.Destiny.Definitions.PowerCaps;
using BungieSharper.Schema.Destiny.Definitions.Presentation;
using BungieSharper.Schema.Destiny.Definitions.Progression;
using BungieSharper.Schema.Destiny.Definitions.Records;
using BungieSharper.Schema.Destiny.Definitions.Reporting;
using BungieSharper.Schema.Destiny.Definitions.Seasons;
using BungieSharper.Schema.Destiny.Definitions.Sockets;
using BungieSharper.Schema.Destiny.Definitions.Traits;
using System.Collections.Generic;

namespace BungieSharper.Schema
{
    public class BSharperManifest
    {
        // public Dictionary<uint, DestinyEnemyRaceDefinition> DestinyEnemyRaceDefinition { get; set; }

        // public Dictionary<uint, DestinyNodeStepSummaryDefinition> DestinyNodeStepSummaryDefinition { get; set; }

        // public Dictionary<uint, DestinyArtDyeChannelDefinition> DestinyArtDyeChannelDefinition { get; set; }

        // public Dictionary<uint, DestinyArtDyeReferenceDefinition> DestinyArtDyeReferenceDefinition { get; set; }

        public Dictionary<uint, DestinyPlaceDefinition> DestinyPlaceDefinition { get; set; }

        public Dictionary<uint, DestinyActivityDefinition> DestinyActivityDefinition { get; set; }

        public Dictionary<uint, DestinyActivityTypeDefinition> DestinyActivityTypeDefinition { get; set; }

        public Dictionary<uint, DestinyClassDefinition> DestinyClassDefinition { get; set; }

        public Dictionary<uint, DestinyGenderDefinition> DestinyGenderDefinition { get; set; }

        public Dictionary<uint, DestinyInventoryBucketDefinition> DestinyInventoryBucketDefinition { get; set; }

        public Dictionary<uint, DestinyRaceDefinition> DestinyRaceDefinition { get; set; }

        public Dictionary<uint, DestinyTalentGridDefinition> DestinyTalentGridDefinition { get; set; }

        public Dictionary<uint, DestinyUnlockDefinition> DestinyUnlockDefinition { get; set; }

        public Dictionary<uint, DestinyMaterialRequirementSetDefinition> DestinyMaterialRequirementSetDefinition { get; set; }

        public Dictionary<uint, DestinySandboxPerkDefinition> DestinySandboxPerkDefinition { get; set; }

        public Dictionary<uint, DestinyStatGroupDefinition> DestinyStatGroupDefinition { get; set; }

        public Dictionary<uint, DestinyProgressionMappingDefinition> DestinyProgressionMappingDefinition { get; set; }

        public Dictionary<uint, DestinyFactionDefinition> DestinyFactionDefinition { get; set; }

        public Dictionary<uint, DestinyVendorGroupDefinition> DestinyVendorGroupDefinition { get; set; }

        public Dictionary<uint, DestinyRewardSourceDefinition> DestinyRewardSourceDefinition { get; set; }

        public Dictionary<uint, DestinyUnlockValueDefinition> DestinyUnlockValueDefinition { get; set; }

        // public Dictionary<uint, DestinyRewardMappingDefinition> DestinyRewardMappingDefinition { get; set; }

        // public Dictionary<uint, DestinyRewardSheetDefinition> DestinyRewardSheetDefinition { get; set; }

        public Dictionary<uint, DestinyItemCategoryDefinition> DestinyItemCategoryDefinition { get; set; }

        public Dictionary<uint, DestinyDamageTypeDefinition> DestinyDamageTypeDefinition { get; set; }

        public Dictionary<uint, DestinyActivityModeDefinition> DestinyActivityModeDefinition { get; set; }

        // public Dictionary<uint, DestinyMedalTierDefinition> DestinyMedalTierDefinition { get; set; }

        // public Dictionary<uint, DestinyAchievementDefinition> DestinyAchievementDefinition { get; set; }

        public Dictionary<uint, DestinyActivityGraphDefinition> DestinyActivityGraphDefinition { get; set; }

        // public Dictionary<uint, DestinyActivityInteractableDefinition> DestinyActivityInteractableDefinition { get; set; }

        // public Dictionary<uint, DestinyBondDefinition> DestinyBondDefinition { get; set; }

        // public Dictionary<uint, DestinyCharacterCustomizationCategoryDefinition> DestinyCharacterCustomizationCategoryDefinition { get; set; }

        // public Dictionary<uint, DestinyCharacterCustomizationOptionDefinition> DestinyCharacterCustomizationOptionDefinition { get; set; }

        public Dictionary<uint, DestinyCollectibleDefinition> DestinyCollectibleDefinition { get; set; }

        public Dictionary<uint, DestinyDestinationDefinition> DestinyDestinationDefinition { get; set; }

        // public Dictionary<uint, DestinyEntitlementOfferDefinition> DestinyEntitlementOfferDefinition { get; set; }

        public Dictionary<uint, DestinyEquipmentSlotDefinition> DestinyEquipmentSlotDefinition { get; set; }

        public Dictionary<uint, DestinyStatDefinition> DestinyStatDefinition { get; set; }

        public Dictionary<uint, DestinyInventoryItemDefinition> DestinyInventoryItemDefinition { get; set; }

        // public Dictionary<uint, DestinyInventoryItemLiteDefinition> DestinyInventoryItemLiteDefinition { get; set; }

        public Dictionary<uint, DestinyItemTierTypeDefinition> DestinyItemTierTypeDefinition { get; set; }

        public Dictionary<uint, DestinyLocationDefinition> DestinyLocationDefinition { get; set; }

        public Dictionary<uint, DestinyLoreDefinition> DestinyLoreDefinition { get; set; }

        public Dictionary<uint, DestinyMetricDefinition> DestinyMetricDefinition { get; set; }

        public Dictionary<uint, DestinyObjectiveDefinition> DestinyObjectiveDefinition { get; set; }

        // public Dictionary<uint, DestinyPlatformBucketMappingDefinition> DestinyPlatformBucketMappingDefinition { get; set; }

        public Dictionary<uint, DestinyPlugSetDefinition> DestinyPlugSetDefinition { get; set; }

        public Dictionary<uint, DestinyPowerCapDefinition> DestinyPowerCapDefinition { get; set; }

        public Dictionary<uint, DestinyPresentationNodeDefinition> DestinyPresentationNodeDefinition { get; set; }

        public Dictionary<uint, DestinyPresentationNodeBaseDefinition> DestinyPresentationNodeBaseDefinition { get; set; }

        public Dictionary<uint, DestinyProgressionDefinition> DestinyProgressionDefinition { get; set; }

        public Dictionary<uint, DestinyProgressionLevelRequirementDefinition> DestinyProgressionLevelRequirementDefinition { get; set; }

        public Dictionary<uint, DestinyRecordDefinition> DestinyRecordDefinition { get; set; }

        // public Dictionary<uint, DestinyRewardAdjusterPointerDefinition> DestinyRewardAdjusterPointerDefinition { get; set; }

        // public Dictionary<uint, DestinyRewardAdjusterProgressionMapDefinition> DestinyRewardAdjusterProgressionMapDefinition { get; set; }

        // public Dictionary<uint, DestinyRewardItemListDefinition> DestinyRewardItemListDefinition { get; set; }

        // public Dictionary<uint, DestinySackRewardItemListDefinition> DestinySackRewardItemListDefinition { get; set; }

        // public Dictionary<uint, DestinySandboxPatternDefinition> DestinySandboxPatternDefinition { get; set; }

        public Dictionary<uint, DestinySeasonDefinition> DestinySeasonDefinition { get; set; }

        public Dictionary<uint, DestinySeasonPassDefinition> DestinySeasonPassDefinition { get; set; }

        public Dictionary<uint, DestinySocketCategoryDefinition> DestinySocketCategoryDefinition { get; set; }

        public Dictionary<uint, DestinySocketTypeDefinition> DestinySocketTypeDefinition { get; set; }

        public Dictionary<uint, DestinyTraitDefinition> DestinyTraitDefinition { get; set; }

        public Dictionary<uint, DestinyTraitCategoryDefinition> DestinyTraitCategoryDefinition { get; set; }

        // public Dictionary<uint, DestinyUnlockCountMappingDefinition> DestinyUnlockCountMappingDefinition { get; set; }

        // public Dictionary<uint, DestinyUnlockEventDefinition> DestinyUnlockEventDefinition { get; set; }

        // public Dictionary<uint, DestinyUnlockExpressionMappingDefinition> DestinyUnlockExpressionMappingDefinition { get; set; }

        public Dictionary<uint, DestinyVendorDefinition> DestinyVendorDefinition { get; set; }

        public Dictionary<uint, DestinyMilestoneDefinition> DestinyMilestoneDefinition { get; set; }

        public Dictionary<uint, DestinyActivityModifierDefinition> DestinyActivityModifierDefinition { get; set; }

        public Dictionary<uint, DestinyReportReasonCategoryDefinition> DestinyReportReasonCategoryDefinition { get; set; }

        public Dictionary<uint, DestinyArtifactDefinition> DestinyArtifactDefinition { get; set; }

        public Dictionary<uint, DestinyBreakerTypeDefinition> DestinyBreakerTypeDefinition { get; set; }

        public Dictionary<uint, DestinyChecklistDefinition> DestinyChecklistDefinition { get; set; }

        public Dictionary<uint, DestinyEnergyTypeDefinition> DestinyEnergyTypeDefinition { get; set; }
    }
}