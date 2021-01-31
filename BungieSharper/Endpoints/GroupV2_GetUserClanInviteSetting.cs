using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets the state of the user's clan invite preferences for a particular membership type - true if they wish to be invited to clans, false otherwise.
        /// </summary>
        public async Task<bool> GroupV2_GetUserClanInviteSetting(Schema.BungieMembershipType mType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/GetUserClanInviteSetting/{mType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}