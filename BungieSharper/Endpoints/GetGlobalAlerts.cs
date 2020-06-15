using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.GlobalAlert>> GetGlobalAlerts(bool includestreaming)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.GlobalAlert>>(
                $"GlobalAlerts/", null, null, HttpMethod.Get
                );
        }
    }
}