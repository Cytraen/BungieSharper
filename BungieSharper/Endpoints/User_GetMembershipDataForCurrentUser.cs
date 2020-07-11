using System;
using System.Collections.Generic;
using System.Net.Http;
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
            return await this._apiAccessor.ApiRequestAsync<Schema.User.UserMembershipData>(
                $"User/GetMembershipsForCurrentUser/", null, null, HttpMethod.Get
                );
        }
    }
}