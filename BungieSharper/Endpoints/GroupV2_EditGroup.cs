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
        /// Edit an existing group. You must have suitable permissions in the group to perform this operation. This latest revision will only edit the fields you pass in - pass null for properties you want to leave unaltered.
<<<<<<< HEAD
        /// </summary>
        public async Task<int> GroupV2_EditGroup(long groupId, Schema.GroupsV2.GroupEditAction requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        public async Task<int> GroupV2_EditGroup(long groupId, Entities.GroupsV2.GroupEditAction requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Edit/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}