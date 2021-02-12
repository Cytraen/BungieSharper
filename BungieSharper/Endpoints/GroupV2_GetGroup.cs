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
        /// Get information about a specific group of the given ID.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.GroupsV2.GroupResponse> GroupV2_GetGroup(long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupResponse>(
=======
        /// <param name="groupId">Requested group's id.</param>
        public async Task<Entities.GroupsV2.GroupResponse> GroupV2_GetGroup(long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupResponse>(
>>>>>>> rewrite
                new Uri($"GroupV2/{groupId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}