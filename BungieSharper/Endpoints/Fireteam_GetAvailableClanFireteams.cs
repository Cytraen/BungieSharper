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
        /// Gets a listing of all of this clan's fireteams that are have available slots. Caller is not checked for join criteria so caching is maximized.
        /// </summary>
        public async Task<Schema.SearchResultOfFireteamSummary> Fireteam_GetAvailableClanFireteams(int activityType, Schema.Fireteam.FireteamDateRange dateRange, long groupId, int page, Schema.Fireteam.FireteamPlatform platform, Schema.Fireteam.FireteamPublicSearchOption publicOnly, Schema.Fireteam.FireteamSlotSearch slotFilter, string langFilter = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamSummary>(
                new Uri($"Fireteam/Clan/{groupId}/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{publicOnly}/{page}/" + HttpRequestGenerator.MakeQuerystring(langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}