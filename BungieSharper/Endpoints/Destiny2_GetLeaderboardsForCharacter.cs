using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Dictionary<string, Dictionary<string, Schema.Destiny.HistoricalStats.DestinyLeaderboard>>> Destiny2_GetLeaderboardsForCharacter(long characterId, long destinyMembershipId, int maxtop, Schema.BungieMembershipType membershipType, string modes, string statid)
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<string, Dictionary<string, Schema.Destiny.HistoricalStats.DestinyLeaderboard>>>(
                "Destiny2/Stats/Leaderboards/{membershipType}/{destinyMembershipId}/{characterId}/", null, null, HttpMethod.Get
                );
        }
    }
}