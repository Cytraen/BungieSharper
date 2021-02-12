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
        /// Get the list of users who are awaiting a decision on their application to join a given group. Modified to include application info.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">ID of the group.</param>
        public async Task<Entities.SearchResultOfGroupMemberApplication> GroupV2_GetPendingMemberships(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMemberApplication>(
                new Uri($"GroupV2/{groupId}/Members/Pending/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}