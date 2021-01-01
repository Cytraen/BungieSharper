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
        /// Gets custom localized content for the milestone of the given hash, if it exists.
        /// </summary>
        public async Task<Schema.Destiny.Milestones.DestinyMilestoneContent> Destiny2_GetPublicMilestoneContent(uint milestoneHash, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Milestones.DestinyMilestoneContent>(
                new Uri($"Destiny2/Milestones/{milestoneHash}/Content/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}