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
        /// Gets a count of all active non-public fireteams for the specified clan. Maximum value returned is 25.
<<<<<<< HEAD
        /// </summary>
        public async Task<int> Fireteam_GetActivePrivateClanFireteamCount(long groupId, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): ReadGroups
        /// </summary>
        /// <param name="groupId">The group id of the clan.</param>
        public async Task<int> Fireteam_GetActivePrivateClanFireteamCount(long groupId, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"Fireteam/Clan/{groupId}/ActiveCount/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}