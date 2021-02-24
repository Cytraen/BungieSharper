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
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        /// <param name="includestreaming">Determines whether Streaming Alerts are included in results</param>
        public Task<IEnumerable<Entities.GlobalAlert>> _GetGlobalAlerts(bool? includestreaming = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.GlobalAlert>>(
                new Uri($"GlobalAlerts/" + HttpRequestGenerator.MakeQuerystring(includestreaming != null ? $"includestreaming={includestreaming}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}