using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Content.ContentItemPublicContract> Content_GetContentById(bool head, long id, string locale)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Content.ContentItemPublicContract>(
                "Content/GetContentById/{id}/{locale}/", null, null, HttpMethod.Get
                );
        }
    }
}