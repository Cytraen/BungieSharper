using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Interpolation;

public class InterpolationPoint
{
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }
}

public class InterpolationPointFloat
{
    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("weight")]
    public float Weight { get; set; }
}