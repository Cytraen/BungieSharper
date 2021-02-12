using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
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
        /// Returns a list of all available group avatars for the signed-in user.
        /// </summary>
<<<<<<< HEAD
        public async Task<Dictionary<int, string>> GroupV2_GetAvailableAvatars(string authToken = null, CancellationToken cancelToken = default)
=======
        public async Task<Dictionary<int, string>> GroupV2_GetAvailableAvatars(string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<int, string>>(
                new Uri($"GroupV2/GetAvailableAvatars/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}