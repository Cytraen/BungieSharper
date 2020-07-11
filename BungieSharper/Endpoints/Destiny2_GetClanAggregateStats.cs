using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// This is a preview method.
        /// Gets aggregated stats for a clan using the same categories as the clan leaderboards. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
        /// </summary>
        public async Task<IEnumerable<Schema.Destiny.HistoricalStats.DestinyClanAggregateStat>> Destiny2_GetClanAggregateStats(long groupId, string modes = null)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Destiny.HistoricalStats.DestinyClanAggregateStat>>(
                $"Destiny2/Stats/AggregateClanStats/{groupId}/", null, null, HttpMethod.Get,
                modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null);
        }
    }
}