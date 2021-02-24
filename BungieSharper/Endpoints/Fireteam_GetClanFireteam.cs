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
        /// Gets a specific clan fireteam.
        /// Requires OAuth2 scope(s): ReadGroups
        /// </summary>
        /// <param name="fireteamId">The unique id of the fireteam.</param>
        /// <param name="groupId">The group id of the clan.</param>
        public Task<Entities.Fireteam.FireteamResponse> Fireteam_GetClanFireteam(long fireteamId, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Fireteam.FireteamResponse>(
                new Uri($"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}