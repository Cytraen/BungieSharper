using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Kick a member from the given group, forcing them to reapply if they wish to re-join the group. You must have suitable permissions in the group to perform this operation.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupMemberLeaveResult> GroupV2_KickMember(long groupId, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupMemberLeaveResult>(
                $"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Kick/", null, null, HttpMethod.Post
                );
        }
    }
}