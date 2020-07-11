using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Get topics from any forum.
        /// </summary>
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetTopicsPaged(Schema.Forum.ForumTopicsCategoryFiltersEnum categoryFilter, long group, int page, int pageSize, Schema.Forum.ForumTopicsQuickDateEnum quickDate, Schema.Forum.ForumTopicsSortEnum sort, string locales = null, string tagstring = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/", null, null, HttpMethod.Get,
                locales != null ? $"locales={Uri.EscapeDataString(locales)}" : null, tagstring != null ? $"tagstring={Uri.EscapeDataString(tagstring)}" : null);
        }
    }
}