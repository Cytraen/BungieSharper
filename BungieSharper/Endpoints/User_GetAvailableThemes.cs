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
        /// Returns a list of all available user themes.
        /// </summary>
<<<<<<< HEAD
        public async Task<IEnumerable<Schema.Config.UserTheme>> User_GetAvailableThemes(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Config.UserTheme>>(
=======
        public async Task<IEnumerable<Entities.Config.UserTheme>> User_GetAvailableThemes(string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Config.UserTheme>>(
>>>>>>> rewrite
                new Uri($"User/GetAvailableThemes/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}