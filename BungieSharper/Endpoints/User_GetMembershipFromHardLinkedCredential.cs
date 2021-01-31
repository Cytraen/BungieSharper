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
        /// Gets any hard linked membership given a credential. Only works for credentials that are public (just SteamID64 right now). Cross Save aware.
        /// </summary>
        public async Task<Schema.User.HardLinkedUserMembership> User_GetMembershipFromHardLinkedCredential(string credential, Schema.BungieCredentialType crType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.User.HardLinkedUserMembership>(
                new Uri($"User/GetMembershipFromHardLinkedCredential/{crType}/{Uri.EscapeDataString(credential)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}