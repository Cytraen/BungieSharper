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
        /// Allows a founder to manually recover a group they can see in game but not on bungie.net
        /// </summary>
        public async Task<Schema.GroupsV2.GroupMembershipSearchResponse> GroupV2_RecoverGroupForFounder(Schema.GroupsV2.GroupType groupType, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupMembershipSearchResponse>(
                $"GroupV2/Recover/{membershipType}/{membershipId}/{groupType}/", null, null, HttpMethod.Get
                );
        }
    }
}