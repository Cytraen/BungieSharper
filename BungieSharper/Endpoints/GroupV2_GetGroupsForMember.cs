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
        /// Get information about the groups that a given member has joined.
        /// </summary>
        public async Task<Schema.GroupsV2.GetGroupsForMemberResponse> GroupV2_GetGroupsForMember(Schema.GroupsV2.GroupsForMemberFilter filter, Schema.GroupsV2.GroupType groupType, long membershipId, Schema.BungieMembershipType membershipType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GetGroupsForMemberResponse>(
                new Uri($"GroupV2/User/{membershipType}/{membershipId}/{filter}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}