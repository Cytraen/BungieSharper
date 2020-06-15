using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.Config.GroupTheme>> GroupV2_GetAvailableThemes()
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Config.GroupTheme>>(
                "GroupV2/GetAvailableThemes/", null, null, HttpMethod.Get
                );
        }
    }
}