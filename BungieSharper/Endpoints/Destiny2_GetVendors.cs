using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic inventories. Use their definitions as-is for those.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyVendorsResponse> Destiny2_GetVendors(long characterId, IEnumerable<Schema.Destiny.DestinyComponentType> components, long destinyMembershipId, Schema.Destiny.DestinyVendorFilter filter, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyVendorsResponse>(
                $"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/", null, null, HttpMethod.Get
                );
        }
    }
}