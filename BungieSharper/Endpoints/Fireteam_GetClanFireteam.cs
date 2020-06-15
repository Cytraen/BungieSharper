using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Fireteam.FireteamResponse> Fireteam_GetClanFireteam(long fireteamId, long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Fireteam.FireteamResponse>(
                $"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", null, null, HttpMethod.Get
                );
        }
    }
}