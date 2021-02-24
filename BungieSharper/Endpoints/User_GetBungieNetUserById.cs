using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Loads a bungienet user by membership id.
        /// </summary>
        /// <param name="id">The requested Bungie.net membership id.</param>
        public Task<Entities.User.GeneralUser> User_GetBungieNetUserById(long id, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.User.GeneralUser>(
                new Uri($"User/GetBungieNetUserById/{id}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}