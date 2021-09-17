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

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(HyperlinkReference))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class HyperlinkReferenceJsonContext : JsonSerializerContext { }
#endif
}