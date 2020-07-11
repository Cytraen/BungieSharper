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
        /// Gets historical stats for indicated character.
        /// </summary>
        public async Task<Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>> Destiny2_GetHistoricalStats(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType, DateTime? dayend = null, DateTime? daystart = null, IEnumerable<Schema.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType> groups = null, IEnumerable<Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType> modes = null, Schema.Destiny.HistoricalStats.Definitions.PeriodType? periodType = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<string, Schema.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>(
                $"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/", null, null, HttpMethod.Get,
                dayend != null ? $"dayend={dayend}" : null, daystart != null ? $"daystart={daystart}" : null, groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null, modes != null ? $"modes={string.Join(",", modes.Select(x => x.ToString()))}" : null, periodType != null ? $"periodType={periodType}" : null);
        }
    }
}