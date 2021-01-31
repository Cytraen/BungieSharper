namespace BungieSharper.Schema.Destiny.Definitions.BreakerTypes
{
    public class DestinyBreakerTypeDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>We have an enumeration for Breaker types for quick reference. This is the current definition's breaker type enum value.</summary>
        public Destiny.DestinyBreakerType enumValue { get; set; }
    }
}