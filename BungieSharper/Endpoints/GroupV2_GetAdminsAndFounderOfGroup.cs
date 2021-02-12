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
        /// Get the list of members in a given group who are of admin level or higher.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.SearchResultOfGroupMember> GroupV2_GetAdminsAndFounderOfGroup(int currentpage, long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMember>(
=======
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">The ID of the group.</param>
        public async Task<Entities.SearchResultOfGroupMember> GroupV2_GetAdminsAndFounderOfGroup(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMember>(
>>>>>>> rewrite
                new Uri($"GroupV2/{groupId}/AdminsAndFounder/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}