using BungieSharper.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Client
{
    public class BungieApiClient : IDisposable
    {
        private const ushort MaxRequestsPerSecond = 25;
        private const ushort DefaultRequestsPerSecond = 15;

        private readonly ApiAccessor _apiAccessor;

        public Endpoints.Endpoints Api { get; }

        public Endpoints.OAuthRequests OAuth { get; }

        public BungieApiClient()
        {
            _apiAccessor = new ApiAccessor();
            SetRateLimit(DefaultRequestsPerSecond);

            Api = new Endpoints.Endpoints(_apiAccessor);
            OAuth = new Endpoints.OAuthRequests(_apiAccessor);
        }

        public BungieApiClient(string apiKey) : this()
        {
            SetApiKey(apiKey);
        }

        public BungieApiClient(string apiKey, string userAgent) : this(apiKey)
        {
            SetUserAgent(userAgent);
        }

        public void SetApiKey(string apiKey)
        {
            _apiAccessor.SetApiKey(apiKey);
        }

        public void SetUserAgent(string userAgent)
        {
            _apiAccessor.SetUserAgent(userAgent + " BungieSharper/" + typeof(BungieApiClient).Assembly.GetName().Version!.ToString(3) + " (+github.com/ashakoor/BungieSharper)");
        }

        public void SetRateLimit()
        {
            _apiAccessor.SetRateLimit(DefaultRequestsPerSecond);
        }

        public void SetRateLimit(ushort requestsPerSecond)
        {
            _apiAccessor.SetRateLimit(requestsPerSecond < MaxRequestsPerSecond ? requestsPerSecond : MaxRequestsPerSecond);
        }

        public void SetRetryErrorCodes(List<PlatformErrorCodes> errorCodes)
        {
            _apiAccessor.SetRetryErrorCodes(errorCodes);
        }

        public void SetRetryCodes(IEnumerable<PlatformErrorCodes> errorCodes)
        {
            SetRetryErrorCodes(errorCodes.ToList());
        }

        public void SetRetryCodes(params PlatformErrorCodes[] errorCodes)
        {
            SetRetryErrorCodes(errorCodes.ToList());
        }

        public void SetOAuthClientId(uint clientId)
        {
            OAuth.SetOAuthClientId(clientId);
        }

        public void SetOAuthClientSecret(string clientSecret)
        {
            OAuth.SetOAuthClientSecret(clientSecret);
        }

        public Task DownloadFile(string uri, FileStream fileStream, CancellationToken cancelToken = default)
        {
            return DownloadFile(new Uri(uri, UriKind.Relative), fileStream, cancelToken);
        }

        public async Task DownloadFile(Uri uri, FileStream fileStream, CancellationToken cancelToken = default)
        {
            var stream = await _apiAccessor.GetStream(uri, cancelToken);
            await stream.CopyToAsync(fileStream, cancelToken);
        }

        public Task<string> DownloadString(string uri, CancellationToken cancelToken = default)
        {
            return DownloadString(new Uri(uri, UriKind.Relative), cancelToken);
        }

        public Task<string> DownloadString(Uri uri, CancellationToken cancelToken = default)
        {
            return _apiAccessor.GetString(uri, cancelToken);
        }

        public void Dispose()
        {
            _apiAccessor.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}