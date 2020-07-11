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

using BungieSharper.Schema.Exceptions;
using System.Collections.Generic;

namespace BungieSharper.Client
{
    public class ApiResponse<T>
    {
        public PlatformErrorCodes ErrorCode { get; set; }

        public long ThrottleSeconds { get; set; }

        public string ErrorStatus { get; set; }

        public string Message { get; set; }

        public Dictionary<string, string> MessageData { get; set; }

        public string DetailedErrorTrace { get; set; }

        public T Response { get; set; }

        public static implicit operator ApiResponse(ApiResponse<T> response)
        {
            return new ApiResponse
            {
                ErrorCode = response.ErrorCode,
                ThrottleSeconds = response.ThrottleSeconds,
                ErrorStatus = response.ErrorStatus,
                Message = response.Message,
                MessageData = response.MessageData,
                DetailedErrorTrace = response.DetailedErrorTrace
            };
        }
    }

    public class ApiResponse
    {
        public PlatformErrorCodes ErrorCode { get; set; }

        public long ThrottleSeconds { get; set; }

        public string ErrorStatus { get; set; }

        public string Message { get; set; }

        public Dictionary<string, string> MessageData { get; set; }

        public string DetailedErrorTrace { get; set; }
    }
}