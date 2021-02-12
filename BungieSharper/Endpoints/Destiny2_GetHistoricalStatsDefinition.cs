using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets historical stats definitions.
        /// </summary>
<<<<<<< HEAD
        public async Task<Dictionary<string, Schema.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>> Destiny2_GetHistoricalStatsDefinition(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, Schema.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>(
=======
        public async Task<Dictionary<string, Entities.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>> Destiny2_GetHistoricalStatsDefinition(string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, Entities.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>(
>>>>>>> rewrite
                new Uri($"Destiny2/Stats/Definition/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}