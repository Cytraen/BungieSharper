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
        public Entities.ApiResponse ApiResponseMsg { get; }

        internal BungieBaseApiResponseException(Entities.ApiResponse apiResponseMsg, string message) : base(message)
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

        internal NonRetryErrorCodeException(Entities.ApiResponse apiResponse, string message = DefaultErrorMessage) : base(apiResponse, message)
        {
        }
    }

    public class NullResponseException : BungieBaseApiResponseException
    {
        private const string DefaultErrorMessage = "The response provided by the Bungie API was null or empty.";

        internal NullResponseException(Entities.ApiResponse apiResponse, string message = DefaultErrorMessage) : base(apiResponse, message)
        {
        }
    }
}