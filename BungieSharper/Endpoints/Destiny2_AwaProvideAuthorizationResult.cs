using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<int> Destiny2_AwaProvideAuthorizationResult()
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Awa/AwaProvideAuthorizationResult/", null, null, HttpMethod.Post
                );
        }
    }
}