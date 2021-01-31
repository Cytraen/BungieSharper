namespace BungieSharper.Schema.Destiny.Definitions.ActivityModifiers
{
    /// <summary>
    /// Modifiers - in Destiny 1, these were referred to as "Skulls" - are changes that can be applied to an Activity.
    /// </summary>
    public class DestinyActivityModifierDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }
}