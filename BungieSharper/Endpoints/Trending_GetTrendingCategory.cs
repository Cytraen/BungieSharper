using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns paginated lists of trending items for a category.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.SearchResultOfTrendingEntry> Trending_GetTrendingCategory(string categoryId, int pageNumber, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfTrendingEntry>(
=======
        /// <param name="categoryId">The ID of the category for whom you want additional results.</param>
        /// <param name="pageNumber">The page # of results to return.</param>
        public async Task<Entities.SearchResultOfTrendingEntry> Trending_GetTrendingCategory(string categoryId, int pageNumber, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.SearchResultOfTrendingEntry>(
>>>>>>> rewrite
                new Uri($"Trending/Categories/{Uri.EscapeDataString(categoryId)}/{pageNumber}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}