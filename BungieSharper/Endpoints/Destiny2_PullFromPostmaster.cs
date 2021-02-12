using BungieSharper.Client;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
>>>>>>> rewrite
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Extract an item from the Postmaster, with whatever implications that may entail. You must have a valid Destiny account. You must also pass BOTH a reference AND an instance ID if it's an instanced item.
<<<<<<< HEAD
        /// </summary>
        public async Task<int> Destiny2_PullFromPostmaster(Schema.Destiny.Requests.Actions.DestinyPostmasterTransferRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): MoveEquipDestinyItems
        /// </summary>
        public async Task<int> Destiny2_PullFromPostmaster(Entities.Destiny.Requests.Actions.DestinyPostmasterTransferRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"Destiny2/Actions/Items/PullFromPostmaster/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}