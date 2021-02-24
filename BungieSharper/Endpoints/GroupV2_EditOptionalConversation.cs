using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Edit the settings of an optional conversation/chat channel. Requires admin permissions to the group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="conversationId">Conversation Id of the channel being edited.</param>
        /// <param name="groupId">Group ID of the group to edit.</param>
        public Task<long> GroupV2_EditOptionalConversation(long conversationId, long groupId, Entities.GroupsV2.GroupOptionalConversationEditRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<long>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/Edit/{conversationId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}