using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.User.GeneralUser>> User_SearchUsers(string q)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.User.GeneralUser>>(
                $"User/SearchUsers/", null, null, HttpMethod.Get
                );
        }
    }
}