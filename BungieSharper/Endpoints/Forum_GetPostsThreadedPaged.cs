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
        /// Returns a thread of posts at the given parent, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        public async Task<Entities.Forum.PostSearchResponse> Forum_GetPostsThreadedPaged(bool getParentPost, int page, int pageSize, long parentPostId, int replySize, bool rootThreadMode, Entities.Forum.ForumPostSortEnum sortMode, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostsThreadedPaged/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}