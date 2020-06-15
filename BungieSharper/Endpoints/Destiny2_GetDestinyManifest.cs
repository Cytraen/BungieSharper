using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.Config.DestinyManifest> Destiny2_GetDestinyManifest()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Config.DestinyManifest>(
                $"Destiny2/Manifest/", null, null, HttpMethod.Get
                );
        }
    }
}