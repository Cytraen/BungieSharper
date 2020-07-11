using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a list of all available group avatars for the signed-in user.
        /// </summary>
        public async Task<Dictionary<int, string>> GroupV2_GetAvailableAvatars()
        {
            return await this._apiAccessor.ApiRequestAsync<Dictionary<int, string>>(
                $"GroupV2/GetAvailableAvatars/", null, null, HttpMethod.Get
                );
        }
    }
}