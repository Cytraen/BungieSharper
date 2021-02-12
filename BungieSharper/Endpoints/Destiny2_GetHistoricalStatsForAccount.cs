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
        /// Gets aggregate historical stats organized around each character for a given account.
        /// </summary>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="groups">Groups of stats to include, otherwise only general stats are returned. Comma separated list is allowed. Values: General, Weapons, Medals.</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        public async Task<Entities.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult> Destiny2_GetHistoricalStatsForAccount(long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>? groups = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/" + HttpRequestGenerator.MakeQuerystring(groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}