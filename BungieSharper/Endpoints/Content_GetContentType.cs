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
        /// Gets an object describing a particular variant of content.
        /// </summary>
        public async Task<Schema.Content.Models.ContentTypeDescription> Content_GetContentType(string type, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Content.Models.ContentTypeDescription>(
                new Uri($"Content/GetContentType/{Uri.EscapeDataString(type)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}