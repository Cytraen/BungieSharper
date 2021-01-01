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
        /// Get information about the groups that a given member has applied to or been invited to.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupPotentialMembershipSearchResponse> GroupV2_GetPotentialGroupsForMember(Schema.GroupsV2.GroupPotentialMemberStatus filter, Schema.GroupsV2.GroupType groupType, long membershipId, Schema.BungieMembershipType membershipType, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupPotentialMembershipSearchResponse>(
                new Uri($"GroupV2/User/Potential/{membershipType}/{membershipId}/{filter}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}