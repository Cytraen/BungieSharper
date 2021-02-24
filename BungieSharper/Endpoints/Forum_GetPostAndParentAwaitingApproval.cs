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
        /// Returns the post specified and its immediate parent of posts that are awaiting approval.
        /// </summary>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        public Task<Entities.Forum.PostSearchResponse> Forum_GetPostAndParentAwaitingApproval(long childPostId, string? showbanned = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostAndParentAwaitingApproval/{childPostId}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}