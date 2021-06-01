using BungieSharper.Entities.Exceptions;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities
{
    public class ApiResponse
    {
        public PlatformErrorCodes ErrorCode { get; set; }

        public int ThrottleSeconds { get; set; }

        public string ErrorStatus { get; set; }

        public string Message { get; set; }

        public Dictionary<string, string> MessageData { get; set; }

        public string? DetailedErrorTrace { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Response { get; set; }
    }

    public class TokenResponse
    {
        /// <summary>
        /// The access token, to be sent with authenticated requests
        /// </summary>
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }

        /// <summary>
        /// Always "Bearer"
        /// </summary>
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        /// <summary>
        /// The number of seconds before the access token expires
        /// </summary>
        [JsonPropertyName("expires_in")]
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// The refresh token, to be used to refresh the <see cref="AccessToken"/> (for "confidential" clients only)
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        /// <summary>
        /// The number of seconds before the refresh token expires
        /// </summary>
        [JsonPropertyName("refresh_expires_in")]
        public long? RefreshExpiresIn { get; set; }

        /// <summary>
        /// The Bungie.net (membership type BungieNext / 254) membership ID of the authenticated user
        /// </summary>
        [JsonPropertyName("membership_id")]
        public long? MembershipId { get; set; }

        /// <summary>
        /// The error, if there is one
        /// </summary>
        [JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// A (hopefully) more detailed description of the error, if there is one
        /// </summary>
        [JsonPropertyName("error_description")]
        public string? ErrorDescription { get; set; }
    }
}