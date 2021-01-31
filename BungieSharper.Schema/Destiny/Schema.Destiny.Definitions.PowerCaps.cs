namespace BungieSharper.Schema.Destiny.Definitions.PowerCaps
{
    /// <summary>
    /// Defines a 'power cap' (limit) for gear items, based on the rarity tier and season of release.
    /// </summary>
    public class DestinyPowerCapDefinition : Destiny.Definitions.DestinyDefinition
    {
        /// <summary>The raw value for a power cap.</summary>
        public int powerCap { get; set; }
    }
}