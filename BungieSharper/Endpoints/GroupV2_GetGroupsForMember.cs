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
        /// Get information about the groups that a given member has joined.
        /// </summary>
        /// <param name="filter">Filter apply to list of joined groups.</param>
        /// <param name="groupType">Type of group the supplied member founded.</param>
        /// <param name="membershipId">Membership ID to for which to find founded groups.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        public Task<Entities.GroupsV2.GetGroupsForMemberResponse> GroupV2_GetGroupsForMember(Entities.GroupsV2.GroupsForMemberFilter filter, Entities.GroupsV2.GroupType groupType, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GetGroupsForMemberResponse>(
                new Uri($"GroupV2/User/{membershipType}/{membershipId}/{filter}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}