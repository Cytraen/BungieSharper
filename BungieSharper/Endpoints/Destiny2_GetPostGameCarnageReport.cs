using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
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
        /// Gets the available post game carnage report for the activity ID.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportData> Destiny2_GetPostGameCarnageReport(long activityId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>(
=======
        /// <param name="activityId">The ID of the activity whose PGCR is requested.</param>
        public async Task<Entities.Destiny.HistoricalStats.DestinyPostGameCarnageReportData> Destiny2_GetPostGameCarnageReport(long activityId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>(
>>>>>>> rewrite
                new Uri($"Destiny2/Stats/PostGameCarnageReport/{activityId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}