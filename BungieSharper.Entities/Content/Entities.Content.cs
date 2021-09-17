using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Content
{
    public class ContentItemPublicContract
    {
        [JsonPropertyName("contentId")]
        public long ContentId { get; set; }

        [JsonPropertyName("cType")]
        public string CType { get; set; }

        [JsonPropertyName("cmsPath")]
        public string CmsPath { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("modifyDate")]
        public DateTime ModifyDate { get; set; }

        [JsonPropertyName("allowComments")]
        public bool AllowComments { get; set; }

        [JsonPropertyName("hasAgeGate")]
        public bool HasAgeGate { get; set; }

        [JsonPropertyName("minimumAge")]
        public int MinimumAge { get; set; }

        [JsonPropertyName("ratingImagePath")]
        public string RatingImagePath { get; set; }

        [JsonPropertyName("author")]
        public User.GeneralUser Author { get; set; }

        [JsonPropertyName("autoEnglishPropertyFallback")]
        public bool AutoEnglishPropertyFallback { get; set; }

        /// <summary>
        /// Firehose content is really a collection of metadata and "properties", which are the potentially-but-not-strictly localizable data that comprises the meat of whatever content is being shown.
        /// As Cole Porter would have crooned, "Anything Goes" with Firehose properties. They are most often strings, but they can theoretically be anything. They are JSON encoded, and could be JSON structures, simple strings, numbers etc... The Content Type of the item (cType) will describe the properties, and thus how they ought to be deserialized.
        /// </summary>
        [JsonPropertyName("properties")]
        public Dictionary<string, object> Properties { get; set; }

        [JsonPropertyName("representations")]
        public IEnumerable<Content.ContentRepresentation> Representations { get; set; }

        /// <summary>NOTE: Tags will always be lower case.</summary>
        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; set; }

        [JsonPropertyName("commentSummary")]
        public Content.CommentSummary CommentSummary { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ContentItemPublicContract))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ContentItemPublicContractJsonContext : JsonSerializerContext { }
#endif

    public class ContentRepresentation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("validationString")]
        public string ValidationString { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ContentRepresentation))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ContentRepresentationJsonContext : JsonSerializerContext { }
#endif

    public class CommentSummary
    {
        [JsonPropertyName("topicId")]
        public long TopicId { get; set; }

        [JsonPropertyName("commentCount")]
        public int CommentCount { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(CommentSummary))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class CommentSummaryJsonContext : JsonSerializerContext { }
#endif
}