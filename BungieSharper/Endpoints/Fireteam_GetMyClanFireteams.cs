using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets a listing of all clan fireteams that caller is an applicant, a member, or an alternate of.
        /// </summary>
        public async Task<Schema.SearchResultOfFireteamResponse> Fireteam_GetMyClanFireteams(long groupId, bool includeClosed, int page, Schema.Fireteam.FireteamPlatform platform, bool? groupFilter = null, string langFilter = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfFireteamResponse>(
                $"Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/", null, null, HttpMethod.Get,
                groupFilter != null ? $"groupFilter={groupFilter}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null);
        }
    }
}