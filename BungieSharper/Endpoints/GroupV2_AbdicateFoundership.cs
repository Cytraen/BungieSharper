using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<bool> GroupV2_AbdicateFoundership(long founderIdNew, long groupId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<bool>(
                "GroupV2/{groupId}/Admin/AbdicateFoundership/{membershipType}/{founderIdNew}/", null, null, HttpMethod.Post
                );
        }
    }
}