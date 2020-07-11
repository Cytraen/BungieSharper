﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets the post Id for the given content item's comments, if it exists.
        /// </summary>
        public async Task<long> Forum_GetTopicForContent(long contentId)
        {
            return await this._apiAccessor.ApiRequestAsync<long>(
                $"Forum/GetTopicForContent/{contentId}/", null, null, HttpMethod.Get
                );
        }
    }
}