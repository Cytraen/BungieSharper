using BungieSharper.Client;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
>>>>>>> rewrite
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Provide the result of the user interaction. Called by the Bungie Destiny App to approve or reject a request.
        /// </summary>
<<<<<<< HEAD
        public async Task<int> Destiny2_AwaProvideAuthorizationResult(Schema.Destiny.Advanced.AwaUserResponse requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        public async Task<int> Destiny2_AwaProvideAuthorizationResult(Entities.Destiny.Advanced.AwaUserResponse requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"Destiny2/Awa/AwaProvideAuthorizationResult/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}