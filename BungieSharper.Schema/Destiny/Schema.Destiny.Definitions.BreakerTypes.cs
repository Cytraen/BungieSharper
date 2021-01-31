namespace BungieSharper.Schema.Destiny.Definitions.BreakerTypes
{
    public class DestinyBreakerTypeDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        /// <summary>We have an enumeration for Breaker types for quick reference. This is the current definition's breaker type enum value.</summary>
        public Schema.Destiny.DestinyBreakerType enumValue { get; set; }
    }
}