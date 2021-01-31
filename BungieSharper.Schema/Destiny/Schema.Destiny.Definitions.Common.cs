using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Common
{
    /// <summary>
    /// Many Destiny*Definition contracts - the "first order" entities of Destiny that have their own tables in the Manifest Database - also have displayable information. This is the base class for that display information.
    /// </summary>
    public class DestinyDisplayPropertiesDefinition
    {
        public string description { get; set; }

        public string name { get; set; }

        /// <summary>
        /// Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
        /// But usually, it will be a small square image that you can use as... well, an icon.
        /// They are currently represented as 96px x 96px images.
        /// </summary>
        public string icon { get; set; }

        public IEnumerable<Destiny.Definitions.Common.DestinyIconSequenceDefinition> iconSequences { get; set; }

        /// <summary>If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.</summary>
        public string highResIcon { get; set; }

        public bool hasIcon { get; set; }
    }

    public class DestinyIconSequenceDefinition
    {
        public IEnumerable<string> frames { get; set; }
    }

    public class DestinyPositionDefinition
    {
        public int x { get; set; }

        public int y { get; set; }

        public int z { get; set; }
    }
}