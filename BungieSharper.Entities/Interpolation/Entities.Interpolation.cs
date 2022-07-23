using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Interpolation
{
    public class InterpolationPoint
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }
    }

    [JsonSerializable(typeof(InterpolationPoint))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class InterpolationPointJsonContext : JsonSerializerContext { }

    public class InterpolationPointFloat
    {
        [JsonPropertyName("value")]
        public float Value { get; set; }

        [JsonPropertyName("weight")]
        public float Weight { get; set; }
    }

    [JsonSerializable(typeof(InterpolationPointFloat))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class InterpolationPointFloatJsonContext : JsonSerializerContext { }
}