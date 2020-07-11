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
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Config.UserTheme>>(
                $"User/GetAvailableThemes/", null, null, HttpMethod.Get
                );
        }
    }
}