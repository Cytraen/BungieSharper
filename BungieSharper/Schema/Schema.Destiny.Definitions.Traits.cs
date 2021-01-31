using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Traits
{
    public class DestinyTraitDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        public string traitCategoryId { get; set; }
        public uint traitCategoryHash { get; set; }
    }

    public class DestinyTraitCategoryDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public string traitCategoryId { get; set; }
        public IEnumerable<uint> traitHashes { get; set; }
        public IEnumerable<string> traitIds { get; set; }
    }
}