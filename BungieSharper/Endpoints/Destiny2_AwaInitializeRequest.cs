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
        /// Initialize a request to perform an advanced write action.
        /// Requires OAuth2 scope(s): AdvancedWriteActions
        /// </summary>
        public Task<Entities.Destiny.Advanced.AwaInitializeResponse> Destiny2_AwaInitializeRequest(Entities.Destiny.Advanced.AwaPermissionRequested requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Destiny.Advanced.AwaInitializeResponse>(
                new Uri($"Destiny2/Awa/Initialize/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}