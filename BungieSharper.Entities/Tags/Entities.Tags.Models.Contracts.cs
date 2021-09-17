using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Tags.Models.Contracts
{
    public class TagResponse
    {
        [JsonPropertyName("tagText")]
        public string TagText { get; set; }

        [JsonPropertyName("ignoreStatus")]
        public Ignores.IgnoreResponse IgnoreStatus { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(TagResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class TagResponseJsonContext : JsonSerializerContext { }
#endif
}