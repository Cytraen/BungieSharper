using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a list of possible users based on the search string
        /// </summary>
        public async Task<IEnumerable<Schema.User.GeneralUser>> User_SearchUsers(string q = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.User.GeneralUser>>(
                new Uri($"User/SearchUsers/" + HttpRequestGenerator.MakeQuerystring(q != null ? $"q={Uri.EscapeDataString(q)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}