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
        /// Get the details of a specific Vendor.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyVendorResponse> Destiny2_GetVendor(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType, uint vendorHash, IEnumerable<Schema.Destiny.DestinyComponentType> components = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyVendorResponse>(
                new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}