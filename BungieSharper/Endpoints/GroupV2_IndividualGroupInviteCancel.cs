using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Cancels a pending invitation to join a group.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInviteCancel(long groupId, long membershipId, Schema.BungieMembershipType membershipType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupApplicationResponse>(
=======
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group you would like to join.</param>
        /// <param name="membershipId">Membership id of the account being cancelled.</param>
        /// <param name="membershipType">MembershipType of the account being cancelled.</param>
        public async Task<Entities.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInviteCancel(long groupId, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupApplicationResponse>(
>>>>>>> rewrite
                new Uri($"GroupV2/{groupId}/Members/IndividualInviteCancel/{membershipType}/{membershipId}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}