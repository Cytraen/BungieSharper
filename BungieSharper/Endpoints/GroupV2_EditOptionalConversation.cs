using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<long> GroupV2_EditOptionalConversation(long conversationId, long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<long>(
                $"GroupV2/{groupId}/OptionalConversations/Edit/{conversationId}/", null, null, HttpMethod.Post
                );
        }
    }
}