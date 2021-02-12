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
        /// List of available localization cultures
        /// </summary>
<<<<<<< HEAD
        public async Task<Dictionary<string, string>> GetAvailableLocales(string authToken = null, CancellationToken cancelToken = default)
=======
        public async Task<Dictionary<string, string>> _GetAvailableLocales(string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, string>>(
                new Uri($"GetAvailableLocales/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}