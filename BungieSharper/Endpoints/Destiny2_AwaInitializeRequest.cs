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
        /// Initialize a request to perform an advanced write action.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.Destiny.Advanced.AwaInitializeResponse> Destiny2_AwaInitializeRequest(Schema.Destiny.Advanced.AwaPermissionRequested requestBody, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Advanced.AwaInitializeResponse>(
=======
        /// Requires OAuth2 scope(s): AdvancedWriteActions
        /// </summary>
        public async Task<Entities.Destiny.Advanced.AwaInitializeResponse> Destiny2_AwaInitializeRequest(Entities.Destiny.Advanced.AwaPermissionRequested requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Advanced.AwaInitializeResponse>(
>>>>>>> rewrite
                new Uri($"Destiny2/Awa/Initialize/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}