using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.HistoricalStats.DestinyAggregateActivityResults> Destiny2_GetDestinyAggregateActivityStats(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyAggregateActivityResults>(
                $"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/", null, null, HttpMethod.Get
                );
        }
    }
}