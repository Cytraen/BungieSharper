using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<int> GroupV2_UnbanMember(long groupId, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                "GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Unban/", null, null, HttpMethod.Post
                );
        }
    }
}