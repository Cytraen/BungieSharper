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
        /// Invite a user to join this group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group you would like to join.</param>
        /// <param name="membershipId">Membership id of the account being invited.</param>
        /// <param name="membershipType">MembershipType of the account being invited.</param>
        public Task<Entities.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInvite(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupApplicationResponse>(
                new Uri($"GroupV2/{groupId}/Members/IndividualInvite/{membershipType}/{membershipId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}