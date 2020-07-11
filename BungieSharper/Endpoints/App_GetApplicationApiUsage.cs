using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get API usage by application for time frame specified. You can go as far back as 30 days ago, and can ask for up to a 48 hour window of time in a single request. You must be authenticated with at least the ReadUserData permission to access this endpoint.
        /// </summary>
        public async Task<Schema.Applications.ApiUsage> App_GetApplicationApiUsage(int applicationId, DateTime end, DateTime start)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Applications.ApiUsage>(
                $"App/ApiUsage/{applicationId}/", null, null, HttpMethod.Get
                );
        }
    }
}