using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get the details of a specific Vendor.
        /// </summary>
        /// <param name="characterId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
        /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="vendorHash">The Hash identifier of the Vendor to be returned.</param>
        public Task<Entities.Destiny.Responses.DestinyVendorResponse> Destiny2_GetVendor(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, uint vendorHash, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyVendorResponse>(
                new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}