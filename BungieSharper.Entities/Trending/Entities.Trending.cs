using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Trending
{
    public class TrendingCategories
    {
        [JsonPropertyName("categories")]
        public IEnumerable<Trending.TrendingCategory> Categories { get; set; }
    }

    public class TrendingCategory
    {
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("entries")]
        public SearchResultOfTrendingEntry Entries { get; set; }

        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; }
    }

    /// <summary>
    /// The list entry view for trending items. Returns just enough to show the item on the trending page.
    /// </summary>
    public class TrendingEntry
    {
        /// <summary>The weighted score of this trending item.</summary>
        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("isFeatured")]
        public bool IsFeatured { get; set; }

        /// <summary>We don't know whether the identifier will be a string, a uint, or a long... so we're going to cast it all to a string. But either way, we need any trending item created to have a single unique identifier for its type.</summary>
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        /// <summary>An enum - unfortunately - dictating all of the possible kinds of trending items that you might get in your result set, in case you want to do custom rendering or call to get the details of the item.</summary>
        [JsonPropertyName("entityType")]
        public Trending.TrendingEntryType EntityType { get; set; }

        /// <summary>The localized "display name/article title/'primary localized identifier'" of the entity.</summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>If the entity has a localized tagline/subtitle/motto/whatever, that is found here.</summary>
        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("startDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("endDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>If this is populated, the entry has a related WebM video to show. I am 100% certain I am going to regret putting this directly on TrendingEntry, but it will work so yolo</summary>
        [JsonPropertyName("webmVideo")]
        public string WebmVideo { get; set; }

        /// <summary>If this is populated, the entry has a related MP4 video to show. I am 100% certain I am going to regret putting this directly on TrendingEntry, but it will work so yolo</summary>
        [JsonPropertyName("mp4Video")]
        public string Mp4Video { get; set; }

        /// <summary>If isFeatured, this image will be populated with whatever the featured image is. Note that this will likely be a very large image, so don't use it all the time.</summary>
        [JsonPropertyName("featureImage")]
        public string FeatureImage { get; set; }

        /// <summary>If the item is of entityType TrendingEntryType.Container, it may have items - also Trending Entries - contained within it. This is the ordered list of those to display under the Container's header.</summary>
        [JsonPropertyName("items")]
        public IEnumerable<Trending.TrendingEntry> Items { get; set; }

        /// <summary>If the entry has a date at which it was created, this is that date.</summary>
        [JsonPropertyName("creationDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? CreationDate { get; set; }
    }

    /// <summary>
    /// The known entity types that you can have returned from Trending.
    /// </summary>
    public enum TrendingEntryType : int
    {
        News = 0,
        DestinyItem = 1,
        DestinyActivity = 2,
        DestinyRitual = 3,
        SupportArticle = 4,
        Creation = 5,
        Stream = 6,
        Update = 7,
        Link = 8,
        ForumTag = 9,
        Container = 10,
        Release = 11
    }

    public class TrendingDetail
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("entityType")]
        public Trending.TrendingEntryType EntityType { get; set; }

        [JsonPropertyName("news")]
        public Trending.TrendingEntryNews News { get; set; }

        [JsonPropertyName("support")]
        public Trending.TrendingEntrySupportArticle Support { get; set; }

        [JsonPropertyName("destinyItem")]
        public Trending.TrendingEntryDestinyItem DestinyItem { get; set; }

        [JsonPropertyName("destinyActivity")]
        public Trending.TrendingEntryDestinyActivity DestinyActivity { get; set; }

        [JsonPropertyName("destinyRitual")]
        public Trending.TrendingEntryDestinyRitual DestinyRitual { get; set; }

        [JsonPropertyName("creation")]
        public Trending.TrendingEntryCommunityCreation Creation { get; set; }
    }

    public class TrendingEntryNews
    {
        [JsonPropertyName("article")]
        public Content.ContentItemPublicContract Article { get; set; }
    }

    public class TrendingEntrySupportArticle
    {
        [JsonPropertyName("article")]
        public Content.ContentItemPublicContract Article { get; set; }
    }

    public class TrendingEntryDestinyItem
    {
        [JsonPropertyName("itemHash")]
        public uint ItemHash { get; set; }
    }

    public class TrendingEntryDestinyActivity
    {
        [JsonPropertyName("activityHash")]
        public uint ActivityHash { get; set; }

        [JsonPropertyName("status")]
        public Destiny.Activities.DestinyPublicActivityStatus Status { get; set; }
    }

    public class TrendingEntryDestinyRitual
    {
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }

        [JsonPropertyName("dateStart")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DateStart { get; set; }

        [JsonPropertyName("dateEnd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DateEnd { get; set; }

        /// <summary>A destiny event does not necessarily have a related Milestone, but if it does the details will be returned here.</summary>
        [JsonPropertyName("milestoneDetails")]
        public Destiny.Milestones.DestinyPublicMilestone MilestoneDetails { get; set; }

        /// <summary>A destiny event will not necessarily have milestone "custom content", but if it does the details will be here.</summary>
        [JsonPropertyName("eventContent")]
        public Destiny.Milestones.DestinyMilestoneContent EventContent { get; set; }
    }

    public class TrendingEntryCommunityCreation
    {
        [JsonPropertyName("media")]
        public string Media { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("authorMembershipId")]
        public long AuthorMembershipId { get; set; }

        [JsonPropertyName("postId")]
        public long PostId { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("upvotes")]
        public int Upvotes { get; set; }
    }
}