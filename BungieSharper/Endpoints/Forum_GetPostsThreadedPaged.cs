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
        /// Returns a thread of posts at the given parent, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPostsThreadedPaged(bool getParentPost, int page, int pageSize, long parentPostId, int replySize, bool rootThreadMode, Schema.Forum.ForumPostSortEnum sortMode, string showbanned = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"Forum/GetPostsThreadedPaged/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/", null, null, HttpMethod.Get,
                showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null);
        }
    }
}