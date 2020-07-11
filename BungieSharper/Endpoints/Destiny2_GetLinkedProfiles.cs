using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information. The passed-in Membership Type/Membership ID may be a Bungie.Net membership or a Destiny membership. It only returns the minimal amount of data to begin making more substantive requests, but will hopefully serve as a useful alternative to UserServices for people who just care about Destiny data. Note that it will only return linked accounts whose linkages you are allowed to view.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyLinkedProfilesResponse> Destiny2_GetLinkedProfiles(bool getAllMemberships, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyLinkedProfilesResponse>(
                $"Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/", null, null, HttpMethod.Get
                );
        }
    }
}