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
        /// Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those descendants in the context of the requesting character.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyCollectibleNodeDetailResponse> Destiny2_GetCollectibleNodeDetails(long characterId, uint collectiblePresentationNodeHash, long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.DestinyComponentType> components = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyCollectibleNodeDetailResponse>(
                $"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/", null, null, HttpMethod.Get,
                components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null);
        }
    }
}