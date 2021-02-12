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
        /// Gets the specified forum poll.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPoll(long topicId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
=======
        /// <param name="topicId">The post id of the topic that has the poll.</param>
        public async Task<Entities.Forum.PostSearchResponse> Forum_GetPoll(long topicId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Forum.PostSearchResponse>(
>>>>>>> rewrite
                new Uri($"Forum/Poll/{topicId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}