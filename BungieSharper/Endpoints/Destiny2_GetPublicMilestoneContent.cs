using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets custom localized content for the milestone of the given hash, if it exists.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Destiny.Milestones.DestinyMilestoneContent> Destiny2_GetPublicMilestoneContent(uint milestoneHash, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Milestones.DestinyMilestoneContent>(
=======
        /// <param name="milestoneHash">The identifier for the milestone to be returned.</param>
        public async Task<Entities.Destiny.Milestones.DestinyMilestoneContent> Destiny2_GetPublicMilestoneContent(uint milestoneHash, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Milestones.DestinyMilestoneContent>(
>>>>>>> rewrite
                new Uri($"Destiny2/Milestones/{milestoneHash}/Content/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}