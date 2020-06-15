using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.Applications.Application>> App_GetBungieApplications()
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Applications.Application>>(
                "App/FirstParty/", null, null, HttpMethod.Get
                );
        }
    }
}