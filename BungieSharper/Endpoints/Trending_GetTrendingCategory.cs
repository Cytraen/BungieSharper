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
        /// Returns paginated lists of trending items for a category.
        /// </summary>
        public async Task<Schema.SearchResultOfTrendingEntry> Trending_GetTrendingCategory(string categoryId, int pageNumber, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfTrendingEntry>(
                new Uri($"Trending/Categories/{Uri.EscapeDataString(categoryId)}/{pageNumber}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}