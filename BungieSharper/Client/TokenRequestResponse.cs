namespace BungieSharper.Client
{
    public class TokenRequestResponse
    {
        public string access_token { get; set; }

        /// <summary>
        /// Always "Bearer"
        /// </summary>
        public string token_type { get; set; }

        public long? expires_in { get; set; }

        public string refresh_token { get; set; }

        /// <summary>
        /// The number of seconds before the refresh token expires
        /// </summary>
        public long? refresh_expires_in { get; set; }

        /// <summary>
        /// The Bungie.net (as in, membership type BungieNext / 254) membership ID of the authenticated user
        /// </summary>
        public long? membership_id { get; set; }

        public string error { get; set; }

        public string error_description { get; set; }
    }
}