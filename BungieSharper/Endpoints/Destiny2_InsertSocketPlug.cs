using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>This is a preview method.</summary>
        public async Task<Schema.Destiny.Responses.DestinyItemChangeResponse> Destiny2_InsertSocketPlug()
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyItemChangeResponse>(
                $"Destiny2/Actions/Items/InsertSocketPlug/", null, null, HttpMethod.Post
                );
        }
    }
}