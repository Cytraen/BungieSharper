using BungieSharper.Client;
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
        /// Gets the available post game carnage report for the activity ID.
        /// </summary>
        public async Task<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportData> Destiny2_GetPostGameCarnageReport(long activityId, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>(
                new Uri($"Destiny2/Stats/PostGameCarnageReport/{activityId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}