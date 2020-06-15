using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPostAndParent(long childPostId, string showbanned)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"Forum/GetPostAndParent/{childPostId}/", null, null, HttpMethod.Get
                );
        }
    }
}