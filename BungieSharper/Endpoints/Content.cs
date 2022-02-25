using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets an object describing a particular variant of content.
        /// </summary>
        /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Content.Models.ContentTypeDescription> Content_GetContentType(string type, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Content.Models.ContentTypeDescription>(
                new Uri($"Content/GetContentType/{Uri.EscapeDataString(type)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Content_GetContentType(string, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Content_GetContentType<T>(string type, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Content/GetContentType/{Uri.EscapeDataString(type)}/", UriKind.Relative),
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
            return _apiAccessor.ApiRequestAsync<Entities.Content.ContentItemPublicContract>(
                new Uri($"Content/GetContentById/{id}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Content_GetContentById(long, string, bool?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Content_GetContentById<T>(long id, string locale, bool? head = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Content/GetContentById/{id}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative),
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
            return _apiAccessor.ApiRequestAsync<Entities.Content.ContentItemPublicContract>(
                new Uri($"Content/GetContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Content_GetContentByTagAndType(string, string, string, bool?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Content_GetContentByTagAndType<T>(string locale, string tag, string type, bool? head = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Content/GetContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative),
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
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfContentItemPublicContract>(
                new Uri($"Content/Search/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(ctype != null ? $"ctype={Uri.EscapeDataString(ctype)}" : null, currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, searchtext != null ? $"searchtext={Uri.EscapeDataString(searchtext)}" : null, source != null ? $"source={Uri.EscapeDataString(source)}" : null, tag != null ? $"tag={Uri.EscapeDataString(tag)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Content_SearchContentWithText(string, string?, int?, bool?, string?, string?, string?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Content_SearchContentWithText<T>(string locale, string? ctype = null, int? currentpage = null, bool? head = null, string? searchtext = null, string? source = null, string? tag = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Content/Search/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(ctype != null ? $"ctype={Uri.EscapeDataString(ctype)}" : null, currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, searchtext != null ? $"searchtext={Uri.EscapeDataString(searchtext)}" : null, source != null ? $"source={Uri.EscapeDataString(source)}" : null, tag != null ? $"tag={Uri.EscapeDataString(tag)}" : null), UriKind.Relative),
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
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfContentItemPublicContract>(
                new Uri($"Content/SearchContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, itemsperpage != null ? $"itemsperpage={itemsperpage}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Content_SearchContentByTagAndType(string, string, string, int?, bool?, int?, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Content_SearchContentByTagAndType<T>(string locale, string tag, string type, int? currentpage = null, bool? head = null, int? itemsperpage = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Content/SearchContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, itemsperpage != null ? $"itemsperpage={itemsperpage}" : null), UriKind.Relative),
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
            return _apiAccessor.ApiRequestAsync<object>(
                new Uri($"Content/SearchHelpArticles/{Uri.EscapeDataString(searchtext)}/{Uri.EscapeDataString(size)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <inheritdoc cref="Content_SearchHelpArticles(string, string, string?, CancellationToken)" />
        /// <typeparam name="T">The custom type to deserialize to.</typeparam>
        public Task<T> Content_SearchHelpArticles<T>(string searchtext, string size, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<T>(
                new Uri($"Content/SearchHelpArticles/{Uri.EscapeDataString(searchtext)}/{Uri.EscapeDataString(size)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }
    }
}