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
using System.Linq;

namespace BungieSharper.Client
{
    public class BungieApiClient : IDisposable
    {
        private const ushort DefaultRequestsPerSecond = 15;
        private const ushort MaxRequestsPerSecond = 25;

        private readonly ApiAccessor _apiAccessor;

        public Endpoints.Endpoints ClientEndpoints { get; internal set; }

        private void InitializeEndpoints()
        {
            ClientEndpoints = new Endpoints.Endpoints(_apiAccessor);
        }

        public BungieApiClient(string apiKey)
        {
            _apiAccessor = new ApiAccessor();
            _apiAccessor.SetApiKey(apiKey);
            _apiAccessor.SetRateLimit(DefaultRequestsPerSecond);
            InitializeEndpoints();
        }

        public BungieApiClient(string apiKey, string userAgent)
        {
            _apiAccessor = new ApiAccessor();
            _apiAccessor.SetApiKey(apiKey);
            _apiAccessor.SetUserAgent(userAgent);
            _apiAccessor.SetRateLimit(DefaultRequestsPerSecond);
            InitializeEndpoints();
        }

        public void SetApiKey(string apiKey)
        {
            _apiAccessor.SetApiKey(apiKey);
        }

        public void SetUserAgent(string userAgent)
        {
            _apiAccessor.SetUserAgent(userAgent);
        }

        public void SetRateLimit()
        {
            _apiAccessor.SetRateLimit(DefaultRequestsPerSecond);
        }

        public void SetRateLimit(ushort requestsPerSecond)
        {
            _apiAccessor.SetRateLimit(requestsPerSecond < MaxRequestsPerSecond ? requestsPerSecond : MaxRequestsPerSecond);
        }

        public void SetRetryCodes(List<PlatformErrorCodes> errorCodes)
        {
            _apiAccessor.SetRetryCodes(errorCodes);
        }

        public static void SetRetryCodes(IEnumerable<PlatformErrorCodes> errorCodes)
        {
            SetRetryCodes(errorCodes.ToList());
        }

        public static void SetRetryCodes(params PlatformErrorCodes[] errorCodes)
        {
            SetRetryCodes(errorCodes.ToList());
        }

        public void Dispose() => _apiAccessor.Dispose();
    }
}