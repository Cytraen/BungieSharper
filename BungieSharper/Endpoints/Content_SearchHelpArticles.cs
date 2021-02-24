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
        /// Search for Help Articles.
        /// </summary>
        public Task<dynamic> Content_SearchHelpArticles(string searchtext, string size, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<dynamic>(
                new Uri($"Content/SearchHelpArticles/{Uri.EscapeDataString(searchtext)}/{Uri.EscapeDataString(size)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}