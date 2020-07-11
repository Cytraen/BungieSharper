using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// This is a preview method.
        /// Get items available from vendors where the vendors have items for sale that are common for everyone. If any portion of the Vendor's available inventory is character or account specific, we will be unable to return their data from this endpoint due to the way that available inventory is computed. As I am often guilty of saying: 'It's a long story...'
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyPublicVendorsResponse> Destiny2_GetPublicVendors(IEnumerable<Schema.Destiny.DestinyComponentType> components)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyPublicVendorsResponse>(
                $"Destiny2//Vendors/", null, null, HttpMethod.Get
                );
        }
    }
}