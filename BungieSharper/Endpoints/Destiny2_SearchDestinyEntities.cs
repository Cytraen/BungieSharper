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
        /// Gets a page list of Destiny items.
        /// </summary>
        public async Task<Schema.Destiny.Definitions.DestinyEntitySearchResult> Destiny2_SearchDestinyEntities(string searchTerm, string type, int? page = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Definitions.DestinyEntitySearchResult>(
                new Uri($"Destiny2/Armory/Search/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(searchTerm)}/" + HttpRequestGenerator.MakeQuerystring(page != null ? $"page={page}" : null), UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}