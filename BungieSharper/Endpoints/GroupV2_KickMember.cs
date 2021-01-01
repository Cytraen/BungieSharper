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
        /// Kick a member from the given group, forcing them to reapply if they wish to re-join the group. You must have suitable permissions in the group to perform this operation.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupMemberLeaveResult> GroupV2_KickMember(long groupId, long membershipId, Schema.BungieMembershipType membershipType, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupMemberLeaveResult>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Kick/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}