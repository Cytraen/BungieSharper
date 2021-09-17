using System;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Dates
{
    public class DateRange
    {
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime End { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DateRange))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DateRangeJsonContext : JsonSerializerContext { }
#endif
}