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
        /// Gets any hard linked membership given a credential. Only works for credentials that are public (just SteamID64 right now). Cross Save aware.
        /// </summary>
        public async Task<Schema.User.HardLinkedUserMembership> User_GetMembershipFromHardLinkedCredential(string credential, Schema.BungieCredentialType crType)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.User.HardLinkedUserMembership>(
                $"User/GetMembershipFromHardLinkedCredential/{crType}/{Uri.EscapeDataString(credential)}/", null, null, HttpMethod.Get
                );
        }
    }
}