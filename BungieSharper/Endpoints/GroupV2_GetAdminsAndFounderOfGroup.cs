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
        /// Get the list of members in a given group who are of admin level or higher.
        /// </summary>
        public async Task<Schema.SearchResultOfGroupMember> GroupV2_GetAdminsAndFounderOfGroup(int currentpage, long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMember>(
                $"GroupV2/{groupId}/AdminsAndFounder/", null, null, HttpMethod.Get
                );
        }
    }
}