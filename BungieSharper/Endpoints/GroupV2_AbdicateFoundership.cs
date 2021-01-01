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
        /// An administrative method to allow the founder of a group or clan to give up their position to another admin permanently.
        /// </summary>
        public async Task<bool> GroupV2_AbdicateFoundership(long founderIdNew, long groupId, Schema.BungieMembershipType membershipType, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/{groupId}/Admin/AbdicateFoundership/{membershipType}/{founderIdNew}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}