using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Common
{
    /// <summary>
    /// Many Destiny*Definition contracts - the "first order" entities of Destiny that have their own tables in the Manifest Database - also have displayable information. This is the base class for that display information.
    /// </summary>
    public class DestinyDisplayPropertiesDefinition
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
        /// But usually, it will be a small square image that you can use as... well, an icon.
        /// They are currently represented as 96px x 96px images.
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("iconSequences")]
        public IEnumerable<Destiny.Definitions.Common.DestinyIconSequenceDefinition> IconSequences { get; set; }

        /// <summary>If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.</summary>
        [JsonPropertyName("highResIcon")]
        public string HighResIcon { get; set; }

        [JsonPropertyName("hasIcon")]
        public bool HasIcon { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyDisplayPropertiesDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyDisplayPropertiesDefinitionJsonContext : JsonSerializerContext { }
#endif

    public class DestinyIconSequenceDefinition
    {
        [JsonPropertyName("frames")]
        public IEnumerable<string> Frames { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyIconSequenceDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyIconSequenceDefinitionJsonContext : JsonSerializerContext { }
#endif

    public class DestinyPositionDefinition
    {
        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }

        [JsonPropertyName("z")]
        public int Z { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyPositionDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyPositionDefinitionJsonContext : JsonSerializerContext { }
#endif
}