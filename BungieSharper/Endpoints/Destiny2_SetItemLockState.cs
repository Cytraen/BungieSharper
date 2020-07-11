using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Set the Lock State for an instanced item. You must have a valid Destiny Account.
        /// </summary>
        public async Task<int> Destiny2_SetItemLockState()
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Actions/Items/SetLockState/", null, null, HttpMethod.Post
                );
        }
    }
}