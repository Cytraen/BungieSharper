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
        /// Bans the requested member from the requested group for the specified period of time.
        /// </summary>
        public async Task<int> GroupV2_BanMember(long groupId, long membershipId, Schema.BungieMembershipType membershipType, Schema.GroupsV2.GroupBanRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Ban/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}