using System.Text.Json.Serialization;

namespace BungieSharper.Client
{
    public class TokenRequestResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Always "Bearer"
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public long? ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The number of seconds before the refresh token expires
        /// </summary>
        [JsonPropertyName("refresh_expires_in")]
        public long? RefreshExpiresIn { get; set; }

        /// <summary>
        /// The Bungie.net (as in, membership type BungieNext / 254) membership ID of the authenticated user
        /// </summary>
        [JsonPropertyName("membership_id")]
        public long? MembershipId { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }
    }
}