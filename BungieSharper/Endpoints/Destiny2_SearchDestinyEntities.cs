using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Definitions.DestinyEntitySearchResult> Destiny2_SearchDestinyEntities(int page, string searchTerm, string type)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Definitions.DestinyEntitySearchResult>(
                "Destiny2/Armory/Search/{type}/{searchTerm}/", null, null, HttpMethod.Get
                );
        }
    }
}