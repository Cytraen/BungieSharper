using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.User.UserMembershipData> User_GetMembershipDataById(long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.User.UserMembershipData>(
                $"User/GetMembershipsById/{membershipId}/{membershipType}/", null, null, HttpMethod.Get
                );
        }
    }
}