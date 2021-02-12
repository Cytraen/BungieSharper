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
        /// Returns a list of all available group themes.
        /// </summary>
<<<<<<< HEAD
        public async Task<IEnumerable<Schema.Config.GroupTheme>> GroupV2_GetAvailableThemes(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Config.GroupTheme>>(
=======
        public async Task<IEnumerable<Entities.Config.GroupTheme>> GroupV2_GetAvailableThemes(string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Config.GroupTheme>>(
>>>>>>> rewrite
                new Uri($"GroupV2/GetAvailableThemes/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}