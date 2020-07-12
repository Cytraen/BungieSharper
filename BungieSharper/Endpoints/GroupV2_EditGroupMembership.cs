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
        /// Edit the membership type of a given member. You must have suitable permissions in the group to perform this operation.
        /// </summary>
        public async Task<int> GroupV2_EditGroupMembership(long groupId, long membershipId, Schema.BungieMembershipType membershipType, Schema.GroupsV2.RuntimeGroupMemberType memberType)
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/SetMembershipType/{memberType}/", UriKind.Relative),
                null, null, HttpMethod.Post
                ).ConfigureAwait(false);
        }
    }
}