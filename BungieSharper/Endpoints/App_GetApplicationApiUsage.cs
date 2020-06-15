using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Applications.ApiUsage> App_GetApplicationApiUsage(int applicationId, DateTime end, DateTime start)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Applications.ApiUsage>(
                "App/ApiUsage/{applicationId}/", null, null, HttpMethod.Get
                );
        }
    }
}