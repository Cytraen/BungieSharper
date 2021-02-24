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
        /// Returns a list of accounts associated with signed in user. This is useful for OAuth implementations that do not give you access to the token response.
        /// Requires OAuth2 scope(s): ReadBasicUserProfile
        /// </summary>
        public Task<Entities.User.UserMembershipData> User_GetMembershipDataForCurrentUser(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.User.UserMembershipData>(
                new Uri($"User/GetMembershipsForCurrentUser/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}