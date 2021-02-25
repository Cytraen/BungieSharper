using BungieSharper.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void SetOAuthClientId(ushort clientId)
        {
            OAuth.SetOAuthClientId(clientId);
        }

        public void SetOAuthClientSecret(string clientSecret)
        {
            OAuth.SetOAuthClientSecret(clientSecret);
        }

        public void Dispose() => _apiAccessor.Dispose();
    }
}