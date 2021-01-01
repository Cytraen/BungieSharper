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
        /// Get list of applications created by Bungie.
        /// </summary>
        public async Task<IEnumerable<Schema.Applications.Application>> App_GetBungieApplications(string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Applications.Application>>(
                new Uri($"App/FirstParty/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}