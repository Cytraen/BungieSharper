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
        /// Returns the action token if user approves the request.
        /// Requires OAuth2 scope(s): AdvancedWriteActions
        /// </summary>
        /// <param name="correlationId">The identifier for the advanced write action request.</param>
        public Task<Entities.Destiny.Advanced.AwaAuthorizationResult> Destiny2_AwaGetActionToken(string correlationId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Destiny.Advanced.AwaAuthorizationResult>(
                new Uri($"Destiny2/Awa/GetActionToken/{Uri.EscapeDataString(correlationId)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}