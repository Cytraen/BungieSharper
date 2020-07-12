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
        /// List of available localization cultures
        /// </summary>
        public async Task<Dictionary<string, string>> GetAvailableLocales()
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, string>>(
                new Uri($"GetAvailableLocales/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}