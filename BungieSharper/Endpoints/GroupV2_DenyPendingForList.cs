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
        /// Deny all of the pending users for the given group that match the passed-in .
        /// </summary>
        public async Task<IEnumerable<Schema.Entities.EntityActionResult>> GroupV2_DenyPendingForList(long groupId, Schema.GroupsV2.GroupApplicationListRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Entities.EntityActionResult>>(
                new Uri($"GroupV2/{groupId}/Members/DenyList/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}