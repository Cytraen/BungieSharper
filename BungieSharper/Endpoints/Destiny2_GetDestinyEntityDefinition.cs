using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Definitions.DestinyDefinition> Destiny2_GetDestinyEntityDefinition(string entityType, uint hashIdentifier)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Definitions.DestinyDefinition>(
                "Destiny2/Manifest/{entityType}/{hashIdentifier}/", null, null, HttpMethod.Get
                );
        }
    }
}