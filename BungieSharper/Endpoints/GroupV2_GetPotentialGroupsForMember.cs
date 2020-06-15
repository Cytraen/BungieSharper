using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.GroupsV2.GroupPotentialMembershipSearchResponse> GroupV2_GetPotentialGroupsForMember(Schema.GroupsV2.GroupPotentialMemberStatus filter, Schema.GroupsV2.GroupType groupType, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupPotentialMembershipSearchResponse>(
                $"GroupV2/User/Potential/{membershipType}/{membershipId}/{filter}/{groupType}/", null, null, HttpMethod.Get
                );
        }
    }
}