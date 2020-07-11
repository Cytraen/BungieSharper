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
        /// Gets aggregate historical stats organized around each character for a given account.
        /// </summary>
        public async Task<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult> Destiny2_GetHistoricalStatsForAccount(long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType> groups = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>(
                $"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/", null, null, HttpMethod.Get,
                groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null);
        }
    }
}