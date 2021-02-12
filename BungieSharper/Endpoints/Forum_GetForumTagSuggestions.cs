using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
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
        /// Gets tag suggestions based on partial text entry, matching them with other tags previously used in the forums.
        /// </summary>
<<<<<<< HEAD
        public async Task<IEnumerable<Schema.Tags.Models.Contracts.TagResponse>> Forum_GetForumTagSuggestions(string partialtag = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Tags.Models.Contracts.TagResponse>>(
=======
        /// <param name="partialtag">The partial tag input to generate suggestions from.</param>
        public async Task<IEnumerable<Entities.Tags.Models.Contracts.TagResponse>> Forum_GetForumTagSuggestions(string? partialtag = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Tags.Models.Contracts.TagResponse>>(
>>>>>>> rewrite
                new Uri($"Forum/GetForumTagSuggestions/" + HttpRequestGenerator.MakeQuerystring(partialtag != null ? $"partialtag={Uri.EscapeDataString(partialtag)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}