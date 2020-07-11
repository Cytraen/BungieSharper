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
        /// Get the list of banned members in a given group. Only accessible to group Admins and above. Not applicable to all groups. Check group features.
        /// </summary>
        public async Task<Schema.SearchResultOfGroupBan> GroupV2_GetBannedMembersOfGroup(int currentpage, long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupBan>(
                $"GroupV2/{groupId}/Banned/", null, null, HttpMethod.Get
                );
        }
    }
}