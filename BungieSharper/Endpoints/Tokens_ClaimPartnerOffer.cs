using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Claim a partner offer as the authenticated user.
        /// </summary>
        public async Task<bool> Tokens_ClaimPartnerOffer(Schema.Tokens.PartnerOfferClaimRequest requestBody)
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Tokens/Partner/ClaimOffer/", UriKind.Relative),
                null, new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post
                ).ConfigureAwait(false);
        }
    }
}