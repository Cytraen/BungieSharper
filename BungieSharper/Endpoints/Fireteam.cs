using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public partial class Endpoints
{
    /// <summary>
    /// Gets a count of all active non-public fireteams for the specified clan. Maximum value returned is 25.
    /// Requires OAuth2 scope(s): ReadGroups
    /// </summary>
    /// <param name="groupId">The group id of the clan.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Fireteam_GetActivePrivateClanFireteamCount(long groupId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Fireteam/Clan/{groupId}/ActiveCount/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Fireteam_GetActivePrivateClanFireteamCount(long, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Fireteam_GetActivePrivateClanFireteamCount<T>(long groupId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Fireteam/Clan/{groupId}/ActiveCount/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a listing of all of this clan's fireteams that are have available slots. Caller is not checked for join criteria so caching is maximized.
    /// Requires OAuth2 scope(s): ReadGroups
    /// </summary>
    /// <param name="activityType">The activity type to filter by.</param>
    /// <param name="dateRange">The date range to grab available fireteams.</param>
    /// <param name="groupId">The group id of the clan.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Zero based page</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="publicOnly">Determines public/private filtering.</param>
    /// <param name="slotFilter">Filters based on available slots</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfFireteamSummary> Fireteam_GetAvailableClanFireteams(int activityType, Entities.Fireteam.FireteamDateRange dateRange, long groupId, int page, Entities.Fireteam.FireteamPlatform platform, Entities.Fireteam.FireteamPublicSearchOption publicOnly, Entities.Fireteam.FireteamSlotSearch slotFilter, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfFireteamSummary>(
            new Uri($"Fireteam/Clan/{groupId}/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{publicOnly}/{page}/" + HttpRequestGenerator.MakeQuerystring(langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Fireteam_GetAvailableClanFireteams(int, Entities.Fireteam.FireteamDateRange, long, int, Entities.Fireteam.FireteamPlatform, Entities.Fireteam.FireteamPublicSearchOption, Entities.Fireteam.FireteamSlotSearch, string?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Fireteam_GetAvailableClanFireteams<T>(int activityType, Entities.Fireteam.FireteamDateRange dateRange, long groupId, int page, Entities.Fireteam.FireteamPlatform platform, Entities.Fireteam.FireteamPublicSearchOption publicOnly, Entities.Fireteam.FireteamSlotSearch slotFilter, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Fireteam/Clan/{groupId}/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{publicOnly}/{page}/" + HttpRequestGenerator.MakeQuerystring(langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a listing of all public fireteams starting now with open slots. Caller is not checked for join criteria so caching is maximized.
    /// Requires OAuth2 scope(s): ReadGroups
    /// </summary>
    /// <param name="activityType">The activity type to filter by.</param>
    /// <param name="dateRange">The date range to grab available fireteams.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Zero based page</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="slotFilter">Filters based on available slots</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfFireteamSummary> Fireteam_SearchPublicAvailableClanFireteams(int activityType, Entities.Fireteam.FireteamDateRange dateRange, int page, Entities.Fireteam.FireteamPlatform platform, Entities.Fireteam.FireteamSlotSearch slotFilter, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfFireteamSummary>(
            new Uri($"Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/" + HttpRequestGenerator.MakeQuerystring(langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Fireteam_SearchPublicAvailableClanFireteams(int, Entities.Fireteam.FireteamDateRange, int, Entities.Fireteam.FireteamPlatform, Entities.Fireteam.FireteamSlotSearch, string?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Fireteam_SearchPublicAvailableClanFireteams<T>(int activityType, Entities.Fireteam.FireteamDateRange dateRange, int page, Entities.Fireteam.FireteamPlatform platform, Entities.Fireteam.FireteamSlotSearch slotFilter, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/" + HttpRequestGenerator.MakeQuerystring(langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a listing of all fireteams that caller is an applicant, a member, or an alternate of.
    /// Requires OAuth2 scope(s): ReadGroups
    /// </summary>
    /// <param name="groupFilter">If true, filter by clan. Otherwise, ignore the clan and show all of the user's fireteams.</param>
    /// <param name="groupId">The group id of the clan. (This parameter is ignored unless the optional query parameter groupFilter is true).</param>
    /// <param name="includeClosed">If true, return fireteams that have been closed.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Deprecated parameter, ignored.</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfFireteamResponse> Fireteam_GetMyClanFireteams(long groupId, bool includeClosed, int page, Entities.Fireteam.FireteamPlatform platform, bool? groupFilter = null, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.SearchResultOfFireteamResponse>(
            new Uri($"Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/" + HttpRequestGenerator.MakeQuerystring(groupFilter != null ? $"groupFilter={groupFilter}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Fireteam_GetMyClanFireteams(long, bool, int, Entities.Fireteam.FireteamPlatform, bool?, string?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Fireteam_GetMyClanFireteams<T>(long groupId, bool includeClosed, int page, Entities.Fireteam.FireteamPlatform platform, bool? groupFilter = null, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/" + HttpRequestGenerator.MakeQuerystring(groupFilter != null ? $"groupFilter={groupFilter}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a specific fireteam.
    /// Requires OAuth2 scope(s): ReadGroups
    /// </summary>
    /// <param name="fireteamId">The unique id of the fireteam.</param>
    /// <param name="groupId">The group id of the clan.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Fireteam.FireteamResponse> Fireteam_GetClanFireteam(long fireteamId, long groupId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Fireteam.FireteamResponse>(
            new Uri($"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Fireteam_GetClanFireteam(long, long, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Fireteam_GetClanFireteam<T>(long fireteamId, long groupId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}