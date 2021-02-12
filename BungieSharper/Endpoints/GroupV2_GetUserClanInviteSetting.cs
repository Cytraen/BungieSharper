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
        /// Gets the state of the user's clan invite preferences for a particular membership type - true if they wish to be invited to clans, false otherwise.
<<<<<<< HEAD
        /// </summary>
        public async Task<bool> GroupV2_GetUserClanInviteSetting(Schema.BungieMembershipType mType, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): ReadUserData
        /// </summary>
        /// <param name="mType">The Destiny membership type of the account we wish to access settings.</param>
        public async Task<bool> GroupV2_GetUserClanInviteSetting(Entities.BungieMembershipType mType, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/GetUserClanInviteSetting/{mType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}