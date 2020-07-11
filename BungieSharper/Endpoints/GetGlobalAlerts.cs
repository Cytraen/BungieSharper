using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        public async Task<IEnumerable<Schema.GlobalAlert>> GetGlobalAlerts(bool includestreaming)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.GlobalAlert>>(
                $"GlobalAlerts/", null, null, HttpMethod.Get
                );
        }
    }
}