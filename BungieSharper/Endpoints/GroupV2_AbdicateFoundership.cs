using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// An administrative method to allow the founder of a group or clan to give up their position to another admin permanently.
        /// </summary>
        /// <param name="founderIdNew">The new founder for this group. Must already be a group admin.</param>
        /// <param name="groupId">The target group id.</param>
        /// <param name="membershipType">Membership type of the provided founderIdNew.</param>
        public async Task<bool> GroupV2_AbdicateFoundership(long founderIdNew, long groupId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/{groupId}/Admin/AbdicateFoundership/{membershipType}/{founderIdNew}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}