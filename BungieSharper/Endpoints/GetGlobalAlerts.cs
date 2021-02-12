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
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
<<<<<<< HEAD
        public async Task<IEnumerable<Schema.GlobalAlert>> GetGlobalAlerts(bool? includestreaming = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.GlobalAlert>>(
=======
        /// <param name="includestreaming">Determines whether Streaming Alerts are included in results</param>
        public async Task<IEnumerable<Entities.GlobalAlert>> _GetGlobalAlerts(bool? includestreaming = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.GlobalAlert>>(
>>>>>>> rewrite
                new Uri($"GlobalAlerts/" + HttpRequestGenerator.MakeQuerystring(includestreaming != null ? $"includestreaming={includestreaming}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}