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
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
<<<<<<< HEAD
        public async Task<Dictionary<string, Schema.Common.Models.CoreSystem>> GetUserSystemOverrides(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, Schema.Common.Models.CoreSystem>>(
=======
        public async Task<Dictionary<string, Entities.Common.Models.CoreSystem>> _GetUserSystemOverrides(string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, Entities.Common.Models.CoreSystem>>(
>>>>>>> rewrite
                new Uri($"UserSystemOverrides/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}