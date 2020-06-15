using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.SearchResultOfFireteamSummary> Fireteam_SearchPublicAvailableClanFireteams(int activityType, Schema.Fireteam.FireteamDateRange dateRange, string langFilter, int page, Schema.Fireteam.FireteamPlatform platform, Schema.Fireteam.FireteamSlotSearch slotFilter)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamSummary>(
                "Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/", null, null, HttpMethod.Get
                );
        }
    }
}