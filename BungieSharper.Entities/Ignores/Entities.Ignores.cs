using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Ignores
{
    public class IgnoreResponse
    {
        [JsonPropertyName("isIgnored")]
        public bool IsIgnored { get; set; }

        [JsonPropertyName("ignoreFlags")]
        public Ignores.IgnoreStatus IgnoreFlags { get; set; }
    }

    [JsonSerializable(typeof(IgnoreResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class IgnoreResponseJsonContext : JsonSerializerContext { }

    [System.Flags]
    public enum IgnoreStatus : int
    {
        NotIgnored = 0,
        IgnoredUser = 1,
        IgnoredGroup = 2,
        IgnoredByGroup = 4,
        IgnoredPost = 8,
        IgnoredTag = 16,
        IgnoredGlobal = 32
    }

    public enum IgnoreLength : int
    {
        None = 0,
        Week = 1,
        TwoWeeks = 2,
        ThreeWeeks = 3,
        Month = 4,
        ThreeMonths = 5,
        SixMonths = 6,
        Year = 7,
        Forever = 8,
        ThreeMinutes = 9,
        Hour = 10,
        ThirtyDays = 11
    }
}