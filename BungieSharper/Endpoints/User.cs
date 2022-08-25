using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public partial class Endpoints
{
    /// <summary>
    /// Loads a bungienet user by membership id.
    /// </summary>
    /// <param name="id">The requested Bungie.net membership id.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.User.GeneralUser> User_GetBungieNetUserById(long id, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.User.GeneralUser>(
            new Uri($"User/GetBungieNetUserById/{id}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_GetBungieNetUserById(long, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_GetBungieNetUserById<T>(long id, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/GetBungieNetUserById/{id}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a list of all display names linked to this membership id but sanitized (profanity filtered). Obeys all visibility rules of calling user and is heavily cached.
    /// </summary>
    /// <param name="membershipId">The requested membership id to load.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<byte, string>> User_GetSanitizedPlatformDisplayNames(long membershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Dictionary<byte, string>>(
            new Uri($"User/GetSanitizedPlatformDisplayNames/{membershipId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_GetSanitizedPlatformDisplayNames(long, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_GetSanitizedPlatformDisplayNames<T>(long membershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/GetSanitizedPlatformDisplayNames/{membershipId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a list of credential types attached to the requested account
    /// </summary>
    /// <param name="membershipId">The user's membership id</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<IEnumerable<Entities.User.Models.GetCredentialTypesForAccountResponse>> User_GetCredentialTypesForTargetAccount(long membershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.User.Models.GetCredentialTypesForAccountResponse>>(
            new Uri($"User/GetCredentialTypesForTargetAccount/{membershipId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_GetCredentialTypesForTargetAccount(long, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_GetCredentialTypesForTargetAccount<T>(long membershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/GetCredentialTypesForTargetAccount/{membershipId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a list of all available user themes.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<IEnumerable<Entities.Config.UserTheme>> User_GetAvailableThemes(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Config.UserTheme>>(
            new Uri($"User/GetAvailableThemes/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_GetAvailableThemes(string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_GetAvailableThemes<T>(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/GetAvailableThemes/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
    /// </summary>
    /// <param name="membershipId">The membership ID of the target user.</param>
    /// <param name="membershipType">Type of the supplied membership ID.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.User.UserMembershipData> User_GetMembershipDataById(long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.User.UserMembershipData>(
            new Uri($"User/GetMembershipsById/{membershipId}/{membershipType}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_GetMembershipDataById(long, Entities.BungieMembershipType, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_GetMembershipDataById<T>(long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/GetMembershipsById/{membershipId}/{membershipType}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a list of accounts associated with signed in user. This is useful for OAuth implementations that do not give you access to the token response.
    /// Requires OAuth2 scope(s): ReadBasicUserProfile
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.User.UserMembershipData> User_GetMembershipDataForCurrentUser(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.User.UserMembershipData>(
            new Uri($"User/GetMembershipsForCurrentUser/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_GetMembershipDataForCurrentUser(string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_GetMembershipDataForCurrentUser<T>(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/GetMembershipsForCurrentUser/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets any hard linked membership given a credential. Only works for credentials that are public (just SteamID64 right now). Cross Save aware.
    /// </summary>
    /// <param name="credential">The credential to look up. Must be a valid SteamID64.</param>
    /// <param name="crType">The credential type. 'SteamId' is the only valid value at present.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.User.HardLinkedUserMembership> User_GetMembershipFromHardLinkedCredential(string credential, Entities.BungieCredentialType crType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.User.HardLinkedUserMembership>(
            new Uri($"User/GetMembershipFromHardLinkedCredential/{crType}/{Uri.EscapeDataString(credential)}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_GetMembershipFromHardLinkedCredential(string, Entities.BungieCredentialType, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_GetMembershipFromHardLinkedCredential<T>(string credential, Entities.BungieCredentialType crType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/GetMembershipFromHardLinkedCredential/{crType}/{Uri.EscapeDataString(credential)}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// [OBSOLETE] Do not use this to search users, use SearchByGlobalNamePost instead.
    /// </summary>
    /// <param name="displayNamePrefix">The display name prefix you're looking for.</param>
    /// <param name="page">The zero-based page of results you desire.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.User.UserSearchResponse> User_SearchByGlobalNamePrefix(string displayNamePrefix, int page, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.User.UserSearchResponse>(
            new Uri($"User/Search/Prefix/{Uri.EscapeDataString(displayNamePrefix)}/{page}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_SearchByGlobalNamePrefix(string, int, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_SearchByGlobalNamePrefix<T>(string displayNamePrefix, int page, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/Search/Prefix/{Uri.EscapeDataString(displayNamePrefix)}/{page}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Given the prefix of a global display name, returns all users who share that name.
    /// </summary>
    /// <param name="page">The zero-based page of results you desire.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.User.UserSearchResponse> User_SearchByGlobalNamePost(int page, Entities.User.UserSearchPrefixRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.User.UserSearchResponse>(
            new Uri($"User/Search/GlobalName/{page}/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="User_SearchByGlobalNamePost(int, Entities.User.UserSearchPrefixRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> User_SearchByGlobalNamePost<T>(int page, Entities.User.UserSearchPrefixRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"User/Search/GlobalName/{page}/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }
}