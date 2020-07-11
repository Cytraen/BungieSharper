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
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        private List<PlatformErrorCodes> _retryErrorCodes = new List<PlatformErrorCodes>
        {
            PlatformErrorCodes.ThrottleLimitExceeded,
            PlatformErrorCodes.ThrottleLimitExceededMinutes,
            PlatformErrorCodes.ThrottleLimitExceededMomentarily,
            PlatformErrorCodes.ThrottleLimitExceededSeconds
        };

        internal ApiAccessor()
        {
            this._semaphore = new SemaphoreSlim(1, 1);
            this._httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl, UriKind.Absolute)
            };
            this._serializerOptions = new JsonSerializerOptions();
            this._serializerOptions.Converters.Add(new LongToStringConverter());
        }

        internal void SetApiKey(string apiKey)
        {
            this._httpClient.DefaultRequestHeaders.Remove("X-API-Key");
            this._httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
        }

        internal void SetUserAgent(string userAgent)
        {
            this._httpClient.DefaultRequestHeaders.Remove("User-Agent");
            this._httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
        }

        internal void SetRetryCodes(List<PlatformErrorCodes> errorCodes)
        {
            this._retryErrorCodes = errorCodes;
        }

        internal void SetRateLimit(ushort requestsPerSecond) => this._msPerRequest = TimeSpan.FromMilliseconds(1000.0 / requestsPerSecond);

        internal async Task<T> ApiRequestAsync<T>(
          string url,
          string token,
          string content,
          HttpMethod method,
          params string[] queryParams)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            await this._semaphore.WaitAsync().ConfigureAwait(false);

            while (true)
            {
                var throttleTask = Task.Delay(this._msPerRequest);
                var httpResponseMessage = await ApiRequest(url, token, content, method, string.Join("&", queryParams.Where(x => x != null))).ConfigureAwait(false);

                if (httpResponseMessage.Content.Headers.ContentType.MediaType != "application/json")
                {
                    await AwaitThrottleAndReleaseSemaphore(throttleTask, this._semaphore).ConfigureAwait(false);
                    throw new ContentNotJsonException();
                }

                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) ?? throw new ContentNullJsonException(), this._serializerOptions);
                if (apiResponse.ErrorCode != PlatformErrorCodes.Success)
                {
                    if (ApiRetry(apiResponse))
                    {
                        await throttleTask.ConfigureAwait(false);
                        await Task.Delay((int)apiResponse.ThrottleSeconds).ConfigureAwait(false);
                    }
                    else
                    {
                        await AwaitThrottleAndReleaseSemaphore(throttleTask, this._semaphore).ConfigureAwait(false);

                        throw new NonRetryErrorCodeException(
                            $"'{url}' returned {apiResponse.ErrorCode}: {apiResponse.Message}", apiResponse
                            );
                    }
                }
                else
                {
                    if (apiResponse.Response == null)
                    {
                        await AwaitThrottleAndReleaseSemaphore(throttleTask, this._semaphore).ConfigureAwait(false);
                        throw new NullResponseException("'" + url + "' returned a null 'Response' property.", apiResponse);
                    }

                    await AwaitThrottleAndReleaseSemaphore(throttleTask, this._semaphore).ConfigureAwait(false);
                    return apiResponse.Response;
                }
            }
        }

        private async Task<HttpResponseMessage> ApiRequest(
          string url,
          string token,
          string content,
          HttpMethod method,
          string queryParamString)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url + (queryParamString.Length != 0 ? "?" : "") + queryParamString, UriKind.Relative)
            };
            if (token != null)
            {
                request.Headers.Add("Authorization", "Bearer " + token);
            }
            if (content != null)
            {
                request.Content = new StringContent(content);
                request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            }
            return await this._httpClient.SendAsync(request).ConfigureAwait(false);
        }

        private static async Task AwaitThrottleAndReleaseSemaphore(Task throttleTask, SemaphoreSlim semaphore)
        {
            await throttleTask.ConfigureAwait(false);
            semaphore.Release();
        }

        private bool ApiRetry<T>(ApiResponse<T> response) => this._retryErrorCodes.Contains(response.ErrorCode);

        public void Dispose() => this._httpClient.Dispose();
    }

    public class LongToStringConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                ReadOnlySpan<byte> span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out long number, out var bytesConsumed) && span.Length == bytesConsumed)
                {
                    return number;
                }

                if (long.TryParse(reader.GetString(), out number))
                {
                    return number;
                }
            }

            return reader.GetInt64();
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}