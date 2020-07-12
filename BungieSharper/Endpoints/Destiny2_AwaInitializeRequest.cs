using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Initialize a request to perform an advanced write action.
        /// </summary>
        public async Task<Schema.Destiny.Advanced.AwaInitializeResponse> Destiny2_AwaInitializeRequest(Schema.Destiny.Advanced.AwaPermissionRequested requestBody)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Advanced.AwaInitializeResponse>(
                new Uri($"Destiny2/Awa/Initialize/", UriKind.Relative),
                null, new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post
                ).ConfigureAwait(false);
        }
    }
}