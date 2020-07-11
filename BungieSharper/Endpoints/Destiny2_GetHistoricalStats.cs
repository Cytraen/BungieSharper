using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets historical stats for indicated character.
        /// </summary>
        public async Task<Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>> Destiny2_GetHistoricalStats(long characterId, DateTime dayend, DateTime daystart, long destinyMembershipId, IEnumerable<Schema.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType> groups, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType> modes, Schema.Destiny.HistoricalStats.Definitions.PeriodType periodType)
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>(
                $"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/", null, null, HttpMethod.Get
                );
        }
    }
}