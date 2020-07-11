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
        /// An administrative method to allow the founder of a group or clan to give up their position to another admin permanently.
        /// </summary>
        public async Task<bool> GroupV2_AbdicateFoundership(long founderIdNew, long groupId, Schema.BungieMembershipType membershipType)
        {
            return await this._apiAccessor.ApiRequestAsync<bool>(
                $"GroupV2/{groupId}/Admin/AbdicateFoundership/{membershipType}/{founderIdNew}/", null, null, HttpMethod.Post
                );
        }
    }
}