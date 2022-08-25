using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Tags.Models.Contracts;

public class TagResponse
{
    [JsonPropertyName("tagText")]
    public string TagText { get; set; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse IgnoreStatus { get; set; }
}