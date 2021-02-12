using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
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
        /// Approve all of the pending users for the given group.
<<<<<<< HEAD
        /// </summary>
        public async Task<IEnumerable<Schema.Entities.EntityActionResult>> GroupV2_ApproveAllPending(long groupId, Schema.GroupsV2.GroupApplicationRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Entities.EntityActionResult>>(
=======
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        public async Task<IEnumerable<Entities.Entities.EntityActionResult>> GroupV2_ApproveAllPending(long groupId, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Entities.EntityActionResult>>(
>>>>>>> rewrite
                new Uri($"GroupV2/{groupId}/Members/ApproveAll/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}