using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public partial class Endpoints
{
    /// <summary>
    /// Get API usage by application for time frame specified. You can go as far back as 30 days ago, and can ask for up to a 48 hour window of time in a single request. You must be authenticated with at least the ReadUserData permission to access this endpoint.
    /// Requires OAuth2 scope(s): ReadUserData
    /// </summary>
    /// <param name="applicationId">ID of the application to get usage statistics.</param>
    /// <param name="end">End time for query. Goes to now if not specified.</param>
    /// <param name="start">Start time for query. Goes to 24 hours ago if not specified.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Applications.ApiUsage> App_GetApplicationApiUsage(int applicationId, DateTime? end = null, DateTime? start = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Applications.ApiUsage>(
            new Uri($"App/ApiUsage/{applicationId}/" + HttpRequestGenerator.MakeQuerystring(end != null ? $"end={end}" : null, start != null ? $"start={start}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="App_GetApplicationApiUsage(int, DateTime?, DateTime?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> App_GetApplicationApiUsage<T>(int applicationId, DateTime? end = null, DateTime? start = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"App/ApiUsage/{applicationId}/" + HttpRequestGenerator.MakeQuerystring(end != null ? $"end={end}" : null, start != null ? $"start={start}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Get list of applications created by Bungie.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<IEnumerable<Entities.Applications.Application>> App_GetBungieApplications(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Applications.Application>>(
            new Uri($"App/FirstParty/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="App_GetBungieApplications(string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> App_GetBungieApplications<T>(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"App/FirstParty/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}