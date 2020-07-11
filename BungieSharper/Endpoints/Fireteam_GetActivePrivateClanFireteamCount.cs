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
        /// Gets a count of all active non-public fireteams for the specified clan. Maximum value returned is 25.
        /// </summary>
        public async Task<int> Fireteam_GetActivePrivateClanFireteamCount(long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Fireteam/Clan/{groupId}/ActiveCount/", null, null, HttpMethod.Get
                );
        }
    }
}