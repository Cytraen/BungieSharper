using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Links
{
    public class HyperlinkReference
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    [JsonSerializable(typeof(HyperlinkReference))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class HyperlinkReferenceJsonContext : JsonSerializerContext { }
}