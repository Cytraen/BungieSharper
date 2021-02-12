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
        /// Gets activity history stats for indicated character.
        /// </summary>
        /// <param name="characterId">The id of the character to retrieve.</param>
        /// <param name="count">Number of rows to return</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="mode">A filter for the activity mode to be returned. None returns all activities. See the documentation for DestinyActivityModeType for valid values, and pass in string representation.</param>
        /// <param name="page">Page number to return, starting with 0.</param>
        public async Task<Entities.Destiny.HistoricalStats.DestinyActivityHistoryResults> Destiny2_GetActivityHistory(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, int? count = null, Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType? mode = null, int? page = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyActivityHistoryResults>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/" + HttpRequestGenerator.MakeQuerystring(count != null ? $"count={count}" : null, mode != null ? $"mode={mode}" : null, page != null ? $"page={page}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}