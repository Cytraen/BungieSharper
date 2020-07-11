﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// This is a preview method.
        /// Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
        /// </summary>
        public async Task<Dictionary<string, Dictionary<string, Schema.Destiny.HistoricalStats.DestinyLeaderboard>>> Destiny2_GetClanLeaderboards(long groupId, int maxtop, string modes, string statid)
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<string, Dictionary<string, Schema.Destiny.HistoricalStats.DestinyLeaderboard>>>(
                $"Destiny2/Stats/Leaderboards/Clans/{groupId}/", null, null, HttpMethod.Get
                );
        }
    }
}