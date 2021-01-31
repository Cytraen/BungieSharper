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
        /// Get API usage by application for time frame specified. You can go as far back as 30 days ago, and can ask for up to a 48 hour window of time in a single request. You must be authenticated with at least the ReadUserData permission to access this endpoint.
        /// </summary>
        public async Task<Schema.Applications.ApiUsage> App_GetApplicationApiUsage(int applicationId, DateTime? end = null, DateTime? start = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Applications.ApiUsage>(
                new Uri($"App/ApiUsage/{applicationId}/" + HttpRequestGenerator.MakeQuerystring(end != null ? $"end={end}" : null, start != null ? $"start={start}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}