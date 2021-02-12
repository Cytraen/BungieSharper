using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
<<<<<<< HEAD
=======
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
<<<<<<< HEAD
        /// This is a preview method.
        /// Get items available from vendors where the vendors have items for sale that are common for everyone. If any portion of the Vendor's available inventory is character or account specific, we will be unable to return their data from this endpoint due to the way that available inventory is computed. As I am often guilty of saying: 'It's a long story...'
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyPublicVendorsResponse> Destiny2_GetPublicVendors(IEnumerable<Schema.Destiny.DestinyComponentType> components = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyPublicVendorsResponse>(
=======
        /// Get items available from vendors where the vendors have items for sale that are common for everyone. If any portion of the Vendor's available inventory is character or account specific, we will be unable to return their data from this endpoint due to the way that available inventory is computed. As I am often guilty of saying: 'It's a long story...'
        /// </summary>
        /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        public async Task<Entities.Destiny.Responses.DestinyPublicVendorsResponse> Destiny2_GetPublicVendors(IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyPublicVendorsResponse>(
>>>>>>> rewrite
                new Uri($"Destiny2/Vendors/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}