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
        /// Get information about a specific group with the given name and type. The POST version.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupResponse> GroupV2_GetGroupByNameV2(Schema.GroupsV2.GroupNameSearchRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupResponse>(
                $"GroupV2/NameV2/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}