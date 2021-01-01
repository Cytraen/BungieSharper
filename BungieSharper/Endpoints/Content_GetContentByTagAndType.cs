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
        /// Returns the newest item that matches a given tag and Content Type.
        /// </summary>
        public async Task<Schema.Content.ContentItemPublicContract> Content_GetContentByTagAndType(string locale, string tag, string type, bool? head = null, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Content.ContentItemPublicContract>(
                new Uri($"Content/GetContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}