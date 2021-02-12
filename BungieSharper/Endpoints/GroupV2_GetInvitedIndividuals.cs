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
        /// Get the list of users who have been invited into the group.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.SearchResultOfGroupMemberApplication> GroupV2_GetInvitedIndividuals(int currentpage, long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMemberApplication>(
=======
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">ID of the group.</param>
        public async Task<Entities.SearchResultOfGroupMemberApplication> GroupV2_GetInvitedIndividuals(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMemberApplication>(
>>>>>>> rewrite
                new Uri($"GroupV2/{groupId}/Members/InvitedIndividuals/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}