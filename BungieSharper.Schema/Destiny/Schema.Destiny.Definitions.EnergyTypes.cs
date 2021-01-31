namespace BungieSharper.Schema.Destiny.Definitions.EnergyTypes
{
    /// <summary>
    /// Represents types of Energy that can be used for costs and payments related to Armor 2.0 mods.
    /// </summary>
    public class DestinyEnergyTypeDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>The description of the energy type, icon etc...</summary>
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>A variant of the icon that is transparent and colorless.</summary>
        public string transparentIconPath { get; set; }

        /// <summary>If TRUE, the game shows this Energy type's icon. Otherwise, it doesn't. Whether you show it or not is up to you.</summary>
        public bool showIcon { get; set; }

        /// <summary>We have an enumeration for Energy types for quick reference. This is the current definition's Energy type enum value.</summary>
        public Destiny.DestinyEnergyType enumValue { get; set; }

        /// <summary>If this Energy Type can be used for determining the Type of Energy that an item can consume, this is the hash for the DestinyInvestmentStatDefinition that represents the stat which holds the Capacity for that energy type. (Note that this is optional because "Any" is a valid cost, but not valid for Capacity - an Armor must have a specific Energy Type for determining the energy type that the Armor is restricted to use)</summary>
        public uint? capacityStatHash { get; set; }

        /// <summary>If this Energy Type can be used as a cost to pay for socketing Armor 2.0 items, this is the hash for the DestinyInvestmentStatDefinition that stores the plug's raw cost.</summary>
        public uint costStatHash { get; set; }
    }
}