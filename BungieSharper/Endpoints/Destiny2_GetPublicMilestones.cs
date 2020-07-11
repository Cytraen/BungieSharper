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
        /// Gets public information about currently available Milestones.
        /// </summary>
        public async Task<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>> Destiny2_GetPublicMilestones()
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>>(
                $"Destiny2/Milestones/", null, null, HttpMethod.Get
                );
        }
    }
}