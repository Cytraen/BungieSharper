using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.User.HardLinkedUserMembership> User_GetMembershipFromHardLinkedCredential(string credential, Schema.BungieCredentialType crType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.User.HardLinkedUserMembership>(
                "User/GetMembershipFromHardLinkedCredential/{crType}/{credential}/", null, null, HttpMethod.Get
                );
        }
    }
}