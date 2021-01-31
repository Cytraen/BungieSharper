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
        /// Gets all activities the character has participated in together with aggregate statistics for those activities.
        /// </summary>
        public async Task<Schema.Destiny.HistoricalStats.DestinyAggregateActivityResults> Destiny2_GetDestinyAggregateActivityStats(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyAggregateActivityResults>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}