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
        /// Get information about a specific group with the given name and type. The POST version.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.GroupsV2.GroupResponse> GroupV2_GetGroupByNameV2(Schema.GroupsV2.GroupNameSearchRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupResponse>(
=======
        public async Task<Entities.GroupsV2.GroupResponse> GroupV2_GetGroupByNameV2(Entities.GroupsV2.GroupNameSearchRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupResponse>(
>>>>>>> rewrite
                new Uri($"GroupV2/NameV2/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}