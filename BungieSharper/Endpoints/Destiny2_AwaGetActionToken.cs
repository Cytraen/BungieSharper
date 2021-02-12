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
        /// Returns the action token if user approves the request.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.Destiny.Advanced.AwaAuthorizationResult> Destiny2_AwaGetActionToken(string correlationId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Advanced.AwaAuthorizationResult>(
=======
        /// Requires OAuth2 scope(s): AdvancedWriteActions
        /// </summary>
        /// <param name="correlationId">The identifier for the advanced write action request.</param>
        public async Task<Entities.Destiny.Advanced.AwaAuthorizationResult> Destiny2_AwaGetActionToken(string correlationId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Advanced.AwaAuthorizationResult>(
>>>>>>> rewrite
                new Uri($"Destiny2/Awa/GetActionToken/{Uri.EscapeDataString(correlationId)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}