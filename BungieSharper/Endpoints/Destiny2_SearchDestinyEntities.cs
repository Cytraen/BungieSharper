using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets a page list of Destiny items.
        /// </summary>
        /// <param name="page">Page number to return, starting with 0.</param>
        /// <param name="searchTerm">The string to use when searching for Destiny entities.</param>
        /// <param name="type">The type of entity for whom you would like results. These correspond to the entity's definition contract name. For instance, if you are looking for items, this property should be 'DestinyInventoryItemDefinition'.</param>
        public Task<Entities.Destiny.Definitions.DestinyEntitySearchResult> Destiny2_SearchDestinyEntities(string searchTerm, string type, int? page = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Destiny.Definitions.DestinyEntitySearchResult>(
                new Uri($"Destiny2/Armory/Search/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(searchTerm)}/" + HttpRequestGenerator.MakeQuerystring(page != null ? $"page={page}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}