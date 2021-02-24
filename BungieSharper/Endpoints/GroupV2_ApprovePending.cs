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
        /// Approve the given membershipId to join the group/clan as long as they have applied.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="membershipId">The membership id being approved.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        public Task<bool> GroupV2_ApprovePending(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/{groupId}/Members/Approve/{membershipType}/{membershipId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}