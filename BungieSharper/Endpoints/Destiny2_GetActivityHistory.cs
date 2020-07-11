using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets activity history stats for indicated character.
        /// </summary>
        public async Task<Schema.Destiny.HistoricalStats.DestinyActivityHistoryResults> Destiny2_GetActivityHistory(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType, int? count = null, Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType? mode = null, int? page = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyActivityHistoryResults>(
                $"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/", null, null, HttpMethod.Get,
                count != null ? $"count={count}" : null, mode != null ? $"mode={mode}" : null, page != null ? $"page={page}" : null);
        }
    }
}