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
    /// List of available localization cultures
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, string>> GetAvailableLocales(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("GetAvailableLocales/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseDictionaryStringString,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Get the common settings used by the Bungie.Net environment.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Common.Models.CoreSettingsConfiguration> GetCommonSettings(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("Settings/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseCoreSettingsConfiguration,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Get the user-specific system overrides that should be respected alongside common systems.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Entities.Common.Models.CoreSystem>> GetUserSystemOverrides(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("UserSystemOverrides/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseDictionaryStringCoreSystem,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
    /// </summary>
    /// <param name="includestreaming">Determines whether Streaming Alerts are included in results</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<IEnumerable<Entities.GlobalAlert>> GetGlobalAlerts(bool? includestreaming = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("GlobalAlerts/" + HttpRequestGenerator.MakeQuerystring(includestreaming != null ? $"includestreaming={includestreaming}" : null), UriKind.Relative), _apiAccessor.JsonContext.ApiResponseIEnumerableGlobalAlert,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}