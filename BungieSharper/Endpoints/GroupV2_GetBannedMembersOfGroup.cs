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
        /// Get the list of banned members in a given group. Only accessible to group Admins and above. Not applicable to all groups. Check group features.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.SearchResultOfGroupBan> GroupV2_GetBannedMembersOfGroup(int currentpage, long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupBan>(
=======
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 entries.</param>
        /// <param name="groupId">Group ID whose banned members you are fetching</param>
        public async Task<Entities.SearchResultOfGroupBan> GroupV2_GetBannedMembersOfGroup(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupBan>(
>>>>>>> rewrite
                new Uri($"GroupV2/{groupId}/Banned/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}