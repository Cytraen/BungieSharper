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
        /// Gets groups recommended for you based on the groups to whom those you follow belong.
        /// Requires OAuth2 scope(s): ReadGroups
        /// </summary>
        /// <param name="createDateRange">Requested range in which to pull recommended groups</param>
        /// <param name="groupType">Type of groups requested</param>
        public Task<IEnumerable<Entities.GroupsV2.GroupV2Card>> GroupV2_GetRecommendedGroups(Entities.GroupsV2.GroupDateRange createDateRange, Entities.GroupsV2.GroupType groupType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.GroupsV2.GroupV2Card>>(
                new Uri($"GroupV2/Recommended/{groupType}/{createDateRange}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}