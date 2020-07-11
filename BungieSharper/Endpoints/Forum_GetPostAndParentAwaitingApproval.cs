using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns the post specified and its immediate parent of posts that are awaiting approval.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPostAndParentAwaitingApproval(long childPostId, string showbanned = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"Forum/GetPostAndParentAwaitingApproval/{childPostId}/", null, null, HttpMethod.Get,
                showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null);
        }
    }
}