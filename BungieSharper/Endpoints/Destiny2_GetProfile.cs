using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns Destiny Profile information for the supplied membership.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyProfileResponse> Destiny2_GetProfile(long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.DestinyComponentType> components = null, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyProfileResponse>(
                new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}