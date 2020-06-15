using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>> Destiny2_GetPublicMilestones()
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>>(
                $"Destiny2/Milestones/", null, null, HttpMethod.Get
                );
        }
    }
}