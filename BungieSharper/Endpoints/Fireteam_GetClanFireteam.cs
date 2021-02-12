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
        /// Gets a specific clan fireteam.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.Fireteam.FireteamResponse> Fireteam_GetClanFireteam(long fireteamId, long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Fireteam.FireteamResponse>(
=======
        /// Requires OAuth2 scope(s): ReadGroups
        /// </summary>
        /// <param name="fireteamId">The unique id of the fireteam.</param>
        /// <param name="groupId">The group id of the clan.</param>
        public async Task<Entities.Fireteam.FireteamResponse> Fireteam_GetClanFireteam(long fireteamId, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Fireteam.FireteamResponse>(
>>>>>>> rewrite
                new Uri($"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}