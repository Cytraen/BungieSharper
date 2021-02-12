<<<<<<< HEAD
﻿namespace BungieSharper.Client
{
    public class TokenRequestResponse
    {
        public string access_token { get; set; }
=======
﻿using System.Text.Json.Serialization;

namespace BungieSharper.Client
{
    public class TokenRequestResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
>>>>>>> rewrite

        /// <summary>
        /// Always "Bearer"
        /// </summary>
<<<<<<< HEAD
        public string token_type { get; set; }

        public long? expires_in { get; set; }

        public string refresh_token { get; set; }
=======
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public long? ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
>>>>>>> rewrite

        /// <summary>
        /// The number of seconds before the refresh token expires
        /// </summary>
<<<<<<< HEAD
        public long? refresh_expires_in { get; set; }
=======
        [JsonPropertyName("refresh_expires_in")]
        public long? RefreshExpiresIn { get; set; }
>>>>>>> rewrite

        /// <summary>
        /// The Bungie.net (as in, membership type BungieNext / 254) membership ID of the authenticated user
        /// </summary>
<<<<<<< HEAD
        public long? membership_id { get; set; }

        public string error { get; set; }

        public string error_description { get; set; }
=======
        [JsonPropertyName("membership_id")]
        public long? MembershipId { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }
>>>>>>> rewrite
    }
}