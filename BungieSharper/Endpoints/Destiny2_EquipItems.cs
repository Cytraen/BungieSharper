using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Equip a list of items by itemInstanceIds. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline. Any items not found on your character will be ignored.
        /// </summary>
        public async Task<Schema.Destiny.DestinyEquipItemResults> Destiny2_EquipItems()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.DestinyEquipItemResults>(
                $"Destiny2/Actions/Items/EquipItems/", null, null, HttpMethod.Post
                );
        }
    }
}