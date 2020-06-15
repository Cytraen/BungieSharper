using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.SearchResultOfContentItemPublicContract> Content_SearchContentByTagAndType(int currentpage, bool head, int itemsperpage, string locale, string tag, string type)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfContentItemPublicContract>(
                "Content/SearchContentByTagAndType/{tag}/{type}/{locale}/", null, null, HttpMethod.Get
                );
        }
    }
}