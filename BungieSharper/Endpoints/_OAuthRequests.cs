using BungieSharper.Client;
using BungieSharper.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public class OAuthRequests
{
    private const string OAuthAuthorizationUrl =
        "https://www.bungie.net/en/OAuth/Authorize?response_type=code&client_id=";

    private const string OAuthTokenUrl = "https://www.bungie.net/Platform/App/OAuth/Token/";

    private readonly ApiAccessor _apiAccessor;
    private string? _oAuthClientId;
    private string? _oAuthClientSecret;

    internal OAuthRequests(ApiAccessor apiAccessor)
    {
        _apiAccessor = apiAccessor;
    }

    /// <summary>
    ///     Use the authorization code provided by the redirect to get usable OAuth tokens.
    /// </summary>
    /// <param name="authorizationCode">
    ///     Code provided by the "code" querystring parameter when the user is redirected back to
    ///     your application.
    /// </param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    /// <returns>The OAuth token response, with a refresh token for confidential clients.</returns>
    public Task<TokenResponse> GetOAuthToken(string authorizationCode, CancellationToken cancelToken = default)
    {
        var encodedContentPairs = new List<KeyValuePair<string?, string?>>
        {
            new("grant_type", "authorization_code"),
            new("code", authorizationCode),
            new("client_id", _oAuthClientId)
        };

        if (!string.IsNullOrWhiteSpace(_oAuthClientSecret))
            encodedContentPairs.Add(new KeyValuePair<string?, string?>("client_secret", _oAuthClientSecret));

        var encodedContent = new FormUrlEncodedContent(encodedContentPairs);

        return _apiAccessor.ApiTokenRequestResponseAsync(new Uri(OAuthTokenUrl, UriKind.Absolute),
            _apiAccessor.JsonContext.TokenResponse, encodedContent,
            HttpMethod.Post, cancelToken);
    }

    /// <summary>
    ///     Refresh OAuth tokens, only usable for "confidential" clients.
    /// </summary>
    /// <param name="refreshToken">The refresh token to use.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    /// <returns>The OAuth token response.</returns>
    public Task<TokenResponse> RefreshOAuthToken(string refreshToken, CancellationToken cancelToken = default)
    {
        var encodedContentPairs = new List<KeyValuePair<string?, string?>>
        {
            new("grant_type", "refresh_token"),
            new("refresh_token", refreshToken),
            new("client_id", _oAuthClientId)
        };

        if (!string.IsNullOrWhiteSpace(_oAuthClientSecret))
            encodedContentPairs.Add(new KeyValuePair<string?, string?>("client_secret", _oAuthClientSecret));

        var encodedContent = new FormUrlEncodedContent(encodedContentPairs);

        return _apiAccessor.ApiTokenRequestResponseAsync(new Uri(OAuthTokenUrl, UriKind.Absolute),
            _apiAccessor.JsonContext.TokenResponse, encodedContent,
            HttpMethod.Post, cancelToken);
    }

    /// <summary>
    ///     Gets the OAuth authorization URL. This URL should be provided to users.
    /// </summary>
    /// <returns>The OAuth authorization URL.</returns>
    public string GetOAuthAuthorizationUrl()
    {
        if (string.IsNullOrWhiteSpace(_oAuthClientId)) throw new NullReferenceException(nameof(_oAuthClientId));

        return OAuthAuthorizationUrl + _oAuthClientId;
    }

    /// <summary>
    ///     Gets the OAuth authorization URL with the "state" querystring parameter. This URL should be provided to users.
    /// </summary>
    /// <param name="state">The value of the "state" querystring parameter.</param>
    /// <returns>The OAuth authorization URL.</returns>
    public string GetOAuthAuthorizationUrl(string state)
    {
        if (string.IsNullOrWhiteSpace(state)) return GetOAuthAuthorizationUrl();

        return GetOAuthAuthorizationUrl() + "&state=" + state;
    }

    internal void SetOAuthClientId(uint? clientId)
    {
        _oAuthClientId = clientId.ToString();
    }

    internal void SetOAuthClientSecret(string? clientSecret)
    {
        _oAuthClientSecret = clientSecret;
    }
}