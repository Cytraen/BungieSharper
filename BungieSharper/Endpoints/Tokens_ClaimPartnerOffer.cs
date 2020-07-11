using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Claim a partner offer as the authenticated user.
        /// </summary>
        public async Task<bool> Tokens_ClaimPartnerOffer()
        {
            return await this._apiAccessor.ApiRequestAsync<bool>(
                $"Tokens/Partner/ClaimOffer/", null, null, HttpMethod.Post
                );
        }
    }
}