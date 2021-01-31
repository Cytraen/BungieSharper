using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Trending
{
    public class TrendingCategories
    {
        public IEnumerable<Schema.Trending.TrendingCategory> categories { get; set; }
    }

    public class TrendingCategory
    {
        public string categoryName { get; set; }
        public Schema.SearchResultOfTrendingEntry entries { get; set; }
        public string categoryId { get; set; }
    }

    /// <summary>
    /// The list entry view for trending items. Returns just enough to show the item on the trending page.
    /// </summary>
    public class TrendingEntry
    {
        /// <summary>The weighted score of this trending item.</summary>
        public double weight { get; set; }
        public bool isFeatured { get; set; }
        /// <summary>We don't know whether the identifier will be a string, a uint, or a long... so we're going to cast it all to a string. But either way, we need any trending item created to have a single unique identifier for its type.</summary>
        public string identifier { get; set; }
        /// <summary>An enum - unfortunately - dictating all of the possible kinds of trending items that you might get in your result set, in case you want to do custom rendering or call to get the details of the item.</summary>
        public Schema.Trending.TrendingEntryType entityType { get; set; }
        /// <summary>The localized "display name/article title/'primary localized identifier'" of the entity.</summary>
        public string displayName { get; set; }
        /// <summary>If the entity has a localized tagline/subtitle/motto/whatever, that is found here.</summary>
        public string tagline { get; set; }
        public string image { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string link { get; set; }
        /// <summary>If this is populated, the entry has a related WebM video to show. I am 100% certain I am going to regret putting this directly on TrendingEntry, but it will work so yolo</summary>
        public string webmVideo { get; set; }
        /// <summary>If this is populated, the entry has a related MP4 video to show. I am 100% certain I am going to regret putting this directly on TrendingEntry, but it will work so yolo</summary>
        public string mp4Video { get; set; }
        /// <summary>If isFeatured, this image will be populated with whatever the featured image is. Note that this will likely be a very large image, so don't use it all the time.</summary>
        public string featureImage { get; set; }
        /// <summary>If the item is of entityType TrendingEntryType.Container, it may have items - also Trending Entries - contained within it. This is the ordered list of those to display under the Container's header.</summary>
        public IEnumerable<Schema.Trending.TrendingEntry> items { get; set; }
        /// <summary>If the entry has a date at which it was created, this is that date.</summary>
        public DateTime? creationDate { get; set; }
    }

    /// <summary>
    /// The known entity types that you can have returned from Trending.
    /// </summary>
    public enum TrendingEntryType
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
        public string identifier { get; set; }
        public Schema.Trending.TrendingEntryType entityType { get; set; }
        public Schema.Trending.TrendingEntryNews news { get; set; }
        public Schema.Trending.TrendingEntrySupportArticle support { get; set; }
        public Schema.Trending.TrendingEntryDestinyItem destinyItem { get; set; }
        public Schema.Trending.TrendingEntryDestinyActivity destinyActivity { get; set; }
        public Schema.Trending.TrendingEntryDestinyRitual destinyRitual { get; set; }
        public Schema.Trending.TrendingEntryCommunityCreation creation { get; set; }
    }

    public class TrendingEntryNews
    {
        public Schema.Content.ContentItemPublicContract article { get; set; }
    }

    public class TrendingEntrySupportArticle
    {
        public Schema.Content.ContentItemPublicContract article { get; set; }
    }

    public class TrendingEntryDestinyItem
    {
        public uint itemHash { get; set; }
    }

    public class TrendingEntryDestinyActivity
    {
        public uint activityHash { get; set; }
        public Schema.Destiny.Activities.DestinyPublicActivityStatus status { get; set; }
    }

    public class TrendingEntryDestinyRitual
    {
        public string image { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public DateTime? dateStart { get; set; }
        public DateTime? dateEnd { get; set; }
        /// <summary>A destiny event does not necessarily have a related Milestone, but if it does the details will be returned here.</summary>
        public Schema.Destiny.Milestones.DestinyPublicMilestone milestoneDetails { get; set; }
        /// <summary>A destiny event will not necessarily have milestone "custom content", but if it does the details will be here.</summary>
        public Schema.Destiny.Milestones.DestinyMilestoneContent eventContent { get; set; }
    }

    public class TrendingEntryCommunityCreation
    {
        public string media { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public long authorMembershipId { get; set; }
        public long postId { get; set; }
        public string body { get; set; }
        public int upvotes { get; set; }
    }
}