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
        private ContentNotJsonException(HttpResponseMessage httpResponse, string message) : base(httpResponse, message)
        {
        }

        internal static ContentNotJsonException NewContentNotJsonException(HttpResponseMessage httpResponse)
        {
            return new(
                httpResponse,
                "The Bungie API returned content that was of type " + httpResponse.Content.Headers.ContentType?.MediaType + " instead of \"application/json\""
                );
        }
    }

    public class ContentNullJsonException : BungieBaseHttpResponseException
    {
        private ContentNullJsonException(HttpResponseMessage httpResponse, string message) : base(httpResponse, message)
        {
        }

        internal static ContentNullJsonException NewContentNullJsonException(HttpResponseMessage httpResponse)
        {
            return new(
                httpResponse,
                "The response contained JSON content that was null or empty."
                );
        }
    }

    public class NonRetryErrorCodeException : BungieBaseApiResponseException
    {
        private NonRetryErrorCodeException(Entities.ApiResponse apiResponse, string message) : base(apiResponse, message)
        {
        }

        internal static NonRetryErrorCodeException NewNonRetryErrorCodeException(Entities.ApiResponse apiResponse)
        {
            return new(
                apiResponse,
                $"The Bungie API returned an error code ({(int)apiResponse.ErrorCode}: {apiResponse.ErrorCode}) that will not be retried on."
                );
        }
    }

    public class NullResponseException : BungieBaseApiResponseException
    {
        private NullResponseException(Entities.ApiResponse apiResponse, string message) : base(apiResponse, message)
        {
        }

        internal static NullResponseException NewNullResponseException(Entities.ApiResponse apiResponse)
        {
            return new(
                apiResponse,
                "The response provided by the Bungie API was null or empty."
                );
        }
    }
}