using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Dictionary<string, string>> GetAvailableLocales()
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<string, string>>(
                "GetAvailableLocales/", null, null, HttpMethod.Get
                );
        }
    }
}