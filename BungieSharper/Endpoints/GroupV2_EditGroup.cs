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
        /// Edit an existing group. You must have suitable permissions in the group to perform this operation. This latest revision will only edit the fields you pass in - pass null for properties you want to leave unaltered.
        /// </summary>
        public async Task<int> GroupV2_EditGroup(long groupId, Schema.GroupsV2.GroupEditAction requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"GroupV2/{groupId}/Edit/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}