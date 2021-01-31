using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get the list of users who have been invited into the group.
        /// </summary>
        public async Task<Schema.SearchResultOfGroupMemberApplication> GroupV2_GetInvitedIndividuals(int currentpage, long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMemberApplication>(
                new Uri($"GroupV2/{groupId}/Members/InvitedIndividuals/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}