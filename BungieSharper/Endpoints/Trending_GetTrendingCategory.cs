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
        /// Returns paginated lists of trending items for a category.
        /// </summary>
        /// <param name="categoryId">The ID of the category for whom you want additional results.</param>
        /// <param name="pageNumber">The page # of results to return.</param>
        public Task<Entities.SearchResultOfTrendingEntry> Trending_GetTrendingCategory(string categoryId, int pageNumber, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfTrendingEntry>(
                new Uri($"Trending/Categories/{Uri.EscapeDataString(categoryId)}/{pageNumber}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}