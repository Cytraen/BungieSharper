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
        /// Search for Help Articles.
        /// </summary>
        public async Task<dynamic> Content_SearchHelpArticles(string searchtext, string size)
        {
            return await this._apiAccessor.ApiRequestAsync<dynamic>(
                $"Content/SearchHelpArticles/{Uri.EscapeDataString(searchtext)}/{Uri.EscapeDataString(size)}/", null, null, HttpMethod.Get
                );
        }
    }
}