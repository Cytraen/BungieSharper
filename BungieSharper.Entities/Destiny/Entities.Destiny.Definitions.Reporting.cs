using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Reporting
{
    /// <summary>
    /// If you're going to report someone for a Terms of Service violation, you need to choose a category and reason for the report. This definition holds both the categories and the reasons within those categories, for simplicity and my own laziness' sake.
    /// Note tha this means that, to refer to a Reason by reasonHash, you need a combination of the reasonHash *and* the associated ReasonCategory's hash: there are some reasons defined under multiple categories.
    /// </summary>
    public class DestinyReportReasonCategoryDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>The specific reasons for the report under this category.</summary>
        [JsonPropertyName("reasons")]
        public Dictionary<uint, DestinyReportReasonDefinition> Reasons { get; set; }

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

    /// <summary>
    /// A specific reason for being banned. Only accessible under the related category (DestinyReportReasonCategoryDefinition) under which it is shown. Note that this means that report reasons' reasonHash are not globally unique: and indeed, entries like "Other" are defined under most categories for example.
    /// </summary>
    public class DestinyReportReasonDefinition
    {
        /// <summary>The identifier for the reason: they are only guaranteed unique under the Category in which they are found.</summary>
        [JsonPropertyName("reasonHash")]
        public uint ReasonHash { get; set; }

        [JsonPropertyName("displayProperties")]
        public Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }
    }
}