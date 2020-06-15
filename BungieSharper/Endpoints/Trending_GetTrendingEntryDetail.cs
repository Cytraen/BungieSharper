using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Trending.TrendingDetail> Trending_GetTrendingEntryDetail(string identifier, Schema.Trending.TrendingEntryType trendingEntryType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Trending.TrendingDetail>(
                $"Trending/Details/{trendingEntryType}/{identifier}/", null, null, HttpMethod.Get
                );
        }
    }
}