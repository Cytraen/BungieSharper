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
        /// Gets content based on querystring information passed in. Provides basic search and text search capabilities.
        /// </summary>
        /// <param name="ctype">Content type tag: Help, News, etc. Supply multiple ctypes separated by space.</param>
        /// <param name="currentpage">Page number for the search results, starting with page 1.</param>
        /// <param name="head">Not used.</param>
        /// <param name="searchtext">Word or phrase for the search.</param>
        /// <param name="source">For analytics, hint at the part of the app that triggered the search. Optional.</param>
        /// <param name="tag">Tag used on the content to be searched.</param>
        public Task<Entities.SearchResultOfContentItemPublicContract> Content_SearchContentWithText(string locale, string? ctype = null, int? currentpage = null, bool? head = null, string? searchtext = null, string? source = null, string? tag = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfContentItemPublicContract>(
                new Uri($"Content/Search/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(ctype != null ? $"ctype={Uri.EscapeDataString(ctype)}" : null, currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, searchtext != null ? $"searchtext={Uri.EscapeDataString(searchtext)}" : null, source != null ? $"source={Uri.EscapeDataString(source)}" : null, tag != null ? $"tag={Uri.EscapeDataString(tag)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}