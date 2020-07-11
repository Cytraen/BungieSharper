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
        /// Returns the static definition of an entity of the given Type and hash identifier. Examine the API Documentation for the Type Names of entities that have their own definitions. Note that the return type will always *inherit from* DestinyDefinition, but the specific type returned will be the requested entity type if it can be found. Please don't use this as a chatty alternative to the Manifest database if you require large sets of data, but for simple and one-off accesses this should be handy.
        /// </summary>
        public async Task<Schema.Destiny.Definitions.DestinyDefinition> Destiny2_GetDestinyEntityDefinition(string entityType, uint hashIdentifier)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Definitions.DestinyDefinition>(
                $"Destiny2/Manifest/{Uri.EscapeDataString(entityType)}/{hashIdentifier}/", null, null, HttpMethod.Get
                );
        }
    }
}