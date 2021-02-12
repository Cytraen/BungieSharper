using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
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
        /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Destiny.Milestones.DestinyMilestone> Destiny2_GetClanWeeklyRewardState(long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Milestones.DestinyMilestone>(
=======
        /// <param name="groupId">A valid group id of clan.</param>
        public async Task<Entities.Destiny.Milestones.DestinyMilestone> Destiny2_GetClanWeeklyRewardState(long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Milestones.DestinyMilestone>(
>>>>>>> rewrite
                new Uri($"Destiny2/Clan/{groupId}/WeeklyRewardState/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}