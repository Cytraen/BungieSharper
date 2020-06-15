using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.HistoricalStats.DestinyActivityHistoryResults> Destiny2_GetActivityHistory(long characterId, int count, long destinyMembershipId, Schema.BungieMembershipType membershipType, Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode, int page)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyActivityHistoryResults>(
                "Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/", null, null, HttpMethod.Get
                );
        }
    }
}