using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
        /// </summary>
        public async Task<Schema.Destiny.Milestones.DestinyMilestone> Destiny2_GetClanWeeklyRewardState(long groupId)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Milestones.DestinyMilestone>(
                new Uri($"Destiny2/Clan/{groupId}/WeeklyRewardState/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}