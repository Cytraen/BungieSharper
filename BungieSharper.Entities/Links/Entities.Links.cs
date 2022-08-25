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
}