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
        /// Search for Help Articles.
        /// </summary>
        public async Task<dynamic> Content_SearchHelpArticles(string searchtext, string size)
        {
            return await _apiAccessor.ApiRequestAsync<dynamic>(
                new Uri($"Content/SearchHelpArticles/{Uri.EscapeDataString(searchtext)}/{Uri.EscapeDataString(size)}/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}