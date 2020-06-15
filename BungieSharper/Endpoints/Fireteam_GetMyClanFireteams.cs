using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.SearchResultOfFireteamResponse> Fireteam_GetMyClanFireteams(bool groupFilter, long groupId, bool includeClosed, string langFilter, int page, Schema.Fireteam.FireteamPlatform platform)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamResponse>(
                "Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/", null, null, HttpMethod.Get
                );
        }
    }
}