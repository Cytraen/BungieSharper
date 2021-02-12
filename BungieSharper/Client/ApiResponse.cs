using BungieSharper.Entities.Exceptions;
using System.Collections.Generic;

namespace BungieSharper.Client
{
    public class ApiResponse
    {
        public PlatformErrorCodes ErrorCode { get; set; }

        public long ThrottleSeconds { get; set; }

        public string ErrorStatus { get; set; }

        public string Message { get; set; }

        public Dictionary<string, string> MessageData { get; set; }

        public string DetailedErrorTrace { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Response { get; set; }
    }
}