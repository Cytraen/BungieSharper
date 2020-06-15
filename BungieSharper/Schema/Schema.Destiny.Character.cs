using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Character
{

    /// <summary>
    /// Raw data about the customization options chosen for a character's face and appearance.
    /// You can look up the relevant class/race/gender combo in DestinyCharacterCustomizationOptionDefinition for the character, and then look up these values within the CustomizationOptions found to pull some data about their choices. Warning: not all of that data is meaningful. Some data has useful icons. Others have nothing, and are only meant for 3D rendering purposes (which we sadly do not expose yet)
    /// </summary>
    public class DestinyCharacterCustomization
    {
        public uint personality { get; set; }
        public uint face { get; set; }
        public uint skinColor { get; set; }
        public uint lipColor { get; set; }
        public uint eyeColor { get; set; }
        public IEnumerable<uint> hairColors { get; set; }
        public IEnumerable<uint> featureColors { get; set; }
        public uint decalColor { get; set; }
        public bool wearHelmet { get; set; }
        public int hairIndex { get; set; }
        public int featureIndex { get; set; }
        public int decalIndex { get; set; }
    }

    /// <summary>
    /// A minimal view of a character's equipped items, for the purpose of rendering a summary screen or showing the character in 3D.
    /// </summary>
    public class DestinyCharacterPeerView
    {
        public IEnumerable<Schema.Destiny.Character.DestinyItemPeerView> equipment { get; set; }
    }

    /// <summary>
    /// Bare minimum summary information for an item, for the sake of 3D rendering the item.
    /// </summary>
    public class DestinyItemPeerView
    {
        /// <summary>The hash identifier of the item in question. Use it to look up the DestinyInventoryItemDefinition of the item for static rendering data.</summary>
        public uint itemHash { get; set; }
        /// <summary>The list of dyes that have been applied to this item.</summary>
        public IEnumerable<Schema.Destiny.DyeReference> dyes { get; set; }
    }
}