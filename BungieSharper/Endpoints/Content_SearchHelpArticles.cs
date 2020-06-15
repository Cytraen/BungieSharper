using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<dynamic> Content_SearchHelpArticles(string searchtext, string size)
        {
            return await this._apiAccessor.ApiRequestAsync<dynamic>(
                $"Content/SearchHelpArticles/{searchtext}/{size}/", null, null, HttpMethod.Get
                );
        }
    }
}