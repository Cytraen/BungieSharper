using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<int> Fireteam_GetActivePrivateClanFireteamCount(long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                "Fireteam/Clan/{groupId}/ActiveCount/", null, null, HttpMethod.Get
                );
        }
    }
}