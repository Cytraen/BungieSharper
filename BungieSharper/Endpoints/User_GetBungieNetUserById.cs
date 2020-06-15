using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.User.GeneralUser> User_GetBungieNetUserById(long id)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.User.GeneralUser>(
                "User/GetBungieNetUserById/{id}/", null, null, HttpMethod.Get
                );
        }
    }
}