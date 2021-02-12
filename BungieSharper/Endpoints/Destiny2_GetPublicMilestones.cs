using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets public information about currently available Milestones.
        /// </summary>
<<<<<<< HEAD
        public async Task<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>> Destiny2_GetPublicMilestones(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>>(
=======
        public async Task<Dictionary<uint, Entities.Destiny.Milestones.DestinyPublicMilestone>> Destiny2_GetPublicMilestones(string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<uint, Entities.Destiny.Milestones.DestinyPublicMilestone>>(
>>>>>>> rewrite
                new Uri($"Destiny2/Milestones/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}