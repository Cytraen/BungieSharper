using BungieSharper.Entities;
using System;
using System.Net.Http;

namespace BungieSharper.Client;

public class BungieBaseException : Exception
{
    internal BungieBaseException(string message) : base(message)
    {
    }
}

public class BungieBaseHttpResponseException : BungieBaseException
{
    internal BungieBaseHttpResponseException(HttpResponseMessage httpResponseMsg, string message) : base(message)
    {
        HttpResponseMsg = httpResponseMsg;
    }

    public HttpResponseMessage HttpResponseMsg { get; }
}

public class BungieBaseApiResponseException : BungieBaseException
{
    internal BungieBaseApiResponseException(ApiResponse apiResponseMsg, string message) : base(message)
    {
        ApiResponseMsg = apiResponseMsg;
    }

    public ApiResponse ApiResponseMsg { get; }
}

public class BungieResponseContentNotJsonException : BungieBaseHttpResponseException
{
    internal BungieResponseContentNotJsonException(HttpResponseMessage httpResponse, string message) : base(
        httpResponse, message)
    {
    }

    internal BungieResponseContentNotJsonException(HttpResponseMessage httpResponse) : this(httpResponse,
        $"The Bungie API returned content that was of type {httpResponse.Content.Headers.ContentType?.MediaType} instead of \"application/json\"")
    {
    }
}

public class BungieResponseContentEmptyJsonException : BungieBaseHttpResponseException
{
    internal BungieResponseContentEmptyJsonException(HttpResponseMessage httpResponse, string message) : base(
        httpResponse, message)
    {
    }

    internal BungieResponseContentEmptyJsonException(HttpResponseMessage httpResponse) : this(httpResponse,
        "The Bungie API response contained empty or null JSON.")
    {
    }
}

public class BungieApiNoRetryException : BungieBaseApiResponseException
{
    internal BungieApiNoRetryException(ApiResponse apiResponse, string message) : base(apiResponse, message)
    {
    }

    internal BungieApiNoRetryException(ApiResponse apiResponse) : this(apiResponse,
        $"The Bungie API returned an error code ({(int)apiResponse.ErrorCode}: {apiResponse.ErrorCode}) that will not be retried on.")
    {
    }
}

public class BungieApiNullResponseException : BungieBaseApiResponseException
{
    internal BungieApiNullResponseException(ApiResponse apiResponse, string message) : base(apiResponse, message)
    {
    }

    internal BungieApiNullResponseException(ApiResponse apiResponse) : this(apiResponse,
        "The \"Response\" property of the API response was null or empty.")
    {
    }
}