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
        /// Returns a content item referenced by id
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Content.ContentItemPublicContract> Content_GetContentById(long id, string locale, bool? head = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Content.ContentItemPublicContract>(
=======
        /// <param name="head">false</param>
        public async Task<Entities.Content.ContentItemPublicContract> Content_GetContentById(long id, string locale, bool? head = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Content.ContentItemPublicContract>(
>>>>>>> rewrite
                new Uri($"Content/GetContentById/{id}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}