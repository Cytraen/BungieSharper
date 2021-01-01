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
        public async Task<Dictionary<string, string>> GetAvailableLocales(string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<string, string>>(
                new Uri($"GetAvailableLocales/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}