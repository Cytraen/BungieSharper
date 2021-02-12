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
        /// Gets a listing of all topics marked as part of the core group.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetCoreTopicsPaged(Schema.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, int page, Schema.Forum.ForumTopicsQuickDateEnum quickDate, Schema.Forum.ForumTopicsSortEnum sort, string locales = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
=======
        /// <param name="categoryFilter">The category filter.</param>
        /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
        /// <param name="page">Zero base page</param>
        /// <param name="quickDate">The date filter.</param>
        /// <param name="sort">The sort mode.</param>
        public async Task<Entities.Forum.PostSearchResponse> Forum_GetCoreTopicsPaged(Entities.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, int page, Entities.Forum.ForumTopicsQuickDateEnum quickDate, Entities.Forum.ForumTopicsSortEnum sort, string? locales = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
>>>>>>> rewrite
                new Uri($"Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/" + HttpRequestGenerator.MakeQuerystring(locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}