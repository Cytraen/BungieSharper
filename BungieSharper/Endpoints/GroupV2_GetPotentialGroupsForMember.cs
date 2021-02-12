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
        /// Get information about the groups that a given member has applied to or been invited to.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.GroupsV2.GroupPotentialMembershipSearchResponse> GroupV2_GetPotentialGroupsForMember(Schema.GroupsV2.GroupPotentialMemberStatus filter, Schema.GroupsV2.GroupType groupType, long membershipId, Schema.BungieMembershipType membershipType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupPotentialMembershipSearchResponse>(
=======
        /// <param name="filter">Filter apply to list of potential joined groups.</param>
        /// <param name="groupType">Type of group the supplied member applied.</param>
        /// <param name="membershipId">Membership ID to for which to find applied groups.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        public async Task<Entities.GroupsV2.GroupPotentialMembershipSearchResponse> GroupV2_GetPotentialGroupsForMember(Entities.GroupsV2.GroupPotentialMemberStatus filter, Entities.GroupsV2.GroupType groupType, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupPotentialMembershipSearchResponse>(
>>>>>>> rewrite
                new Uri($"GroupV2/User/Potential/{membershipType}/{membershipId}/{filter}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}