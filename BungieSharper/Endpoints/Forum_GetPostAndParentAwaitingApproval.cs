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
        /// Returns the post specified and its immediate parent of posts that are awaiting approval.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPostAndParentAwaitingApproval(long childPostId, string showbanned = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                new Uri($"Forum/GetPostAndParentAwaitingApproval/{childPostId}/" + HttpRequestGenerator.MakeQuerystring(showbanned != null ? $"showbanned={Uri.EscapeDataString(showbanned)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}