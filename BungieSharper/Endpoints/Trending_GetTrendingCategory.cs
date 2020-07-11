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
        /// Returns paginated lists of trending items for a category.
        /// </summary>
        public async Task<Schema.SearchResultOfTrendingEntry> Trending_GetTrendingCategory(string categoryId, int pageNumber)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfTrendingEntry>(
                $"Trending/Categories/{Uri.EscapeDataString(categoryId)}/{pageNumber}/", null, null, HttpMethod.Get
                );
        }
    }
}