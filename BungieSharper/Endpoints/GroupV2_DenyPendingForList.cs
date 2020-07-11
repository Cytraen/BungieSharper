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
        /// Deny all of the pending users for the given group that match the passed-in .
        /// </summary>
        public async Task<IEnumerable<Schema.Entities.EntityActionResult>> GroupV2_DenyPendingForList(long groupId, Schema.GroupsV2.GroupApplicationListRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Entities.EntityActionResult>>(
                $"GroupV2/{groupId}/Members/DenyList/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}