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
        /// Set the Lock State for an instanced item. You must have a valid Destiny Account.
        /// </summary>
        public async Task<int> Destiny2_SetItemLockState(Schema.Destiny.Requests.Actions.DestinyItemStateRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Actions/Items/SetLockState/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}