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
        /// Gets the state of the user's clan invite preferences for a particular membership type - true if they wish to be invited to clans, false otherwise.
        /// Requires OAuth2 scope(s): ReadUserData
        /// </summary>
        /// <param name="mType">The Destiny membership type of the account we wish to access settings.</param>
        public Task<bool> GroupV2_GetUserClanInviteSetting(Entities.BungieMembershipType mType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/GetUserClanInviteSetting/{mType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}