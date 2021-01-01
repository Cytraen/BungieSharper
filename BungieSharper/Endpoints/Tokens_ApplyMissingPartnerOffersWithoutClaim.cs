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
        /// Apply a partner offer to the targeted user. This endpoint does not claim a new offer, but any already claimed offers will be applied to the game if not already.
        /// </summary>
        public async Task<bool> Tokens_ApplyMissingPartnerOffersWithoutClaim(int partnerApplicationId, long targetBnetMembershipId, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Tokens/Partner/ApplyMissingOffers/{partnerApplicationId}/{targetBnetMembershipId}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}