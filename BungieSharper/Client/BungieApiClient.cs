using BungieSharper.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Client
{
    /// <summary>
    /// BungieSharper's Bungie API client.
    /// </summary>
    public class BungieApiClient : IDisposable
    {
        internal const byte MaxRequestsPerSecond = 50;
        internal const byte DefaultRequestsPerSecond = 10;

        private readonly ApiAccessor _apiAccessor;

        /// <summary>
        /// Contains methods to use the API endpoints for the Bungie.net API.
        /// </summary>
        public Endpoints.Endpoints Api { get; }

        /// <summary>
        /// Contains methods to use the OAuth endpoints for the Bungie.net API.
        /// </summary>
        public Endpoints.OAuthRequests OAuth { get; }

        /// <summary>
        /// The API key to set in the X-API-Key header.
        /// </summary>
        /// <remarks> If you don't have one, you can get one at https://www.bungie.net/en/Application/ </remarks>
        public string ApiKey
        {
            init => SetApiKey(value);
        }

        /// <summary>
        /// The value of the "User-Agent" header. If <c>null</c>, it will be removed/omitted.
        /// </summary>
        /// <remarks>Format should be {ProductName}/{ProductVersion} (+{contact info}) e.g.: YourAppName/v1.2.3 (+your@email.here)</remarks>
        public string UserAgent
        {
            init => SetUserAgent(value);
        }

        /// <summary>
        /// The client's OAuth client ID
        /// </summary>
        public uint OAuthClientId
        {
            init => SetOAuthClientId(value);
        }

        /// <summary>
        /// The client's OAuth client secret
        /// </summary>
        /// <remarks>Only for confidential clients</remarks>
        public string OAuthClientSecret
        {
            init => SetOAuthClientSecret(value);
        }

        /// <summary>
        /// The maximum number of Bungie API requests to make per second.
        /// </summary>
        /// <remarks>The official limit is 250/10sec/IP (25/sec.) The absolute maximum is 50, but if you go higher than 25, you're on your own.</remarks>
        public byte RateLimit
        {
            set => SetRateLimit(value);
        }

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle from the API response, if provided)
        /// </summary>
        public HashSet<PlatformErrorCodes> RetryErrorCodes
        {
            set => SetRetryErrorCodes(value);
        }

        private BungieApiClient()
        {
            _apiAccessor = new ApiAccessor();
            SetRateLimit(DefaultRequestsPerSecond);

            Api = new Endpoints.Endpoints(_apiAccessor);
            OAuth = new Endpoints.OAuthRequests(_apiAccessor);
        }

        /// <summary>
        /// Creates a new <see cref="BungieApiClient">BungieApiClient.</see>
        /// </summary>
        /// <param name="config">The <see cref="BungieClientConfig">BungieClientConfig</see> containing the settings for the client.</param>
        public BungieApiClient(BungieClientConfig config) : this()
        {
            SetApiKey(config.ApiKey);
            SetUserAgent(config.UserAgent);
            SetOAuthClientId(config.OAuthClientId);
            SetOAuthClientSecret(config.OAuthClientSecret);
            SetRateLimit(config.RateLimit);
            SetRetryErrorCodes(config.RetryErrorCodes);
        }

        private void SetApiKey(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("The parameter must not be null or whitespace.", nameof(apiKey));
            }

            _apiAccessor.ApiKey = apiKey;
        }

        private void SetUserAgent(string? userAgent)
        {
            _apiAccessor.UserAgent = userAgent + " BungieSharper/" + typeof(BungieApiClient).Assembly.GetName().Version!.ToString(3) + " (+github.com/ashakoor/BungieSharper)";
        }

        private void SetOAuthClientId(uint? clientId)
        {
            OAuth.SetOAuthClientId(clientId);
        }

        private void SetOAuthClientSecret(string? clientSecret)
        {
            OAuth.SetOAuthClientSecret(clientSecret);
        }

        /// <summary>
        /// Sets the maximum number of requests per second that the client can make to the default value, 10/sec.
        /// </summary>
        public void SetRateLimit()
        {
            _apiAccessor.RequestsPerSecond = DefaultRequestsPerSecond;
        }

        /// <summary>
        /// Sets the maximum number of requests per second that the client can make.
        /// </summary>
        /// <param name="requestsPerSecond">The maximum number of requests to make per second. The absolute maximum is 50, but the official limit is 250/10sec/IP (25/sec) If you go higher than 25, you're on your own.</param>
        public void SetRateLimit(byte requestsPerSecond)
        {
            if (requestsPerSecond > MaxRequestsPerSecond)
            {
                throw new ArgumentOutOfRangeException(nameof(requestsPerSecond),
                    "\"requestsPerSecond\" must be below " + MaxRequestsPerSecond);
            }

            _apiAccessor.RequestsPerSecond = requestsPerSecond;
        }

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle, if provided)
        /// </summary>
        /// <param name="errorCodes">The list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> to automatically retry upon receipt.</param>
        public void SetRetryErrorCodes(HashSet<PlatformErrorCodes>? errorCodes)
        {
            _apiAccessor.RetryErrorCodes = errorCodes ?? new HashSet<PlatformErrorCodes>();
        }

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle, if provided)
        /// </summary>
        /// <param name="errorCodes">The list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> to automatically retry upon receipt. Will be converted to a <see cref="HashSet{PlatformErrorCodes}">HashSet&lt;PlatformErrorCodes&gt;</see></param>
        public void SetRetryErrorCodes(IEnumerable<PlatformErrorCodes>? errorCodes)
        {
            SetRetryErrorCodes(errorCodes?.ToHashSet());
        }

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle, if provided)
        /// </summary>
        /// <param name="errorCodes">The list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> to automatically retry upon receipt. Will be converted to a <see cref="HashSet{PlatformErrorCodes}">HashSet&lt;PlatformErrorCodes&gt;</see></param>
        public void SetRetryErrorCodes(params PlatformErrorCodes[]? errorCodes)
        {
            SetRetryErrorCodes(errorCodes?.ToHashSet());
        }

        /// <summary>
        /// Downloads the file at the URI (relative to bungie.net)
        /// </summary>
        /// <param name="uri">The URI of the file to download, relative to https://stats.bungie.net/ </param>
        /// <param name="fileStream">The <see cref="FileStream">filestream</see> to download the content to.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task DownloadFile(string uri, FileStream fileStream, CancellationToken cancelToken = default)
        {
            return DownloadFile(new Uri(uri, UriKind.Relative), fileStream, cancelToken);
        }

        /// <summary>
        /// Downloads the file at the URI (relative to bungie.net)
        /// </summary>
        /// <param name="uri">The URI of the file to download, relative to https://stats.bungie.net/ </param>
        /// <param name="fileStream">The <see cref="FileStream">filestream</see> to download the content to.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public async Task DownloadFile(Uri uri, FileStream fileStream, CancellationToken cancelToken = default)
        {
            var stream = await _apiAccessor.GetStream(uri, cancelToken);
            await stream.CopyToAsync(fileStream, cancelToken);
        }

        /// <summary>
        /// Downloads the content at the URI (relative to bungie.net) as a string.
        /// </summary>
        /// <param name="uri">The URI of the string to download, relative to https://stats.bungie.net/ </param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        /// <returns>The content at the URI, in string form.</returns>
        public Task<string> DownloadString(string uri, CancellationToken cancelToken = default)
        {
            return DownloadString(new Uri(uri, UriKind.Relative), cancelToken);
        }

        /// <summary>
        /// Downloads the content at the URI (relative to bungie.net) as a string.
        /// </summary>
        /// <param name="uri">The URI of the string to download, relative to https://stats.bungie.net/ </param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        /// <returns>The content at the URI, in string form.</returns>
        public Task<string> DownloadString(Uri uri, CancellationToken cancelToken = default)
        {
            if (uri.IsAbsoluteUri) throw new ArgumentException("The URI must be relative.", nameof(uri));

            return _apiAccessor.GetString(uri, cancelToken);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _apiAccessor.Dispose();
        }
    }
}