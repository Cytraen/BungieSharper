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
        /// Returns trending items for Bungie.net, collapsed into the first page of items per category. For pagination within a category, call GetTrendingCategory.
        /// </summary>
        public async Task<Schema.Trending.TrendingCategories> Trending_GetTrendingCategories()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Trending.TrendingCategories>(
                $"Trending/Categories/", null, null, HttpMethod.Get
                );
        }
    }
}