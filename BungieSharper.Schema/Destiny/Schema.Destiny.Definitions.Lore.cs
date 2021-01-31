namespace BungieSharper.Schema.Destiny.Definitions.Lore
{
    /// <summary>
    /// These are definitions for in-game "Lore," meant to be narrative enhancements of the game experience.
    /// DestinyInventoryItemDefinitions for interesting items point to these definitions, but nothing's stopping you from scraping all of these and doing something cool with them. If they end up having cool data.
    /// </summary>
    public class DestinyLoreDefinition : Destiny.Definitions.DestinyDefinition
    {
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }

        public string subtitle { get; set; }
    }
}