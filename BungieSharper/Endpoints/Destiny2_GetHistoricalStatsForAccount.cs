using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets aggregate historical stats organized around each character for a given account.
        /// </summary>
        public async Task<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult> Destiny2_GetHistoricalStatsForAccount(long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType> groups = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/" + HttpRequestGenerator.MakeQuerystring(groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}