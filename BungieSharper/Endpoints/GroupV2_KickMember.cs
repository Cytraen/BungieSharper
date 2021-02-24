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
        /// Kick a member from the given group, forcing them to reapply if they wish to re-join the group. You must have suitable permissions in the group to perform this operation.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID to kick the user from.</param>
        /// <param name="membershipId">Membership ID to kick.</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        public Task<Entities.GroupsV2.GroupMemberLeaveResult> GroupV2_KickMember(long groupId, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupMemberLeaveResult>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Kick/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}