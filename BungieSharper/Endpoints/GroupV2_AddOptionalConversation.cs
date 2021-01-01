using BungieSharper.Client;
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
        /// Add a new optional conversation/chat channel. Requires admin permissions to the group.
        /// </summary>
        public async Task<long> GroupV2_AddOptionalConversation(long groupId, Schema.GroupsV2.GroupOptionalConversationAddRequest requestBody, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<long>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/Add/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}