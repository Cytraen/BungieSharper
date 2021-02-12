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
        /// Set the Lock State for an instanced item. You must have a valid Destiny Account.
<<<<<<< HEAD
        /// </summary>
        public async Task<int> Destiny2_SetItemLockState(Schema.Destiny.Requests.Actions.DestinyItemStateRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
=======
        /// Requires OAuth2 scope(s): MoveEquipDestinyItems
        /// </summary>
        public async Task<int> Destiny2_SetItemLockState(Entities.Destiny.Requests.Actions.DestinyItemStateRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
>>>>>>> rewrite
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"Destiny2/Actions/Items/SetLockState/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}