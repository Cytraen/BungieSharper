﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<int> Destiny2_TransferItem()
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                "Destiny2/Actions/Items/TransferItem/", null, null, HttpMethod.Post
                );
        }
    }
}