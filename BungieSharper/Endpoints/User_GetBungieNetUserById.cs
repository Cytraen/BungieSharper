using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Loads a bungienet user by membership id.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.User.GeneralUser> User_GetBungieNetUserById(long id, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.User.GeneralUser>(
=======
        /// <param name="id">The requested Bungie.net membership id.</param>
        public async Task<Entities.User.GeneralUser> User_GetBungieNetUserById(long id, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.User.GeneralUser>(
>>>>>>> rewrite
                new Uri($"User/GetBungieNetUserById/{id}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}