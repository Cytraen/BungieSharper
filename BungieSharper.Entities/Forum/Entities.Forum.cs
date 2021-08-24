using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Forum
{
    [Flags]
    public enum ForumTopicsCategoryFiltersEnum : int
    {
        None = 0,
        Links = 1,
        Questions = 2,
        AnsweredQuestions = 4,
        Media = 8,
        TextOnly = 16,
        Announcement = 32,
        BungieOfficial = 64,
        Polls = 128
    }

    public enum ForumTopicsQuickDateEnum : int
    {
        All = 0,
        LastYear = 1,
        LastMonth = 2,
        LastWeek = 3,
        LastDay = 4
    }

    public enum ForumTopicsSortEnum : byte
    {
        Default = 0,
        LastReplied = 1,
        MostReplied = 2,
        Popularity = 3,
        Controversiality = 4,
        Liked = 5,
        HighestRated = 6,
        MostUpvoted = 7
    }

    public class PostResponse
    {
        [JsonPropertyName("lastReplyTimestamp")]
        public DateTime LastReplyTimestamp { get; set; }

        [JsonPropertyName("IsPinned")]
        public bool IsPinned { get; set; }

        [JsonPropertyName("urlMediaType")]
        public Forum.ForumMediaType UrlMediaType { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("popularity")]
        public Forum.ForumPostPopularity Popularity { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isAnnouncement")]
        public bool IsAnnouncement { get; set; }

        [JsonPropertyName("userRating")]
        public int UserRating { get; set; }

        [JsonPropertyName("userHasRated")]
        public bool UserHasRated { get; set; }

        [JsonPropertyName("userHasMutedPost")]
        public bool UserHasMutedPost { get; set; }

        [JsonPropertyName("latestReplyPostId")]
        public long LatestReplyPostId { get; set; }

        [JsonPropertyName("latestReplyAuthorId")]
        public long LatestReplyAuthorId { get; set; }

        [JsonPropertyName("ignoreStatus")]
        public Ignores.IgnoreResponse IgnoreStatus { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }
    }

    public enum ForumMediaType : int
    {
        None = 0,
        Image = 1,
        Video = 2,
        Youtube = 3
    }

    public enum ForumPostPopularity : int
    {
        Empty = 0,
        Default = 1,
        Discussed = 2,
        CoolStory = 3,
        HeatingUp = 4,
        Hot = 5
    }

    public class PostSearchResponse
    {
        [JsonPropertyName("relatedPosts")]
        public IEnumerable<Forum.PostResponse> RelatedPosts { get; set; }

        [JsonPropertyName("authors")]
        public IEnumerable<User.GeneralUser> Authors { get; set; }

        [JsonPropertyName("groups")]
        public IEnumerable<GroupsV2.GroupResponse> Groups { get; set; }

        [JsonPropertyName("searchedTags")]
        public IEnumerable<Tags.Models.Contracts.TagResponse> SearchedTags { get; set; }

        [JsonPropertyName("polls")]
        public IEnumerable<Forum.PollResponse> Polls { get; set; }

        [JsonPropertyName("recruitmentDetails")]
        public IEnumerable<Forum.ForumRecruitmentDetail> RecruitmentDetails { get; set; }

        [JsonPropertyName("availablePages"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AvailablePages { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<Forum.PostResponse> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

    public class PollResponse
    {
        [JsonPropertyName("topicId")]
        public long TopicId { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<Forum.PollResult> Results { get; set; }

        [JsonPropertyName("totalVotes")]
        public int TotalVotes { get; set; }
    }

    public class PollResult
    {
        [JsonPropertyName("answerText")]
        public string AnswerText { get; set; }

        [JsonPropertyName("answerSlot")]
        public int AnswerSlot { get; set; }

        [JsonPropertyName("lastVoteDate")]
        public DateTime LastVoteDate { get; set; }

        [JsonPropertyName("votes")]
        public int Votes { get; set; }

        [JsonPropertyName("requestingUserVoted")]
        public bool RequestingUserVoted { get; set; }
    }

    public class ForumRecruitmentDetail
    {
        [JsonPropertyName("topicId")]
        public long TopicId { get; set; }

        [JsonPropertyName("microphoneRequired")]
        public bool MicrophoneRequired { get; set; }

        [JsonPropertyName("intensity")]
        public Forum.ForumRecruitmentIntensityLabel Intensity { get; set; }

        [JsonPropertyName("tone")]
        public Forum.ForumRecruitmentToneLabel Tone { get; set; }

        [JsonPropertyName("approved")]
        public bool Approved { get; set; }

        [JsonPropertyName("conversationId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ConversationId { get; set; }

        [JsonPropertyName("playerSlotsTotal")]
        public int PlayerSlotsTotal { get; set; }

        [JsonPropertyName("playerSlotsRemaining")]
        public int PlayerSlotsRemaining { get; set; }

        [JsonPropertyName("Fireteam")]
        public IEnumerable<User.GeneralUser> Fireteam { get; set; }

        [JsonPropertyName("kickedPlayerIds")]
        public IEnumerable<long> KickedPlayerIds { get; set; }
    }

    public enum ForumRecruitmentIntensityLabel : byte
    {
        None = 0,
        Casual = 1,
        Professional = 2
    }

    public enum ForumRecruitmentToneLabel : byte
    {
        None = 0,
        FamilyFriendly = 1,
        Rowdy = 2
    }

    public enum ForumPostSortEnum : int
    {
        Default = 0,
        OldestFirst = 1
    }

    public enum CommunityContentSortMode : byte
    {
        Trending = 0,
        Latest = 1,
        HighestRated = 2
    }
}