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
        /// Returns the detailed results for a specific trending entry. Note that trending entries are uniquely identified by a combination of *both* the TrendingEntryType *and* the identifier: the identifier alone is not guaranteed to be globally unique.
        /// </summary>
        public async Task<Schema.Trending.TrendingDetail> Trending_GetTrendingEntryDetail(string identifier, Schema.Trending.TrendingEntryType trendingEntryType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Trending.TrendingDetail>(
                $"Trending/Details/{trendingEntryType}/{Uri.EscapeDataString(identifier)}/", null, null, HttpMethod.Get
                );
        }
    }
}