using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get topics from any forum.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetTopicsPaged(Schema.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, long group, int page, int pageSize, Schema.Forum.ForumTopicsQuickDateEnum quickDate, Schema.Forum.ForumTopicsSortEnum sort, string locales = null, string tagstring = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
=======
        /// <param name="categoryFilter">A category filter</param>
        /// <param name="group">The group, if any.</param>
        /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
        /// <param name="page">Zero paged page number</param>
        /// <param name="pageSize">Unused</param>
        /// <param name="quickDate">A date filter.</param>
        /// <param name="sort">The sort mode.</param>
        /// <param name="tagstring">The tags to search, if any.</param>
        public async Task<Entities.Forum.PostSearchResponse> Forum_GetTopicsPaged(Entities.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, long group, int page, int pageSize, Entities.Forum.ForumTopicsQuickDateEnum quickDate, Entities.Forum.ForumTopicsSortEnum sort, string? locales = null, string? tagstring = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
>>>>>>> rewrite
                new Uri($"Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/" + HttpRequestGenerator.MakeQuerystring(locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null, tagstring != null ? $"tagstring={Uri.EscapeDataString(tagstring)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}