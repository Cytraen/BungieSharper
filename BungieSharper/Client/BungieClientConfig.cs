using BungieSharper.Entities.Exceptions;
using System;
using System.Collections.Generic;

namespace BungieSharper.Client
{
    /// <summary>
    /// Optional configuration class for <see cref="BungieApiClient">BungieApiClient</see>.
    /// </summary>
    public class BungieClientConfig
    {
        private string _apiKey = string.Empty;

        /// <summary>
        /// The API key to set in the X-API-Key header.
        /// </summary>
        /// <remarks> If you don't have one, you can get one at https://www.bungie.net/en/Application/ </remarks>
        public string ApiKey
        {
            internal get
            {
                return _apiKey;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _apiKey = value;
            }
        }

        private string? _userAgent;

        /// <summary>
        /// The value of the "User-Agent" header. If <c>null</c>, it will be removed/omitted.
        /// </summary>
        /// <remarks>Format should be {ProductName}/{ProductVersion} (+{contact info}) e.g.: YourAppName/v1.2.3 (+your@email.here)</remarks>
        public string? UserAgent
        {
            internal get
            {
                return _userAgent;
            }

            set
            {
                _userAgent = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }

        private uint? _oAuthClientId;

        /// <summary>
        /// The client's OAuth client ID
        /// </summary>
        public uint? OAuthClientId
        {
            internal get
            {
                return _oAuthClientId;
            }

            set
            {
                _oAuthClientId = value;
            }
        }

        private string? _oAuthClientSecret;

        /// <summary>
        /// The client's OAuth client secret
        /// </summary>
        /// <remarks>Only for confidential clients</remarks>
        public string? OAuthClientSecret
        {
            internal get
            {
                return _oAuthClientSecret;
            }

            set
            {
                _oAuthClientSecret = value;
            }
        }

        private byte _requestsPerSecond = BungieApiClient.DefaultRequestsPerSecond;

        /// <summary>
        /// The maximum number of Bungie API requests to make per second.
        /// </summary>
        /// <remarks>The official limit is 250/10sec/IP (25/sec.) The absolute maximum is 50, but if you go higher than 25, you're on your own.</remarks>
        public byte RateLimit
        {
            internal get
            {
                return _requestsPerSecond;
            }

            set
            {
                if (value > BungieApiClient.MaxRequestsPerSecond)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "The maximum number of requests per second is " + BungieApiClient.MaxRequestsPerSecond);
                }

                _requestsPerSecond = value;
            }
        }

        private HashSet<PlatformErrorCodes> _retryErrorCodes = new()
        {
            PlatformErrorCodes.ThrottleLimitExceeded,
            PlatformErrorCodes.ThrottleLimitExceededMinutes,
            PlatformErrorCodes.ThrottleLimitExceededMomentarily,
            PlatformErrorCodes.ThrottleLimitExceededSeconds,
            PlatformErrorCodes.PerEndpointRequestThrottleExceeded,
            PlatformErrorCodes.PerApplicationThrottleExceeded,
            PlatformErrorCodes.PerApplicationAnonymousThrottleExceeded,
            PlatformErrorCodes.PerApplicationAuthenticatedThrottleExceeded,
            PlatformErrorCodes.PerUserThrottleExceeded,
            PlatformErrorCodes.MessagingSendThrottle,
            PlatformErrorCodes.GroupCultureThrottle,
            PlatformErrorCodes.DestinyThrottledByGameServer,
            PlatformErrorCodes.RAFGenerateThrottled,
            PlatformErrorCodes.RAFRedeemThrottled
        };

        /// <summary>
        /// Sets the list of <see cref="PlatformErrorCodes">PlatformErrorCodes</see> that will automatically be retried on (after waiting for the throttle from the API response, if provided)
        /// </summary>
        public HashSet<PlatformErrorCodes> RetryErrorCodes
        {
            internal get
            {
                return _retryErrorCodes;
            }

            set
            {
                _retryErrorCodes = value;
            }
        }
    }
}