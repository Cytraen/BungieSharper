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