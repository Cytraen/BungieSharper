using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public partial class Endpoints
{
    /// <summary>
    /// Gets an object describing a particular variant of content.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Content.Models.ContentTypeDescription> Content_GetContentType(string type, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Content/GetContentType/{Uri.EscapeDataString(type)}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseContentTypeDescription,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a content item referenced by id
    /// </summary>
    /// <param name="head">false</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Content.ContentItemPublicContract> Content_GetContentById(long id, string locale, bool? head = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Content/GetContentById/{id}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseContentItemPublicContract,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the newest item that matches a given tag and Content Type.
    /// </summary>
    /// <param name="head">Not used.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Content.ContentItemPublicContract> Content_GetContentByTagAndType(string locale, string tag, string type, bool? head = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Content/GetContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseContentItemPublicContract,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets content based on querystring information passed in. Provides basic search and text search capabilities.
    /// </summary>
    /// <param name="ctype">Content type tag: Help, News, etc. Supply multiple ctypes separated by space.</param>
    /// <param name="currentpage">Page number for the search results, starting with page 1.</param>
    /// <param name="head">Not used.</param>
    /// <param name="searchtext">Word or phrase for the search.</param>
    /// <param name="source">For analytics, hint at the part of the app that triggered the search. Optional.</param>
    /// <param name="tag">Tag used on the content to be searched.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfContentItemPublicContract> Content_SearchContentWithText(string locale, string? ctype = null, int? currentpage = null, bool? head = null, string? searchtext = null, string? source = null, string? tag = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Content/Search/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(ctype != null ? $"ctype={Uri.EscapeDataString(ctype)}" : null, currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, searchtext != null ? $"searchtext={Uri.EscapeDataString(searchtext)}" : null, source != null ? $"source={Uri.EscapeDataString(source)}" : null, tag != null ? $"tag={Uri.EscapeDataString(tag)}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseSearchResultOfContentItemPublicContract,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Searches for Content Items that match the given Tag and Content Type.
    /// </summary>
    /// <param name="currentpage">Page number for the search results starting with page 1.</param>
    /// <param name="head">Not used.</param>
    /// <param name="itemsperpage">Not used.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfContentItemPublicContract> Content_SearchContentByTagAndType(string locale, string tag, string type, int? currentpage = null, bool? head = null, int? itemsperpage = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Content/SearchContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, itemsperpage != null ? $"itemsperpage={itemsperpage}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseSearchResultOfContentItemPublicContract,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Search for Help Articles.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<object> Content_SearchHelpArticles(string searchtext, string size, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Content/SearchHelpArticles/{Uri.EscapeDataString(searchtext)}/{Uri.EscapeDataString(size)}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseObject,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a JSON string response that is the RSS feed for news articles.
    /// </summary>
    /// <param name="categoryfilter">Optionally filter response to only include news items in a certain category.</param>
    /// <param name="includebody">Optionally include full content body for each news item.</param>
    /// <param name="pageToken">Zero-based pagination token for paging through result sets.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Content.NewsArticleRssResponse> Content_RssNewsArticles(string pageToken, string? categoryfilter = null, bool? includebody = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Content/Rss/NewsArticles/{Uri.EscapeDataString(pageToken)}/" + HttpRequestGenerator.MakeQuerystring(categoryfilter != null ? $"categoryfilter={Uri.EscapeDataString(categoryfilter)}" : null, includebody != null ? $"includebody={includebody}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseNewsArticleRssResponse,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}