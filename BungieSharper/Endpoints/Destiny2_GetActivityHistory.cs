using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets activity history stats for indicated character.
        /// </summary>
        public async Task<Schema.Destiny.HistoricalStats.DestinyActivityHistoryResults> Destiny2_GetActivityHistory(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType, int? count = null, Schema.Destiny.HistoricalStats.Definitions.DestinyActivityModeType? mode = null, int? page = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyActivityHistoryResults>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/" + HttpRequestGenerator.MakeQuerystring(count != null ? $"count={count}" : null, mode != null ? $"mode={mode}" : null, page != null ? $"page={page}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}