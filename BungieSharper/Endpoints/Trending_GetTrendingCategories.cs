using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Trending.TrendingCategories> Trending_GetTrendingCategories()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Trending.TrendingCategories>(
                "Trending/Categories/", null, null, HttpMethod.Get
                );
        }
    }
}