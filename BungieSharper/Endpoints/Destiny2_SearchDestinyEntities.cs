using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Definitions.DestinyEntitySearchResult>(
                $"Destiny2/Armory/Search/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(searchTerm)}/", null, null, HttpMethod.Get,
                page != null ? $"page={page}" : null);
        }
    }
}