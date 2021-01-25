using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets a listing of all clan fireteams that caller is an applicant, a member, or an alternate of.
        /// </summary>
        public async Task<Schema.SearchResultOfFireteamResponse> Fireteam_GetMyClanFireteams(long groupId, bool includeClosed, int page, Schema.Fireteam.FireteamPlatform platform, bool? groupFilter = null, string langFilter = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamResponse>(
                new Uri($"Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/" + HttpRequestGenerator.MakeQuerystring(groupFilter != null ? $"groupFilter={groupFilter}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}