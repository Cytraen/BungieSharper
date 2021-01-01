/*
   Copyright (C) 2020 ashakoor

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU Affero General Public License as
   published by the Free Software Foundation, either version 3 of the
   License or any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU Affero General Public License for more details.

   You should have received a copy of the GNU Affero General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

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
        /// the number of seconds before the refresh token expires
        /// </summary>
        public long? refresh_expires_in { get; set; }

        /// <summary>
        /// the Bungie.net membership ID of the authenticated user
        /// </summary>
        public long? membership_id { get; set; }

        public string error { get; set; }

        public string error_description { get; set; }
    }
}