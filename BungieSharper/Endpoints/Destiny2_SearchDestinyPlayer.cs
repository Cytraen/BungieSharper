using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a list of Destiny memberships given a full Gamertag or PSN ID. Unless you pass returnOriginalProfile=true, this will return membership information for the users' Primary Cross Save Profile if they are engaged in cross save rather than any original Destiny profile that is now being overridden.
        /// </summary>
        public async Task<IEnumerable<Schema.User.UserInfoCard>> Destiny2_SearchDestinyPlayer(string displayName, Schema.BungieMembershipType membershipType, bool returnOriginalProfile)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.User.UserInfoCard>>(
                $"Destiny2/SearchDestinyPlayer/{membershipType}/{displayName}/", null, null, HttpMethod.Get
                );
        }
    }
}