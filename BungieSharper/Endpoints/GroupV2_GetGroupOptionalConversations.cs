using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.GroupsV2.GroupOptionalConversation>> GroupV2_GetGroupOptionalConversations(long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.GroupsV2.GroupOptionalConversation>>(
                "GroupV2/{groupId}/OptionalConversations/", null, null, HttpMethod.Get
                );
        }
    }
}