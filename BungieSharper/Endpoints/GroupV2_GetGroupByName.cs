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
        /// Get information about a specific group with the given name and type.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupResponse> GroupV2_GetGroupByName(string groupName, Schema.GroupsV2.GroupType groupType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupResponse>(
                $"GroupV2/Name/{Uri.EscapeDataString(groupName)}/{groupType}/", null, null, HttpMethod.Get
                );
        }
    }
}