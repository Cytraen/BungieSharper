using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.Destiny.HistoricalStats.DestinyClanAggregateStat>> Destiny2_GetClanAggregateStats(long groupId, string modes)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Destiny.HistoricalStats.DestinyClanAggregateStat>>(
                $"Destiny2/Stats/AggregateClanStats/{groupId}/", null, null, HttpMethod.Get
                );
        }
    }
}