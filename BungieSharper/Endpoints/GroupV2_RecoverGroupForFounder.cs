using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.GroupsV2.GroupMembershipSearchResponse> GroupV2_RecoverGroupForFounder(Schema.GroupsV2.GroupType groupType, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupMembershipSearchResponse>(
                "GroupV2/Recover/{membershipType}/{membershipId}/{groupType}/", null, null, HttpMethod.Get
                );
        }
    }
}