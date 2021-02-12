using BungieSharper.Client;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
>>>>>>> rewrite
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Report a player that you met in an activity that was engaging in ToS-violating activities. Both you and the offending player must have played in the activityId passed in. Please use this judiciously and only when you have strong suspicions of violation, pretty please.
<<<<<<< HEAD
        /// </summary>
        public async Task<int> Destiny2_ReportOffensivePostGameCarnageReportPlayer(long activityId, Schema.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): BnetWrite
        /// </summary>
        /// <param name="activityId">The ID of the activity where you ran into the brigand that you're reporting.</param>
        public async Task<int> Destiny2_ReportOffensivePostGameCarnageReportPlayer(long activityId, Entities.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"Destiny2/Stats/PostGameCarnageReport/{activityId}/Report/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}