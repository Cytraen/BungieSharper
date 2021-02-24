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
        /// Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint has not yet been implemented. It is being returned for a preview of future functionality, and for public comment/suggestion/preparation.
        /// </summary>
        /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
        /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
        /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
        public Task<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>> Destiny2_GetLeaderboards(long destinyMembershipId, Entities.BungieMembershipType membershipType, int? maxtop = null, string? modes = null, string? statid = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>>(
                new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/Leaderboards/" + HttpRequestGenerator.MakeQuerystring(maxtop != null ? $"maxtop={maxtop}" : null, modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null, statid != null ? $"statid={Uri.EscapeDataString(statid)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}