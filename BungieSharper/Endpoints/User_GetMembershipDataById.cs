using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
        /// </summary>
        public async Task<Schema.User.UserMembershipData> User_GetMembershipDataById(long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.User.UserMembershipData>(
                $"User/GetMembershipsById/{membershipId}/{membershipType}/", null, null, HttpMethod.Get
                );
        }
    }
}