using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns the partner sku and offer history of the targeted user. Elevated permissions are required to see users that are not yourself.
<<<<<<< HEAD
        /// </summary>
        public async Task<IEnumerable<Schema.Tokens.PartnerOfferSkuHistoryResponse>> Tokens_GetPartnerOfferSkuHistory(int partnerApplicationId, long targetBnetMembershipId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Tokens.PartnerOfferSkuHistoryResponse>>(
=======
        /// Requires OAuth2 scope(s): PartnerOfferGrant
        /// </summary>
        /// <param name="partnerApplicationId">The partner application identifier.</param>
        /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
        public async Task<IEnumerable<Entities.Tokens.PartnerOfferSkuHistoryResponse>> Tokens_GetPartnerOfferSkuHistory(int partnerApplicationId, long targetBnetMembershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Tokens.PartnerOfferSkuHistoryResponse>>(
>>>>>>> rewrite
                new Uri($"Tokens/Partner/History/{partnerApplicationId}/{targetBnetMembershipId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}