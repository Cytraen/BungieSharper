using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Traits
{
    public class DestinyTraitDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        [JsonPropertyName("traitCategoryId")]
        public string TraitCategoryId { get; set; }

        [JsonPropertyName("traitCategoryHash")]
        public uint TraitCategoryHash { get; set; }

        /// <summary>An identifier for how this trait can be displayed. For example: a 'keyword' hint to show an explanation for certain related terms.</summary>
        [JsonPropertyName("displayHint")]
        public string DisplayHint { get; set; }

        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        [JsonPropertyName("hash")]
        public uint Hash { get; set; }

        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        [JsonPropertyName("redacted")]
        public bool Redacted { get; set; }
    }

    [JsonSerializable(typeof(DestinyTraitDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyTraitDefinitionJsonContext : JsonSerializerContext { }

    public class DestinyTraitCategoryDefinition
    {
        [JsonPropertyName("traitCategoryId")]
        public string TraitCategoryId { get; set; }

        [JsonPropertyName("traitHashes")]
        public IEnumerable<uint> TraitHashes { get; set; }

        [JsonPropertyName("traitIds")]
        public IEnumerable<string> TraitIds { get; set; }

        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        [JsonPropertyName("hash")]
        public uint Hash { get; set; }

        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        [JsonPropertyName("redacted")]
        public bool Redacted { get; set; }
    }

    [JsonSerializable(typeof(DestinyTraitCategoryDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyTraitCategoryDefinitionJsonContext : JsonSerializerContext { }
}