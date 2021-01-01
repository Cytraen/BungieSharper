using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns community content.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> CommunityContent_GetCommunityContent(Schema.Forum.ForumTopicsCategoryFiltersEnum mediaFilter, int page, Schema.Forum.CommunityContentSortMode sort, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                new Uri($"CommunityContent/Get/{sort}/{mediaFilter}/{page}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}