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
        private const byte MaxRequestsPerSecond = 50;
        private const byte DefaultRequestsPerSecond = 10;

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
        /// Creates a new <see cref="BungieApiClient">BungieApiClient</see> without an API key.
        /// </summary>
        public BungieApiClient()
        {
            _apiAccessor = new ApiAccessor();
            SetRateLimit(DefaultRequestsPerSecond);

            Api = new Endpoints.Endpoints(_apiAccessor);
            OAuth = new Endpoints.OAuthRequests(_apiAccessor);
        }

        /// <summary>
        /// Creates a new <see cref="BungieApiClient">BungieApiClient.</see>
        /// </summary>
        /// <param name="apiKey">The API key to set in the X-API-Key header.</param>
        public BungieApiClient(string apiKey) : this()
        {
            SetApiKey(apiKey);
        }

        /// <summary>
        /// Creates a new <see cref="BungieApiClient">BungieApiClient.</see>
        /// </summary>
        /// <param name="apiKey">The API key to set in the X-API-Key header.</param>
        /// <param name="userAgent">The value to be set in the "User-Agent" header. Format should be {ProductName}/{ProductVersion} (+{contact info}) e.g. BungieSharper/v1.0.0 (+github.com/ashakoor/BungieSharper)</param>
        public BungieApiClient(string apiKey, string userAgent) : this(apiKey)
        {
            SetUserAgent(userAgent);
        }

        /// <summary>
        /// Sets the client's "X-API-Key" header, necessary for every API request except <see cref="Endpoints.Endpoints.Destiny2_GetDestinyManifest">Destiny2.GetDestinyManifest</see>
        /// </summary>
        /// <param name="apiKey">The API key to set in the X-API-Key header.</param>
        public void SetApiKey(string apiKey)
        {
            _apiAccessor.SetApiKey(apiKey);
        }

        /// <summary>
        /// Removes the "User-Agent" header from the client, if there is one.
        /// </summary>
        public void SetUserAgent()
        {
            _apiAccessor.RemoveUserAgent();
        }

        /// <summary>
        /// Sets the client's "User-Agent" header. You do not need to append BungieSharper, it will be done for you.
        /// </summary>
        /// <param name="userAgent">The value of the "User-Agent" header. Format should be {ProductName}/{ProductVersion} (+{contact info}) e.g. BungieSharper/v1.0.0 (+github.com/ashakoor/BungieSharper)</param>
        public void SetUserAgent(string userAgent)
        {
            _apiAccessor.RemoveUserAgent();
            _apiAccessor.AddUserAgent(userAgent + " BungieSharper/" + typeof(BungieApiClient).Assembly.GetName().Version!.ToString(3) + " (+github.com/ashakoor/BungieSharper)");
        }

        /// <summary>
        /// Sets the maximum number of requests per second that the client can make to the default value, 10/sec.
        /// </summary>
        public void SetRateLimit()
        {
            _apiAccessor.SetRateLimit(DefaultRequestsPerSecond);
        }

        /// <summary>
        /// Sets the maximum number of requests per second that the client can make.
        /// </summary>
        /// <param name="requestsPerSecond">The maximum number of requests to make per second. The absolute maximum is 50, but the official limit is 250/10sec/IP (25/sec) If you go higher than 25, you're on your own.</param>
        public void SetRateLimit(byte requestsPerSecond)
        {
            _apiAccessor.SetRateLimit(requestsPerSecond <= MaxRequestsPerSecond ? requestsPerSecond : throw new ArgumentOutOfRangeException(nameof(requestsPerSecond), "\"requestsPerSecond\" must be below " + MaxRequestsPerSecond));
        }

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle, if provided)
        /// </summary>
        /// <param name="errorCodes">The list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> to automatically retry upon receipt.</param>
        public void SetRetryErrorCodes(List<PlatformErrorCodes> errorCodes)
        {
            _apiAccessor.SetRetryErrorCodes(errorCodes);
        }

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle, if provided)
        /// </summary>
        /// <param name="errorCodes">The list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> to automatically retry upon receipt. Will be converted to a <see cref="List{PlatformErrorCodes}">List&lt;PlatformErrorCodes&gt;</see></param>
        public void SetRetryErrorCodes(IEnumerable<PlatformErrorCodes> errorCodes)
        {
            SetRetryErrorCodes(errorCodes.ToList());
        }

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle, if provided)
        /// </summary>
        /// <param name="errorCodes">The list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> to automatically retry upon receipt. Will be converted to a <see cref="List{PlatformErrorCodes}">List&lt;PlatformErrorCodes&gt;</see></param>
        public void SetRetryErrorCodes(params PlatformErrorCodes[] errorCodes)
        {
            SetRetryErrorCodes(errorCodes.ToList());
        }

        /// <summary>
        /// Sets the client's OAuth client ID
        /// </summary>
        /// <param name="clientId">The client's OAuth client ID</param>
        public void SetOAuthClientId(uint clientId)
        {
            OAuth.SetOAuthClientId(clientId);
        }

        /// <summary>
        /// Sets the client's OAuth client secret
        /// </summary>
        /// <param name="clientSecret">The client's OAuth client secret</param>
        public void SetOAuthClientSecret(string clientSecret)
        {
            OAuth.SetOAuthClientSecret(clientSecret);
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