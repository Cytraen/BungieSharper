using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Apply a partner offer to the targeted user. This endpoint does not claim a new offer, but any already claimed offers will be applied to the game if not already.
        /// Requires OAuth2 scope(s): PartnerOfferGrant
        /// </summary>
        /// <param name="partnerApplicationId">The partner application identifier.</param>
        /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
        public async Task<bool> Tokens_ApplyMissingPartnerOffersWithoutClaim(int partnerApplicationId, long targetBnetMembershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Tokens/Partner/ApplyMissingOffers/{partnerApplicationId}/{targetBnetMembershipId}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}