using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.GroupsV2.GroupResponse> GroupV2_GetGroupByName(string groupName, Schema.GroupsV2.GroupType groupType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupResponse>(
                "GroupV2/Name/{groupName}/{groupType}/", null, null, HttpMethod.Get
                );
        }
    }
}