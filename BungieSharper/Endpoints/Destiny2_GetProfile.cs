using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Responses.DestinyProfileResponse> Destiny2_GetProfile(IEnumerable<Schema.Destiny.DestinyComponentType> components, long destinyMembershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyProfileResponse>(
                $"Destiny2/{membershipType}/Profile/{destinyMembershipId}/", null, null, HttpMethod.Get
                );
        }
    }
}