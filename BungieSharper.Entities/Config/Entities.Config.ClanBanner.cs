using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Config.ClanBanner
{
    public class ClanBannerSource { }

    public class ClanBannerDecal
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("foregroundPath")]
        public string ForegroundPath { get; set; }

        [JsonPropertyName("backgroundPath")]
        public string BackgroundPath { get; set; }
    }
}