using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Responses.DestinyVendorsResponse> Destiny2_GetVendors(long characterId, IEnumerable<Schema.Destiny.DestinyComponentType> components, long destinyMembershipId, Schema.Destiny.DestinyVendorFilter filter, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyVendorsResponse>(
                "Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/", null, null, HttpMethod.Get
                );
        }
    }
}