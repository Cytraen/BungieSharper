using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.Config.UserTheme>> User_GetAvailableThemes()
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Config.UserTheme>>(
                "User/GetAvailableThemes/", null, null, HttpMethod.Get
                );
        }
    }
}