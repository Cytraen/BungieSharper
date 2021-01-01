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
        /// Gets a specific clan fireteam.
        /// </summary>
        public async Task<Schema.Fireteam.FireteamResponse> Fireteam_GetClanFireteam(long fireteamId, long groupId, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Fireteam.FireteamResponse>(
                new Uri($"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}