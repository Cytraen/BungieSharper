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
using System.Net.Http;

namespace BungieSharper.Client
{
    public class BungieBaseException : Exception
    {
        internal BungieBaseException(string message) : base(message)
        {
        }
    }

    public class BungieBaseHttpResponseException : BungieBaseException
    {
        public HttpResponseMessage HttpResponseMsg { get; }
        
        internal BungieBaseHttpResponseException(HttpResponseMessage httpResponseMsg, string message) : base(message)
        {
            HttpResponseMsg = httpResponseMsg;
        }
    }

    public class BungieBaseApiResponseException : BungieBaseException
    {
        public ApiResponse ApiResponseMsg { get; }

        internal BungieBaseApiResponseException(ApiResponse apiResponseMsg, string message) : base(message)
        {
            ApiResponseMsg = apiResponseMsg;
        }
    }

    public class ContentNotJsonException : BungieBaseHttpResponseException
    {
        private const string DefaultErrorMessage = "The Bungie API returned content that was not of type 'application/json'.";

        internal ContentNotJsonException(HttpResponseMessage httpResponse, string message = DefaultErrorMessage) : base(httpResponse, message)
        {
        }
    }

    public class ContentNullJsonException : BungieBaseHttpResponseException
    {
        private const string DefaultErrorMessage = "The Bungie API returned json content that was null or empty.";

        internal ContentNullJsonException(HttpResponseMessage httpResponse, string message = DefaultErrorMessage) : base(httpResponse, message)
        {
        }
    }

    public class NonRetryErrorCodeException : BungieBaseApiResponseException
    {
        private const string DefaultErrorMessage = "The Bungie API returned an error code that should not be retried on.";

        internal NonRetryErrorCodeException(ApiResponse apiResponse, string message = DefaultErrorMessage) : base(apiResponse, message)
        {
        }
    }

    public class NullResponseException : BungieBaseApiResponseException
    {
        private const string DefaultErrorMessage = "The response provided by the Bungie API was null or empty.";

        internal NullResponseException(ApiResponse apiResponse, string message = DefaultErrorMessage) : base(apiResponse, message)
        {
        }
    }
}