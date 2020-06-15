using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.DestinyEquipItemResults> Destiny2_EquipItems()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.DestinyEquipItemResults>(
                $"Destiny2/Actions/Items/EquipItems/", null, null, HttpMethod.Post
                );
        }
    }
}