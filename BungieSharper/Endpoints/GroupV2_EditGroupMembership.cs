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
        /// Edit the membership type of a given member. You must have suitable permissions in the group to perform this operation.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group to which the member belongs.</param>
        /// <param name="membershipId">Membership ID to modify.</param>
        /// <param name="membershipType">Membership type of the provide membership ID.</param>
        /// <param name="memberType">New membertype for the specified member.</param>
        public async Task<int> GroupV2_EditGroupMembership(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.RuntimeGroupMemberType memberType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/SetMembershipType/{memberType}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}