﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Set the Tracking State for an instanced item, if that item is a Quest or Bounty. You must have a valid Destiny Account. Yeah, it's an item.
        /// </summary>
        public async Task<int> Destiny2_SetQuestTrackedState()
        {
            return await this._apiAccessor.ApiRequestAsync<int>(
                $"Destiny2/Actions/Items/SetTrackedState/", null, null, HttpMethod.Post
                );
        }
    }
}