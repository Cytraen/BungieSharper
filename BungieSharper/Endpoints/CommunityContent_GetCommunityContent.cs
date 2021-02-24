using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
        public Task<Entities.Forum.PostSearchResponse> CommunityContent_GetCommunityContent(Entities.Forum.ForumTopicsCategoryFiltersEnum mediaFilter, int page, Entities.Forum.CommunityContentSortMode sort, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"CommunityContent/Get/{sort}/{mediaFilter}/{page}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}