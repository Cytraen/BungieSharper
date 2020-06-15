using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<bool> Tokens_ApplyMissingPartnerOffersWithoutClaim(int partnerApplicationId, long targetBnetMembershipId)
        {
            return await this._apiAccessor.ApiRequestAsync<bool>(
                $"Tokens/Partner/ApplyMissingOffers/{partnerApplicationId}/{targetBnetMembershipId}/", null, null, HttpMethod.Post
                );
        }
    }
}