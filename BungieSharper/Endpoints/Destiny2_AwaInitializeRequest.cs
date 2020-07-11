using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Initialize a request to perform an advanced write action.
        /// </summary>
        public async Task<Schema.Destiny.Advanced.AwaInitializeResponse> Destiny2_AwaInitializeRequest()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Advanced.AwaInitializeResponse>(
                $"Destiny2/Awa/Initialize/", null, null, HttpMethod.Post
                );
        }
    }
}