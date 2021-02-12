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
        /// Gets an object describing a particular variant of content.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Content.Models.ContentTypeDescription> Content_GetContentType(string type, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Content.Models.ContentTypeDescription>(
=======
        public async Task<Entities.Content.Models.ContentTypeDescription> Content_GetContentType(string type, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Content.Models.ContentTypeDescription>(
>>>>>>> rewrite
                new Uri($"Content/GetContentType/{Uri.EscapeDataString(type)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}