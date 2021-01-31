using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Progression
{
    /// <summary>
    /// These are pre-constructed collections of data that can be used to determine the Level Requirement for an item given a Progression to be tested (such as the Character's level).
    /// For instance, say a character receives a new Auto Rifle, and that Auto Rifle's DestinyInventoryItemDefinition.quality.progressionLevelRequirementHash property is pointing at one of these DestinyProgressionLevelRequirementDefinitions. Let's pretend also that the progressionHash it is pointing at is the Character Level progression. In that situation, the character's level will be used to interpolate a value in the requirementCurve property. The value picked up from that interpolation will be the required level for the item.
    /// </summary>
    public class DestinyProgressionLevelRequirementDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>
        /// A curve of level requirements, weighted by the related progressions' level.
        /// Interpolate against this curve with the character's progression level to determine what the level requirement of the generated item that is using this data will be.
        /// </summary>
        public IEnumerable<Interpolation.InterpolationPointFloat> requirementCurve { get; set; }

        /// <summary>
        /// The progression whose level should be used to determine the level requirement.
        /// Look up the DestinyProgressionDefinition with this hash for more information about the progression in question.
        /// </summary>
        public uint progressionHash { get; set; }
    }
}