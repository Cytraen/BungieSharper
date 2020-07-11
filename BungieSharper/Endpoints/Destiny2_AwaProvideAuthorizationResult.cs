using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Provide the result of the user interaction. Called by the Bungie Destiny App to approve or reject a request.
        /// </summary>
        public async Task<int> Destiny2_AwaProvideAuthorizationResult()
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Awa/AwaProvideAuthorizationResult/", null, null, HttpMethod.Post
                );
        }
    }
}