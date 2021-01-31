using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets a listing of all topics marked as part of the core group.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetCoreTopicsPaged(Schema.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, int page, Schema.Forum.ForumTopicsQuickDateEnum quickDate, Schema.Forum.ForumTopicsSortEnum sort, string locales = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                new Uri($"Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/" + HttpRequestGenerator.MakeQuerystring(locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}