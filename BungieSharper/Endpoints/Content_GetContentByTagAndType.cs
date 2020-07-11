using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns the newest item that matches a given tag and Content Type.
        /// </summary>
        public async Task<Schema.Content.ContentItemPublicContract> Content_GetContentByTagAndType(bool head, string locale, string tag, string type)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Content.ContentItemPublicContract>(
                $"Content/GetContentByTagAndType/{tag}/{type}/{locale}/", null, null, HttpMethod.Get
                );
        }
    }
}