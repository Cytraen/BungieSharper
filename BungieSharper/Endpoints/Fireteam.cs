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
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Fireteam/Clan/{groupId}/ActiveCount/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseInt32,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a listing of all of this clan's fireteams that are have available slots. Caller is not checked for join criteria so caching is maximized.
    /// Requires OAuth2 scope(s): ReadGroups
    /// </summary>
    /// <param name="activityType">The activity type to filter by.</param>
    /// <param name="dateRange">The date range to grab available fireteams.</param>
    /// <param name="excludeImmediate">If you wish the result to exclude immediate fireteams, set this to true. Immediate-only can be forced using the dateRange enum.</param>
    /// <param name="groupId">The group id of the clan.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Zero based page</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="publicOnly">Determines public/private filtering.</param>
    /// <param name="slotFilter">Filters based on available slots</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfFireteamSummary> Fireteam_GetAvailableClanFireteams(int activityType, Entities.Fireteam.FireteamDateRange dateRange, long groupId, int page, Entities.Fireteam.FireteamPlatform platform, Entities.Fireteam.FireteamPublicSearchOption publicOnly, Entities.Fireteam.FireteamSlotSearch slotFilter, bool? excludeImmediate = null, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Fireteam/Clan/{groupId}/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{publicOnly}/{page}/" + HttpRequestGenerator.MakeQuerystring(excludeImmediate != null ? $"excludeImmediate={excludeImmediate}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseSearchResultOfFireteamSummary,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a listing of all public fireteams starting now with open slots. Caller is not checked for join criteria so caching is maximized.
    /// Requires OAuth2 scope(s): ReadGroups
    /// </summary>
    /// <param name="activityType">The activity type to filter by.</param>
    /// <param name="dateRange">The date range to grab available fireteams.</param>
    /// <param name="excludeImmediate">If you wish the result to exclude immediate fireteams, set this to true. Immediate-only can be forced using the dateRange enum.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Zero based page</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="slotFilter">Filters based on available slots</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfFireteamSummary> Fireteam_SearchPublicAvailableClanFireteams(int activityType, Entities.Fireteam.FireteamDateRange dateRange, int page, Entities.Fireteam.FireteamPlatform platform, Entities.Fireteam.FireteamSlotSearch slotFilter, bool? excludeImmediate = null, string? langFilter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/" + HttpRequestGenerator.MakeQuerystring(excludeImmediate != null ? $"excludeImmediate={excludeImmediate}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseSearchResultOfFireteamSummary,
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
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/" + HttpRequestGenerator.MakeQuerystring(groupFilter != null ? $"groupFilter={groupFilter}" : null, langFilter != null ? $"langFilter={Uri.EscapeDataString(langFilter)}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseSearchResultOfFireteamResponse,
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
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseFireteamResponse,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}