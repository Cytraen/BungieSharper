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
        /// Returns the current version of the manifest as a json object.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Destiny.Config.DestinyManifest> Destiny2_GetDestinyManifest(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Config.DestinyManifest>(
=======
        public async Task<Entities.Destiny.Config.DestinyManifest> Destiny2_GetDestinyManifest(string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Config.DestinyManifest>(
>>>>>>> rewrite
                new Uri($"Destiny2/Manifest/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}