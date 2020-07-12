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
        /// Returns a list of all available user themes.
        /// </summary>
        public async Task<IEnumerable<Schema.Config.UserTheme>> User_GetAvailableThemes()
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Config.UserTheme>>(
                new Uri($"User/GetAvailableThemes/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}