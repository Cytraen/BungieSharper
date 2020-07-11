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
        /// Returns the newest item that matches a given tag and Content Type.
        /// </summary>
        public async Task<Schema.Content.ContentItemPublicContract> Content_GetContentByTagAndType(string locale, string tag, string type, bool? head = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Content.ContentItemPublicContract>(
                $"Content/GetContentByTagAndType/{Uri.EscapeDataString(tag)}/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(locale)}/", null, null, HttpMethod.Get,
                head != null ? $"head={head}" : null);
        }
    }
}