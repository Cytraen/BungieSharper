using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.SearchResultOfTrendingEntry> Trending_GetTrendingCategory(string categoryId, int pageNumber)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfTrendingEntry>(
                $"Trending/Categories/{categoryId}/{pageNumber}/", null, null, HttpMethod.Get
                );
        }
    }
}