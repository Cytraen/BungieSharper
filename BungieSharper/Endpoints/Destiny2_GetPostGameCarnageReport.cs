using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportData> Destiny2_GetPostGameCarnageReport(long activityId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>(
                $"Destiny2/Stats/PostGameCarnageReport/{activityId}/", null, null, HttpMethod.Get
                );
        }
    }
}