using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get topics from any forum.
        /// </summary>
        /// <param name="categoryFilter">A category filter</param>
        /// <param name="group">The group, if any.</param>
        /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
        /// <param name="page">Zero paged page number</param>
        /// <param name="pageSize">Unused</param>
        /// <param name="quickDate">A date filter.</param>
        /// <param name="sort">The sort mode.</param>
        /// <param name="tagstring">The tags to search, if any.</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetTopicsPaged(Entities.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, long group, int page, int pageSize, Entities.Forum.ForumTopicsQuickDateEnum quickDate, Entities.Forum.ForumTopicsSortEnum sort, string? locales = null, string? tagstring = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/" + HttpRequestGenerator.MakeQuerystring(locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null, tagstring != null ? $"tagstring={Uri.EscapeDataString(tagstring)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetTopicsPaged(Entities.Forum.ForumTopicsCategoryFiltersEnum, long, int, int, Entities.Forum.ForumTopicsQuickDateEnum, Entities.Forum.ForumTopicsSortEnum, string?, string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetTopicsPaged<T>(Entities.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, long group, int page, int pageSize, Entities.Forum.ForumTopicsQuickDateEnum quickDate, Entities.Forum.ForumTopicsSortEnum sort, string? locales = null, string? tagstring = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/" + HttpRequestGenerator.MakeQuerystring(locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null, tagstring != null ? $"tagstring={Uri.EscapeDataString(tagstring)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets a listing of all topics marked as part of the core group.
        /// </summary>
        /// <param name="categoryFilter">The category filter.</param>
        /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
        /// <param name="page">Zero base page</param>
        /// <param name="quickDate">The date filter.</param>
        /// <param name="sort">The sort mode.</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetCoreTopicsPaged(Entities.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, int page, Entities.Forum.ForumTopicsQuickDateEnum quickDate, Entities.Forum.ForumTopicsSortEnum sort, string? locales = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/" + HttpRequestGenerator.MakeQuerystring(locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetCoreTopicsPaged(Entities.Forum.ForumTopicsCategoryFiltersEnum, int, Entities.Forum.ForumTopicsQuickDateEnum, Entities.Forum.ForumTopicsSortEnum, string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetCoreTopicsPaged<T>(Entities.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, int page, Entities.Forum.ForumTopicsQuickDateEnum quickDate, Entities.Forum.ForumTopicsSortEnum sort, string? locales = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/" + HttpRequestGenerator.MakeQuerystring(locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Returns a thread of posts at the given parent, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetPostsThreadedPaged(bool getParentPost, int page, int pageSize, long parentPostId, int replySize, bool rootThreadMode, Entities.Forum.ForumPostSortEnum sortMode, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostsThreadedPaged/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetPostsThreadedPaged(bool, int, int, long, int, bool, Entities.Forum.ForumPostSortEnum, string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetPostsThreadedPaged<T>(bool getParentPost, int page, int pageSize, long parentPostId, int replySize, bool rootThreadMode, Entities.Forum.ForumPostSortEnum sortMode, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetPostsThreadedPaged/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Returns a thread of posts starting at the topicId of the input childPostId, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetPostsThreadedPagedFromChild(long childPostId, int page, int pageSize, int replySize, bool rootThreadMode, Entities.Forum.ForumPostSortEnum sortMode, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetPostsThreadedPagedFromChild(long, int, int, int, bool, Entities.Forum.ForumPostSortEnum, string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetPostsThreadedPagedFromChild<T>(long childPostId, int page, int pageSize, int replySize, bool rootThreadMode, Entities.Forum.ForumPostSortEnum sortMode, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Returns the post specified and its immediate parent.
        /// </summary>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetPostAndParent(long childPostId, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostAndParent/{childPostId}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetPostAndParent(long, string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetPostAndParent<T>(long childPostId, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetPostAndParent/{childPostId}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Returns the post specified and its immediate parent of posts that are awaiting approval.
        /// </summary>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetPostAndParentAwaitingApproval(long childPostId, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostAndParentAwaitingApproval/{childPostId}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetPostAndParentAwaitingApproval(long, string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetPostAndParentAwaitingApproval<T>(long childPostId, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetPostAndParentAwaitingApproval/{childPostId}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets the post Id for the given content item's comments, if it exists.
        /// </summary>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<long> Forum_GetTopicForContent(long contentId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<long>(
                new Uri($"Forum/GetTopicForContent/{contentId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetTopicForContent(long, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetTopicForContent<T>(long contentId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetTopicForContent/{contentId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets tag suggestions based on partial text entry, matching them with other tags previously used in the forums.
        /// </summary>
        /// <param name="partialtag">The partial tag input to generate suggestions from.</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.Tags.Models.Contracts.TagResponse>> Forum_GetForumTagSuggestions(string? partialtag = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Tags.Models.Contracts.TagResponse>>(
                new Uri($"Forum/GetForumTagSuggestions/" + HttpRequestGenerator.MakeQuerystring(partialtag != null ? $"partialtag={Uri.EscapeDataString(partialtag)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetForumTagSuggestions(string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetForumTagSuggestions<T>(string? partialtag = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/GetForumTagSuggestions/" + HttpRequestGenerator.MakeQuerystring(partialtag != null ? $"partialtag={Uri.EscapeDataString(partialtag)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets the specified forum poll.
        /// </summary>
        /// <param name="topicId">The post id of the topic that has the poll.</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetPoll(long topicId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/Poll/{topicId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetPoll(long, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetPoll<T>(long topicId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/Poll/{topicId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Allows the caller to get a list of to 25 recruitment thread summary information objects.
        /// </summary>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.Forum.ForumRecruitmentDetail>> Forum_GetRecruitmentThreadSummaries(IEnumerable<long> requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Forum.ForumRecruitmentDetail>>(
                new Uri($"Forum/Recruit/Summaries/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Forum_GetRecruitmentThreadSummaries(IEnumerable<long>, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Forum_GetRecruitmentThreadSummaries<T>(IEnumerable<long> requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Forum/Recruit/Summaries/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }
    }
}