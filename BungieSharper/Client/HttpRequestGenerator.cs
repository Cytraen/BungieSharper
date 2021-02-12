using System;
using System.Linq;
using System.Net.Http;

namespace BungieSharper.Client
{
    internal static class HttpRequestGenerator
    {
<<<<<<< HEAD
        internal static string MakeQuerystring(params string[] queries)
        {
=======
        internal static string MakeQuerystring(params string?[]? queries)
        {
            if (queries is null || !queries.Any())
            {
                return string.Empty;
            }

>>>>>>> rewrite
            var qString = string.Join("&", queries.Where(x => x != null));
            if (qString != string.Empty)
            {
                return "?" + qString;
            }

            return string.Empty;
        }

<<<<<<< HEAD
        internal static HttpRequestMessage MakeApiRequestMessage(Uri uri, HttpContent httpContent, HttpMethod httpMethod, string authToken, AuthHeaderType authType)
=======
        internal static HttpRequestMessage MakeApiRequestMessage(Uri uri, HttpContent? httpContent, HttpMethod httpMethod, string? authToken, AuthHeaderType authType)
>>>>>>> rewrite
        {
            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = uri,
                Content = httpContent
            };

            if (!(string.IsNullOrWhiteSpace(authToken) || authType == AuthHeaderType.None))
            {
                request.Headers.Add("Authorization", authType.ToString() + " " + authToken);
            }

            return request;
        }
    }
}