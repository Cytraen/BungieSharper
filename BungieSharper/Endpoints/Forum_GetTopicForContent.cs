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
        /// Gets the post Id for the given content item's comments, if it exists.
        /// </summary>
        public async Task<long> Forum_GetTopicForContent(long contentId)
        {
            return await _apiAccessor.ApiRequestAsync<long>(
                new Uri($"Forum/GetTopicForContent/{contentId}/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}