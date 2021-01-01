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
        /// Get information about a specific group with the given name and type. The POST version.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupResponse> GroupV2_GetGroupByNameV2(Schema.GroupsV2.GroupNameSearchRequest requestBody, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupResponse>(
                new Uri($"GroupV2/NameV2/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}