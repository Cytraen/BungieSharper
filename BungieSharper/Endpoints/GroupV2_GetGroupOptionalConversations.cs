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
        /// Gets a list of available optional conversation channels and their settings.
        /// </summary>
        /// <param name="groupId">Requested group's id.</param>
        public Task<IEnumerable<Entities.GroupsV2.GroupOptionalConversation>> GroupV2_GetGroupOptionalConversations(long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.GroupsV2.GroupOptionalConversation>>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}