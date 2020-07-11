using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Cancels a pending invitation to join a group.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInviteCancel(long groupId, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupApplicationResponse>(
                $"GroupV2/{groupId}/Members/IndividualInviteCancel/{membershipType}/{membershipId}/", null, null, HttpMethod.Post
                );
        }
    }
}