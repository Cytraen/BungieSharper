using BungieSharper.Client;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
>>>>>>> rewrite
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
<<<<<<< HEAD
        /// </summary>
        public async Task<long> GroupV2_EditOptionalConversation(long conversationId, long groupId, Schema.GroupsV2.GroupOptionalConversationEditRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="conversationId">Conversation Id of the channel being edited.</param>
        /// <param name="groupId">Group ID of the group to edit.</param>
        public async Task<long> GroupV2_EditOptionalConversation(long conversationId, long groupId, Entities.GroupsV2.GroupOptionalConversationEditRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<long>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/Edit/{conversationId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}