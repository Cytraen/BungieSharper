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
        /// Gets groups recommended for you based on the groups to whom those you follow belong.
        /// </summary>
        public async Task<IEnumerable<Schema.GroupsV2.GroupV2Card>> GroupV2_GetRecommendedGroups(Schema.GroupsV2.GroupDateRange createDateRange, Schema.GroupsV2.GroupType groupType)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.GroupsV2.GroupV2Card>>(
                $"GroupV2/Recommended/{groupType}/{createDateRange}/", null, null, HttpMethod.Post
                );
        }
    }
}