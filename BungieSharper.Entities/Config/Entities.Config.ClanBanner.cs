using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Config.ClanBanner
{
    public class ClanBannerSource { }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ClanBannerSource))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ClanBannerSourceJsonContext : JsonSerializerContext { }
#endif

    public class ClanBannerDecal
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("foregroundPath")]
        public string ForegroundPath { get; set; }

        [JsonPropertyName("backgroundPath")]
        public string BackgroundPath { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ClanBannerDecal))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ClanBannerDecalJsonContext : JsonSerializerContext { }
#endif
}