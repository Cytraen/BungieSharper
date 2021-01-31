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
        /// Returns a content item referenced by id
        /// </summary>
        public async Task<Schema.Content.ContentItemPublicContract> Content_GetContentById(long id, string locale, bool? head = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Content.ContentItemPublicContract>(
                new Uri($"Content/GetContentById/{id}/{Uri.EscapeDataString(locale)}/" + HttpRequestGenerator.MakeQuerystring(head != null ? $"head={head}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}