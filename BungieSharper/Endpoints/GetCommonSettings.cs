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
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Common.Models.CoreSettingsConfiguration> GetCommonSettings(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Common.Models.CoreSettingsConfiguration>(
=======
        public async Task<Entities.Common.Models.CoreSettingsConfiguration> _GetCommonSettings(string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Common.Models.CoreSettingsConfiguration>(
>>>>>>> rewrite
                new Uri($"Settings/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}