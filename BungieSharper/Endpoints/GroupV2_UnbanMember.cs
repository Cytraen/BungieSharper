﻿using BungieSharper.Client;
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
        /// Unbans the requested member, allowing them to re-apply for membership.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="membershipId">Membership ID of the member to unban from the group</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        public async Task<int> GroupV2_UnbanMember(long groupId, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Unban/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}