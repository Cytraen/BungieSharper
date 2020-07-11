using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets an object describing a particular variant of content.
        /// </summary>
        public async Task<Schema.Content.Models.ContentTypeDescription> Content_GetContentType(string type)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Content.Models.ContentTypeDescription>(
                $"Content/GetContentType/{type}/", null, null, HttpMethod.Get
                );
        }
    }
}