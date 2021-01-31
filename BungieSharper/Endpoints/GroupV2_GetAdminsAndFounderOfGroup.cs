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
        /// Get the list of members in a given group who are of admin level or higher.
        /// </summary>
        public async Task<Schema.SearchResultOfGroupMember> GroupV2_GetAdminsAndFounderOfGroup(int currentpage, long groupId, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMember>(
                new Uri($"GroupV2/{groupId}/AdminsAndFounder/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}