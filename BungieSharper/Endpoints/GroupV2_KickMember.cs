using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.GroupsV2.GroupMemberLeaveResult> GroupV2_KickMember(long groupId, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupMemberLeaveResult>(
                $"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Kick/", null, null, HttpMethod.Post
                );
        }
    }
}