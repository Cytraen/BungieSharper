using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Responses.DestinyCollectibleNodeDetailResponse> Destiny2_GetCollectibleNodeDetails(long characterId, uint collectiblePresentationNodeHash, IEnumerable<Schema.Destiny.DestinyComponentType> components, long destinyMembershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyCollectibleNodeDetailResponse>(
                $"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/", null, null, HttpMethod.Get
                );
        }
    }
}