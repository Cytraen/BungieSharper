using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Animations
{
    public class DestinyAnimationReference
    {
        [JsonPropertyName("animName")]
        public string AnimName { get; set; }

        [JsonPropertyName("animIdentifier")]
        public string AnimIdentifier { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }

    [JsonSerializable(typeof(DestinyAnimationReference))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyAnimationReferenceJsonContext : JsonSerializerContext { }
}