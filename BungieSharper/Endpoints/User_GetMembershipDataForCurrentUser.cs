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
        /// Returns a list of accounts associated with signed in user. This is useful for OAuth implementations that do not give you access to the token response.
        /// </summary>
        public async Task<Schema.User.UserMembershipData> User_GetMembershipDataForCurrentUser()
        {
            return await _apiAccessor.ApiRequestAsync<Schema.User.UserMembershipData>(
                new Uri($"User/GetMembershipsForCurrentUser/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}