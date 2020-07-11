using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Milestones.DestinyMilestone>(
                $"Destiny2/Clan/{groupId}/WeeklyRewardState/", null, null, HttpMethod.Get
                );
        }
    }
}