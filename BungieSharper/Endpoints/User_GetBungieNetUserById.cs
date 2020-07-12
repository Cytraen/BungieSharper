using BungieSharper.Client;
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
        /// Loads a bungienet user by membership id.
        /// </summary>
        public async Task<Schema.User.GeneralUser> User_GetBungieNetUserById(long id)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.User.GeneralUser>(
                new Uri($"User/GetBungieNetUserById/{id}/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}