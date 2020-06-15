using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Responses.DestinyVendorResponse> Destiny2_GetVendor(long characterId, IEnumerable<Schema.Destiny.DestinyComponentType> components, long destinyMembershipId, Schema.BungieMembershipType membershipType, uint vendorHash)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyVendorResponse>(
                "Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/", null, null, HttpMethod.Get
                );
        }
    }
}