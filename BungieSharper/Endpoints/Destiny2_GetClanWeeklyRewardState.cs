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
        /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
        /// </summary>
        /// <param name="groupId">A valid group id of clan.</param>
        public Task<Entities.Destiny.Milestones.DestinyMilestone> Destiny2_GetClanWeeklyRewardState(long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Destiny.Milestones.DestinyMilestone>(
                new Uri($"Destiny2/Clan/{groupId}/WeeklyRewardState/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}