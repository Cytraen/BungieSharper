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
        /// Gets the post Id for the given content item's comments, if it exists.
        /// </summary>
<<<<<<< HEAD
        public async Task<long> Forum_GetTopicForContent(long contentId, string authToken = null, CancellationToken cancelToken = default)
=======
        public async Task<long> Forum_GetTopicForContent(long contentId, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<long>(
                new Uri($"Forum/GetTopicForContent/{contentId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}