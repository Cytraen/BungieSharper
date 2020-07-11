using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets the specified forum poll.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPoll(long topicId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"Forum/Poll/{topicId}/", null, null, HttpMethod.Get
                );
        }
    }
}