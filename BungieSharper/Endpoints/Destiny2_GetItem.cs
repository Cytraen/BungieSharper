using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Responses.DestinyItemResponse> Destiny2_GetItem(IEnumerable<Schema.Destiny.DestinyComponentType> components, long destinyMembershipId, long itemInstanceId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyItemResponse>(
                $"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Item/{itemInstanceId}/", null, null, HttpMethod.Get
                );
        }
    }
}