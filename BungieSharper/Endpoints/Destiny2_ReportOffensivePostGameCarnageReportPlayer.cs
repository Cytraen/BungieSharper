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
        /// Report a player that you met in an activity that was engaging in ToS-violating activities. Both you and the offending player must have played in the activityId passed in. Please use this judiciously and only when you have strong suspicions of violation, pretty please.
        /// </summary>
        public async Task<int> Destiny2_ReportOffensivePostGameCarnageReportPlayer(long activityId, Schema.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Stats/PostGameCarnageReport/{activityId}/Report/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}