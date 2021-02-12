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
<<<<<<< HEAD
        /// This is a preview method.
        /// Gets aggregated stats for a clan using the same categories as the clan leaderboards. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
        /// </summary>
        public async Task<IEnumerable<Schema.Destiny.HistoricalStats.DestinyClanAggregateStat>> Destiny2_GetClanAggregateStats(long groupId, string modes = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Destiny.HistoricalStats.DestinyClanAggregateStat>>(
=======
        /// Gets aggregated stats for a clan using the same categories as the clan leaderboards. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
        /// </summary>
        /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
        /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
        public async Task<IEnumerable<Entities.Destiny.HistoricalStats.DestinyClanAggregateStat>> Destiny2_GetClanAggregateStats(long groupId, string? modes = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Destiny.HistoricalStats.DestinyClanAggregateStat>>(
>>>>>>> rewrite
                new Uri($"Destiny2/Stats/AggregateClanStats/{groupId}/" + HttpRequestGenerator.MakeQuerystring(modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}