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
        /// Edit the settings of an optional conversation/chat channel. Requires admin permissions to the group.
        /// </summary>
        public async Task<long> GroupV2_EditOptionalConversation(long conversationId, long groupId, Schema.GroupsV2.GroupOptionalConversationEditRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<long>(
                $"GroupV2/{groupId}/OptionalConversations/Edit/{conversationId}/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}