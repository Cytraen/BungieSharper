using BungieSharper.Client;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
>>>>>>> rewrite
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Claim a partner offer as the authenticated user.
<<<<<<< HEAD
        /// </summary>
        public async Task<bool> Tokens_ClaimPartnerOffer(Schema.Tokens.PartnerOfferClaimRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): PartnerOfferGrant
        /// </summary>
        public async Task<bool> Tokens_ClaimPartnerOffer(Entities.Tokens.PartnerOfferClaimRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Tokens/Partner/ClaimOffer/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}