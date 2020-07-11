using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Approve the given membershipId to join the group/clan as long as they have applied.
        /// </summary>
        public async Task<bool> GroupV2_ApprovePending(long groupId, long membershipId, Schema.BungieMembershipType membershipType, Schema.GroupsV2.GroupApplicationRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<bool>(
                $"GroupV2/{groupId}/Members/Approve/{membershipType}/{membershipId}/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}