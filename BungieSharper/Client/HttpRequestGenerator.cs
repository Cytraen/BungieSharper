using System;
using System.Linq;
using System.Net.Http;

namespace BungieSharper.Client
{
    internal static class HttpRequestGenerator
    {
        internal static string MakeQuerystring(params string?[]? queries)
        {
            if (queries is null || !queries.Any())
            {
                return string.Empty;
            }

            var qString = string.Join("&", queries.Where(x => x != null));
            if (qString != string.Empty)
            {
                return "?" + qString;
            }

            return string.Empty;
        }

        internal static HttpRequestMessage MakeApiRequestMessage(Uri uri, HttpContent? httpContent, HttpMethod httpMethod)
        {
            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = uri,
                Content = httpContent
            };

            return request;
        }

        internal static HttpRequestMessage MakeApiRequestMessage(Uri uri, HttpContent? httpContent, HttpMethod httpMethod, string? authToken)
        {
            var request = MakeApiRequestMessage(uri, httpContent, httpMethod);

            if (!string.IsNullOrWhiteSpace(authToken))
            {
                request.Headers.Add("Authorization", "Bearer " + authToken);
            }

            return request;
        }
    }
}