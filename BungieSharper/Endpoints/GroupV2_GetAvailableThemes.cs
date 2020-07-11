using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a list of all available group themes.
        /// </summary>
        public async Task<IEnumerable<Schema.Config.GroupTheme>> GroupV2_GetAvailableThemes()
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Config.GroupTheme>>(
                $"GroupV2/GetAvailableThemes/", null, null, HttpMethod.Get
                );
        }
    }
}