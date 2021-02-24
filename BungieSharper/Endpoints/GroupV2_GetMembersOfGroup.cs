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
        /// Get the list of members in a given group.
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="memberType">Filter out other member types. Use None for all members.</param>
        /// <param name="nameSearch">The name fragment upon which a search should be executed for members with matching display or unique names.</param>
        public Task<Entities.SearchResultOfGroupMember> GroupV2_GetMembersOfGroup(int currentpage, long groupId, Entities.GroupsV2.RuntimeGroupMemberType? memberType = null, string? nameSearch = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMember>(
                new Uri($"GroupV2/{groupId}/Members/" + HttpRequestGenerator.MakeQuerystring(memberType != null ? $"memberType={memberType}" : null, nameSearch != null ? $"nameSearch={Uri.EscapeDataString(nameSearch)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}