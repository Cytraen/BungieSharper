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
        /// Requires OAuth2 scope(s): ReadGroups
        /// </summary>
        /// <param name="groupFilter">If true, filter by clan. Otherwise, ignore the clan and show all of the user's fireteams.</param>
        /// <param name="groupId">The group id of the clan. (This parameter is ignored unless the optional query parameter groupFilter is true).</param>
        /// <param name="includeClosed">If true, return fireteams that have been closed.</param>
        /// <param name="langFilter">An optional language filter.</param>
        /// <param name="page">Deprecated parameter, ignored.</param>
        /// <param name="platform">The platform filter.</param>
        public Task<Entities.SearchResultOfFireteamResponse> Fireteam_GetMyClanFireteams(long groupId, bool includeClosed, int page, Entities.Fireteam.FireteamPlatform platform, bool? groupFilter = null, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfFireteamResponse>(
                new Uri($"Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/" + HttpRequestGenerator.MakeQuerystring(groupFilter != null ? $"groupFilter={groupFilter}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}