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

namespace BungieSharper.Client
{
    public class BungieBaseException : Exception
    {
        public ApiResponse? ApiResponse { get; }

        internal BungieBaseException()
        {
        }

        internal BungieBaseException(string message) : base(message)
        {
        }

        internal BungieBaseException(string message, ApiResponse apiResponse) : base(message)
        {
            ApiResponse = apiResponse;
        }
    }

    public class ContentNotJsonException : BungieBaseException
    {
        internal ContentNotJsonException() : base()
        {
        }

        internal ContentNotJsonException(string message) : base(message)
        {
        }

        internal ContentNotJsonException(string message, ApiResponse apiResponse) : base(message, apiResponse)
        {
        }
    }

    public class ContentNullJsonException : BungieBaseException
    {
        internal ContentNullJsonException() : base()
        {
        }

        internal ContentNullJsonException(string message) : base(message)
        {
        }
    }

    public class NonRetryErrorCodeException : BungieBaseException
    {
        internal NonRetryErrorCodeException() : base()
        {
        }

        internal NonRetryErrorCodeException(string message) : base(message)
        {
        }

        internal NonRetryErrorCodeException(string message, ApiResponse apiResponse) : base(message, apiResponse)
        {
        }
    }

    public class NullResponseException : BungieBaseException
    {
        internal NullResponseException() : base()
        {
        }

        internal NullResponseException(string message) : base(message)
        {
        }

        internal NullResponseException(string message, ApiResponse apiResponse) : base(message, apiResponse)
        {
        }
    }
}