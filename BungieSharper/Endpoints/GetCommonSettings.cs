using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Common.Models.CoreSettingsConfiguration> GetCommonSettings()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Common.Models.CoreSettingsConfiguration>(
                "Settings/", null, null, HttpMethod.Get
                );
        }
    }
}