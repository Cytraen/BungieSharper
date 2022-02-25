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
        /// Returns community content.
        /// </summary>
        /// <param name="mediaFilter">The type of media to get</param>
        /// <param name="page">Zero based page</param>
        /// <param name="sort">The sort mode.</param>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Forum.PostSearchResponse> CommunityContent_GetCommunityContent(Entities.Forum.ForumTopicsCategoryFiltersEnum mediaFilter, int page, Entities.Forum.CommunityContentSortMode sort, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"CommunityContent/Get/{sort}/{mediaFilter}/{page}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="CommunityContent_GetCommunityContent(Entities.Forum.ForumTopicsCategoryFiltersEnum, int, Entities.Forum.CommunityContentSortMode, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> CommunityContent_GetCommunityContent<T>(Entities.Forum.ForumTopicsCategoryFiltersEnum mediaFilter, int page, Entities.Forum.CommunityContentSortMode sort, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"CommunityContent/Get/{sort}/{mediaFilter}/{page}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }
    }
}