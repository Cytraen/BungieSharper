using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public class OAuthRequests
    {
        private const string OAuthAuthorizationUrl = "https://www.bungie.net/en/OAuth/Authorize?response_type=code&client_id=";
        private const string OAuthTokenUrl = "https://www.bungie.net/Platform/App/OAuth/Token/";

        private readonly ApiAccessor _apiAccessor;
        private uint _oAuthClientId;
        private string _oAuthClientSecret;

        internal OAuthRequests(ApiAccessor apiAccessor)
        {
            _apiAccessor = apiAccessor;
        }

        public async Task<TokenRequestResponse> GetOAuthToken(string authorizationCode, string authToken = null, AuthHeaderType tokenType = AuthHeaderType.None)
        {
            var encodedContentPairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("client_id", _oAuthClientId.ToString())
            };

            if (!string.IsNullOrWhiteSpace(_oAuthClientSecret))
            {
                encodedContentPairs.Add(new KeyValuePair<string, string>("client_secret", _oAuthClientSecret));
            }

            var encodedContent = new FormUrlEncodedContent(encodedContentPairs);

            return await _apiAccessor.ApiTokenRequestResponseAsync(new Uri(OAuthTokenUrl, UriKind.Absolute), encodedContent, HttpMethod.Post, null, AuthHeaderType.None).ConfigureAwait(false);
        }

        public async Task<TokenRequestResponse> RefreshOAuthToken(string refreshToken, string authToken = null, AuthHeaderType tokenType = AuthHeaderType.None)
        {
            var encodedContentPairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken),
                new KeyValuePair<string, string>("client_id", _oAuthClientId.ToString())
            };

            if (!string.IsNullOrWhiteSpace(_oAuthClientSecret))
            {
                encodedContentPairs.Add(new KeyValuePair<string, string>("client_secret", _oAuthClientSecret));
            }

            var encodedContent = new FormUrlEncodedContent(encodedContentPairs);

            return await _apiAccessor.ApiTokenRequestResponseAsync(new Uri(OAuthTokenUrl, UriKind.Absolute), encodedContent, HttpMethod.Post, null, AuthHeaderType.None).ConfigureAwait(false);
        }

        public string GetOAuthAuthorizationUrl()
        {
            return OAuthAuthorizationUrl + _oAuthClientId;
        }

        internal void SetOAuthClientId(uint clientId)
        {
            _oAuthClientId = clientId;
        }

        internal void SetOAuthClientSecret(string clientSecret)
        {
            _oAuthClientSecret = clientSecret;
        }
    }
}