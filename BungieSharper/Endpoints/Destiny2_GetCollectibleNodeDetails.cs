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
        /// Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those descendants in the context of the requesting character.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Destiny.Responses.DestinyCollectibleNodeDetailResponse> Destiny2_GetCollectibleNodeDetails(long characterId, uint collectiblePresentationNodeHash, long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.DestinyComponentType> components = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyCollectibleNodeDetailResponse>(
=======
        /// <param name="characterId">The Destiny Character ID of the character for whom we're getting collectible detail info.</param>
        /// <param name="collectiblePresentationNodeHash">The hash identifier of the Presentation Node for whom we should return collectible details. Details will only be returned for collectibles that are direct descendants of this node.</param>
        /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        public async Task<Entities.Destiny.Responses.DestinyCollectibleNodeDetailResponse> Destiny2_GetCollectibleNodeDetails(long characterId, uint collectiblePresentationNodeHash, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyCollectibleNodeDetailResponse>(
>>>>>>> rewrite
                new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}