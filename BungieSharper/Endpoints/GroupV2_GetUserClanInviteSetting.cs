using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<bool> GroupV2_GetUserClanInviteSetting(Schema.BungieMembershipType mType)
        {
            return await this._apiAccessor.ApiRequestAsync<bool>(
                $"GroupV2/GetUserClanInviteSetting/{mType}/", null, null, HttpMethod.Get
                );
        }
    }
}