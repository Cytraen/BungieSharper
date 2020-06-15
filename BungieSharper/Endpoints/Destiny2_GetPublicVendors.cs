using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Responses.DestinyPublicVendorsResponse> Destiny2_GetPublicVendors(IEnumerable<Schema.Destiny.DestinyComponentType> components)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyPublicVendorsResponse>(
                "Destiny2//Vendors/", null, null, HttpMethod.Get
                );
        }
    }
}