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
        /// Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
        /// </summary>
        /// <param name="membershipId">The membership ID of the target user.</param>
        /// <param name="membershipType">Type of the supplied membership ID.</param>
        public Task<Entities.User.UserMembershipData> User_GetMembershipDataById(long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.User.UserMembershipData>(
                new Uri($"User/GetMembershipsById/{membershipId}/{membershipType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}