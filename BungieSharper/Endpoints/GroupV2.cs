using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a list of all available group avatars for the signed-in user.
        /// </summary>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Dictionary<int, string>> GroupV2_GetAvailableAvatars(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Dictionary<int, string>>(
                new Uri($"GroupV2/GetAvailableAvatars/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Returns a list of all available group themes.
        /// </summary>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.Config.GroupTheme>> GroupV2_GetAvailableThemes(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Config.GroupTheme>>(
                new Uri($"GroupV2/GetAvailableThemes/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets the state of the user's clan invite preferences for a particular membership type - true if they wish to be invited to clans, false otherwise.
        /// Requires OAuth2 scope(s): ReadUserData
        /// </summary>
        /// <param name="mType">The Destiny membership type of the account we wish to access settings.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> GroupV2_GetUserClanInviteSetting(Entities.BungieMembershipType mType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/GetUserClanInviteSetting/{mType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets groups recommended for you based on the groups to whom those you follow belong.
        /// Requires OAuth2 scope(s): ReadGroups
        /// </summary>
        /// <param name="createDateRange">Requested range in which to pull recommended groups</param>
        /// <param name="groupType">Type of groups requested</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.GroupsV2.GroupV2Card>> GroupV2_GetRecommendedGroups(Entities.GroupsV2.GroupDateRange createDateRange, Entities.GroupsV2.GroupType groupType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.GroupsV2.GroupV2Card>>(
                new Uri($"GroupV2/Recommended/{groupType}/{createDateRange}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Search for Groups.
        /// </summary>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupSearchResponse> GroupV2_GroupSearch(Entities.GroupsV2.GroupQuery requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupSearchResponse>(
                new Uri($"GroupV2/Search/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get information about a specific group of the given ID.
        /// </summary>
        /// <param name="groupId">Requested group's id.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupResponse> GroupV2_GetGroup(long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupResponse>(
                new Uri($"GroupV2/{groupId}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get information about a specific group with the given name and type.
        /// </summary>
        /// <param name="groupName">Exact name of the group to find.</param>
        /// <param name="groupType">Type of group to find.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupResponse> GroupV2_GetGroupByName(string groupName, Entities.GroupsV2.GroupType groupType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupResponse>(
                new Uri($"GroupV2/Name/{Uri.EscapeDataString(groupName)}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get information about a specific group with the given name and type. The POST version.
        /// </summary>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupResponse> GroupV2_GetGroupByNameV2(Entities.GroupsV2.GroupNameSearchRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupResponse>(
                new Uri($"GroupV2/NameV2/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets a list of available optional conversation channels and their settings.
        /// </summary>
        /// <param name="groupId">Requested group's id.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.GroupsV2.GroupOptionalConversation>> GroupV2_GetGroupOptionalConversations(long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.GroupsV2.GroupOptionalConversation>>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Edit an existing group. You must have suitable permissions in the group to perform this operation. This latest revision will only edit the fields you pass in - pass null for properties you want to leave unaltered.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<int> GroupV2_EditGroup(long groupId, Entities.GroupsV2.GroupEditAction requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Edit/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Edit an existing group's clan banner. You must have suitable permissions in the group to perform this operation. All fields are required.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<int> GroupV2_EditClanBanner(long groupId, Entities.GroupsV2.ClanBanner requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/EditClanBanner/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Edit group options only available to a founder. You must have suitable permissions in the group to perform this operation.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<int> GroupV2_EditFounderOptions(long groupId, Entities.GroupsV2.GroupOptionsEditAction requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/EditFounderOptions/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Add a new optional conversation/chat channel. Requires admin permissions to the group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<long> GroupV2_AddOptionalConversation(long groupId, Entities.GroupsV2.GroupOptionalConversationAddRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<long>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/Add/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Edit the settings of an optional conversation/chat channel. Requires admin permissions to the group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="conversationId">Conversation Id of the channel being edited.</param>
        /// <param name="groupId">Group ID of the group to edit.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<long> GroupV2_EditOptionalConversation(long conversationId, long groupId, Entities.GroupsV2.GroupOptionalConversationEditRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<long>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/Edit/{conversationId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get the list of members in a given group.
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="memberType">Filter out other member types. Use None for all members.</param>
        /// <param name="nameSearch">The name fragment upon which a search should be executed for members with matching display or unique names.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.SearchResultOfGroupMember> GroupV2_GetMembersOfGroup(int currentpage, long groupId, Entities.GroupsV2.RuntimeGroupMemberType? memberType = null, string? nameSearch = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMember>(
                new Uri($"GroupV2/{groupId}/Members/" + HttpRequestGenerator.MakeQuerystring(memberType != null ? $"memberType={memberType}" : null, nameSearch != null ? $"nameSearch={Uri.EscapeDataString(nameSearch)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get the list of members in a given group who are of admin level or higher.
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.SearchResultOfGroupMember> GroupV2_GetAdminsAndFounderOfGroup(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMember>(
                new Uri($"GroupV2/{groupId}/AdminsAndFounder/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Edit the membership type of a given member. You must have suitable permissions in the group to perform this operation.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group to which the member belongs.</param>
        /// <param name="membershipId">Membership ID to modify.</param>
        /// <param name="membershipType">Membership type of the provide membership ID.</param>
        /// <param name="memberType">New membertype for the specified member.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<int> GroupV2_EditGroupMembership(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.RuntimeGroupMemberType memberType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/SetMembershipType/{memberType}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Kick a member from the given group, forcing them to reapply if they wish to re-join the group. You must have suitable permissions in the group to perform this operation.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID to kick the user from.</param>
        /// <param name="membershipId">Membership ID to kick.</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupMemberLeaveResult> GroupV2_KickMember(long groupId, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupMemberLeaveResult>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Kick/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Bans the requested member from the requested group for the specified period of time.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">Group ID that has the member to ban.</param>
        /// <param name="membershipId">Membership ID of the member to ban from the group.</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<int> GroupV2_BanMember(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.GroupBanRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Ban/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Unbans the requested member, allowing them to re-apply for membership.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="membershipId">Membership ID of the member to unban from the group</param>
        /// <param name="membershipType">Membership type of the provided membership ID.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<int> GroupV2_UnbanMember(long groupId, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Unban/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get the list of banned members in a given group. Only accessible to group Admins and above. Not applicable to all groups. Check group features.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 entries.</param>
        /// <param name="groupId">Group ID whose banned members you are fetching</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.SearchResultOfGroupBan> GroupV2_GetBannedMembersOfGroup(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupBan>(
                new Uri($"GroupV2/{groupId}/Banned/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// An administrative method to allow the founder of a group or clan to give up their position to another admin permanently.
        /// </summary>
        /// <param name="founderIdNew">The new founder for this group. Must already be a group admin.</param>
        /// <param name="groupId">The target group id.</param>
        /// <param name="membershipType">Membership type of the provided founderIdNew.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> GroupV2_AbdicateFoundership(long founderIdNew, long groupId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/{groupId}/Admin/AbdicateFoundership/{membershipType}/{founderIdNew}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get the list of users who are awaiting a decision on their application to join a given group. Modified to include application info.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.SearchResultOfGroupMemberApplication> GroupV2_GetPendingMemberships(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMemberApplication>(
                new Uri($"GroupV2/{groupId}/Members/Pending/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get the list of users who have been invited into the group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.SearchResultOfGroupMemberApplication> GroupV2_GetInvitedIndividuals(int currentpage, long groupId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfGroupMemberApplication>(
                new Uri($"GroupV2/{groupId}/Members/InvitedIndividuals/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Approve all of the pending users for the given group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.Entities.EntityActionResult>> GroupV2_ApproveAllPending(long groupId, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Entities.EntityActionResult>>(
                new Uri($"GroupV2/{groupId}/Members/ApproveAll/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Deny all of the pending users for the given group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.Entities.EntityActionResult>> GroupV2_DenyAllPending(long groupId, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Entities.EntityActionResult>>(
                new Uri($"GroupV2/{groupId}/Members/DenyAll/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Approve all of the pending users for the given group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.Entities.EntityActionResult>> GroupV2_ApprovePendingForList(long groupId, Entities.GroupsV2.GroupApplicationListRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Entities.EntityActionResult>>(
                new Uri($"GroupV2/{groupId}/Members/ApproveList/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Approve the given membershipId to join the group/clan as long as they have applied.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="membershipId">The membership id being approved.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> GroupV2_ApprovePending(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"GroupV2/{groupId}/Members/Approve/{membershipType}/{membershipId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Deny all of the pending users for the given group that match the passed-in .
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<IEnumerable<Entities.Entities.EntityActionResult>> GroupV2_DenyPendingForList(long groupId, Entities.GroupsV2.GroupApplicationListRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Entities.EntityActionResult>>(
                new Uri($"GroupV2/{groupId}/Members/DenyList/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get information about the groups that a given member has joined.
        /// </summary>
        /// <param name="filter">Filter apply to list of joined groups.</param>
        /// <param name="groupType">Type of group the supplied member founded.</param>
        /// <param name="membershipId">Membership ID to for which to find founded groups.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GetGroupsForMemberResponse> GroupV2_GetGroupsForMember(Entities.GroupsV2.GroupsForMemberFilter filter, Entities.GroupsV2.GroupType groupType, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GetGroupsForMemberResponse>(
                new Uri($"GroupV2/User/{membershipType}/{membershipId}/{filter}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Allows a founder to manually recover a group they can see in game but not on bungie.net
        /// </summary>
        /// <param name="groupType">Type of group the supplied member founded.</param>
        /// <param name="membershipId">Membership ID to for which to find founded groups.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupMembershipSearchResponse> GroupV2_RecoverGroupForFounder(Entities.GroupsV2.GroupType groupType, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupMembershipSearchResponse>(
                new Uri($"GroupV2/Recover/{membershipType}/{membershipId}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Get information about the groups that a given member has applied to or been invited to.
        /// </summary>
        /// <param name="filter">Filter apply to list of potential joined groups.</param>
        /// <param name="groupType">Type of group the supplied member applied.</param>
        /// <param name="membershipId">Membership ID to for which to find applied groups.</param>
        /// <param name="membershipType">Membership type of the supplied membership ID.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupPotentialMembershipSearchResponse> GroupV2_GetPotentialGroupsForMember(Entities.GroupsV2.GroupPotentialMemberStatus filter, Entities.GroupsV2.GroupType groupType, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupPotentialMembershipSearchResponse>(
                new Uri($"GroupV2/User/Potential/{membershipType}/{membershipId}/{filter}/{groupType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Invite a user to join this group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group you would like to join.</param>
        /// <param name="membershipId">Membership id of the account being invited.</param>
        /// <param name="membershipType">MembershipType of the account being invited.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInvite(long groupId, long membershipId, Entities.BungieMembershipType membershipType, Entities.GroupsV2.GroupApplicationRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupApplicationResponse>(
                new Uri($"GroupV2/{groupId}/Members/IndividualInvite/{membershipType}/{membershipId}/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Cancels a pending invitation to join a group.
        /// Requires OAuth2 scope(s): AdminGroups
        /// </summary>
        /// <param name="groupId">ID of the group you would like to join.</param>
        /// <param name="membershipId">Membership id of the account being cancelled.</param>
        /// <param name="membershipType">MembershipType of the account being cancelled.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.GroupsV2.GroupApplicationResponse> GroupV2_IndividualGroupInviteCancel(long groupId, long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupApplicationResponse>(
                new Uri($"GroupV2/{groupId}/Members/IndividualInviteCancel/{membershipType}/{membershipId}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }
    }
}