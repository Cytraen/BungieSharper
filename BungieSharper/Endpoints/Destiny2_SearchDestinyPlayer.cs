using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.User.UserInfoCard>> Destiny2_SearchDestinyPlayer(string displayName, Schema.BungieMembershipType membershipType, bool returnOriginalProfile)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.User.UserInfoCard>>(
                $"Destiny2/SearchDestinyPlayer/{membershipType}/{displayName}/", null, null, HttpMethod.Get
                );
        }
    }
}