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
        private const byte SimultaneousRequests = 2;

        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _semaphore;
        private readonly JsonSerializerOptions _serializerOptions;
        private TimeSpan _msPerRequest;
        private List<PlatformErrorCodes> _retryErrorCodes;

        public void Dispose() => _httpClient.Dispose();

        internal ApiAccessor()
        {
            _semaphore = new SemaphoreSlim(SimultaneousRequests, SimultaneousRequests);
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
            _msPerRequest = TimeSpan.FromMilliseconds(1000.0 / requestsPerSecond * SimultaneousRequests);
        }

        internal async Task<T> ApiRequestAsync<T>(Uri uri, HttpContent httpContent, HttpMethod httpMethod, string authToken, AuthHeaderType authType, CancellationToken cancelToken)
        {
            var semaphoreTask = _semaphore.WaitAsync(cancelToken).ConfigureAwait(false);
            var httpRequestMessage = HttpRequestGenerator.MakeApiRequestMessage(uri, httpContent, httpMethod, authToken, authType);
            await semaphoreTask;

            while (true)
            {
                var throttleTask = Task.Delay(_msPerRequest, cancelToken);
                var httpResponseMessage = await GetApiResponseAsync(httpRequestMessage, cancelToken).ConfigureAwait(false);
                
                if (cancelToken.IsCancellationRequested)
                {
                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    throw new OperationCanceledException();
                }

                if (httpResponseMessage.Content.Headers.ContentType.MediaType != "application/json")
                {
                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    throw new ContentNotJsonException(httpResponseMessage);
                }

                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(
                    await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false), _serializerOptions
                    );

                if (apiResponse is null)
                {
                    throw new ContentNullJsonException(httpResponseMessage);
                }

                if (apiResponse.ErrorCode != PlatformErrorCodes.Success)
                {
                    if (ApiRetry(apiResponse.ErrorCode))
                    {
                        await throttleTask.ConfigureAwait(false);
                        await Task.Delay((int)apiResponse.ThrottleSeconds, cancelToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);

                        throw new NonRetryErrorCodeException(apiResponse);
                    }
                }
                else
                {
                    if (apiResponse.Response == null)
                    {
                        await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                        throw new NullResponseException(apiResponse);
                    }

                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    return apiResponse.Response;
                }
            }
        }

        internal async Task<TokenRequestResponse> ApiTokenRequestResponseAsync(Uri uri, HttpContent httpContent, HttpMethod httpMethod, string authToken, AuthHeaderType authType,  CancellationToken cancelToken)
        {
            var semaphoreTask = _semaphore.WaitAsync(cancelToken).ConfigureAwait(false);
            var httpRequestMessage = HttpRequestGenerator.MakeApiRequestMessage(uri, httpContent, httpMethod, authToken, authType);
            await semaphoreTask;

            while (true)
            {
                var throttleTask = Task.Delay(_msPerRequest, cancelToken);
                var httpResponseMessage = await GetApiResponseAsync(httpRequestMessage, cancelToken).ConfigureAwait(false);
                
                if (cancelToken.IsCancellationRequested)
                {
                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    throw new OperationCanceledException();
                }

                if (httpResponseMessage.Content.Headers.ContentType.MediaType != "application/json")
                {
                    await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                    throw new ContentNotJsonException(httpResponseMessage);
                }

                var apiResponse = JsonSerializer.Deserialize<TokenRequestResponse>(
                    await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false), _serializerOptions
                    );

                if (apiResponse is null)
                {
                    throw new ContentNullJsonException(httpResponseMessage);
                }

                await AwaitThrottleAndReleaseSemaphore(throttleTask, _semaphore).ConfigureAwait(false);
                return apiResponse;
            }
        }

        private async Task<HttpResponseMessage> GetApiResponseAsync(HttpRequestMessage request, CancellationToken cancelToken)
        {
            return await _httpClient.SendAsync(request, cancelToken).ConfigureAwait(false);
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