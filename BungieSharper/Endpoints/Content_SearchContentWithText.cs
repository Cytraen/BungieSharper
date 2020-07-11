using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets content based on querystring information passed in. Provides basic search and text search capabilities.
        /// </summary>
        public async Task<Schema.SearchResultOfContentItemPublicContract> Content_SearchContentWithText(string ctype, int currentpage, bool head, string locale, string searchtext, string source, string tag)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfContentItemPublicContract>(
                $"Content/Search/{locale}/", null, null, HttpMethod.Get
                );
        }
    }
}