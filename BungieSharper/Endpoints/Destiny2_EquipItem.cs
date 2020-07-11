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
        /// Equip an item. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline.
        /// </summary>
        public async Task<int> Destiny2_EquipItem(Schema.Destiny.Requests.Actions.DestinyItemActionRequest requestBody)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Actions/Items/EquipItem/", null, JsonSerializer.Serialize(requestBody), HttpMethod.Post
                );
        }
    }
}