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
        /// Edit an existing group's clan banner. You must have suitable permissions in the group to perform this operation. All fields are required.
        /// </summary>
        public async Task<int> GroupV2_EditClanBanner(long groupId, Schema.GroupsV2.ClanBanner requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"GroupV2/{groupId}/EditClanBanner/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}