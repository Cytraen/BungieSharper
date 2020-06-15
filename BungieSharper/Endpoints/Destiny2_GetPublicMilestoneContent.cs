using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Milestones.DestinyMilestoneContent> Destiny2_GetPublicMilestoneContent(uint milestoneHash)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Milestones.DestinyMilestoneContent>(
                $"Destiny2/Milestones/{milestoneHash}/Content/", null, null, HttpMethod.Get
                );
        }
    }
}