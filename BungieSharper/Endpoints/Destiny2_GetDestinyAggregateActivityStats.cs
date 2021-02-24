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
        /// Gets all activities the character has participated in together with aggregate statistics for those activities.
        /// </summary>
        /// <param name="characterId">The specific character whose activities should be returned.</param>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        public Task<Entities.Destiny.HistoricalStats.DestinyAggregateActivityResults> Destiny2_GetDestinyAggregateActivityStats(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyAggregateActivityResults>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}