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
        /// Returns character information for the supplied character.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyCharacterResponse> Destiny2_GetCharacter(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.DestinyComponentType> components = null, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyCharacterResponse>(
                new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}