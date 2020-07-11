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
        /// Equip an item. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline.
        /// </summary>
        public async Task<int> Destiny2_EquipItem()
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Actions/Items/EquipItem/", null, null, HttpMethod.Post
                );
        }
    }
}