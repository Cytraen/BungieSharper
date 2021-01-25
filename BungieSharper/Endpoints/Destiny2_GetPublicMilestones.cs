﻿using BungieSharper.Client;
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
        /// Gets public information about currently available Milestones.
        /// </summary>
        public async Task<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>> Destiny2_GetPublicMilestones(string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<uint, Schema.Destiny.Milestones.DestinyPublicMilestone>>(
                new Uri($"Destiny2/Milestones/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}