using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.SearchResultOfGroupBan> GroupV2_GetBannedMembersOfGroup(int currentpage, long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupBan>(
                $"GroupV2/{groupId}/Banned/", null, null, HttpMethod.Get
                );
        }
    }
}