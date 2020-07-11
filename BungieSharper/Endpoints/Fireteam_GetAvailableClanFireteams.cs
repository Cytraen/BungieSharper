﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets a listing of all of this clan's fireteams that are have available slots. Caller is not checked for join criteria so caching is maximized.
        /// </summary>
        public async Task<Schema.SearchResultOfFireteamSummary> Fireteam_GetAvailableClanFireteams(int activityType, Schema.Fireteam.FireteamDateRange dateRange, long groupId, string langFilter, int page, Schema.Fireteam.FireteamPlatform platform, Schema.Fireteam.FireteamPublicSearchOption publicOnly, Schema.Fireteam.FireteamSlotSearch slotFilter)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamSummary>(
                $"Fireteam/Clan/{groupId}/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{publicOnly}/{page}/", null, null, HttpMethod.Get
                );
        }
    }
}