using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        public async Task<IEnumerable<Schema.GlobalAlert>> GetGlobalAlerts(bool? includestreaming = null, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.GlobalAlert>>(
                new Uri($"GlobalAlerts/" + HttpRequestGenerator.MakeQuerystring(includestreaming != null ? $"includestreaming={includestreaming}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}