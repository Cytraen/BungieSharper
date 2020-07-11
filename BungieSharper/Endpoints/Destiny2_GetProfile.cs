using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns Destiny Profile information for the supplied membership.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyProfileResponse> Destiny2_GetProfile(long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.DestinyComponentType> components = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyProfileResponse>(
                $"Destiny2/{membershipType}/Profile/{destinyMembershipId}/", null, null, HttpMethod.Get,
                components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null);
        }
    }
}