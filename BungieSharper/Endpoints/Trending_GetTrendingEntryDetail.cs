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
        /// Returns the detailed results for a specific trending entry. Note that trending entries are uniquely identified by a combination of *both* the TrendingEntryType *and* the identifier: the identifier alone is not guaranteed to be globally unique.
        /// </summary>
        /// <param name="identifier">The identifier for the entity to be returned.</param>
        /// <param name="trendingEntryType">The type of entity to be returned.</param>
        public Task<Entities.Trending.TrendingDetail> Trending_GetTrendingEntryDetail(string identifier, Entities.Trending.TrendingEntryType trendingEntryType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Trending.TrendingDetail>(
                new Uri($"Trending/Details/{trendingEntryType}/{Uri.EscapeDataString(identifier)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}