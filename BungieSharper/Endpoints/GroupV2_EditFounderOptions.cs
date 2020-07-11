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
        /// Edit group options only available to a founder. You must have suitable permissions in the group to perform this operation.
        /// </summary>
        public async Task<int> GroupV2_EditFounderOptions(long groupId, Schema.GroupsV2.GroupOptionsEditAction requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"GroupV2/{groupId}/EditFounderOptions/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}