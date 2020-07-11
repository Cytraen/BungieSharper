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
        /// Approve all of the pending users for the given group.
        /// </summary>
        public async Task<IEnumerable<Schema.Entities.EntityActionResult>> GroupV2_ApproveAllPending(long groupId, Schema.GroupsV2.GroupApplicationRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Entities.EntityActionResult>>(
                $"GroupV2/{groupId}/Members/ApproveAll/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}