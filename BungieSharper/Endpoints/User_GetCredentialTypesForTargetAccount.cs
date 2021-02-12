using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
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
        /// Returns a list of credential types attached to the requested account
        /// </summary>
<<<<<<< HEAD
        public async Task<IEnumerable<Schema.User.Models.GetCredentialTypesForAccountResponse>> User_GetCredentialTypesForTargetAccount(long membershipId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.User.Models.GetCredentialTypesForAccountResponse>>(
=======
        /// <param name="membershipId">The user's membership id</param>
        public async Task<IEnumerable<Entities.User.Models.GetCredentialTypesForAccountResponse>> User_GetCredentialTypesForTargetAccount(long membershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.User.Models.GetCredentialTypesForAccountResponse>>(
>>>>>>> rewrite
                new Uri($"User/GetCredentialTypesForTargetAccount/{membershipId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}