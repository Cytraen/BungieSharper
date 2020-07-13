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
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Client
{
    internal class ApiAccessor : IDisposable
    {
        private const string BaseUrl = "https://stats.bungie.net/Platform/";

        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _semaphore;
        private readonly JsonSerializerOptions _serializerOptions;
        private TimeSpan _msPerRequest;
        private List<PlatformErrorCodes> _retryErrorCodes;

        public void Dispose() => _httpClient.Dispose();

        internal ApiAccessor()
        {
            _semaphore = new SemaphoreSlim(1, 1);
            _serializerOptions = new JsonSerializerOptions();
            _serializerOptions.Converters.Add(new JsonLongConverter());

            var cookieContainer = new CookieContainer();
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                UseCookies = true
            };
            _httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(BaseUrl, UriKind.Absolute)
            };

            _retryErrorCodes = new List<PlatformErrorCodes>
            {
                PlatformErrorCodes.ThrottleLimitExceeded,
                PlatformErrorCodes.ThrottleLimitExceededMinutes,
                PlatformErrorCodes.ThrottleLimitExceededMomentarily,
                PlatformErrorCodes.ThrottleLimitExceededSeconds,
                PlatformErrorCodes.DestinyThrottledByGameServer
            };
        }

        internal void SetApiKey(string apiKey)
        {
            _httpClient.DefaultRequestHeaders.Remove("X-API-Key");
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
        }

        internal void SetUserAgent(string userAgent)
        {
            _httpClient.DefaultRequestHeaders.Remove("User-Agent");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
        }

        internal void SetRetryErrorCodes(List<PlatformErrorCodes> errorCodes)
        {
            _retryErrorCodes = errorCodes;
        }

        internal void SetRateLimit(ushort requestsPerSecond)
        {
            _msPerRequest = TimeSpan.FromMilliseconds(1000.0 / requestsPerSecond);
        }

        internal async Task<T> ApiRequestAsync<T>(Uri uri, string bearerToken, HttpContent httpContent, HttpMethod httpMethod)
        {
            var semaphoreTask = _semaphore.WaitAsync().ConfigureAwait(false);

            var httpRequestMessage = HttpRequestGenerator.MakeApiRequestMessage(uri, bearerToken, httpContent, httpMethod);

            await semaphoreTask;

            while (true)
            {
                var throttleTask = Task.Delay(_msPerRequest);
                var httpResponseMessage = await GetApiResponseAsync(httpRequestMessage).ConfigureAwait(false);

                if (httpResponseMessage.Content.Headers.ContentType.MediaType != "application/json")
                {
                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    throw new ContentNotJsonException();
                }

                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(
                    await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) ?? throw new ContentNullJsonException(),
                    _serializerOptions);

                if (apiResponse.ErrorCode != PlatformErrorCodes.Success)
                {
                    if (ApiRetry(apiResponse.ErrorCode))
                    {
                        await throttleTask.ConfigureAwait(false);
                        await Task.Delay((int)apiResponse.ThrottleSeconds).ConfigureAwait(false);
                    }
                    else
                    {
                        await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);

                        throw new NonRetryErrorCodeException(
                            $"'{uri.OriginalString}' returned {apiResponse.ErrorCode}: {apiResponse.Message}", apiResponse
                        );
                    }
                }
                else
                {
                    if (apiResponse.Response == null)
                    {
                        await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                        throw new NullResponseException($"'{uri.OriginalString}' returned a null 'Response' property.", apiResponse);
                    }

                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    return apiResponse.Response;
                }
            }
        }

        internal async Task<TokenRequestResponse> ApiTokenRequestResponseAsync(Uri uri, string bearerToken, HttpContent httpContent, HttpMethod httpMethod)
        {
            var semaphoreTask = _semaphore.WaitAsync().ConfigureAwait(false);

            var httpRequestMessage = HttpRequestGenerator.MakeApiRequestMessage(uri, bearerToken, httpContent, httpMethod);

            await semaphoreTask;

            while (true)
            {
                var throttleTask = Task.Delay(_msPerRequest);
                var httpResponseMessage = await GetApiResponseAsync(httpRequestMessage).ConfigureAwait(false);

                if (httpResponseMessage.Content.Headers.ContentType.MediaType != "application/json")
                {
                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    throw new ContentNotJsonException();
                }

                var apiResponse = JsonSerializer.Deserialize<TokenRequestResponse>(
                    await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) ?? throw new ContentNullJsonException(),
                    _serializerOptions);

                return apiResponse;
            }
        }

        private async Task<HttpResponseMessage> GetApiResponseAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request).ConfigureAwait(false);
        }

        private static async Task AwaitThrottleAndReleaseSemaphore(Task throttleTask, SemaphoreSlim semaphore)
        {
            await throttleTask.ConfigureAwait(false);
            semaphore.Release();
        }

        private bool ApiRetry(PlatformErrorCodes errorCode)
        {
            return _retryErrorCodes.Contains(errorCode);
        }
    }
}