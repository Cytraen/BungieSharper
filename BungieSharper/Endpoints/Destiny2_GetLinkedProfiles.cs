using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information. The passed-in Membership Type/Membership ID may be a Bungie.Net membership or a Destiny membership. It only returns the minimal amount of data to begin making more substantive requests, but will hopefully serve as a useful alternative to UserServices for people who just care about Destiny data. Note that it will only return linked accounts whose linkages you are allowed to view.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Destiny.Responses.DestinyLinkedProfilesResponse> Destiny2_GetLinkedProfiles(long membershipId, Schema.BungieMembershipType membershipType, bool? getAllMemberships = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyLinkedProfilesResponse>(
=======
        /// <param name="getAllMemberships">(optional) if set to 'true', all memberships regardless of whether they're obscured by overrides will be returned. Normal privacy restrictions on account linking will still apply no matter what.</param>
        /// <param name="membershipId">The ID of the membership whose linked Destiny accounts you want returned. Make sure your membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not going to work!</param>
        /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
        public async Task<Entities.Destiny.Responses.DestinyLinkedProfilesResponse> Destiny2_GetLinkedProfiles(long membershipId, Entities.BungieMembershipType membershipType, bool? getAllMemberships = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyLinkedProfilesResponse>(
>>>>>>> rewrite
                new Uri($"Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/" + HttpRequestGenerator.MakeQuerystring(getAllMemberships != null ? $"getAllMemberships={getAllMemberships}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}