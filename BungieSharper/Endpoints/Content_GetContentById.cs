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
        /// Returns a content item referenced by id
        /// </summary>
        public async Task<Schema.Content.ContentItemPublicContract> Content_GetContentById(long id, string locale, bool? head = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Content.ContentItemPublicContract>(
                $"Content/GetContentById/{id}/{Uri.EscapeDataString(locale)}/", null, null, HttpMethod.Get,
                head != null ? $"head={head}" : null);
        }
    }
}