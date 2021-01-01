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
        /// Returns a thread of posts starting at the topicId of the input childPostId, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPostsThreadedPagedFromChild(long childPostId, int page, int pageSize, int replySize, bool rootThreadMode, Schema.Forum.ForumPostSortEnum sortMode, string showbanned = null, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}