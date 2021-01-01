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
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
        public async Task<Dictionary<string, Schema.Common.Models.CoreSystem>> GetUserSystemOverrides(string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, Schema.Common.Models.CoreSystem>>(
                new Uri($"UserSystemOverrides/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}