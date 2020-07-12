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
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
        public async Task<Schema.Common.Models.CoreSettingsConfiguration> GetCommonSettings()
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Common.Models.CoreSettingsConfiguration>(
                new Uri($"Settings/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}