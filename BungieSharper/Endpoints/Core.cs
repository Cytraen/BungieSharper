using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// List of available localization cultures
        /// </summary>
        public Task<Dictionary<string, string>> GetAvailableLocales(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Dictionary<string, string>>(
                new Uri($"GetAvailableLocales/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }

        /// <summary>
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
        public Task<Entities.Common.Models.CoreSettingsConfiguration> GetCommonSettings(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Common.Models.CoreSettingsConfiguration>(
                new Uri($"Settings/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }

        /// <summary>
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
        public Task<Dictionary<string, Entities.Common.Models.CoreSystem>> GetUserSystemOverrides(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Dictionary<string, Entities.Common.Models.CoreSystem>>(
                new Uri($"UserSystemOverrides/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }

        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        /// <param name="includestreaming">Determines whether Streaming Alerts are included in results</param>
        public Task<IEnumerable<Entities.GlobalAlert>> GetGlobalAlerts(bool? includestreaming = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.GlobalAlert>>(
                new Uri($"GlobalAlerts/" + HttpRequestGenerator.MakeQuerystring(includestreaming != null ? $"includestreaming={includestreaming}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                );
        }
    }
}