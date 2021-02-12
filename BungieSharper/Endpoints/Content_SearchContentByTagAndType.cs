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
        /// Searches for Content Items that match the given Tag and Content Type.
        /// </summary>
        /// <param name="currentpage">Page number for the search results starting with page 1.</param>
        /// <param name="head">Not used.</param>
        /// <param name="itemsperpage">Not used.</param>
        public async Task<Entities.SearchResultOfContentItemPublicContract> Content_SearchContentByTagAndType(string locale, string tag, string type, int? currentpage = null, bool? head = null, int? itemsperpage = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.SearchResultOfContentItemPublicContract>(
                new Uri($"Content/SearchContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, itemsperpage != null ? $"itemsperpage={itemsperpage}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}