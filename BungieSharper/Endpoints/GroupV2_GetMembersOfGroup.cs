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
        /// Get the list of members in a given group.
        /// </summary>
        public async Task<Schema.SearchResultOfGroupMember> GroupV2_GetMembersOfGroup(int currentpage, long groupId, Schema.GroupsV2.RuntimeGroupMemberType? memberType = null, string nameSearch = null, string authToken = null)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMember>(
                new Uri($"GroupV2/{groupId}/Members/" + HttpRequestGenerator.MakeQuerystring(memberType != null ? $"memberType={memberType}" : null, nameSearch != null ? $"nameSearch={Uri.EscapeDataString(nameSearch)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer
                ).ConfigureAwait(false);
        }
    }
}