using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get the list of members in a given group.
        /// </summary>
        public async Task<Schema.SearchResultOfGroupMember> GroupV2_GetMembersOfGroup(int currentpage, long groupId, Schema.GroupsV2.RuntimeGroupMemberType? memberType = null, string nameSearch = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMember>(
                $"GroupV2/{groupId}/Members/", null, null, HttpMethod.Get,
                memberType != null ? $"memberType={memberType}" : null, nameSearch != null ? $"nameSearch={Uri.EscapeDataString(nameSearch)}" : null);
        }
    }
}