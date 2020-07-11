using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets historical stats definitions.
        /// </summary>
        public async Task<Dictionary<string, Schema.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>> Destiny2_GetHistoricalStatsDefinition()
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<string, Schema.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>(
                $"Destiny2/Stats/Definition/", null, null, HttpMethod.Get
                );
        }
    }
}