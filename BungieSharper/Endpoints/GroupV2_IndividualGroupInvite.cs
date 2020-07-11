using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Invite a user to join this group.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInvite(long groupId, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupApplicationResponse>(
                $"GroupV2/{groupId}/Members/IndividualInvite/{membershipType}/{membershipId}/", null, null, HttpMethod.Post
                );
        }
    }
}