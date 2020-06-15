using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<bool> GroupV2_ApprovePending(long groupId, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<bool>(
                $"GroupV2/{groupId}/Members/Approve/{membershipType}/{membershipId}/", null, null, HttpMethod.Post
                );
        }
    }
}