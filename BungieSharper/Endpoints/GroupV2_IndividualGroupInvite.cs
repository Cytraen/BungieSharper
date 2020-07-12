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
        /// Invite a user to join this group.
        /// </summary>
        public async Task<Schema.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInvite(long groupId, long membershipId, Schema.BungieMembershipType membershipType, Schema.GroupsV2.GroupApplicationRequest requestBody)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupApplicationResponse>(
                new Uri($"GroupV2/{groupId}/Members/IndividualInvite/{membershipType}/{membershipId}/", UriKind.Relative),
                null, new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post
                ).ConfigureAwait(false);
        }
    }
}