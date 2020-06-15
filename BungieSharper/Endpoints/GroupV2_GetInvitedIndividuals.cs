using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.SearchResultOfGroupMemberApplication> GroupV2_GetInvitedIndividuals(int currentpage, long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMemberApplication>(
                $"GroupV2/{groupId}/Members/InvitedIndividuals/", null, null, HttpMethod.Get
                );
        }
    }
}