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
        /// Returns community content.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> CommunityContent_GetCommunityContent(Schema.Forum.ForumTopicsCategoryFiltersEnum mediaFilter, int page, Schema.Forum.CommunityContentSortMode sort)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"CommunityContent/Get/{sort}/{mediaFilter}/{page}/", null, null, HttpMethod.Get
                );
        }
    }
}