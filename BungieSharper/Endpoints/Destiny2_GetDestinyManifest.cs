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
        /// Returns the current version of the manifest as a json object.
        /// </summary>
        public async Task<Schema.Destiny.Config.DestinyManifest> Destiny2_GetDestinyManifest()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Config.DestinyManifest>(
                $"Destiny2/Manifest/", null, null, HttpMethod.Get
                );
        }
    }
}