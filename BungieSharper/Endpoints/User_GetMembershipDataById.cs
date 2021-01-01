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
        /// Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
        /// </summary>
        public async Task<Schema.User.UserMembershipData> User_GetMembershipDataById(long membershipId, Schema.BungieMembershipType membershipType, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.User.UserMembershipData>(
                new Uri($"User/GetMembershipsById/{membershipId}/{membershipType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}