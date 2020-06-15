using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Responses.DestinyLinkedProfilesResponse> Destiny2_GetLinkedProfiles(bool getAllMemberships, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyLinkedProfilesResponse>(
                "Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/", null, null, HttpMethod.Get
                );
        }
    }
}