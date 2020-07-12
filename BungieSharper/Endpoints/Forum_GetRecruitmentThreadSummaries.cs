using BungieSharper.Client;
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
        /// Allows the caller to get a list of to 25 recruitment thread summary information objects.
        /// </summary>
        public async Task<IEnumerable<Schema.Forum.ForumRecruitmentDetail>> Forum_GetRecruitmentThreadSummaries(IEnumerable<long> requestBody)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Forum.ForumRecruitmentDetail>>(
                new Uri($"Forum/Recruit/Summaries/", UriKind.Relative),
                null, new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post
                ).ConfigureAwait(false);
        }
    }
}