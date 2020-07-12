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

using System;
using System.Linq;
using System.Net.Http;

namespace BungieSharper.Client
{
    internal static class HttpRequestGenerator
    {
        internal static string MakeQuerystring(params string[] queries)
        {
            var qString = string.Join("&", queries.Where(x => x != null));
            if (qString != string.Empty)
            {
                return "?" + qString;
            }

            return string.Empty;
        }

        internal static HttpRequestMessage MakeApiRequestMessage(Uri uri, string bearerToken, HttpContent httpContent, HttpMethod httpMethod)
        {
            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = uri,
                Content = httpContent
            };

            if (bearerToken != null)
            {
                request.Headers.Add("Authorization", "Bearer " + bearerToken);
            }

            return request;
        }
    }
}