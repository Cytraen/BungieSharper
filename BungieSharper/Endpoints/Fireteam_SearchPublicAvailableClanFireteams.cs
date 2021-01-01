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
        /// Gets a listing of all public fireteams starting now with open slots. Caller is not checked for join criteria so caching is maximized.
        /// </summary>
        public async Task<Schema.SearchResultOfFireteamSummary> Fireteam_SearchPublicAvailableClanFireteams(int activityType, Schema.Fireteam.FireteamDateRange dateRange, int page, Schema.Fireteam.FireteamPlatform platform, Schema.Fireteam.FireteamSlotSearch slotFilter, string langFilter = null, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamSummary>(
                new Uri($"Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/" + HttpRequestGenerator.MakeQuerystring(langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}