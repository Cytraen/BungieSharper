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
        /// Gets tag suggestions based on partial text entry, matching them with other tags previously used in the forums.
        /// </summary>
        public async Task<IEnumerable<Schema.Tags.Models.Contracts.TagResponse>> Forum_GetForumTagSuggestions(string partialtag = null)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Tags.Models.Contracts.TagResponse>>(
                $"Forum/GetForumTagSuggestions/", null, null, HttpMethod.Get,
                partialtag != null ? $"partialtag={Uri.EscapeDataString(partialtag)}" : null);
        }
    }
}