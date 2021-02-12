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
        /// Gets a listing of all public fireteams starting now with open slots. Caller is not checked for join criteria so caching is maximized.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.SearchResultOfFireteamSummary> Fireteam_SearchPublicAvailableClanFireteams(int activityType, Schema.Fireteam.FireteamDateRange dateRange, int page, Schema.Fireteam.FireteamPlatform platform, Schema.Fireteam.FireteamSlotSearch slotFilter, string langFilter = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamSummary>(
=======
        /// Requires OAuth2 scope(s): ReadGroups
        /// </summary>
        /// <param name="activityType">The activity type to filter by.</param>
        /// <param name="dateRange">The date range to grab available fireteams.</param>
        /// <param name="langFilter">An optional language filter.</param>
        /// <param name="page">Zero based page</param>
        /// <param name="platform">The platform filter.</param>
        /// <param name="slotFilter">Filters based on available slots</param>
        public async Task<Entities.SearchResultOfFireteamSummary> Fireteam_SearchPublicAvailableClanFireteams(int activityType, Entities.Fireteam.FireteamDateRange dateRange, int page, Entities.Fireteam.FireteamPlatform platform, Entities.Fireteam.FireteamSlotSearch slotFilter, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.SearchResultOfFireteamSummary>(
>>>>>>> rewrite
                new Uri($"Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/" + HttpRequestGenerator.MakeQuerystring(langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}