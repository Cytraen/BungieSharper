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
        /// Gets details about unique weapon usage, including all exotic weapons.
        /// </summary>
        public async Task<Schema.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData> Destiny2_GetUniqueWeaponHistory(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/UniqueWeapons/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}