﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<int> GroupV2_EditFounderOptions(long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                "GroupV2/{groupId}/EditFounderOptions/", null, null, HttpMethod.Post
                );
        }
    }
}