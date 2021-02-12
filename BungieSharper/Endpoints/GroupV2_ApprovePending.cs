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
        /// Approve the given membershipId to join the group/clan as long as they have applied.
<<<<<<< HEAD
        /// </summary>
        public async Task<bool> GroupV2_ApprovePending(long groupId, long membershipId, Schema.BungieMembershipType membershipType, Schema.GroupsV2.GroupApplicationRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="membershipId">The membership id being approved.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        public async Task<bool> GroupV2_ApprovePending(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/{groupId}/Members/Approve/{membershipType}/{membershipId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}