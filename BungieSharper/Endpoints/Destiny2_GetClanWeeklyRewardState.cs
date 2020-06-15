using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Milestones.DestinyMilestone> Destiny2_GetClanWeeklyRewardState(long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Milestones.DestinyMilestone>(
                $"Destiny2/Clan/{groupId}/WeeklyRewardState/", null, null, HttpMethod.Get
                );
        }
    }
}