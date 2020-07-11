using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get topics from any forum.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetTopicsPaged(Schema.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, long group, string locales, int page, int pageSize, Schema.Forum.ForumTopicsQuickDateEnum quickDate, Schema.Forum.ForumTopicsSortEnum sort, string tagstring)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/", null, null, HttpMethod.Get
                );
        }
    }
}