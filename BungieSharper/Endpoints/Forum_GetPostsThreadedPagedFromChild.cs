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
        /// Returns a thread of posts starting at the topicId of the input childPostId, optionally returning replies to those posts as well as the original parent.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPostsThreadedPagedFromChild(long childPostId, int page, int pageSize, int replySize, bool rootThreadMode, Schema.Forum.ForumPostSortEnum sortMode, string showbanned = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
=======
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        public async Task<Entities.Forum.PostSearchResponse> Forum_GetPostsThreadedPagedFromChild(long childPostId, int page, int pageSize, int replySize, bool rootThreadMode, Entities.Forum.ForumPostSortEnum sortMode, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
>>>>>>> rewrite
                new Uri($"Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}