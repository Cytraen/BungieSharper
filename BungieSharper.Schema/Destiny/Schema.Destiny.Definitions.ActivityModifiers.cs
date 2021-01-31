namespace BungieSharper.Schema.Destiny.Definitions.ActivityModifiers
{
    /// <summary>
    /// Modifiers - in Destiny 1, these were referred to as "Skulls" - are changes that can be applied to an Activity.
    /// </summary>
    public class DestinyActivityModifierDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }
}