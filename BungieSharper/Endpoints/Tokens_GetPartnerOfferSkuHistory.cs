using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.Tokens.PartnerOfferSkuHistoryResponse>> Tokens_GetPartnerOfferSkuHistory(int partnerApplicationId, long targetBnetMembershipId)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Tokens.PartnerOfferSkuHistoryResponse>>(
                $"Tokens/Partner/History/{partnerApplicationId}/{targetBnetMembershipId}/", null, null, HttpMethod.Get
                );
        }
    }
}