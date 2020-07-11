using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns character information for the supplied character.
        /// </summary>
        public async Task<Schema.Destiny.Responses.DestinyCharacterResponse> Destiny2_GetCharacter(long characterId, IEnumerable<Schema.Destiny.DestinyComponentType> components, long destinyMembershipId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyCharacterResponse>(
                $"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/", null, null, HttpMethod.Get
                );
        }
    }
}