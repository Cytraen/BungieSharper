using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.SearchResultOfGroupMember> GroupV2_GetMembersOfGroup(int currentpage, long groupId, Schema.GroupsV2.RuntimeGroupMemberType memberType, string nameSearch)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMember>(
                $"GroupV2/{groupId}/Members/", null, null, HttpMethod.Get
                );
        }
    }
}