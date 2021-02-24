using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets historical stats for indicated character.
        /// </summary>
        /// <param name="characterId">The id of the character to retrieve. You can omit this character ID or set it to 0 to get aggregate stats across all characters.</param>
        /// <param name="dayend">Last day to return when daily stats are requested. Use the format YYYY-MM-DD. Currently, we cannot allow more than 31 days of daily data to be requested in a single request.</param>
        /// <param name="daystart">First day to return when daily stats are requested. Use the format YYYY-MM-DD. Currently, we cannot allow more than 31 days of daily data to be requested in a single request.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="groups">Group of stats to include, otherwise only general stats are returned. Comma separated list is allowed. Values: General, Weapons, Medals</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="modes">Game modes to return. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
        /// <param name="periodType">Indicates a specific period type to return. Optional. May be: Daily, AllTime, or Activity</param>
        public Task<Dictionary<string, Entities.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>> Destiny2_GetHistoricalStats(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, DateTime? dayend = null, DateTime? daystart = null, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>? groups = null, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType>? modes = null, Entities.Destiny.HistoricalStats.Definitions.PeriodType? periodType = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Dictionary<string, Entities.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/" + HttpRequestGenerator.MakeQuerystring(dayend != null ? $"dayend={dayend}" : null, daystart != null ? $"daystart={daystart}" : null, groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null, modes != null ? $"modes={string.Join(",", modes.Select(x => x.ToString()))}" : null, periodType != null ? $"periodType={periodType}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}