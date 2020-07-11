using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns the action token if user approves the request.
        /// </summary>
        public async Task<Schema.Destiny.Advanced.AwaAuthorizationResult> Destiny2_AwaGetActionToken(string correlationId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Advanced.AwaAuthorizationResult>(
                $"Destiny2/Awa/GetActionToken/{correlationId}/", null, null, HttpMethod.Get
                );
        }
    }
}